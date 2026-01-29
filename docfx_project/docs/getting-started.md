# Getting Started

This guide will help you quickly integrate IEquatable-Extensions into your .NET project and start using its features.

## Installation

### NuGet Package Manager

Install the package using the NuGet Package Manager Console:

```powershell
Install-Package IEquatable-Extensions
```

### .NET CLI

Use the .NET CLI to add the package to your project:

```bash
dotnet add package IEquatable-Extensions
```

### Package Reference

Alternatively, add the following to your `.csproj` file (replace `1.0.0` with the latest version):

```xml
<PackageReference Include="IEquatable-Extensions" Version="1.0.0" />
```

> **Note**: Check [NuGet.org](https://www.nuget.org/packages/IEquatable-Extensions/) for the latest stable version.

## Basic Usage

### Using Extension Methods

The library provides extension methods for null-safe equality comparisons:

```csharp
using IEquatableExtensions;

var person1 = new Person { Name = "Alice", Age = 30 };
var person2 = new Person { Name = "Alice", Age = 30 };
var person3 = null;

// Null-safe equality check - no need to check for null manually
bool areEqual = person1.EqualsNullSafe(person2); // true
bool isNull = person1.EqualsNullSafe(person3);    // false (no NullReferenceException!)

// Works with collections too
var list1 = new List<int> { 1, 2, 3 };
var list2 = new List<int> { 1, 2, 3 };
bool sequenceEqual = list1.SequenceEqualsNullSafe(list2); // true
```

### Using Helper Classes

Simplify implementing equality in your types with helper methods:

```csharp
using IEquatableExtensions.Helpers;

public class Product : IEquatable<Product>
{
    public string Sku { get; set; }
    public decimal Price { get; set; }

    // Use EqualityHelper to compare properties easily
    public bool Equals(Product? other) =>
        EqualityHelper.AreEqual(this, other, p => p.Sku, p => p.Price);

    public override bool Equals(object? obj) => Equals(obj as Product);
    
    // Use EqualityHelper for consistent hash codes
    public override int GetHashCode() => EqualityHelper.GetHashCode(Sku, Price);
}
```

### Using Attributes (Source Generators)

The library's most powerful feature - automatically generate all equality code with attributes:

```csharp
using IEquatableExtensions.Attributes;

// Just add attributes - no manual implementation needed!
[GenerateEquality]
public partial class Customer
{
    [EqualityProperty]
    public string Email { get; set; }
    
    [EqualityProperty]
    public string CustomerId { get; set; }
    
    // Properties without [EqualityProperty] are ignored in equality
    public DateTime LastLoginDate { get; set; }
}

// The library automatically generates:
// - IEquatable<Customer> implementation
// - Equals(Customer? other) method
// - Equals(object? obj) override
// - GetHashCode() override
// - == and != operators
```

**Benefits:**
- **Zero Boilerplate**: No manual equality code to write
- **Always Correct**: Generated code follows best practices
- **Maintainable**: Add/remove properties by just adding/removing attributes
- **Performance**: Optimized generated code with no overhead

## Common Patterns

### Value Objects with Source Generators

Create immutable value objects with zero boilerplate:

```csharp
[GenerateEquality]
public partial class Address
{
    [EqualityProperty]
    public string Street { get; init; }
    
    [EqualityProperty]
    public string City { get; init; }
    
    [EqualityProperty]
    public string PostalCode { get; init; }
}

// Usage - equality just works!
var address1 = new Address { Street = "123 Main St", City = "Boston", PostalCode = "02101" };
var address2 = new Address { Street = "123 Main St", City = "Boston", PostalCode = "02101" };

bool areSame = address1 == address2; // true - operators automatically generated
```

### Collection Equality

Safe collection comparisons without null checks:

```csharp
using IEquatableExtensions;

var list1 = new List<int> { 1, 2, 3 };
var list2 = new List<int> { 1, 2, 3 };
var list3 = null;

bool sequenceEqual = list1.SequenceEqualsNullSafe(list2);  // true
bool nullSafe = list1.SequenceEqualsNullSafe(list3);       // false (no exception!)
```

### Custom Property Comparers

Compare objects by specific properties:

```csharp
using IEquatableExtensions.Comparers;

var comparer = new PropertyEqualityComparer<Person>(p => p.Email);

var person1 = new Person { Email = "alice@example.com", Name = "Alice" };
var person2 = new Person { Email = "alice@example.com", Name = "Alicia" };

bool areEqual = comparer.Equals(person1, person2); // true - same email
```

### Hash Code Building

Build consistent hash codes with fluent API:

```csharp
using IEquatableExtensions;

public override int GetHashCode()
{
    return new HashCodeBuilder()
        .Add(FirstName)
        .Add(LastName)
        .Add(DateOfBirth)
        .Build();
}
```

## Next Steps

- Review the [Setup](setup.md) guide for advanced configuration options
- Explore the API documentation for detailed method descriptions
- Check out the [examples](../../examples/) folder for more usage scenarios
- Read the [README](readme.md) for additional information about the project

## Need Help?

- Report issues on [GitHub Issues](https://github.com/Chris-Wolfgang/IEquatable-Extensions/issues)
- Check existing discussions and questions
- Refer to the inline XML documentation in your IDE