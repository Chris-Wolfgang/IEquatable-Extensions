# Getting Started

This guide will help you quickly integrate IEquatable-Extensions (Wolfgang.Extensions.IEquatable) into your .NET project and start using its features.

## Installation

### NuGet Package Manager

Install the package using the NuGet Package Manager Console:

```powershell
Install-Package Wolfgang.Extensions.IEquatable
```

### .NET CLI

Use the .NET CLI to add the package to your project:

```bash
dotnet add package Wolfgang.Extensions.IEquatable
```

### Package Reference

Alternatively, add the following to your `.csproj` file (replace `1.0.0` with the latest version):

```xml
<PackageReference Include="Wolfgang.Extensions.IEquatable" Version="1.0.0" />
```

> **Note**: Check [NuGet.org](https://www.nuget.org/packages/Wolfgang.Extensions.IEquatable/) for the latest stable version.

## Basic Usage

Once installed, add the using directive to your C# file:

```csharp
using Wolfgang.Extensions.IEquatable;
```

The extension methods are now available for all types.

### IsInSet Extension Method

Check if a value matches any value in a set:

```csharp
// Simple value comparison
string status = "active";
bool isValid = status.IsInSet("active", "pending", "approved");  // true

// Works with any type
int value = 5;
bool inRange = value.IsInSet(1, 2, 3, 4, 5);  // true

// Works with collections
string[] validStatuses = { "active", "pending", "approved" };
bool isValidStatus = status.IsInSet(validStatuses);  // true

// Works with IEnumerable
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
bool found = value.IsInSet(numbers);  // true
```

This replaces verbose code like:
```csharp
// Before
if (status == "active" || status == "pending" || status == "approved")
{
    // ...
}

// After
if (status.IsInSet("active", "pending", "approved"))
{
    // ...
}
```

### IsNotInSet Extension Method

Check if a value doesn't match any value in a set (inverse of IsInSet):

```csharp
string status = "rejected";
bool isInvalid = status.IsNotInSet("active", "pending", "approved");  // true

// Works with arrays and collections
string[] validStatuses = { "active", "pending", "approved" };
bool isInvalidStatus = status.IsNotInSet(validStatuses);  // true
```

This replaces verbose code like:
```csharp
// Before
if (status != "active" && status != "pending" && status != "approved")
{
    // ...
}

// After
if (status.IsNotInSet("active", "pending", "approved"))
{
    // ...
}
```

### NotEqual Extension Method

Null-safe inequality comparison:

```csharp
string value1 = "hello";
string value2 = "world";
string? value3 = null;

bool different = value1.NotEqual(value2);   // true
bool differentFromNull = value1.NotEqual(value3);  // true (null-safe)
```

The NotEqual method handles null references safely, avoiding NullReferenceExceptions.

## Common Patterns

### Validating Input Against Allowed Values

```csharp
public void SetStatus(string status)
{
    if (status.IsNotInSet("draft", "published", "archived"))
    {
        throw new ArgumentException("Invalid status value");
    }
    
    // Status is valid, continue processing...
}
```

### Switch-like Comparisons

```csharp
public string GetPriority(int level)
{
    if (level.IsInSet(1, 2, 3))
        return "High";
    else if (level.IsInSet(4, 5, 6))
        return "Medium";
    else
        return "Low";
}
```

### Collection Membership Checks

```csharp
HashSet<string> allowedUsers = new HashSet<string> { "admin", "manager", "supervisor" };

public bool CanAccessResource(string username)
{
    return username.IsInSet(allowedUsers);
}
```

### Enum Validation

```csharp
public enum OrderStatus
{
    Pending,
    Processing,
    Shipped,
    Delivered,
    Cancelled
}

public bool IsFinalStatus(OrderStatus status)
{
    return status.IsInSet(OrderStatus.Delivered, OrderStatus.Cancelled);
}
```

## Method Overloads

The library provides multiple overloads for flexibility:

### IsInSet Overloads

```csharp
// Single value
item.IsInSet(value1)

// Two values
item.IsInSet(value1, value2)

// Three values
item.IsInSet(value1, value2, value3)

// Variable number of values (params array)
item.IsInSet(value1, value2, value3, value4, ...)

// IEnumerable<T>
item.IsInSet(collection)

// ICollection<T>
item.IsInSet(hashSet)
```

All IsNotInSet overloads mirror the IsInSet overloads.

## Framework Compatibility

The library supports a wide range of .NET frameworks:

- .NET Framework 4.6.2
- .NET Standard 2.0
- .NET 8.0
- .NET 10.0

The library uses conditional compilation to provide nullable reference type support on .NET 5.0 and later.

## Next Steps

- Review the [Setup](setup.md) guide for advanced configuration options
- Explore the API documentation for detailed method descriptions
- Read the [README](readme.md) for additional information about the project

## Need Help?

- Report issues on [GitHub Issues](https://github.com/Chris-Wolfgang/IEquatable-Extensions/issues)
- Check existing discussions and questions
- Refer to the inline XML documentation in your IDE
