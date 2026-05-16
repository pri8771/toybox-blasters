# Release Tags — ToyBox Blasters

**Task 012** — Semantic versioning for milestones. Tags are created on `main` after release PRs merge.

## Tag format

```
v<MAJOR>.<MINOR>.<PATCH>[-<label>]
```

Examples: `v0.1.0-mvp`, `v0.2.0-softlaunch`, `v1.0.0`

## Planned milestones

| Tag | Phase | Scope (summary) |
|-----|-------|-----------------|
| `v0.1.0-mvp` | MVP | First shippable MVP per `RELEASE_SCOPE.md` — bedroom world, core loop, placeholder art |
| `v0.2.0-softlaunch` | Soft launch | 5–10 levels, Firebase analytics/RC, crash reporting, store test builds |
| `v1.0.0` | Production | Global launch — IAP, rewarded ads, 20+ levels, live ops hooks |

Pre-release internal builds may use `v0.0.x` or `v0.1.0-mvp-rc1` as needed; document in release notes.

## Creating a tag (local)

After `main` contains the release commit:

```bash
git checkout main
git pull origin main
git tag -a v0.1.0-mvp -m "MVP milestone — ToyBox Blasters"
git push origin v0.1.0-mvp
```

## GitHub Releases

1. **Releases → Draft a new release**
2. Choose the tag (or create from tag).
3. Attach build artifacts (`.ipa` / `.aab`) from CI when available — not stored in git.
4. Link `PROJECT_DOCS/RELEASE_SCOPE.md` success criteria in release notes.

## Version vs Unity

- **Git tags** = product milestones.
- **Unity** `PlayerSettings.bundleVersion` / `Application.version` should align with tag at ship time (configure in a later build task).

## Related

- [RELEASE_SCOPE.md](./RELEASE_SCOPE.md)
- [BRANCHING.md](./BRANCHING.md)
