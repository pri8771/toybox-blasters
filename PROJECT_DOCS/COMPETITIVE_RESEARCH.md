# Competitive Research — ToyBox Blasters

**Task:** 004 — Competitive Research (Phase 1)  
**Version:** 1.0  
**Config asset:** `Assets/_ToyBoxBlasters/ScriptableObjects/Config/CompetitiveResearchConfig.asset`  
**Code defaults:** `CompetitiveResearchDefaults.cs` (keep in sync with this doc)

**Sources:** Industry observation and public store listings (Mob Control, Archero, Survivor.io, Count Masters, Join Clash, Last War, hybrid-casual monetization norms). No live web scrape required for Phase 1.

**Related:** [PRD.md](./PRD.md) §5 · [RELEASE_SCOPE.md](./RELEASE_SCOPE.md) · [TECH_DECISIONS.md](./TECH_DECISIONS.md) TD-014–TD-017

---

## Executive summary

ToyBox Blasters sits in the **hybrid-casual squad shooter runner** space: forward auto-run, **+/- gates**, growing squad, **auto-fire**, numbered obstacles, short boss, coin meta. Competitors cluster into **crowd army vs castle** (Mob Control), **room roguelite shooters** (Archero), **horde survival** (Survivor.io), **gate math runners** (Count Masters, Join Clash), and **squad-growth hybrids** (Last War–style). Category weaknesses—shallow combat, ad fatigue, sameness, unclear meta, low-end performance—are opportunities for **toy-room theme**, **readable combat**, **risk gates**, **numbered obstacles**, and **clear coin meta** (see PRD §5).

---

## Subtask 1 — Mob Control (Voodoo): crowd multiplier, gates, army vs castle

| Aspect | Observation |
|--------|-------------|
| **Core loop** | Run forward, pass gates that multiply or trade army size, clash army vs enemy castle/tower. |
| **Gates** | Binary or numeric choices; branches feel like “invest size now vs later.” |
| **Strengths** | Instant readability of crowd scale; satisfying finale crush; low tutorial cost. |
| **Weaknesses** | Abstract stick/capsule armies; minimal shooting skill; high genre sameness. |
| **ToyBox takeaway** | Keep **gate clarity** and **finale payoff**; replace abstract crowd with **toy squad + projectiles**. |

---

## Subtask 2 — Archero-style: room roguelite shooter, permanent gear meta

| Aspect | Observation |
|--------|-------------|
| **Core loop** | Clear rooms, pick perks, dodge patterns, exit to next room; permanent gear between runs. |
| **Meta** | Equipment tiers, talents, energy—deep retention for mid-core players. |
| **Strengths** | Skill expression; build variety; proven long-term monetization. |
| **Weaknesses** | Not a forward runner; sessions can exceed hybrid-casual 2–4 min target; hero-centric not squad. |
| **ToyBox takeaway** | Borrow **permanent stat toys** clarity, not room-by-room structure for MVP. |

---

## Subtask 3 — Survivor.io-style: horde survival, in-run level-ups, escalation

| Aspect | Observation |
|--------|-------------|
| **Core loop** | Survive waves, collect XP gems, level up weapons/skills in-run, escalating density. |
| **Strengths** | Strong “one more upgrade” dopamine; weapon evolution reads well on mobile. |
| **Weaknesses** | Top-down arena vs lane runner; long sessions; weak gate/obstacle teaching. |
| **ToyBox takeaway** | Use **in-run gate upgrades** instead of full roguelite perk trees for Phase 1. |

---

## Subtask 4 — Runner gate games: Count Masters, Join Clash, gate +/- math

| Aspect | Observation |
|--------|-------------|
| **Core loop** | Auto-forward, steer through **+N / −N / ×N** gates, stack units, fight boss or enemy stack. |
| **Strengths** | Fastest genre hook; UA creatives mirror gate math literally. |
| **Weaknesses** | Often no real shooting; obstacles are passive; boss is stat check. |
| **ToyBox takeaway** | Keep **+/- gates** but add **numbered obstacles** and **squad DPS** as depth. |

---

## Subtask 5 — Squad-growth games: crowd runners with shooting (Last War style hybrids)

| Aspect | Observation |
|--------|-------------|
| **Core loop** | Grow squad or army while shooting or auto-attacking; meta layers (base, heroes, timers). |
| **Strengths** | Bridges casual runner with mid-core spend; high LTV when meta clicks. |
| **Weaknesses** | UI and session length bloat; paywalls obscure the casual loop; not ideal MVP surface. |
| **ToyBox takeaway** | **Squad shooter runner** for MVP; defer 4X/base meta to post-launch (see RELEASE_SCOPE). |

---

## Subtask 6 — Hybrid-casual monetization

| Pattern | Typical use | ToyBox phase |
|---------|-------------|--------------|
| **Interstitial cadence** | After fail, level complete, or session exit (every 2–3 attempts) | Soft launch: interface + placeholder; tune via Remote Config |
| **Rewarded opt-in** | Revive, 2× coins, bonus gate roll | Production: after core loop proven |
| **Battle pass** | Seasonal cosmetics + currency | Post-launch roadmap (FEATURE_BACKLOG) |
| **No-ads IAP** | One-time remove interstitials | Global launch |
| **Starter packs** | Time-limited value bundles | Global launch; avoid MVP clutter |

