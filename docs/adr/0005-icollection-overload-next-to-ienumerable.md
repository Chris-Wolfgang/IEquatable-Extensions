# 0005. An `ICollection<T>` overload next to `IEnumerable<T>`

- **Date:** 2026-10-22
- **Status:** Accepted

## Context

`IsInSet(IEnumerable<T>)` calls `Enumerable.Contains`, which already dispatches to `ICollection<T>.Contains` when the runtime type is a collection. A separate `ICollection<T>` overload therefore looks redundant.

## Decision

We keep `IsInSet(ICollection<T?>)` / `IsNotInSet(ICollection<T?>)`. They bind at compile time whenever the argument's static type is a collection (`HashSet<T>`, `List<T>`), call `ICollection<T>.Contains` directly, and make the intent visible: for a `HashSet<T>` the check is an O(1) hash lookup with the set's own comparer.

## Consequences

- The fast path does not rely on a LINQ implementation detail, and the set's comparer (for example `StringComparer.OrdinalIgnoreCase`) is honoured explicitly.
- `ICollection<T>` is invariant, so a nullable-enabled caller passing a `List<string>` where `ICollection<string?>` is expected gets a nullability warning (CS8620); passing an `ICollection<string?>`, or using the `IEnumerable<T>` overload, avoids it.
- Each method has two collection overloads to test. The `IEnumerable<T>` tests wrap their sets in an iterator, so they exercise the sequence-walking path rather than the collection fast path.
