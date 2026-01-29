# Introduction

## Overview

IEquatable-Extensions (Wolfgang.Extensions.IEquatable) is a lightweight .NET library that provides extension methods to simplify common equality comparison patterns when working with types that implement `IEquatable<T>`.

## What is IEquatable?

The `IEquatable<T>` interface in .NET is used to define type-specific equality comparison. When a class implements `IEquatable<T>`, it provides a strongly-typed `Equals` method that avoids boxing and provides better performance than the default `Object.Equals` method.

## What This Library Provides

IEquatable-Extensions adds convenient extension methods for common equality comparison scenarios:

- **IsInSet**: Check if a value matches any of a set of values
- **IsNotInSet**: Check if a value doesn't match any of a set of values
- **NotEqual**: Null-safe inequality comparison

These extension methods help reduce boilerplate code and make your equality checks more readable and maintainable.

## Key Features

- 🚀 **Simple API**: Easy-to-use extension methods that work with any type
- ⚡ **High Performance**: Minimal overhead with optimized implementations
- 📦 **Lightweight**: Single file library with no external dependencies
- 🔒 **Null-safe**: Built-in null handling in extension methods
- ✅ **Well Tested**: Comprehensive test coverage ensuring reliability

## Use Cases

This library is particularly useful for:
- Simplifying conditional logic with multiple equality comparisons
- Validating input against a set of acceptable values
- Writing cleaner switch-like comparison logic
- Checking membership in collections or sets

## Prerequisites

- .NET Framework 4.6.2, .NET Standard 2.0, .NET 8.0, or .NET 10.0
- Basic understanding of C# and object-oriented programming
- Familiarity with equality comparison concepts in .NET

## Next Steps

Ready to get started? Head over to the [Getting Started](getting-started.md) guide to learn how to install and use Wolfgang.Extensions.IEquatable in your project.