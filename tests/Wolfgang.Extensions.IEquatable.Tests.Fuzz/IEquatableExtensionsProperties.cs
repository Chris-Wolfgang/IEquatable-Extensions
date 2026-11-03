using System.Diagnostics.CodeAnalysis;
using FsCheck.Xunit;

namespace Wolfgang.Extensions.IEquatable.Tests.Fuzz;

/// <summary>
/// Property-based fuzz tests for <see cref="IEquatableExtensions"/>. Every property compares an
/// overload with a hand-written reference: <see cref="object.Equals(object, object)"/> for the
/// one / two / three item overloads and <c>NotEqual</c>, and a plain loop over
/// <see cref="EqualityComparer{T}.Default"/> for the collection overloads. Any disagreement means
/// the library added or lost a semantic on top of what a consumer would write by hand, which is
/// the kind of drift a suite of hand-picked cases does not catch. Every <c>IsNotInSet</c> overload
/// is also checked to be the exact negation of its <c>IsInSet</c> twin.
/// </summary>
/// <remarks>
/// The generated types are <see cref="int"/>, <see cref="Nullable{Int32}"/> and <see cref="string"/>
/// (FsCheck generates <see langword="null"/> strings and null elements), so value types, nullable
/// value types and reference types with nulls are all covered. Each property runs
/// <see cref="FuzzPropertyAttribute.DefaultMaxTest"/> (100) cases so <c>dotnet test</c> stays fast
/// for PR CI; the weekly <c>fuzz.yaml</c> run sets <c>FSCHECK_MAX_TESTS</c> to 100,000 (#148).
/// </remarks>
[SuppressMessage("Major Code Smell", "S101:Class names should comply with a naming convention", Justification = "Named to mirror the IEquatableExtensions class whose properties it fuzzes.")]
public class IEquatableExtensionsProperties
{
    // -- one / two / three items and NotEqual ----------------------------------------------

    [FuzzProperty]
    public bool IsInSet_T_T1_T2_T3_on_int_matches_object_Equals(int item, int t1, int t2, int t3) =>
        item.IsInSet(t1) == Equals(item, t1)
        && item.IsInSet(t1, t2) == (Equals(item, t1) || Equals(item, t2))
        && item.IsInSet(t1, t2, t3) == (Equals(item, t1) || Equals(item, t2) || Equals(item, t3));



    [FuzzProperty]
    public bool IsInSet_T_T1_T2_T3_on_nullable_int_matches_object_Equals(int? item, int? t1, int? t2, int? t3) =>
        item.IsInSet(t1) == Equals(item, t1)
        && item.IsInSet(t1, t2) == (Equals(item, t1) || Equals(item, t2))
        && item.IsInSet(t1, t2, t3) == (Equals(item, t1) || Equals(item, t2) || Equals(item, t3));



    [FuzzProperty]
    public bool IsInSet_T_T1_T2_T3_on_string_matches_object_Equals(string? item, string? t1, string? t2, string? t3) =>
        item.IsInSet(t1) == Equals(item, t1)
        && item.IsInSet(t1, t2) == (Equals(item, t1) || Equals(item, t2))
        && item.IsInSet(t1, t2, t3) == (Equals(item, t1) || Equals(item, t2) || Equals(item, t3));



    [FuzzProperty]
    public bool IsNotInSet_T_T1_T2_T3_on_string_negates_IsInSet(string? item, string? t1, string? t2, string? t3) =>
        item.IsNotInSet(t1) == !item.IsInSet(t1)
        && item.IsNotInSet(t1, t2) == !item.IsInSet(t1, t2)
        && item.IsNotInSet(t1, t2, t3) == !item.IsInSet(t1, t2, t3);



    [FuzzProperty]
    public bool NotEqual_matches_negated_object_Equals(int? a, int? b, string? c, string? d) =>
        a.NotEqual(b) == !Equals(a, b)
        && c.NotEqual(d) == !Equals(c, d);



    // -- collection overloads ----------------------------------------------------------------

    [FuzzProperty]
    public bool IsInSet_collection_overloads_on_int_match_a_reference_loop(int item, int[] values) =>
        CollectionOverloadsAgree(item, values);



    [FuzzProperty]
    public bool IsInSet_collection_overloads_on_nullable_int_match_a_reference_loop(int? item, int?[] values) =>
        CollectionOverloadsAgree(item, values);



    [FuzzProperty]
    public bool IsInSet_collection_overloads_on_string_match_a_reference_loop(string? item, string?[] values) =>
        CollectionOverloadsAgree(item, values);



    [FuzzProperty]
    public bool IsInSet_collection_overloads_when_item_is_taken_from_the_set_return_true(string?[] values, int index)
    {
        ArgumentNullException.ThrowIfNull(values);

        return values.Length == 0 || CollectionOverloadsAgree(values[(int)((uint)index % (uint)values.Length)], values, expected: true);
    }



    // The params, IEnumerable<T> (through an iterator, so Enumerable.Contains walks the sequence) and
    // ICollection<T> (a List<T>) overloads must all give the reference answer, and every IsNotInSet
    // overload must give its negation.
    private static bool CollectionOverloadsAgree<T>(T? item, T?[] values, bool? expected = null)
    {
        var reference = Contains(values, item);
        var list = new List<T?>(values);

        return (expected is null || expected == reference)
            && item.IsInSet(values) == reference
            && item.IsInSet(Iterate(values)) == reference
            && item.IsInSet((ICollection<T?>)list) == reference
            && item.IsNotInSet(values) == !reference
            && item.IsNotInSet(Iterate(values)) == !reference
            && item.IsNotInSet((ICollection<T?>)list) == !reference;
    }



    private static bool Contains<T>(T?[] values, T? item)
    {
        var comparer = EqualityComparer<T?>.Default;
        foreach (var value in values)
        {
            if (comparer.Equals(value, item))
            {
                return true;
            }
        }

        return false;
    }



    private static IEnumerable<T> Iterate<T>(IEnumerable<T> source)
    {
        foreach (var value in source)
        {
            yield return value;
        }
    }
}
