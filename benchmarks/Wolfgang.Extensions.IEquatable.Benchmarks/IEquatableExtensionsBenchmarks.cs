using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using Wolfgang.Extensions.IEquatable;

namespace Wolfgang.Extensions.IEquatable.Benchmarks;

/// <summary>
/// Microbenchmarks for the public extension methods. The small-N overloads
/// (1 / 2 / 3 items) currently route through static <c>Equals(object, object)</c>
/// which boxes value-type arguments — the chart should surface that cost so
/// any future move to <c>EqualityComparer&lt;T&gt;.Default</c> can be quantified.
///
/// The collection overloads have different routing: the
/// <c>IEnumerable&lt;T&gt;</c> overload delegates to <c>Enumerable.Contains</c>
/// (LINQ), while the <c>ICollection&lt;T&gt;</c> overload calls
/// <c>ICollection&lt;T&gt;.Contains</c> directly — for <c>HashSet&lt;T&gt;</c>
/// that's an O(1) hash lookup vs the O(N) LINQ enumeration.
///
/// The benchmark types are <c>int?</c> rather than <c>int</c> so the casts
/// bind to the NET5_0_OR_GREATER overloads (<c>T?[]</c>,
/// <c>IEnumerable&lt;T?&gt;</c>, <c>ICollection&lt;T?&gt;</c>) — which is
/// what the published library exposes on the net10.0 target the benchmark
/// project compiles against.
/// </summary>
[MemoryDiagnoser]
public class IEquatableExtensionsBenchmarks
{
    // A representative nullable-int value and a small pre-built set. int? is
    // the most-common value-type T in nullable-enabled code, so any boxing
    // overhead in the small-N overloads shows up here.
    private static readonly int? Sample = 42;

    private static readonly int?[] ParamsSet =
        { 1, 2, 3, 5, 8, 13, 21, 34, 42, 55 };

    private static readonly List<int?> ListSet =
        new() { 1, 2, 3, 5, 8, 13, 21, 34, 42, 55 };

    private static readonly HashSet<int?> HashSet =
        new() { 1, 2, 3, 5, 8, 13, 21, 34, 42, 55 };



    // -------- IsInSet (small-N overloads, value type) --------

    [Benchmark]
    public bool IsInSet_1() => Sample.IsInSet(42);



    [Benchmark]
    public bool IsInSet_2() => Sample.IsInSet(41, 42);



    [Benchmark]
    public bool IsInSet_3() => Sample.IsInSet(40, 41, 42);



    // -------- IsInSet (collection overloads) --------

    [Benchmark]
    public bool IsInSet_ParamsArray() => Sample.IsInSet(ParamsSet);



    [Benchmark]
    public bool IsInSet_IEnumerable() => Sample.IsInSet((IEnumerable<int?>)ListSet);



    [Benchmark]
    public bool IsInSet_ICollection() => Sample.IsInSet((ICollection<int?>)ListSet);



    [Benchmark]
    public bool IsInSet_HashSet_AsICollection() => Sample.IsInSet((ICollection<int?>)HashSet);



    // -------- IsNotInSet (the inverse — same shape) --------

    [Benchmark]
    public bool IsNotInSet_1() => Sample.IsNotInSet(99);



    [Benchmark]
    public bool IsNotInSet_ParamsArray() => Sample.IsNotInSet(ParamsSet);



    // -------- NotEqual --------

    [Benchmark]
    public bool NotEqual() => Sample.NotEqual(99);
}
