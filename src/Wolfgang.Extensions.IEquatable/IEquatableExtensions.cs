namespace Wolfgang.Extensions.IEquatable;

/// <summary>
/// A collection of extension methods for types that implement IEquatable{T}.
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
#if NET5_0_OR_GREATER
    public static bool IsInSet<T>(this T? item, T? t1)
#else
    public static bool IsInSet<T>(this T item, T t1)
#endif
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
#if NET5_0_OR_GREATER
    public static bool IsInSet<T>(this T? item, T? t1, T? t2) 
#else
    public static bool IsInSet<T>(this T item, T t1, T t2) 
#endif
    {
        return Equals(item, t1) || Equals(item, t2);
    }


    //    /// <summary>
    //    /// Determines if the item is in the specified set of items.
    //    /// </summary>
    //    /// <param name="item">The item to search for.</param>
    //    /// <param name="t1">The first item in the set.</param>
    //    /// <param name="t2">The second item in the set.</param>
    //    /// <param name="t3">The third item in the set.</param>
    //    /// <typeparam name="T">The type of the items in the set.</typeparam>
    //    /// <returns>True if the item is in the set; otherwise, false.</returns>
    //#if NET5_0_OR_GREATER
    //    public static bool IsInSet<T>(this T? item, T? t1, T? t2, T? t3) where T : IEquatable<T>
    //#else
    //    public static bool IsInSet<T>(this T item, T t1, T t2, T t3) where T : IEquatable<T>
    //#endif
    //    {
    //        return Equals(item, t1) || Equals(item, t2) || Equals(item, t3);
    //    }



    //    /// <summary>
    //    /// Determines if the item is in the specified set of set.
    //    /// </summary>
    //    /// <param name="item">The item to search for.</param>
    //    /// <param name="set">The set of items to search.</param>
    //    /// <typeparam name="T">The type of the set in the set.</typeparam>
    //    /// <returns>True if the item is in the set; otherwise, false.</returns>
    //    /// <exception cref="ArgumentNullException">set is null</exception>
    //#if NET5_0_OR_GREATER
    //    public static bool IsInSet<T>(this T? item, params T?[] set) where T : IEquatable<T>
    //#else
    //    public static bool IsInSet<T>(this T item, params T[] set) where T : IEquatable<T>
    //#endif
    //    {
    //        if (set == null)
    //        {
    //            throw new ArgumentNullException(nameof(set));
    //        }

    //        return set.Contains(item);
    //    }



    //    /// <summary>
    //    /// Determines if the item is in the specified set of set.
    //    /// </summary>
    //    /// <param name="item">The item to search for.</param>
    //    /// <param name="set">The set of items to search.</param>
    //    /// <typeparam name="T">The type of the set in the set.</typeparam>
    //    /// <returns>True if the item is in the set; otherwise, false.</returns>
    //    /// <exception cref="ArgumentNullException">set is null</exception>
    //#if NET5_0_OR_GREATER
    //    public static bool IsInSet<T>(this T? item, IEnumerable<T?> set) where T : IEquatable<T>
    //#else
    //    public static bool IsInSet<T>(this T item, IEnumerable<T> set) where T : IEquatable<T>
    //#endif
    //    {
    //        if (set == null)
    //        {
    //            throw new ArgumentNullException(nameof(set));
    //        }

    //        return set.Contains(item);
    //    }



    //    /// <summary>
    //    /// Determines if the item is in the specified set of set.
    //    /// </summary>
    //    /// <param name="item">The item to search for.</param>
    //    /// <param name="set">The set of items to search.</param>
    //    /// <typeparam name="T">The type of the set in the set.</typeparam>
    //    /// <returns>True if the item is in the set; otherwise, false.</returns>
    //    /// <exception cref="ArgumentNullException">set is null</exception>
    //#if NET5_0_OR_GREATER
    //    public static bool IsInSet<T>(this T? item, ICollection<T?> set) where T : IEquatable<T>
    //#else
    //    public static bool IsInSet<T>(this T item, ICollection<T> set) where T : IEquatable<T>
    //#endif
    //    {
    //        if (set == null)
    //        {
    //            throw new ArgumentNullException(nameof(set));
    //        }

    //        return set.Contains(item);
    //    }



    //    /// <summary>
    //    /// Determines if the item is not in the specified set of items.
    //    /// </summary>
    //    /// <param name="item">The item to search for.</param>
    //    /// <param name="t1">The first item in the set.</param>
    //    /// <param name="t2">The second item in the set.</param>
    //    /// <typeparam name="T">The type of the items in the set.</typeparam>
    //    /// <returns>True if the item is in the set; otherwise, false.</returns>
    //#if NET5_0_OR_GREATER
    //    public static bool IsNotInSet<T>(this T? item, T? t1, T? t2) where T : IEquatable<T>
    //#else
    //    public static bool IsNotInSet<T>(this T item, T t1, T t2) where T : IEquatable<T>
    //#endif
    //    {
    //        return !IsInSet(item, t1, t2);
    //    }



    //    /// <summary>
    //    /// Determines if the item is not in the specified set of items.
    //    /// </summary>
    //    /// <param name="item">The item to search for.</param>
    //    /// <param name="t1">The first item in the set.</param>
    //    /// <param name="t2">The second item in the set.</param>
    //    /// <param name="t3">The third item in the set.</param>
    //    /// <typeparam name="T">The type of the items in the set.</typeparam>
    //    /// <returns>True if the item is in the set; otherwise, false.</returns>
    //#if NET5_0_OR_GREATER
    //    public static bool IsNotInSet<T>(this T? item, T? t1, T? t2, T? t3) where T : IEquatable<T>
    //#else
    //    public static bool IsNotInSet<T>(this T item, T t1, T t2, T t3) where T : IEquatable<T>
    //#endif
    //    {
    //        return !IsInSet(item, t1, t2, t3);
    //    }



    //    /// <summary>
    //    /// Determines if the item is not in the specified set of items.
    //    /// </summary>
    //    /// <param name="item">The item to search for.</param>
    //    /// <param name="set">The items in the set.</param>
    //    /// <typeparam name="T">The type of the items in the set.</typeparam>
    //    /// <returns>True if the item is in the set; otherwise, false.</returns>
    //    /// <exception cref="ArgumentNullException">set is null</exception>
    //#if NET5_0_OR_GREATER
    //    public static bool IsNotInSet<T>(this T? item, params T?[] set) where T : IEquatable<T>
    //#else
    //    public static bool IsNotInSet<T>(this T item, params T[] set) where T : IEquatable<T>
    //#endif
    //    {
    //        return !IsInSet(item, set);
    //    }



    //    /// <summary>
    //    /// Determines if the item is not in the specified set of set.
    //    /// </summary>
    //    /// <param name="item">The item to search for.</param>
    //    /// <param name="set">The set in the set.</param>
    //    /// <typeparam name="T">The type of the set in the set.</typeparam>
    //    /// <returns>True if the item is in the set; otherwise, false.</returns>
    //    /// <exception cref="ArgumentNullException">set is null</exception>
    //#if NET5_0_OR_GREATER
    //    public static bool IsNotInSet<T>(this T? item, IEnumerable<T?> set) where T : IEquatable<T>
    //#else
    //    public static bool IsNotInSet<T>(this T item, IEnumerable<T> set) where T : IEquatable<T>
    //#endif
    //    {
    //        return !IsInSet(item, set);
    //    }



    //    /// <summary>
    //    /// Determines if the item is not in the specified set of set.
    //    /// </summary>
    //    /// <param name="item">The item to search for.</param>
    //    /// <param name="set">The set in the set.</param>
    //    /// <typeparam name="T">The type of the set in the set.</typeparam>
    //    /// <returns>True if the item is in the set; otherwise, false.</returns>
    //    /// <exception cref="ArgumentNullException">set is null</exception>
    //#if NET5_0_OR_GREATER
    //    public static bool IsNotInSet<T>(this T? item, ICollection<T?> set) where T : IEquatable<T>
    //#else
    //    public static bool IsNotInSet<T>(this T item, ICollection<T> set) where T : IEquatable<T>
    //#endif
    //    {
    //        return !IsInSet(item, set);
    //    }



    /// <summary>
    /// Determines if the item is not in the specified set of items.
    /// </summary>
    /// <param name="item">The item to search for.</param>
    /// <param name="other">The other item to compare with.</param>
    /// <typeparam name="T">The type of the items in the set.</typeparam>
    /// <returns>True if the item is in the set; otherwise, false.</returns>
#if NET5_0_OR_GREATER
        public static bool NotEqual<T>(this T? item, T? other)
#else
    public static bool NotEqual<T>(this T item, T other)
#endif
    {
        // Point to the same item
        if (ReferenceEquals(item, other))
        {
            return false;
        }

        // One is null but the other is not
        if (ReferenceEquals(null, item))
        {
            return true;
        }

        // Both are not null, compare using IEquatable<T>
        return !item.Equals(other);
    }
}