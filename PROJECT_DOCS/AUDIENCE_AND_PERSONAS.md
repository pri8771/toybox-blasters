# Target Audience & Player Personas — ToyBox Blasters

**Task:** 003 — Define Target Audience and Player Personas (Phase 1 — Pre-Production)  
**Status:** Locked  
**Config asset:** `Assets/_ToyBoxBlasters/ScriptableObjects/Config/TargetAudienceConfig.asset` (create via Editor menu)  
**Code defaults:** `AudiencePersonaDefaults` — keep in sync with this document and `PRD.md`

---

## 1. Primary player segment

**Mobile hybrid-casual players aged 18–34** who enjoy short-session arcade runners with light strategy (upgrade gates, squad growth). They already play crowd runners, lane shooters, or idle-arcade titles and want a **toy-room fantasy** with readable portrait combat—not a hardcore tactical shooter.

**Secondary reach:** teens **13–17**; **parents** of younger players who co-play, approve installs, or share family tablets.

---

## 2. Age positioning

| Layer | Positioning |
|-------|-------------|
| **Core** | 18–34 — primary monetization and session design |
| **Accessible** | Teens 13–17 — same mechanics, family-safe tone |
| **Visual appeal** | Younger kids may enjoy toy aesthetic; not the regulatory target |
| **Content guardrails** | No chat, no dark themes, no gore; playful bedroom toy commercial tone |

---

## 3. General audience vs child-directed (locked)

| Decision | Value |
|----------|--------|
| **Classification** | **General audience** (E10+ / PEGI 3+ *style* positioning) |
| **NOT** | Child-directed (COPPA-only) product design |
| **Rationale** | Toy visuals attract kids, but **mechanics, session pacing, and monetization** target broad casual mobile adults. No COPPA-only funnels, no “kids-only” ad policies as primary compliance path. |
| **Implications** | Standard mobile ad/IAP disclosures; avoid designing solely around under-13 data collection; no social chat in V1. |

---

## 4. Session-length expectations

| Metric | Target |
|--------|--------|
| **Per run** | **2–4 minutes** (aligns with hybrid-casual bedroom level + boss) |
| **Daily (engaged player)** | **8–15 minutes** total across multiple runs |
| **Casual cadence** | 1–2 runs per micro-session (waiting in line) |
| **Progression cadence** | 3–5 runs when optimizing gates/meta |

---

## 5. Monetization tolerance (product-level)

**Model:** Hybrid casual — **low pressure in MVP**.

| Mechanism | V1 / MVP | Post soft-launch |
|-----------|----------|------------------|
| **Rewarded ads** | Optional — boosts, currency, revives | Core economy lever for Ad-watcher persona |
| **Interstitials** | Minimal / off in MVP | Between runs, capped frequency |
| **IAP** | Cosmetics + light convenience | No pay-to-win power; **no PvP in V1** |
| **Subscriptions** | Out of scope V1 | Evaluate after retention data |

**Tolerance summary:** Players accept rewarded ads when skip/reward is fast; cosmetic IAP for Collectors; convenience IAP at low tiers for Progression players; reject pay-to-win power and mid-run forced ads.

---

## 6. Player motivation loops

1. **Mastery** — Clear levels, readable combat feedback, gate choices that teach squad power.
2. **Collection** — Toy skins, trails, squad flair tied to bedroom theme.
3. **Progression** — Permanent upgrades (damage, fire rate, starting squad) funded by coins.
4. **Novelty** — New worlds (post-launch) beyond Bedroom Floor.
5. **Social proof** — Leaderboards / friend compare optional post-launch.

---

## 7. Player personas

### 7.1 Casual Casey (`casual_casey`)

| Field | Detail |
|-------|--------|
| **Profile** | Plays during micro-moments (queue, short break). Wants instant fun without grind. |
| **Goals** | Finish a fun level in under 4 minutes; feel squad grow; no session-to-session commitment |
| **Frustrations** | Long tutorials, forced daily login, confusing gates, slow ad skips |
| **Monetization behavior** | Rewarded ads only when reward obvious; ignores most IAP |
| **Monetization tolerance** | **Low** — tolerates ads if skip is fast |
| **Session pattern** | 1–2 runs per visit, several times per week; 2–4 min per run |

