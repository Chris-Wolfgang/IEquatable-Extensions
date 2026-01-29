# Setup Guide

This guide covers installation, configuration, and integration scenarios for Wolfgang.Extensions.IEquatable.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [IDE Integration](#ide-integration)
- [Build Configuration](#build-configuration)
- [Troubleshooting](#troubleshooting)

## Prerequisites

### Minimum Requirements

- **.NET**: .NET Framework 4.6.2 or higher, .NET Standard 2.0, .NET 8.0, or .NET 10.0
- **C# Version**: 7.3 or higher
- **IDE**: Visual Studio 2017 or higher, Visual Studio Code, or JetBrains Rider

### Optional Tools

- **NuGet CLI**: For command-line package management
- **Visual Studio Extensions**: For enhanced IntelliSense support

## Installation

### Standard Installation

For most projects, a standard NuGet package installation is sufficient:

```bash
dotnet add package Wolfgang.Extensions.IEquatable
```

### Development Build Installation

To use the latest development build from a local source:

1. Clone the repository:
   ```bash
   git clone https://github.com/Chris-Wolfgang/IEquatable-Extensions.git
   cd IEquatable-Extensions
   ```

2. Checkout the develop branch:
   ```bash
   git checkout develop
   ```

3. Build the project:
   ```bash
   dotnet build --configuration Release
   ```

4. Pack the NuGet package:
   ```bash
   dotnet pack --configuration Release
   ```

5. Add the local package source:
   ```bash
   dotnet nuget add source ./artifacts/packages/Release --name LocalIEquatableExtensions
   ```

6. Install from the local source:
   ```bash
   dotnet add package Wolfgang.Extensions.IEquatable --source LocalIEquatableExtensions
   ```

## Configuration

### Global Using Directives

To make the extensions available throughout your project without explicit using statements, add to your `GlobalUsings.cs`:

```csharp
global using Wolfgang.Extensions.IEquatable;
```

Or add to your `.csproj` file (C# 10+):

```xml
<ItemGroup>
  <Using Include="Wolfgang.Extensions.IEquatable" />
</ItemGroup>
```

## IDE Integration

### Visual Studio 2017+

1. Install Visual Studio 2017 or higher (Visual Studio 2022 recommended)
2. Ensure the ".NET desktop development" workload is installed
3. The package will provide IntelliSense automatically

### Visual Studio Code

1. Install the C# extension by Microsoft
2. Install the C# Dev Kit (optional but recommended)
3. Ensure a compatible .NET SDK is installed and in PATH

```json
// .vscode/settings.json
{
  "dotnet.preferCSharpExtension": true,
  "omnisharp.enableRoslynAnalyzers": true
}
```

### JetBrains Rider

Rider has built-in support for extension methods. No additional configuration needed.

## Build Configuration

### CI/CD Integration

#### GitHub Actions

```yaml
name: Build

on: [push, pull_request]

jobs:
  build:
    runs-on: ubuntu-latest
    steps:
    - uses: actions/checkout@v4
    - name: Setup .NET
      uses: actions/setup-dotnet@v4
      with:
        dotnet-version: | 
          6.0.x
          8.0.x
    - name: Restore dependencies
      run: dotnet restore
    - name: Build
      run: dotnet build --no-restore --configuration Release
    - name: Test
      run: dotnet test --no-build --configuration Release
```

> **Note**: Adjust the `dotnet-version` to match your project's target frameworks.

#### Azure Pipelines

```yaml
trigger:
- main

pool:
  vmImage: 'ubuntu-latest'

variables:
  buildConfiguration: 'Release'

steps:
- task: UseDotNet@2
  inputs:
    version: '6.0.x'
- task: UseDotNet@2
  inputs:
    version: '8.0.x'
- task: DotNetCoreCLI@2
  displayName: 'Restore packages'
  inputs:
    command: 'restore'
- task: DotNetCoreCLI@2
  displayName: 'Build'
  inputs:
    command: 'build'
    arguments: '--configuration $(buildConfiguration) --no-restore'
- task: DotNetCoreCLI@2
  displayName: 'Test'
  inputs:
    command: 'test'
    arguments: '--configuration $(buildConfiguration) --no-build'
```

> **Note**: Adjust the .NET SDK versions based on your target frameworks.

### Package Reference Options

#### Version Pinning

For production applications, pin to a specific version:

```xml
<PackageReference Include="Wolfgang.Extensions.IEquatable" Version="1.0.0" />
```

#### Floating Versions

For development or when you want automatic updates (use with caution in production):

```xml
<!-- Latest stable (not recommended for production) -->
<PackageReference Include="Wolfgang.Extensions.IEquatable" Version="*" />

<!-- Latest 1.x version -->
<PackageReference Include="Wolfgang.Extensions.IEquatable" Version="1.*" />
```

> **Warning**: Floating versions can introduce breaking changes unexpectedly. Always pin to specific versions in production builds.

## Troubleshooting

### IntelliSense Not Working

**Problem**: Extension methods not showing in IntelliSense

**Solutions**:
1. Add explicit using directive:
   ```csharp
   using Wolfgang.Extensions.IEquatable;
   ```

2. Check that the package reference exists in `.csproj`

3. Restart OmniSharp (VS Code) or Visual Studio

### Build Errors

**Problem**: Compilation errors related to extension methods

**Solutions**:
1. Ensure the using directive is present:
   ```csharp
   using Wolfgang.Extensions.IEquatable;
   ```

2. Verify the package is properly installed:
   ```bash
   dotnet list package
   ```

3. Clean and rebuild:
   ```bash
   dotnet clean
   dotnet build
   ```

### NuGet Package Not Found

**Problem**: Cannot find the package in NuGet

**Solutions**:
1. Clear NuGet cache:
   ```bash
   dotnet nuget locals all --clear
   ```

2. Verify package source:
   ```bash
   dotnet nuget list source
   ```

3. Add nuget.org as a source:
   ```bash
   dotnet nuget add source https://api.nuget.org/v3/index.json -n nuget.org
   ```

## Advanced Scenarios

### Multi-Targeting

If your library needs to target multiple frameworks:

```xml
<PropertyGroup>
  <TargetFrameworks>net462;netstandard2.0;net8.0;net10.0</TargetFrameworks>
</PropertyGroup>
```

> **Note**: The library supports .NET Framework 4.6.2, .NET Standard 2.0, .NET 8.0, and .NET 10.0.

### Integration with Dependency Injection

The library provides extension methods only, so no DI registration is needed. Simply ensure the using directive is present where you need the extensions.

## Next Steps

- Read the [Getting Started](getting-started.md) guide for usage examples
- Explore the [API Reference](../api/index.md) for detailed documentation
- Visit the [GitHub repository](https://github.com/Chris-Wolfgang/IEquatable-Extensions) for source code

## Getting Help

If you encounter issues not covered here:

1. Check [GitHub Issues](https://github.com/Chris-Wolfgang/IEquatable-Extensions/issues)
2. Search [GitHub Discussions](https://github.com/Chris-Wolfgang/IEquatable-Extensions/discussions)
3. Create a new issue with:
   - Your .NET version (`dotnet --version`)
   - Your OS and IDE
   - A minimal reproducible example
   - Error messages and stack traces
