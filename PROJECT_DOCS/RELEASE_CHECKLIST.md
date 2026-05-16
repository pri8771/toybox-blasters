# Release Checklist — ToyBox Blasters

**Version:** 1.0 (Task 010)  
**Scope reference:** [RELEASE_SCOPE.md](./RELEASE_SCOPE.md)  
**Changelog:** [CHANGELOG.md](./CHANGELOG.md)

---

## MVP gate (internal playable)

| # | Gate | Owner | Done |
|---|------|-------|------|
| 1 | First playable vertical slice per RELEASE_SCOPE §9 (runner, steer, 1 gate, 1 slime, 1 obstacle, lane end) | Engineering | ☐ |
| 2 | Squad autofire + numbered obstacle + fail/retry UI | Engineering | ☐ |
| 3 | Coins pickup + 3 meta upgrades (coins only) | Design / Eng | ☐ |
| 4 | Placeholder art on all MVP prefabs | Art | ☐ |
| 5 | No magic numbers — balance in ScriptableObjects | Engineering | ☐ |
| 6 | **Validate Game Concept**, **Release Scope**, **Core Gameplay Loop** pass | Engineering | ☐ |
| 7 | **Validate Documentation System** pass | Product | ☐ |
| 8 | `OPEN_BUGS.md` — no P0 open | QA | ☐ |
| 9 | Project compiles; playable after task merge | Engineering | ☐ |
| 10 | No secrets in repo / `.gitignore` verified | Engineering | ☐ |

---

## Soft launch gate

| # | Gate | Owner | Done |
|---|------|-------|------|
| 1 | 5–10 tuned levels (World 1) | Design | ☐ |
| 2 | Firebase Analytics + Remote Config integrated | Engineering | ☐ |
| 3 | Events per [ANALYTICS_SPEC.md](./ANALYTICS_SPEC.md) in DebugView | Data | ☐ |
| 4 | Crash reporting (Crashlytics or equivalent) | Engineering | ☐ |
| 5 | Ad **interface** + test placements; no mid-combat interstitials | Monetization | ☐ |
| 6 | Store test builds (TestFlight / internal testing) | Product | ☐ |
| 7 | Balancing pass documented in IMPLEMENTATION_LOG | Design | ☐ |
| 8 | Privacy policy + ad disclosure strings | Product / Legal | ☐ |

---

## Production / global gate

| # | Gate | Owner | Done |
|---|------|-------|------|
| 1 | 20+ levels or live content pipeline | Design | ☐ |
| 2 | IAP shop live (remove ads, gem packs, cosmetics — no P2W) | Monetization | ☐ |
| 3 | Rewarded ads live with frequency caps per MONETIZATION_STRATEGY | Monetization | ☐ |
| 4 | ASO assets + store listings | Product | ☐ |
| 5 | Localization EN + 1 | Product | ☐ |
| 6 | Production VFX/audio pass | Art / Audio | ☐ |
| 7 | Retention tuning + KPI review | Data | ☐ |
| 8 | LiveOps event template + Bedroom Tokens economy | Economy | ☐ |
| 9 | Full release checklist sign-off in CHANGELOG | Product | ☐ |

---

## Documentation gate (every release)

- [ ] `CHANGELOG.md` updated
- [ ] `IMPLEMENTATION_LOG.md` entry for ship task
- [ ] `FEATURE_BACKLOG.md` statuses current
- [ ] **Validate Documentation System** in Unity
