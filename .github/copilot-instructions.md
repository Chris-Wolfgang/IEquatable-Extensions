# Copilot instructions for IEquatable-Extensions

## What this repository is

A shipped .NET library, published to NuGet as `Wolfgang.Extensions.IEquatable`. It is one public static class,
`Wolfgang.Extensions.IEquatable.IEquatableExtensions`, in `src/Wolfgang.Extensions.IEquatable/IEquatableExtensions.cs`:

- `IsInSet<T>` — true when the item equals one of 1, 2 or 3 listed values, or appears in a `params T[]`,
  an `IEnumerable<T>` or an `ICollection<T>`.
- `IsNotInSet<T>` — the negation of each `IsInSet` overload.
- `NotEqual<T>` — a fluent `!Equals(item, other)`.

The 1/2/3-item overloads and `NotEqual` use `static object.Equals(object, object)` (value types are boxed). The
collection overloads use `Enumerable.Contains` / `ICollection<T>.Contains`, which go through
`EqualityComparer<T>.Default`. The collection overloads throw `ArgumentNullException` (parameter `set`) for a null set.

- **License:** MIT (`LICENSE`, `<PackageLicenseExpression>MIT</PackageLicenseExpression>`).
- **Library targets:** `net462;netstandard2.0;net8.0;net10.0`.
- **Test targets:** `net462;net472;net48;net481;net5.0;net6.0;net7.0;net8.0;net9.0;net10.0`.
- **SDK:** .NET 10 (the CI tools in `.config/dotnet-tools.json` are restored with `dotnet tool restore`; nothing is installed globally).

## Layout

- `src/Wolfgang.Extensions.IEquatable/` — the library, plus `PublicAPI.Shipped.txt` / `PublicAPI.Unshipped.txt` when present.
- `tests/Wolfgang.Extensions.IEquatable.Tests.Unit/` — xunit 2.9.3 tests, one folder per method family.
- `tests/` may also hold the specialised suites (AOT smoke, doc-example compile check, FsCheck fuzz properties).
- `benchmarks/Wolfgang.Extensions.IEquatable.Benchmarks/` — BenchmarkDotNet, charted on gh-pages by `benchmarks.yaml`.
- `docfx_project/` — the documentation site; `docs/` — maintainer docs (workflow security, release setup).
- `changelog/unreleased/` — changelog fragments (see below).

## Build and validate

```bash
dotnet tool restore
dotnet build "IEquatable Extensions.slnx" -c Release
pwsh ./scripts/build-pr.ps1     # the local equivalent of the Windows stage of pr.yaml
```

`scripts/build-pr.ps1` builds in Release (warnings are errors), runs every test project on every target framework,
enforces coverage, and runs DevSkim and gitleaks. The coverage gates are `CODECOV_MINIMUM` (production code under
`src/`) and `CODECOV_TEST_MINIMUM` (every test assembly, held to 100 %) in `.github/workflows/pr.yaml`;
`build-pr.ps1`'s defaults mirror them. Do not lower a gate or add `[ExcludeFromCodeCoverage]` to get green.

## Conventions

- Allman braces, 4-space indentation, file-scoped namespaces, `var` when the type is obvious.
- Three blank lines between members (constructors, methods, properties).
- Multi-line argument lists put the opening parenthesis on its own line, one argument per line, and the closing
  parenthesis on its own line.
- Every public member has `///` docs with `<see cref=""/>` / `<paramref name=""/>`; `<example><code>` blocks must compile.
- Test names follow `MethodUnderTest_when_condition_expected_result`.
- No implicit or global usings in multi-target projects; every file declares its own `using` directives.
- `<TargetFrameworks>` stays on one line in every csproj; no absolute paths in project files.
- Treat warnings as errors: fix them; suppress only with a justification, never with an inline `nosemgrep`.

## Changelog

`CHANGELOG.md` is not edited by hand. A PR that changes `src/` adds one fragment under `changelog/unreleased/`
(`type: breaking|feature|fix|docs|internal` on line 1, then one user-facing sentence) or carries the `no-changelog`
label. See `changelog/unreleased/README.md`.

## Protected files

`.github/workflows/*`, `.editorconfig`, `*.globalconfig`, `*.ruleset`, `*.DotSettings`, `Directory.Build.props`,
`Directory.Build.targets`, `BannedSymbols.txt`, `coverlet.runsettings`, `.config/dotnet-tools.json`, `.gitleaks.toml`,
`.github/license-audit/*.json` and the CI scripts listed in `docs/WORKFLOW_SECURITY.md` must change in a PR of their
own; `protected-files.yaml` fails a PR that mixes them with other changes. `docs/WORKFLOW_SECURITY.md` is the
authoritative list.
