---
_layout: landing
---

# Wolfgang.Extensions.IEquatable

A lightweight .NET library of extension methods that simplify common equality
comparison patterns — concise membership checks (`IsInSet` / `IsNotInSet`) and a
fluent `NotEqual` complement to `Equals`.

## Quick Start

```csharp
using Wolfgang.Extensions.IEquatable;

// Membership check instead of a verbose OR chain
if (status.IsInSet("active", "pending", "approved"))
{
    // ...
}

// Inverse — instead of a verbose AND chain
if (role.IsNotInSet("admin", "moderator", "owner"))
{
    throw new UnauthorizedAccessException();
}

// Fluent inequality
if (currentVersion.NotEqual(supportedVersion))
{
    // ...
}
```

## Where to next

- [Introduction](docs/introduction.md) — what the library is and when to use it
- [Getting Started](docs/getting-started.md) — install and first usage
- [Setup](docs/setup.md) — configuration and integration scenarios
- [API Reference](api/Wolfgang.Extensions.IEquatable.IEquatableExtensions.html) — every method, generated from source

## Install

```bash
dotnet add package Wolfgang.Extensions.IEquatable
```

Targets .NET Framework 4.6.2, .NET Standard 2.0, .NET 8.0, and .NET 10.0.
