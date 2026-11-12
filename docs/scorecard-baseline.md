# OpenSSF Scorecard baseline

The repository is scored weekly, on every push to `main` and on branch-protection changes by
`.github/workflows/scorecard.yaml`. Findings go to the Security tab (Code Scanning), and the score is meant to be
published to [scorecard.dev](https://scorecard.dev/viewer/?uri=github.com/Chris-Wolfgang/IEquatable-Extensions)
and shown by the badge in the README.

## State on 2026-10-22 (`main` at `a0fb158`)

**No score is published yet.** `https://api.scorecard.dev/projects/github.com/Chris-Wolfgang/IEquatable-Extensions`
returns 404, so the README badge reads "invalid repo path". scorecard.dev rejected every publish because the
analysis job contained a `run:` step (#711); the fix moves the SARIF filter to its own job. The first push to
`main` after that fix publishes the first score.

What the Code Scanning results show in the meantime (they are the same checks, after the suppressions listed below):

| Check | Score | Why, and what is done about it |
|---|---:|---|
| Branch-Protection | 4 | "Not maximal" on the default branch. Improving it is a repository settings (ruleset) change, not a code change. Tracked in #229 (`blocked`). |
| Fuzzing | 0 | "No fuzzer integrations found": Scorecard has no detector for .NET property-based testing, so FsCheck property tests and a weekly fuzz workflow (added in #743 / #744) do not count either. Tracked in #227. |
| Security-Policy | pass | Alert closed 2026-09-23 once `SECURITY.md` met the check. |

Suppressed before the SARIF reaches Code Scanning, with the reason in `scorecard.yaml` (the published score is
unaffected): Code-Review (single-maintainer repository; a required second approver would force an administrator
bypass on every merge), CII-Best-Practices (an external bestpractices.dev registration CI cannot earn), and
Pinned-Dependencies findings for NuGet `restore` commands only (exact versions are pinned in the project files and
nuget.org versions are immutable).

## Baseline scan: 7.0 / 10 (2026-10-16, `main` at `a0fb158`)

scorecard.dev has not accepted a publish yet, but the Scorecard run on every push computes the full result and
prints it in the job log. This is the result of
[run 38899370876](https://github.com/Chris-Wolfgang/IEquatable-Extensions/actions/runs/38899370876) (push to `main`,
2026-10-16, Scorecard v5.6.0), on commit `a0fb158083631f7c8cafff671d9661afbe373c88`, the same `main` as above. It
includes the checks that `scorecard.yaml` filters out of Code Scanning, because the published score does too.

| Check | Score | Scorecard's reason | Accepted? |
|---|---:|---|---|
| Binary-Artifacts | 10 | no binaries found in the repo | |
| Branch-Protection | 4 | no required approvers, no code-owner review, no last-push approval on `main` | Yes: single maintainer (#229, `blocked`) |
| CI-Tests | 10 | 30 out of 30 merged PRs checked by a CI test | |
| CII-Best-Practices | 0 | no OpenSSF best practices badge | Yes: external registration, filtered in `scorecard.yaml` |
| Code-Review | 0 | 0/24 approved changesets | Yes: single maintainer, filtered in `scorecard.yaml` |
| Contributors | 0 | 0 contributing companies or organizations | Yes: single-maintainer project |
| Dangerous-Workflow | 10 | no dangerous workflow patterns | |
| Dependency-Update-Tool | 10 | Dependabot detected | |
| Fuzzing | 0 | no fuzzer integrations found | Yes: no .NET property-test detector (#227, `blocked`) |
| License | 10 | MIT license file detected | |
| Maintained | 10 | 30 commits and 9 issue activities in the last 90 days | |
| Packaging | 10 | packaging workflow detected (`release.yaml`) | |
| Pinned-Dependencies | 7 | 7 `dotnet restore`/`tool restore` commands not hash-pinned; all 73 actions and both pip installs are pinned | Yes: NuGet versions are exact and immutable, filtered in `scorecard.yaml` |
| SAST | 10 | CodeQL on all 30 commits | |
| Security-Policy | 10 | `SECURITY.md` detected | |
| Signed-Releases | 0 | v0.2.0 and v0.3.0 have no signature or provenance asset | Not yet: `release.yaml` attests build provenance, but in GitHub's attestation store, which this check does not read. It looks for `*.intoto.jsonl` / signature assets on the release, so it rises only once the provenance bundle is attached to the release (#154). Signing is #202 (`blocked`). |
| Token-Permissions | 10 | workflow tokens follow least privilege | |
| Vulnerabilities | 10 | 0 open vulnerabilities | |

## Floor

The baseline above is the floor: a change that would lower the published score below it says why in its pull
request, and so does a change that lowers any single check. Once scorecard.dev accepts the first publish, compare its
number with 7.0 and update this table if they differ. There is no automated
enforcement; the workflow publishes the score but does not compare it with a threshold, and the alerts it raises
are tracked as issues by the security-alerts workflow. Re-measure after each release, since the score depends on
the day's repository state (for example the share of recent changesets that were reviewed).
