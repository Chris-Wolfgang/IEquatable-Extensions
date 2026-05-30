# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added

- Real README with installation, Quick Start, API reference table, and
  build instructions (replaces the inherited template stub).
- This CHANGELOG, seeded from git tag history.
- `<RepositoryUrl>` / `<RepositoryType>` package metadata per the
  fleet-wide CI1 canonical (NuGet quality).
- Explicit `<FileVersion>$(Version).0` so file-version metadata tracks
  every release.
- D8 release-time docs-build verification via the canonical
  `verify-docs-build` job — a docs failure now blocks `publish-nuget`
  instead of landing after the package is already on NuGet.
- D6 versions.json preservation guard in `docfx.yaml` — prior
  versioned docs are no longer wiped on a release.
- T1 coverage report published under `docs/coverage/` on every release.
- T3 Stryker mutation-testing workflow scaffolded.
- S1 CodeQL `security-extended` query suite enabled.
- CI2 GitHub Actions ecosystem added to Dependabot.
- A1 PublicApiAnalyzer scaffolding (analyzer is dormant until per-repo
  Shipped.txt baseline is populated at the next release prep).

### Changed

- `<TargetFrameworks>` collapsed onto a single line (CLAUDE.md rule —
  the canonical CI grep parses this and breaks on multi-line).
- `<PackageProjectUrl>` corrected from
  `Wolfgang.Extensions.IEquatable` (the package id) to
  `IEquatable-Extensions` (the actual repo name).
- `<AssemblyVersion>` switched from the 3-part `1.0.0` form to the
  explicit 4-part `1.0.0.0` form. SDK accepts both; explicit 4-part is
  the canonical, unambiguous binding identity.
- `<Nullable>enable</Nullable>` hoisted into `Directory.Build.props`
  (scoped to SDK-style C# projects so legacy / F# projects are not
  affected).
- Canonical re-sync of protected config + workflow files (C1 drift).

### Fixed

- `<AssemblyVersion>` was previously dropped by an earlier canonical
  C4 fanout, leaving the SDK to derive it from `<Version>`. That broke
  binding-identity stability between minor/patch releases on .NET
  Framework consumers. The explicit pin is restored here so future
  bumps keep the same `AssemblyVersion=1.0.0.0` until a deliberate
  breaking-API release.

## [0.2.0] - 2026-05-01

### Added

- Initial published release of the `IsInSet` / `IsNotInSet` /
  `NotEqual` extension method family across `net462`,
  `netstandard2.0`, `net8.0`, and `net10.0`.

[Unreleased]: https://github.com/Chris-Wolfgang/IEquatable-Extensions/compare/v0.2.0...HEAD
[0.2.0]: https://github.com/Chris-Wolfgang/IEquatable-Extensions/releases/tag/v0.2.0
