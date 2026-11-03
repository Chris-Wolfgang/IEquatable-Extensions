using System;
using System.Collections.Generic;
using System.Linq;

namespace Wolfgang.Extensions.IEquatable;

/// <summary>
/// A collection of extension methods for types that implement <see cref="IEquatable{T}"/>.
/// </summary>
// ReSharper disable once InconsistentNaming
public static class IEquatableExtensions
{
    /// <summary>
    /// Determines if the item is in the specified set of items.
    /// </summary>
    /// <param name="item">The item to search for.</param>
    /// <param name="t1">The first item in the set.</param>
    /// <typeparam name="T">The type of the items in the set.</typeparam>
    /// <returns>True if the item is in the set; otherwise, false.</returns>
    /// <example>
    /// <code>
    /// using Wolfgang.Extensions.IEquatable;
    ///
    /// string status = "Open";
    /// bool isOpen = status.IsInSet("Open");   // true
    /// </code>
    /// </example>
    public static bool IsInSet<T>(this T? item, T? t1)
    {
        return Equals(item, t1);
    }



    /// <summary>
    /// Determines if the item is in the specified set of items.
    /// </summary>
    /// <param name="item">The item to search for.</param>
    /// <param name="t1">The first item in the set.</param>
    /// <param name="t2">The second item in the set.</param>
    /// <typeparam name="T">The type of the items in the set.</typeparam>
    /// <returns>True if the item is in the set; otherwise, false.</returns>
    /// <example>
    /// <code>
    /// using Wolfgang.Extensions.IEquatable;
    ///
    /// char answer = 'y';
    /// bool isYes = answer.IsInSet('y', 'Y');   // true
    /// </code>
    /// </example>
    public static bool IsInSet<T>(this T? item, T? t1, T? t2)
    {
        return Equals(item, t1) || Equals(item, t2);
    }



    /// <summary>
    /// Determines if the item is in the specified set of items.
    /// </summary>
    /// <param name="item">The item to search for.</param>
    /// <param name="t1">The first item in the set.</param>
    /// <param name="t2">The second item in the set.</param>
    /// <param name="t3">The third item in the set.</param>
    /// <typeparam name="T">The type of the items in the set.</typeparam>
    /// <returns>True if the item is in the set; otherwise, false.</returns>
    /// <example>
    /// <code>
    /// using Wolfgang.Extensions.IEquatable;
    ///
    /// int? rating = null;
    /// bool isSet = rating.IsInSet(1, 2, 3);   // false - null equals none of them
    /// </code>
    /// </example>
    public static bool IsInSet<T>(this T? item, T? t1, T? t2, T? t3)
    {
        return Equals(item, t1) || Equals(item, t2) || Equals(item, t3);
    }



    /// <summary>
    /// Determines if the item is in the specified set of items.
    /// </summary>
    /// <param name="item">The item to search for.</param>
    /// <param name="set">The set of items to search.</param>
    /// <typeparam name="T">The type of the items in the set.</typeparam>
    /// <returns>True if the item is in the set; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="set"/> is <see langword="null"/>.</exception>
    /// <example>
    /// <code>
    /// using Wolfgang.Extensions.IEquatable;
    ///
    /// var day = System.DayOfWeek.Saturday;
    /// bool isLongWeekend = day.IsInSet(System.DayOfWeek.Friday, System.DayOfWeek.Saturday, System.DayOfWeek.Sunday, System.DayOfWeek.Monday);   // true
    /// </code>
    /// </example>
    public static bool IsInSet<T>(this T? item, params T?[] set)
    {
        if (set == null)
        {
            throw new ArgumentNullException(nameof(set));
        }

        return set.Contains(item);
    }



    /// <summary>
    /// Determines if the item is in the specified set of items.
    /// </summary>
    /// <param name="item">The item to search for.</param>
    /// <param name="set">The set of items to search.</param>
    /// <typeparam name="T">The type of the items in the set.</typeparam>
    /// <returns>True if the item is in the set; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="set"/> is <see langword="null"/>.</exception>
    /// <example>
    /// <code>
    /// using System.Collections.Generic;
    /// using Wolfgang.Extensions.IEquatable;
    ///
    /// IEnumerable&lt;string?&gt; admins = new List&lt;string?&gt; { "alice", "bob" };
    /// bool isAdmin = "bob".IsInSet(admins);   // true
    /// </code>
    /// </example>
    public static bool IsInSet<T>(this T? item, IEnumerable<T?> set)
    {
        if (set == null)
        {
            throw new ArgumentNullException(nameof(set));
        }

        return set.Contains(item);
    }



    /// <summary>
    /// Determines if the item is in the specified set of items.
    /// </summary>
    /// <param name="item">The item to search for.</param>
    /// <param name="set">The set of items to search.</param>
    /// <typeparam name="T">The type of the items in the set.</typeparam>
    /// <returns>True if the item is in the set; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="set"/> is <see langword="null"/>.</exception>
    /// <example>
    /// <code>
    /// using System.Collections.Generic;
    /// using Wolfgang.Extensions.IEquatable;
    ///
    /// ICollection&lt;int?&gt; allowed = new HashSet&lt;int?&gt; { 200, 201, 204 };
    /// bool isSuccess = ((int?)204).IsInSet(allowed);   // true - an O(1) HashSet lookup
    /// </code>
    /// </example>
    public static bool IsInSet<T>(this T? item, ICollection<T?> set)
    {
        if (set == null)
        {
            throw new ArgumentNullException(nameof(set));
        }

        return set.Contains(item);
    }



