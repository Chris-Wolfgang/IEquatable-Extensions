# Wolfgang.Extensions.IEquatable

A collection of extension methods for types that implement `IEquatable<T>` — concise membership checks (`IsInSet` / `IsNotInSet`) and a fluent `NotEqual` complement to `Equals`.

[![NuGet](https://img.shields.io/nuget/v/Wolfgang.Extensions.IEquatable.svg?logo=nuget&label=NuGet)](https://www.nuget.org/packages/Wolfgang.Extensions.IEquatable)
[![NuGet downloads](https://img.shields.io/nuget/dt/Wolfgang.Extensions.IEquatable.svg?logo=nuget&label=downloads)](https://www.nuget.org/packages/Wolfgang.Extensions.IEquatable)
[![PR build](https://img.shields.io/github/actions/workflow/status/Chris-Wolfgang/IEquatable-Extensions/pr.yaml?event=pull_request_target&label=PR%20build&logo=github)](https://github.com/Chris-Wolfgang/IEquatable-Extensions/actions/workflows/pr.yaml)
[![Release](https://img.shields.io/github/actions/workflow/status/Chris-Wolfgang/IEquatable-Extensions/release.yaml?label=release&logo=github)](https://github.com/Chris-Wolfgang/IEquatable-Extensions/actions/workflows/release.yaml)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-Multi--Targeted-purple.svg)](https://dotnet.microsoft.com/)
[![GitHub](https://img.shields.io/badge/GitHub-Repository-181717?logo=github)](https://github.com/Chris-Wolfgang/IEquatable-Extensions)

---

## 📦 Installation

```bash
dotnet add package Wolfgang.Extensions.IEquatable
```

**NuGet Package:** [Wolfgang.Extensions.IEquatable](https://www.nuget.org/packages/Wolfgang.Extensions.IEquatable)

---

## 📄 License

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for details.

---

## 📚 Documentation

- **GitHub Repository:** [https://github.com/Chris-Wolfgang/IEquatable-Extensions](https://github.com/Chris-Wolfgang/IEquatable-Extensions)
- **API Documentation:** https://Chris-Wolfgang.github.io/IEquatable-Extensions/
- **CHANGELOG:** [CHANGELOG.md](CHANGELOG.md)
- **Contributing Guide:** [CONTRIBUTING.md](CONTRIBUTING.md)

---

## 🚀 Quick Start

```csharp
using Wolfgang.Extensions.IEquatable;

// Membership checks against a literal set of items
if (status.IsInSet("active", "pending"))
{
    // ...
}

if (statusCode.IsNotInSet(200, 201, 204))
{
    // ...
}

// Membership against an existing collection
var allowedRoles = new[] { "admin", "editor", "owner" };
if (currentRole.IsInSet(allowedRoles))
{
    // ...
}

// Fluent !Equals
if (lhs.NotEqual(rhs))
{
    // ...
}
```

All methods are pure: they return a `bool` and never mutate the input or the
set. Equality semantics follow the framework `Equals` contract — value types
compare structurally; reference types use `Equals(object)` unless `T`
implements `IEquatable<T>`, in which case the strongly-typed `Equals(T)` is
preferred.

---

## ✨ Features

The table below is a snapshot of the public API at the time of writing. For the
authoritative list (kept in sync with source on every release), see the
[API documentation](https://Chris-Wolfgang.github.io/IEquatable-Extensions/api/Wolfgang.Extensions.IEquatable.IEquatableExtensions.html).

### Methods

| Method | Description |
|--------|-------------|
| `IsInSet(T t1)` | True when `item` equals `t1`. |
| `IsInSet(T t1, T t2)` | True when `item` equals any of the two listed values. |
| `IsInSet(T t1, T t2, T t3)` | True when `item` equals any of the three listed values. |
| `IsInSet(params T[] set)` | True when `item` appears in the provided array. |
| `IsInSet(IEnumerable<T> set)` | True when `item` appears in the provided sequence. |
| `IsInSet(ICollection<T> set)` | True when `item` appears in the provided collection. Preferred when the call site already has an `ICollection<T>` — skips the `IEnumerable` enumerator boxing path. |
| `IsNotInSet(...)` | Negation of `IsInSet` for each of the same overloads. |
| `NotEqual(T other)` | Fluent `!Equals(other)` so equality chains read top-to-bottom. |

### Overload-set notes

- **Nullable annotations.** On `net5.0+` (and net8.0/net10.0 builds) all
  parameters are declared `T?` so nullability flows through the call site. On
  `net462` / `netstandard2.0` builds — which predate the framework's nullable
  reference annotations — they're declared as plain `T`. The runtime behaviour
  is identical; only the compile-time analysis differs.
- **Collection overload preference.** When the source is already an
  `ICollection<T>`, the `ICollection<T>` overload avoids the
  `IEnumerable<T>.GetEnumerator()` indirection. When it's an `IEnumerable<T>`
  the enumerable overload is used — both ultimately delegate to
  `Enumerable.Contains` for the lookup.

### Examples

```csharp
// HTTP status filter
var success = response.StatusCode.IsInSet(200, 201, 204);

// Reverse: anything but a known good code
var problem = response.StatusCode.IsNotInSet(200, 201, 204);

// Role check against a pre-built set
var allowed = new HashSet<string> { "admin", "editor" };
if (user.Role.IsInSet(allowed))
{
    // ...
}

// Replace `if (a != b)` with `if (a.NotEqual(b))` when the LHS reads
// awkwardly with a leading negation
if (currentVersion.NotEqual(supportedVersion))
{
    return Outdated();
}
```

---

## 🧪 Target Frameworks

| Framework | Supported |
|---|---|
| .NET Framework 4.6.2 | ✅ |
| .NET Standard 2.0   | ✅ |
| .NET 8.0            | ✅ |
| .NET 10.0           | ✅ |

The package multi-targets to keep the dependency footprint small on the
modern runtimes while still supporting legacy .NET Framework consumers.

---

## 🛠️ Building from source

```bash
git clone https://github.com/Chris-Wolfgang/IEquatable-Extensions.git
cd IEquatable-Extensions
dotnet restore
dotnet build -c Release
dotnet test  -c Release --no-build
```

Requires the .NET 10.0 SDK (or newer) — earlier SDKs cannot build the `net10.0`
target. The tests run against every framework the source supports.

---

## 🤝 Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md) for the development workflow, coding
conventions, and PR checklist.
