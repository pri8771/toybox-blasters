# Tech Decisions — ToyBox Blasters

## TD-001 — Placeholder art source of truth

**Decision:** Canonical SVGs live in `Assets/PlaceholderPack/` (mirrors prompt `/ASSETS` layout). Unity working copies go to `Assets/_ToyBoxBlasters/Art/SourceSVG/` via **Setup Placeholder Art**.

**Why:** On case-insensitive filesystems (default macOS), Unity `Assets/` and root `ASSETS/` are the same folder. Nesting the pack under `Assets/PlaceholderPack/` avoids collisions while keeping zip parity.

**Linux / CI:** Optional symlink `ASSETS` → `Assets/PlaceholderPack` for prompt-compatible paths.

## TD-002 — SVG import strategy

**Decision:** Prefer `com.unity.vectorgraphics` (listed in `Packages/manifest.json`). If import does not yield sprites for **all** entries, fall back to **primitive prefabs** with materials tinted per `art_bible_placeholder.md`.

**Why:** Gameplay must not block on package install failures or preview-package quirks; primitives always work.

**Alternatives considered:**
- Manual PNG export only — rejected as default (extra toolchain); documented as optional in `ASSETS/UnityImportNotes/unity_asset_import_notes.md`.

## TD-003 — Runtime resolution

**Decision:** `PlaceholderArtId` enum + `PlaceholderArtRegistry` ScriptableObject + `IPlaceholderArtProvider`. Prefab names are stable (`PFB_*_Placeholder`); `PlaceholderVisualTag` marks instances for future swap tooling.

**Why:** Replace final art without rewiring gameplay systems.

## TD-004 — UI placeholder location

**Decision:** UI reference prefabs under `Assets/_ToyBoxBlasters/UI/Prefabs/Placeholders/` (not mixed with world art).

**Why:** Clear separation for future uGUI/UIToolkit skinning.

## TD-006 — macOS `Assets` vs `ASSETS` collision

**Decision:** Do not rely on a separate root-level `ASSETS/` folder on case-insensitive volumes. Use `Assets/PlaceholderPack/` instead.

**Why:** Prevents Unity scripts and SVG sources from overwriting each other (same directory on APFS default).

## TD-007 — Product identity storage (Task 001)

**Decision:** Lock game concept in `PROJECT_DOCS/PRD.md` and `GameConceptConfig` ScriptableObject (`Assets/_ToyBoxBlasters/ScriptableObjects/Config/`). Code defaults live in `GameConceptDefaults` and must stay in sync with PRD.

**Why:** Designers can inspect pitch/fantasy in Editor; engineers validate via `GameConceptValidator` and CI-friendly checks later.

## TD-008 — Folder layout (Scripts / ScriptableObjects / Prefabs)

**Decision:** New work under `Scripts/`, `ScriptableObjects/`, `Prefabs/`. Existing placeholder pipeline stays under `Runtime/Art/` and `Art/` until a dedicated migration task.

**Why:** Matches phase prompts without breaking the asset setup menu or asmdef references.

## TD-009 — Firebase as default backend

**Decision:** Prefer Firebase for auth, cloud data, remote config, and analytics. Expose `IBackendPreference` / future service interfaces; no credentials in repo.

**Why:** Master project rules; allows mock implementations for offline dev.

## TD-010 — Release scope storage (Task 002)

**Decision:** MVP / soft launch / production scope lives in `PROJECT_DOCS/RELEASE_SCOPE.md` and `ReleaseScopeConfig` with `FeatureScopeEntry` rows (id, priority P0–P2, phase, mustHave, dependencies).

**Why:** Single validated source for planning, Editor inspection, and future CI; mirrors Task 001 `GameConceptConfig` pattern.

**Validation:** `ReleaseScopeValidator` checks summaries, minimum must-have counts per phase, dependency integrity, and circular dependency absence.

## TD-012 — Target audience lock (Task 003)

**Decision:** Lock audience segments, session lengths, monetization tolerance, motivation loops, and four personas in `PROJECT_DOCS/AUDIENCE_AND_PERSONAS.md` and `TargetAudienceConfig` (`AudiencePersonaDefaults` in code).

**Why:** Monetization, onboarding, and live-ops hooks must align to real player types before Phase 2 gameplay; validator prevents drift from PRD.

**Alternatives considered:**
- Personas docs-only without ScriptableObject — rejected; Task 001 pattern requires Editor-inspectable config + CI-friendly validation.

## TD-013 — General audience vs child-directed (Task 003)

