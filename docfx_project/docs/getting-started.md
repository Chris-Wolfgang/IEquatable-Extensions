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

Alternatively, add the following to your `.csproj` file:

```xml
<PackageReference Include="IEquatable-Extensions" Version="*" />
```

## Basic Usage

### Using Extension Methods

Once installed, the extension methods are automatically available for any type implementing `IEquatable<T>`:

```csharp
using IEquatableExtensions;

public class Person : IEquatable<Person>
{
    public string Name { get; set; }
    public int Age { get; set; }

    public bool Equals(Person? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name == other.Name && Age == other.Age;
    }

    public override bool Equals(object? obj) 
        => Equals(obj as Person);

    public override int GetHashCode() 
        => HashCode.Combine(Name, Age);
}

// Using the extensions
var person1 = new Person { Name = "Alice", Age = 30 };
var person2 = new Person { Name = "Alice", Age = 30 };

bool areEqual = person1.EqualsNullSafe(person2); // true
```

### Using Helper Classes

IEquatable-Extensions provides helper classes for common scenarios:

```csharp
using IEquatableExtensions.Helpers;

public class Product : IEquatable<Product>
{
    public string Sku { get; set; }
    public decimal Price { get; set; }

    public bool Equals(Product? other)
    {
        return EqualityHelper.AreEqual(this, other,
            p => p.Sku,
            p => p.Price);
    }

    public override bool Equals(object? obj) 
        => Equals(obj as Product);

    public override int GetHashCode() 
        => EqualityHelper.GetHashCode(Sku, Price);
}
```

### Using Attributes (Source Generators)

For even simpler implementation, use the provided attributes:

```csharp
using IEquatableExtensions.Attributes;

[GenerateEquality]
public partial class Customer
{
    [EqualityProperty]
    public string Email { get; set; }
    
    [EqualityProperty]
    public string CustomerId { get; set; }
    
    // This property will be ignored in equality comparison
    public DateTime LastLoginDate { get; set; }
}
```

The source generator will automatically implement `IEquatable<Customer>`, override `Equals` and `GetHashCode`, and implement equality operators.

## Common Patterns

### Value Objects

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
```

### Collections

```csharp
using IEquatableExtensions;

var list1 = new List<int> { 1, 2, 3 };
var list2 = new List<int> { 1, 2, 3 };

bool sequenceEqual = list1.SequenceEqualsNullSafe(list2); // true
```

### Custom Comparers

```csharp
using IEquatableExtensions.Comparers;

var comparer = new PropertyEqualityComparer<Person>(p => p.Name);
bool areEqual = comparer.Equals(person1, person2);
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