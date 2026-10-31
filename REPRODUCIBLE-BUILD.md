# Reproducible builds

The assemblies in the `Wolfgang.Extensions.IEquatable` package are built deterministically: the same source commit, built with the same .NET SDK, produces byte-identical DLLs and PDBs regardless of the machine, the checkout path or the operating system (Linux or Windows). This relies on `Deterministic` and `ContinuousIntegrationBuild` (set when `CI=true`) in `Directory.Build.props`, which normalise source paths, plus SourceLink, which embeds the commit. Two more settings remove the operating-system inputs: `Directory.Build.targets` rewrites the SDK-generated `AssemblyInfo` / `AssemblyAttributes` sources to LF before compiling (the PDB records their hashes), and `Directory.Build.props` compiles the .NET Framework targets against the `Microsoft.NETFramework.ReferenceAssemblies` package on every OS instead of a locally installed targeting pack. Releases built before these two settings were added are reproducible on the same operating system only.

One input depends on the calendar: once the package takes its copyright line from `Directory.Build.props` (`Copyright (c) <UtcNow.Year> Chris Wolfgang`), a rebuild in a later year changes the `AssemblyCopyright` attribute unless the original year is passed back in (see step 2). Releases up to and including 0.3.0 pin `Copyright 2026 Chris Wolfgang` in the csproj, so for those the year does not matter.

## What CI checks

The [Reproducible Build](.github/workflows/reproducible-build.yaml) workflow checks three things on every pull request and push to `main`:

1. On each of `ubuntu-latest` and `windows-latest` it builds the commit twice from two different directories, hashes every `.dll` and `.pdb` the `src/` project produces, and fails when the two sets of hashes differ.
2. In the same job it packs both builds and compares the two `.nupkg` files **entry by entry** (each entry's name and the SHA-256 of its content). The `.nupkg` file itself is never byte-identical, because a zip records each entry's pack time; the entries are what must match.
3. A `cross-os` job compares the Linux hashes with the Windows hashes and fails when any `.dll` or `.pdb` differs.

Both builds of step 1 run in the same job, so the check cannot detect the year dependence described above.

## Verify a release yourself

1. Check out the release tag with the .NET SDK the release's `pack-and-validate` job installed. Any operating system works for a release built with the LF-normalising `Directory.Build.targets`. Older releases, including 0.3.0, must be rebuilt on the release build's operating system (`windows-latest`). The SDK version is printed in the release run's "Setup .NET" log, but GitHub deletes run logs after 90 days, so for an old release it may no longer be recoverable.
2. Set `CI=true` in the environment and build the library:
   `dotnet build src/Wolfgang.Extensions.IEquatable -c Release -p:ContinuousIntegrationBuild=true -p:NuGetAudit=false`.
   For a release whose csproj no longer pins `<Copyright>`, add `"-p:Copyright=Copyright (c) <year> Chris Wolfgang"`, where `<year>` is the year the release was built (the published DLL's `AssemblyCopyright` attribute shows it). Do **not** pass it for 0.3.0 or earlier: a global property overrides the csproj's own value and changes the DLL. `NuGetAudit=false` is needed for older tags: NuGet's vulnerability audit is time-dependent, so a tag that restored cleanly on release day can fail today with `NU1902` once an advisory is published against one of its build-time packages. It switches off the audit only and does not change the output.
3. Download the `.nupkg` from the GitHub Release (or nuget.org) and extract it; it is a zip. For each `lib/<tfm>/Wolfgang.Extensions.IEquatable.dll`, compare it with `src/Wolfgang.Extensions.IEquatable/bin/Release/<tfm>/Wolfgang.Extensions.IEquatable.dll`. `cmp -l published.dll rebuilt.dll | wc -l` prints the number of differing bytes (`0` means byte-identical). A `sha256sum` of each file gives the same yes/no answer.

The guarantee covers the library's own assembly. The PDB embeds the repository URL and commit, so a fork builds different PDBs.

### What a near-match looks like (v0.3.0, measured 2026-10-22)

Rebuilding the `v0.3.0` tag on Windows with SDK 10.0.400 (step 2, without a copyright override) and comparing it with the published 0.3.0 package gave **72 differing bytes** in the `net462`, `net8.0` and `net10.0` assemblies and **69** in `netstandard2.0`, with identical file sizes. For `net8.0` the differences sit in five ranges and nowhere else:

| File offsets (net8.0) | Bytes | Field |
|---|---|---|
| `0x88`–`0x8b` | 4 | PE header `TimeDateStamp` |
| `0xc04`–`0xc13` | 16 | Module version id (MVID) in the metadata GUID heap |
| `0xe8c`–`0xe8f` | 4 | `TimeDateStamp` of the CodeView debug-directory entry |
| `0xee0`–`0xeef` | 16 | CodeView PDB id (GUID) |
| `0xf57`–`0xf76` | 32 | PDB checksum (SHA-256) |

(`netstandard2.0` is 69 rather than 72 only because three bytes of those fields happen to coincide.) These five fields are derived from a hash of the compilation, so a different compiler version or different generated source files change them while leaving the code unchanged; every other byte, including the IL, the metadata tables and the resources, was identical. The 0.3.0 release-run log has expired, so the SDK it used is unknown; a different SDK is consistent with the result but is not proven. A mismatch confined to these five ranges is the expected shape of "same source, different toolchain"; a mismatch anywhere else is a real discrepancy.

Doing the same build with `"-p:Copyright=Copyright (c) 2026 Chris Wolfgang"` gave 768–895 differing bytes per assembly: the override replaced the csproj's `Copyright 2026 Chris Wolfgang`, which shows why step 2 says not to pass it for 0.3.0.

### Reporting a discrepancy

Open an issue and include: the release tag and commit, your operating system and `dotnet --info`, the exact build command, the `cmp -l` byte count per target framework and the offsets of the differing ranges (for example `cmp -l a.dll b.dll | awk '{printf "%x\n", $1-1}'`). Say whether you passed `-p:Copyright`. Ranges outside the five fields above are the interesting ones.

### Release hash manifest

Releases published after the manifest step was added to `release.yaml` carry a `reproducible-build-manifest.json` asset. It lists the tag, the commit, and the SHA-256 of each attached `.nupkg` and `.snupkg` and of every `.dll` and `.pdb` inside them. It describes the **published bytes**, which is what a rebuild is compared against; it is not signed (the build-provenance attestation covers the `.nupkg`, see [SECURITY.md](SECURITY.md)). Because of the toolchain-dependent fields above, a rebuild is not expected to match every hash; compare with `cmp -l` as described and treat a mismatch confined to those five ranges as the expected near-match. Releases up to and including 0.3.0 have no manifest; compare against the `.nupkg` itself.

### Sharing your verification result

There is no third-party attestation service wired into this repository. To record that you rebuilt a release, open an issue titled `Verification: v<version>` containing the same information as a discrepancy report: tag and commit, operating system and `dotnet --info`, the exact build command, and the per-target-framework `cmp -l` byte count with the differing offsets. State plainly whether the result was byte-identical, a near-match confined to the five fields, or a mismatch elsewhere. A report is a claim by the person who ran it, not something this project signs or vouches for.
