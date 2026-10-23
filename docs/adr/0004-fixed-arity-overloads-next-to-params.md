# 0004. One-, two- and three-item overloads next to `params T[]`

- **Date:** 2026-10-22
- **Status:** Accepted

## Context

`IsInSet` / `IsNotInSet` are mostly called with a short literal list, such as `status.IsInSet("Open", "Pending")`. With only a `params T[]` overload, every such call allocates an array at the call site before the method runs, and the method then walks it through `Enumerable.Contains`.

## Decision

We keep three fixed-arity overloads, `(T? t1)`, `(T? t1, T? t2)` and `(T? t1, T? t2, T? t3)`, which compare directly and allocate no array, plus `params T?[]` for four or more items and the `IEnumerable<T>` / `ICollection<T>` overloads for sets the caller already holds. C# overload resolution prefers the fixed-arity overloads for one to three arguments.

## Consequences

- The common short-list call allocates no array. For value types the fixed-arity overloads still box each argument, because they compare with `object.Equals(object, object)`; moving to `EqualityComparer<T>.Default` would remove that and is tracked by #721. `ZeroAllocationTests` documents which call shapes are allocation-free today.
- Three more overloads per method name to document and test, and `IsNotInSet` mirrors each one.
- The fixed-arity and collection overloads use different equality paths (`object.Equals` versus `EqualityComparer<T>.Default`), which can give different answers for a type whose `Equals(object)` and `IEquatable<T>.Equals(T)` disagree. The README states this; #721 would make them agree.