### 7.2 Progression Pat (`progression_pat`)

| Field | Detail |
|-------|--------|
| **Profile** | Optimizes gate routes and meta upgrades; tracks coins per run. |
| **Goals** | Maximize coins; optimal +/- gates; unlock permanent stat toys |
| **Frustrations** | Opaque gates, paywalls on core power, runs without meta growth |
| **Monetization behavior** | Light IAP (starter/convenience); rewarded ads for boost currency |
| **Monetization tolerance** | **Medium** — convenience IAP ok; rejects pay-to-win |
| **Session pattern** | 3–5 runs/day when engaged; 8–15 min daily; studies gate routes |

### 7.3 Collector Chris (`collector_chris`)

| Field | Detail |
|-------|--------|
| **Profile** | Motivated by toy skins, trails, squad flair; shares rare looks. |
| **Goals** | Unlock/show cosmetic sets; complete bedroom-themed collections |
| **Frustrations** | Pay-only exclusives with no earn path, cluttered shop, cheap-looking skins |
| **Monetization behavior** | Primary spend on cosmetic IAP; optional fair battle pass later |
| **Monetization tolerance** | **Medium-high (cosmetics only)** — no power purchases |
| **Session pattern** | Daily shop check-in; 1–3 runs to earn currency toward skins |

### 7.4 Ad-watcher Avery (`ad_watcher_avery`)

| Field | Detail |
|-------|--------|
| **Profile** | Treats rewarded ads as part of the economy. |
| **Goals** | Revive after boss fail; double coins; ad-funded chest spins |
| **Frustrations** | Unskippable mid-run ads, unclear rewards, too-frequent interstitials in MVP |
| **Monetization behavior** | High rewarded engagement; low IAP unless extreme value |
| **Monetization tolerance** | **High (rewarded)** / **Low (interstitial)** unless between runs |
| **Session pattern** | 2–4 runs with 1–2 rewarded ads per session; returns for daily ad bonuses |

---

## 8. Design implications (V1)

- **Onboarding:** &lt; 60s to first gate choice; skippable tips for Casey.
- **Meta UI:** Clear permanent upgrade tree for Pat; visible cosmetic preview for Chris.
- **Ads:** Rewarded placements with explicit outcomes; defer interstitials until post-MVP unless build flag on.
- **Store:** Cosmetic-first layout; no power bundles that dominate bedroom levels.
- **Compliance copy:** General audience labeling in store listings; privacy policy standard mobile (not COPPA-primary).

---

## 9. Task 003 review (hardening pass)

| # | Subtask | Result | Evidence |
|---|---------|--------|----------|
| 1 | Primary player segment | **PASS** | §1, `AudiencePersonaDefaults.PrimarySegment`, validator match |
| 2 | Casual player persona | **PASS** | §7.1, `casual_casey` in defaults + validator |
| 3 | Progression-focused persona | **PASS** | §7.2, `progression_pat` |
| 4 | Cosmetic collector persona | **PASS** | §7.3, `collector_chris` |
| 5 | Ad-watching persona | **PASS** | §7.4, `ad_watcher_avery` |
| 6 | Age positioning | **PASS** | §2, locked `AgePositioning` field |
| 7 | General vs child-directed | **PASS** | §3, `AudienceClassification.GeneralAudience` |
| 8 | Session-length expectations | **PASS** | §4, 2–4 / 8–15 min bounds in config |
| 9 | Monetization tolerance | **PASS** | §5, model + summary fields |
| 10 | Player motivation loops | **PASS** | §6, ≥4 loops in config |

**Review bugs fixed this session:** None (greenfield Task 003).  
**Open TODOs:** Task 002 Release Scope (if not yet done); Phase 2 runner prototype.  
**Next task:** Task 004 per phase plan, or Task 002 if still pending.

---

## 10. Cross-references

- [PRD.md](./PRD.md) — product identity, session length in success metrics
- [GAMEPLAY_DESIGN.md](./GAMEPLAY_DESIGN.md) — gate/squad loops serving Pat and Casey
- [TECH_DECISIONS.md](./TECH_DECISIONS.md) — TD-012, TD-013 audience locks
- `TargetAudienceConfig` / `TargetAudienceValidator` — Unity validation
