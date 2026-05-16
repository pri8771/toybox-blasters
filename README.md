# ToyBox Blasters

[![Unity](https://img.shields.io/badge/Unity-2022.3%20LTS-000000?logo=unity)](https://unity.com/releases/editor/whats-new/2022.3.0)
[![Platform](https://img.shields.io/badge/Platform-iOS%20%7C%20Android-blue)]()
[![License](https://img.shields.io/badge/License-TBD-lightgrey)]()

Unity hybrid-casual squad shooter runner (iOS / Android, portrait).

## Clone

```bash
git clone https://github.com/pri8771/toybox-blasters.git
cd toybox-blasters
git checkout dev   # integration branch; use feature/* for work
```

See [PROJECT_DOCS/GITHUB_SETUP.md](PROJECT_DOCS/GITHUB_SETUP.md) and [BRANCHING.md](PROJECT_DOCS/BRANCHING.md).

## Quick start

1. Open this folder in **Unity 2022.3 LTS** (or newer 2022.3.x).
2. Run **ToyBox Blasters → Setup Placeholder Art** once.
3. Placeholder prefabs and `PlaceholderArtRegistry` are generated under `Assets/_ToyBoxBlasters/`.
4. Create product configs via menus below (once per machine).

Canonical placeholder sources: `Assets/PlaceholderPack/` (same layout as prompt `/ASSETS`). See `Assets/PlaceholderPack/UnityImportNotes/unity_asset_import_notes.md`.

## Documentation index

**→ [PROJECT_DOCS/README.md](PROJECT_DOCS/README.md)** — master table of all docs, owners, task IDs, Phase 1 status.

Key docs: [PRD](PROJECT_DOCS/PRD.md) · [Release scope](PROJECT_DOCS/RELEASE_SCOPE.md) · [Release checklist](PROJECT_DOCS/RELEASE_CHECKLIST.md) · [Changelog](PROJECT_DOCS/CHANGELOG.md) · [GitHub setup](PROJECT_DOCS/GITHUB_SETUP.md) · [Branching](PROJECT_DOCS/BRANCHING.md) · [Release tags](PROJECT_DOCS/RELEASE_TAGS.md)

## Unity version

| Item | Value |
|------|--------|
| Engine | Unity **2022.3 LTS** |
| Orientation | Portrait (primary) |
| Platforms | iOS 14+, Android API 24+ (export TBD) |

## Editor menus

| Menu | Purpose |
|------|---------|
| **ToyBox Blasters → Setup Placeholder Art** | Import/generate placeholder prefabs |
| **ToyBox Blasters → Validate Game Concept** | Task 001 product lock |
| **ToyBox Blasters → Product → Create / Validate …** | Release scope, audience, competitive research, core loop, economy, monetization, art direction |
| **ToyBox Blasters → Documentation → Validate Documentation System** | Task 010 — all required docs on disk |
| **ToyBox Blasters → Documentation → Create Missing Doc Stubs** | Scaffold missing markdown files |
| **ToyBox Blasters → Project → Validate GitHub Setup** | Task 012 — `.gitignore` + `.github/` templates |

## Branch strategy

| Branch | Role |
|--------|------|
| `main` | Release-ready; semver tags ([RELEASE_TAGS](PROJECT_DOCS/RELEASE_TAGS.md)) |
| `dev` | Integration — merge feature PRs here |
| `feature/*` | Task or feature work |
| `hotfix/*` | Urgent production fixes |

## Phase status

| Phase | Status |
|-------|--------|
| **Phase 1** (Tasks 001–010) | **Complete** — product & doc foundation |
| **Phase 2** | In progress — Task 012 GitHub setup **done**; Task 013 folder structure **next** |

## Product (Task 001)

- **Name:** ToyBox Blasters  
- **Genre:** Hybrid-casual squad shooter runner  
- **World 1:** Bedroom Floor  
- Details: `PROJECT_DOCS/PRD.md`

## Cursor / agent

- `00_MASTER/000_MASTER_CURSOR_INSTRUCTIONS.md` — non-negotiable rules  
- Start doc navigation at `PROJECT_DOCS/README.md`
- Contributing: [CONTRIBUTING.md](CONTRIBUTING.md) · GitHub templates: [.github/](.github/README.md)