**Risk:** Showing ads before the toy-room hook lands causes ad fatigue and bad reviews.

---

## Subtask 7 — Ad creatives

| Pattern | Notes |
|---------|--------|
| **Hyperbolic gate math** | +999, rainbow gates—high CTR, rating risk if gameplay underdelivers. |
| **Before/after squad** | Visual scale comparison at lane end. |
| **Fail-state humor** | Character ragdoll, tiny squad vs giant boss. |
| **ToyBox guidance** | Creatives should show **bedroom floor**, **toy squad VFX**, and **real gate tradeoffs** without false power levels. |

---

## Subtask 8 — Competitor weaknesses (opportunities)

| Weakness | Opportunity for ToyBox |
|----------|-------------------------|
| Shallow combat | Numbered obstacles + visible projectiles + hit reactions |
| Ad fatigue | Reward fun first; delay interstitials until soft launch |
| Sameness | Cohesive **toy-room** diorama and Dust Bunny boss personality |
| Unclear meta | Coins → 3 clear permanent upgrades in MVP |
| Low-end performance | URP discipline, pooled VFX, limit squad draw calls |

---

## Subtask 9 — Visual opportunities

1. **Cohesive toy-room diorama** — rug, floorboards, furniture legs, under-bed shadows.  
2. **Readable portrait squad VFX** — muzzle flashes, impact sparks, squad count UI.  
3. **Boss personality** — Dust Bunny King: telegraphed jumps, fluff VFX, playful not scary.  
4. **Signature obstacles** — numbered cardboard boxes aligned with placeholder pipeline.  
5. **Gate readability** — color + icon for positive vs negative tradeoffs.

---

## Subtask 10 — ToyBox Blasters differentiators (PRD §5)

| # | PRD §5 | Competitive angle |
|---|--------|-------------------|
| 1 | Toy-room fantasy | vs abstract stick crowds (Mob Control, Count Masters) |
| 2 | Squad shooter readability | vs gate-only runners with no shooting |
| 3 | Risk gates (+ and −) | vs only positive multiplication gates |
| 4 | Numbered obstacles | vs passive walls or pure stat gates |
| 5 | Boss at hybrid-casual pace | vs long horde sessions (Survivor.io) or room chains (Archero) |
| 6 | Meta loop clarity | vs opaque multi-currency hybrids (Last War) |

---

## COMPETITIVE_MATRIX

| Name | Category | Strengths (summary) | Weaknesses (summary) | Monetization (summary) | ToyBox response |
|------|----------|---------------------|----------------------|------------------------|-----------------|
| Mob Control | Crowd army vs castle | Crowd scale, gate branches, finale | Abstract, shallow shoot | Heavy interstitials, IAP | Toy squad + shoot + gates |
| Archero 2 | Room roguelite | Skill rooms, gear meta | Not runner; long sessions | Gacha, pass, rewarded | Coin stat toys only in MVP |
| Survivor.io | Horde survival | In-run upgrades, escalation | Top-down, long sessions | Revive rewarded, pass | Gates + short levels |
| Count Masters | Gate math runner | +/- math readability | No shooting, weak boss | Interstitial + rewarded | Add obstacles + boss |
| Join Clash 3D | Gate math runner | Stack + boss beat | Stat check combat | Heavy ads, no-ads IAP | Shooting + numbered HP |
| Last War (hybrid) | Squad growth shooter | Squad + meta depth | Complex, long sessions | Packs, pass, rewarded | Stay hybrid-casual lean |
| Genre norms | Monetization | Proven IAP/ad stack | Fatigue if too early | See subtask 6 | Phase per RELEASE_SCOPE |
| UA patterns | Ad creative | High CTR hooks | Misleading = bad reviews | N/A | Honest toy-room creatives |
| Genre aggregate | Weaknesses | Sets player expectations | Shallow, samey, perf | N/A | Theme + clarity + perf |
| Visual lane | Opportunity | — | Gray crowds common | N/A | Bedroom diorama + VFX |
| **ToyBox Blasters** | **Differentiator** | **PRD §5 six pillars** | **Must prove 30s fun** | **MVP none → soft ads** | **Ship vertical slice** |

---

## Review checklist (Task 004)

| Subtask | Pass |
|---------|------|
| 1 Mob Control | Pass |
| 2 Archero-style | Pass |
| 3 Survivor.io-style | Pass |
| 4 Runner gate games | Pass |
| 5 Squad-growth hybrids | Pass |
| 6 Hybrid-casual monetization | Pass |
| 7 Ad creatives | Pass |
| 8 Competitor weaknesses | Pass |
| 9 Visual opportunities | Pass |
| 10 ToyBox differentiators | Pass |

---

## Next steps

- **Task 005** (if scheduled): Economy / monetization design doc + config, or proceed to **Phase 2 first playable** per RELEASE_SCOPE (`FirstPlayablePrototypeGoal`).
- Wire competitive insights into gate/obstacle tuning ScriptableObjects when gameplay lands.
