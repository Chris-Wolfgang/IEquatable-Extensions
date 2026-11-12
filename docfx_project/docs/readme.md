# Wolfgang.Extensions.IEquatable

[![NuGet](https://img.shields.io/nuget/v/Wolfgang.Extensions.IEquatable.svg?logo=nuget&label=NuGet)](https://www.nuget.org/packages/Wolfgang.Extensions.IEquatable)
[![NuGet downloads](https://img.shields.io/nuget/dt/Wolfgang.Extensions.IEquatable.svg?logo=nuget&label=downloads)](https://www.nuget.org/packages/Wolfgang.Extensions.IEquatable)
[![PR build](https://img.shields.io/github/actions/workflow/status/Chris-Wolfgang/IEquatable-Extensions/pr.yaml?branch=main&label=PR%20build&logo=github)](https://github.com/Chris-Wolfgang/IEquatable-Extensions/actions/workflows/pr.yaml)
[![Release](https://img.shields.io/github/actions/workflow/status/Chris-Wolfgang/IEquatable-Extensions/release.yaml?label=release&logo=github)](https://github.com/Chris-Wolfgang/IEquatable-Extensions/actions/workflows/release.yaml)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://github.com/Chris-Wolfgang/IEquatable-Extensions/blob/main/LICENSE)
[![OpenSSF Scorecard](https://api.scorecard.dev/projects/github.com/Chris-Wolfgang/IEquatable-Extensions/badge)](https://scorecard.dev/viewer/?uri=github.com/Chris-Wolfgang/IEquatable-Extensions)

A lightweight .NET library that provides extension methods to simplify common equality comparison patterns.

## 🌟 Why Wolfgang.Extensions.IEquatable?

Writing clean, readable equality comparisons often involves repetitive boilerplate code. This library eliminates that repetition with simple, expressive extension methods.

### Problems This Library Solves

- ❌ **Verbose OR Chains**: `if (x == a || x == b || x == c || x == d)`
- ❌ **Verbose AND Chains**: `if (x != a && x != b && x != c && x != d)`
- ❌ **Readability**: Hard to parse complex conditional logic at a glance

### Our Solution

- ✅ **IsInSet**: Check if a value matches any of a set of values
- ✅ **IsNotInSet**: Check if a value doesn't match any of a set of values
- ✅ **NotEqual**: A fluent `!Equals(item, other)`, so a chain of comparisons reads left to right

## 📦 Installation

Choose your preferred installation method:

### NuGet Package Manager
```powershell
Install-Package Wolfgang.Extensions.IEquatable
```

### .NET CLI
```bash
dotnet add package Wolfgang.Extensions.IEquatable
```

### PackageReference
```xml
<PackageReference Include="Wolfgang.Extensions.IEquatable" Version="0.3.0" />
```

> **Note**: Replace with the specific version you need. Check [NuGet.org](https://www.nuget.org/packages/Wolfgang.Extensions.IEquatable/) for available versions.

## 🎯 Requirements

**Supported Frameworks:**
- .NET Framework 4.6.2 or higher
- .NET Standard 2.0
- .NET 8.0
- .NET 10.0

**Language Version:**
- C# 7.3 or higher in the consuming project (the library itself is built with the newest C# version the .NET SDK supports)

The library is designed to work across a wide range of .NET platforms, making it suitable for both legacy and modern applications.

## 🚀 Quick Start

### Example 1: IsInSet

```csharp
using Wolfgang.Extensions.IEquatable;

// Before: Verbose OR chain
if (status == "active" || status == "pending" || status == "approved")
{
    // Process valid status
}

// After: Clean and readable
if (status.IsInSet("active", "pending", "approved"))
{
    // Process valid status
}
```

### Example 2: IsNotInSet

```csharp
using Wolfgang.Extensions.IEquatable;

// Before: Verbose AND chain
if (role != "admin" && role != "moderator" && role != "owner")
{
    throw new UnauthorizedAccessException();
}

// After: Clean and readable
if (role.IsNotInSet("admin", "moderator", "owner"))
{
    throw new UnauthorizedAccessException();
}
```

### Example 3: NotEqual

```csharp
using Wolfgang.Extensions.IEquatable;

// Inequality check: the same semantics as !Equals(value1, value2)
string? value1 = GetValue();
string? value2 = GetOtherValue();

if (value1.NotEqual(value2))
{
    // Values are different (null and null are equal; null and a value are not)
}
```

## 🎯 Key Features

### IsInSet Extension Methods
Check if a value matches any value in a set. Multiple overloads available:
- Single value: `item.IsInSet(value1)`
- Multiple values: `item.IsInSet(value1, value2, value3)`
- Collections: `item.IsInSet(array)` or `item.IsInSet(collection)`

### IsNotInSet Extension Methods
Check if a value doesn't match any value in a set. Same overloads as IsInSet.

### NotEqual Extension Method
A fluent `!Equals(item, other)`. It has the same null semantics as `static object.Equals`: two nulls are equal, null and a value are not, and nothing throws on null.

### Performance
- The one, two and three item overloads and `NotEqual` call `static object.Equals(object, object)`, which **boxes value-type arguments** (an allocation per call for `int`, `DateTime`, and so on). Reference types do not allocate.
- The collection overloads use `ICollection<T>.Contains` / `Enumerable.Contains`, which go through `EqualityComparer<T>.Default` and do not box; a `HashSet<T>` gives an O(1) lookup.

## 📚 Documentation

- **[Introduction](introduction.md)**: Learn about the library and its purpose
- **[Getting Started](getting-started.md)**: Installation and basic usage
- **[Setup](setup.md)**: Advanced configuration and customization
- **API Reference**: Detailed API documentation (generated by DocFX)

## Project Structure

```
IEquatable-Extensions/
├── src/                    # Source code
│   └── Wolfgang.Extensions.IEquatable/
├── tests/                  # Unit tests
├── benchmarks/            # Performance benchmarks
├── examples/              # Usage examples
└── docs/                  # Documentation
```

## 🤝 Contributing

Contributions are welcome! Please read our [Contributing Guide](https://github.com/Chris-Wolfgang/IEquatable-Extensions/blob/main/CONTRIBUTING.md) before submitting pull requests.

### How to Contribute
1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](https://github.com/Chris-Wolfgang/IEquatable-Extensions/blob/main/LICENSE) file for details.

## 🙏 Acknowledgments

- Inspired by common patterns in the .NET ecosystem
- Compatible with .NET Framework 4.6.2 through .NET 10
- Follows Microsoft's design guidelines for .NET libraries

## 📞 Support

- **Issues**: [GitHub Issues](https://github.com/Chris-Wolfgang/IEquatable-Extensions/issues)
- **Discussions**: [GitHub Discussions](https://github.com/Chris-Wolfgang/IEquatable-Extensions/discussions)
- **Documentation**: [Online Docs](https://chris-wolfgang.github.io/IEquatable-Extensions)

## 🌟 Show Your Support

If you find this library useful, please consider:
- ⭐ Starring the repository
- 📢 Sharing it with others
- 🐛 Reporting bugs or requesting features
- 🤝 Contributing to the codebase

---

Made with ❤️ by Chris Wolfgang
