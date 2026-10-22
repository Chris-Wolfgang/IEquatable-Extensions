#if NET5_0_OR_GREATER
using System;
using System.Collections.Generic;
using Xunit;

namespace Wolfgang.Extensions.IEquatable.Tests.Unit;

/// <summary>
/// Asserts that the call shapes documented as allocation-free stay allocation-free, measured with
/// <see cref="GC.GetAllocatedBytesForCurrentThread"/> over many iterations after a warm-up call.
/// </summary>
/// <remarks>
/// <para>
/// Documented zero-allocation call shapes:
/// </para>
/// <list type="bullet">
/// <item><description><c>IsInSet</c> / <c>IsNotInSet</c> with one, two or three items, and <c>NotEqual</c>,
/// when <c>T</c> is a reference type (<see cref="string"/>, a class). <c>object.Equals(object, object)</c>
/// needs no boxing for references.</description></item>
/// <item><description>The <c>ICollection&lt;T&gt;</c> overloads on a <see cref="HashSet{T}"/> or a
/// <see cref="List{T}"/>, for reference types and for value types.</description></item>
/// <item><description>The <c>IEnumerable&lt;T&gt;</c> overloads when the sequence is an
/// <c>ICollection&lt;T&gt;</c> (<c>Enumerable.Contains</c> dispatches to <c>ICollection&lt;T&gt;.Contains</c>).</description></item>
/// <item><description>The <c>params T[]</c> overloads when the caller passes an array it already holds
/// (a literal list of arguments allocates the array at the call site, before the method runs).</description></item>
/// </list>
/// <para>
/// Not zero-allocation today: the one / two / three item overloads and <c>NotEqual</c> box each
/// value-type argument, because they call <c>object.Equals(object, object)</c>. That is documented in
/// the README and tracked by #721 (switch to <c>EqualityComparer&lt;T&gt;.Default</c>). When it lands,
/// add the value-type rows here.
/// </para>
/// <para>
/// Guarded on NET5_0_OR_GREATER: <see cref="GC.GetAllocatedBytesForCurrentThread"/> does not exist on
/// the .NET Framework targets.
/// </para>
/// </remarks>
public class ZeroAllocationTests
{
    private const int Iterations = 10_000;

    private static readonly IEquatableTestClass Needle = new(3);

    private static readonly IEquatableTestClass[] ClassArray = { new(1), new(2), new(3) };

    private static readonly string[] StringArray = { "one", "two", "three" };

    private static readonly int[] IntArray = { 1, 2, 3 };

    private static readonly HashSet<string?> StringHashSet = new() { "one", "two", "three" };

    private static readonly HashSet<int> IntHashSet = new() { 1, 2, 3 };

    private static readonly List<IEquatableTestClass?> ClassList = new() { new(1), new(2), new(3) };

    private static readonly List<int> IntList = new() { 1, 2, 3 };



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_string_allocates_zero_bytes()
    {
        AssertZeroAllocation(() => "three".IsInSet("one", "two", "three"));
    }



    [Fact]
    public void IsInSet_T_T1_when_T_is_Class_allocates_zero_bytes()
    {
        AssertZeroAllocation(() => Needle.IsInSet(ClassArray[2]));
    }



    [Fact]
    public void IsNotInSet_T_T1_T2_when_T_is_Class_allocates_zero_bytes()
    {
        AssertZeroAllocation(() => Needle.IsNotInSet(ClassArray[0], ClassArray[1]));
    }



    [Fact]
    public void NotEqual_when_T_is_string_allocates_zero_bytes()
    {
        AssertZeroAllocation(() => "one".NotEqual("two"));
    }



    [Fact]
    public void IsInSet_T_ICollection_when_set_is_a_HashSet_of_string_allocates_zero_bytes()
    {
        AssertZeroAllocation(() => "two".IsInSet(StringHashSet));
    }



    [Fact]
    public void IsInSet_T_ICollection_when_set_is_a_HashSet_of_int_allocates_zero_bytes()
    {
        AssertZeroAllocation(() => 2.IsInSet((ICollection<int>)IntHashSet));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_set_is_a_List_of_int_allocates_zero_bytes()
    {
        AssertZeroAllocation(() => 4.IsNotInSet((ICollection<int>)IntList));
    }



    [Fact]
    public void IsInSet_T_IEnumerable_when_set_is_a_List_of_Class_allocates_zero_bytes()
    {
        AssertZeroAllocation(() => Needle.IsInSet((IEnumerable<IEquatableTestClass?>)ClassList));
    }



    [Fact]
    public void IsInSet_T_ParamsArray_when_caller_passes_an_existing_string_array_allocates_zero_bytes()
    {
        AssertZeroAllocation(() => "three".IsInSet(StringArray));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_caller_passes_an_existing_int_array_allocates_zero_bytes()
    {
        AssertZeroAllocation(() => 4.IsNotInSet(IntArray));
    }



    private static void AssertZeroAllocation(Func<bool> call)
    {
        // Warm-up with a full pass: JIT compilation, first-call type loading and the tiered-JIT
        // promotion that happens part-way through the first few thousand calls can allocate a few
        // bytes once. That is not the call's cost, so it stays out of the measured pass.
        for (var i = 0; i < Iterations; i++)
        {
            _ = call();
        }

        var before = GC.GetAllocatedBytesForCurrentThread();
        for (var i = 0; i < Iterations; i++)
        {
            _ = call();
        }

        var allocated = GC.GetAllocatedBytesForCurrentThread() - before;

        Assert.True
        (
            allocated == 0,
            $"Expected 0 bytes allocated over {Iterations} calls, measured {allocated} bytes."
        );
    }
}
#endif