**Decision:** Position as **general audience** (E10+/PEGI 3+ *style*), **not** child-directed (COPPA-primary). Toy visuals are family-friendly; mechanics and hybrid monetization target broad mobile casual adults.

**Why:** Rewarded ads + IAP cosmetic/convenience model fits general mobile F2P; avoids COPPA-only funnels and under-13 data minimization as the primary product constraint.

**Implications:** No chat V1; standard store privacy disclosures; interstitials deferred or capped until post-MVP; parents/teens are secondary reach, not regulatory core.

## TD-005 — Squad vs hero art

**Decision:** Squad reuses `hero_chibi_placeholder.svg` with a smaller primitive scale / separate prefab `PFB_SquadMember_Placeholder`.

**Why:** Same visual language; distinct prefab for squad spacing VFX later.

## TD-014 — Competitive research storage (Task 004)

**Decision:** Store competitor matrix in `PROJECT_DOCS/COMPETITIVE_RESEARCH.md` and `CompetitiveResearchConfig` ScriptableObject. Defaults in `CompetitiveResearchDefaults`; rows as `CompetitorEntry` with `CompetitorCategory` enum mapping to subtasks 1–10.

**Why:** Designers read the doc; engineers and CI validate structured rows via `CompetitiveResearchValidator`.

## TD-015 — Competitor taxonomy (Task 004)

**Decision:** Use `CompetitorCategory` enum (crowd army, roguelite room, horde survival, gate math runner, squad hybrid, monetization norms, ad creative, genre weaknesses, visual opportunity, ToyBox differentiator) instead of free-form tags.

**Why:** Ensures all ten Phase 1 research subtasks are represented in validation.

## TD-016 — Differentiator traceability (Task 004)

**Decision:** `ToyBoxDifferentiators` on config must align with **PRD §5** six bullets; validator requires ≥6 entries and a `ToyBox Blasters` competitor row.

**Why:** Prevents competitive research drift from locked product identity (Task 001).

## TD-017 — Monetization phasing vs competitors (Task 004)

**Decision:** MVP has no ads (per RELEASE_SCOPE); competitive monetization patterns are documented now but implemented soft-launch (interstitial interface) and global (rewarded, no-ads IAP) only.

**Why:** Avoid ad fatigue before core toy-room hook is proven (competitive weakness #8).

## TD-019 — GitHub repository & branching (Task 012)

**Decision:** Use `main` as protected release branch, `dev` for integration, `feature/*` and `hotfix/*` for short-lived work. Document remote setup in `PROJECT_DOCS/GITHUB_SETUP.md`; issue/PR templates under `.github/`. Semver tags per `RELEASE_TAGS.md` (`v0.1.0-mvp`, `v0.2.0-softlaunch`, `v1.0.0`).

**Why:** Phase 2 needs reproducible collaboration, PR review, and milestone tagging before CI and gameplay vertical slice land.

**Rules:** Never force-push `main`; never commit `Library/`, `UserSettings/`, or Firebase secret files (enforced in root `.gitignore`).

**Validation:** **ToyBox Blasters → Project → Validate GitHub Setup** checks `.gitignore` and template files.

## TD-018 — Core gameplay loop storage (Task 005)

**Decision:** Ten loop layers live in `PROJECT_DOCS/CORE_GAMEPLAY_LOOP.md` (mermaid + review table) and `CoreGameplayLoopConfig` / `CoreGameplayLoopDefaults`. Fail rule: **squad wipe**; **50%** partial coins on fail; optional level timer deferred post-MVP.

**Why:** Single validated stack before Phase 2 vertical slice; `CoreGameplayLoopValidator` requires all `GameplayLoopType` enum values exactly once.

**MVP vs later:** Ad, cosmetic, and LiveOps use `LoopImplementationPhase.DesignedOnly` until soft launch / production per `RELEASE_SCOPE.md`.

## TD-020 — Art direction storage (Task 008)

**Decision:** Locked art direction in `PROJECT_DOCS/ART_DIRECTION.md` and `ArtDirectionConfig` (`ArtPaletteEntry`, `ArtRequirementEntry`). Quick hex ref in `art_bible_placeholder.md` with cross-link.

**Why:** Bedroom Floor production and Phase 2 prototype need validated scale, palette categories, checklist, and prefab ↔ SVG mapping without breaking `PlaceholderArtId`.

**Validation:** `ArtDirectionValidator` — summaries, head-height 2.5–3, ≥16 palette rows, all enum ids, `PFB_` prefix.

**Asmdef:** `ToyBoxBlasters.Scripts` references `ToyBoxBlasters.Runtime` for `PlaceholderArtId` in requirement rows.