    /// <summary>
    /// Determines if the item is not in the specified set of items.
    /// </summary>
    /// <param name="item">The item to search for.</param>
    /// <param name="t1">The first item in the set.</param>
    /// <typeparam name="T">The type of the items in the set.</typeparam>
    /// <returns>True if the item is NOT in the set; otherwise, false.</returns>
    /// <example>
    /// <code>
    /// using Wolfgang.Extensions.IEquatable;
    ///
    /// string role = "guest";
    /// bool notAdmin = role.IsNotInSet("admin");   // true
    /// </code>
    /// </example>
    public static bool IsNotInSet<T>(this T? item, T? t1)
    {
        return !IsInSet(item, t1);
    }



    /// <summary>
    /// Determines if the item is not in the specified set of items.
    /// </summary>
    /// <param name="item">The item to search for.</param>
    /// <param name="t1">The first item in the set.</param>
    /// <param name="t2">The second item in the set.</param>
    /// <typeparam name="T">The type of the items in the set.</typeparam>
    /// <returns>True if the item is NOT in the set; otherwise, false.</returns>
    /// <example>
    /// <code>
    /// using Wolfgang.Extensions.IEquatable;
    ///
    /// string? input = null;
    /// bool notBlank = input.IsNotInSet(null, "");   // false - null is in the set
    /// </code>
    /// </example>
    public static bool IsNotInSet<T>(this T? item, T? t1, T? t2)
    {
        return !IsInSet(item, t1, t2);
    }



    /// <summary>
    /// Determines if the item is not in the specified set of items.
    /// </summary>
    /// <param name="item">The item to search for.</param>
    /// <param name="t1">The first item in the set.</param>
    /// <param name="t2">The second item in the set.</param>
    /// <param name="t3">The third item in the set.</param>
    /// <typeparam name="T">The type of the items in the set.</typeparam>
    /// <returns>True if the item is NOT in the set; otherwise, false.</returns>
    /// <example>
    /// <code>
    /// using Wolfgang.Extensions.IEquatable;
    ///
    /// int code = 500;
    /// bool notRedirect = code.IsNotInSet(301, 302, 307);   // true
    /// </code>
    /// </example>
    public static bool IsNotInSet<T>(this T? item, T? t1, T? t2, T? t3)
    {
        return !IsInSet(item, t1, t2, t3);
    }



    /// <summary>
    /// Determines if the item is not in the specified set of items.
    /// </summary>
    /// <param name="item">The item to search for.</param>
    /// <param name="set">The set of items to search.</param>
    /// <typeparam name="T">The type of the items in the set.</typeparam>
    /// <returns>True if the item is NOT in the set; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="set"/> is <see langword="null"/>.</exception>
    /// <example>
    /// <code>
    /// using Wolfgang.Extensions.IEquatable;
    ///
    /// string ext = ".exe";
    /// bool allowed = ext.IsNotInSet(".exe", ".bat", ".cmd", ".ps1");   // false
    /// </code>
    /// </example>
    public static bool IsNotInSet<T>(this T? item, params T?[] set)
    {
        return !IsInSet(item, set);
    }



    /// <summary>
    /// Determines if the item is not in the specified set of items.
    /// </summary>
    /// <param name="item">The item to search for.</param>
    /// <param name="set">The set of items to search.</param>
    /// <typeparam name="T">The type of the items in the set.</typeparam>
    /// <returns>True if the item is NOT in the set; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="set"/> is <see langword="null"/>.</exception>
    /// <example>
    /// <code>
    /// using System.Collections.Generic;
    /// using Wolfgang.Extensions.IEquatable;
    ///
    /// IEnumerable&lt;string?&gt; reserved = new[] { "con", "nul", "aux" };
    /// bool usable = "data".IsNotInSet(reserved);   // true
    /// </code>
    /// </example>
    public static bool IsNotInSet<T>(this T? item, IEnumerable<T?> set)
    {
        return !IsInSet(item, set);
    }



    /// <summary>
    /// Determines if the item is not in the specified set of items.
    /// </summary>
    /// <param name="item">The item to search for.</param>
    /// <param name="set">The set of items to search.</param>
    /// <typeparam name="T">The type of the items in the set.</typeparam>
    /// <returns>True if the item is NOT in the set; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="set"/> is <see langword="null"/>.</exception>
    /// <example>
    /// <code>
    /// using System.Collections.Generic;
    /// using Wolfgang.Extensions.IEquatable;
    ///
    /// ICollection&lt;string?&gt; seen = new HashSet&lt;string?&gt; { "a", "b" };
    /// bool isNew = "c".IsNotInSet(seen);   // true
    /// </code>
    /// </example>
    public static bool IsNotInSet<T>(this T? item, ICollection<T?> set)
    {
        return !IsInSet(item, set);
    }



    /// <summary>
    /// Determines whether the specified item is not equal to another value.
    /// </summary>
    /// <param name="item">The item to compare.</param>
    /// <param name="other">The other item to compare with.</param>
    /// <typeparam name="T">The type of the items being compared.</typeparam>
    /// <returns>True if <paramref name="item"/> and <paramref name="other"/> are not equal; otherwise, false.</returns>
    /// <example>
    /// <code>
    /// using Wolfgang.Extensions.IEquatable;
    ///
    /// string current = "v2";
    /// string previous = "v1";
    /// bool changed = current.NotEqual(previous);   // true - reads like !Equals(current, previous)
    /// </code>
    /// </example>
    public static bool NotEqual<T>(this T? item, T? other)
    {
        return !Equals(item, other);
    }
}
