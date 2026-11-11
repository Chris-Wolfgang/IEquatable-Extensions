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
    public static bool NotEqual<T>(this T? item, T? other)
    {
        return !Equals(item, other);
    }
}
