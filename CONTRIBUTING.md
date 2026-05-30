# Contributing to Wolfgang.Extensions.IEquatable

Thank you for your interest in contributing to **Wolfgang.Extensions.IEquatable**! We welcome contributions to help improve this project.

## How Can You Contribute?

You can contribute in several ways:
- Reporting bugs
- Suggesting enhancements
- Submitting pull requests for new features or bug fixes
- Improving documentation
- Writing or improving tests

**Please note:** Before coding anything please check with me first by entering an issue and getting approval for it. PRs are more likely to get merged if I have agreed to the changes.

---

## Getting Started

1. **Fork the repository** and clone it locally.
2. **Create a new branch** for your feature or bug fix:
   ```sh
   git checkout -b your-feature-name
   ```
3. **Make your changes** and commit them with clear messages:
   ```sh
   git commit -m "Describe your changes"
   ```
4. **Push your branch** to your fork:
   ```sh
   git push origin your-feature-name
   ```
5. **Open a pull request** describing your changes.

6. **PR Checks:**  
   Once you create a pull request (PR), several Continuous Integration (CI) steps will run automatically. These may include:
   - Building the project
   - Running automated tests
   - Checking code style and linting
   - Running static analysis with multiple static analyzers (see list below)

   **It is important to make sure that all CI steps pass before your PR can be merged.**
   - If any CI step fails, please review the error messages and update your PR as needed.
   - Maintainers will review your PR once all checks have passed.

---

## Code Quality Standards

This project maintains **extremely high code quality standards** through multiple layers of static analysis and automated enforcement.

### The 7 Analyzers

All code is analyzed by these tools during build:

1. **Microsoft.CodeAnalysis.NetAnalyzers** (Built-in .NET SDK)
   - Correctness, performance, and security rules
   - Latest analysis level enabled

2. **Roslynator.Analyzers**
   - 500+ refactoring and code quality rules
   - Advanced C# pattern detection

3. **AsyncFixer**
   - Detects common async/await anti-patterns (AsyncFixer01–05)
   - Flags missing or incorrect cancellation-token propagation
   - Prevents fire-and-forget async calls (`async void` outside event handlers)
   - NOTE: `ConfigureAwait()` enforcement is handled by Meziantou's
     MA0004 / SonarAnalyzer S3216 / CA2007, not by AsyncFixer.

4. **Microsoft.VisualStudio.Threading.Analyzers**
   - Thread safety enforcement
   - Async method naming conventions
   - Deadlock prevention

5. **Microsoft.CodeAnalysis.BannedApiAnalyzers**
   - Blocks usage of APIs listed in `BannedSymbols.txt`
   - Enforces async-first patterns (see below)

6. **Meziantou.Analyzer**
   - Comprehensive code quality checks
   - Performance optimizations
   - Best practice enforcement

7. **SonarAnalyzer.CSharp**
   - Industry-standard code analysis
   - Security vulnerability detection
   - Code smell identification

### Banned APIs

`BannedSymbols.txt` is shared fleet-wide and bans the same set of obsolete
or insecure APIs across every Wolfgang.* repo (e.g. `BinaryFormatter`,
`new WebClient()`, `DateTime.Now` — prefer `DateTimeOffset.UtcNow`). The
analyzer enforces these on every build.

The async-blocking bans (`task.Wait()`, `task.Result`, `File.ReadAllText`,
`Thread.Sleep`, etc.) are also part of the shared list. They don't
currently apply to this library — **`Wolfgang.Extensions.IEquatable` is a
synchronous extension-method library** with no async APIs, no I/O, and no
threading. The bans are inert here, but the shared rule set means that
if async code is ever introduced to this project, it will be required to
follow the fleet's async-first conventions from the start.

---

## Build and Test Instructions

### Prerequisites
- .NET 10.0 SDK or later (required for the repo's net10.0 target; older SDKs cannot load the csproj)
- PowerShell Core (optional, for formatting scripts)

### Build the Project

```bash
# Restore NuGet packages
dotnet restore

# Build in Release configuration (enforces all analyzers)
dotnet build --configuration Release
```

**Note:** Release builds treat all analyzer warnings as errors (`<TreatWarningsAsErrors>true</TreatWarningsAsErrors>`). Debug builds allow warnings to facilitate development.

### Run Tests

```bash
# Run all unit tests
dotnet test --configuration Release

# Run with coverage (if configured)
dotnet test --collect:"XPlat Code Coverage"
```

### Code Formatting

This project uses `.editorconfig` for consistent code style:

```bash
# Format all code
dotnet format

# Check formatting without changes (CI mode)
dotnet format --verify-no-changes

# PowerShell formatting script
pwsh ./scripts/format.ps1
```

See [docs/README-FORMATTING.md](docs/README-FORMATTING.md) for detailed formatting rules.

---

## .editorconfig Rules

Key style rules enforced:

- **Indentation:** 4 spaces (C#), 2 spaces (XML/JSON)
- **Line endings:** LF (Unix-style)
- **Charset:** UTF-8
- **Trim trailing whitespace:** Yes
- **Final newline:** Yes
- **Braces:** New line style (Allman)
- **Naming:** PascalCase for public members, camelCase for parameters/locals
- **File-scoped namespaces:** Required in C# 10+
- **`var` preferences:** Use for built-in types and when type is obvious
- **Null checks:** Prefer pattern matching (`is null`, `is not null`)

View the complete configuration in [.editorconfig](.editorconfig).

---

## Guidelines

- Follow the coding style used in the project.
- Write clear, concise commit messages.
- Add relevant tests for new features or bug fixes.
- Document any public APIs with XML documentation comments.
- Ensure all analyzer warnings are addressed (they're treated as errors in Release builds).
- If async code is ever introduced, follow the fleet's async-first
  conventions: avoid blocking calls (`task.Wait()`, `task.Result`,
  `Thread.Sleep`), prefer async I/O, and accept `CancellationToken`
  parameters where appropriate.

---

## Pull Requests

- Ensure your pull request passes all tests and analyzer checks.
- Respond to review feedback in a timely manner.
- Reference related issues in your pull request description.
- Keep changes focused and atomic - one feature/fix per PR.
- Update documentation if you change public APIs.

---

## Code of Conduct

Please be respectful and considerate in all interactions. See [CODE_OF_CONDUCT.md](CODE_OF_CONDUCT.md) for our community guidelines.

---

Thank you for contributing! 🎉
