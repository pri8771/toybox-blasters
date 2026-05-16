# Product Requirements — ToyBox Blasters

**Version:** 1.2 (Tasks 001–003, indexed Task 010)  
**Status:** Locked for pre-production  
**Index:** [PROJECT_DOCS/README.md](./README.md)

## Document links

| Topic | Document |
|-------|----------|
| Scope & phases | [RELEASE_SCOPE.md](./RELEASE_SCOPE.md) |
| Audience | [AUDIENCE_AND_PERSONAS.md](./AUDIENCE_AND_PERSONAS.md) |
| Gameplay | [GAMEPLAY_DESIGN.md](./GAMEPLAY_DESIGN.md) · [CORE_GAMEPLAY_LOOP.md](./CORE_GAMEPLAY_LOOP.md) |
| Economy & monetization | [ECONOMY_DESIGN.md](./ECONOMY_DESIGN.md) · [MONETIZATION_STRATEGY.md](./MONETIZATION_STRATEGY.md) |
| Art | [ART_BIBLE.md](./ART_BIBLE.md) · [ART_DIRECTION.md](./ART_DIRECTION.md) |
| Tech | [TECH_DESIGN.md](./TECH_DESIGN.md) · [TECHNICAL_ARCHITECTURE.md](./TECHNICAL_ARCHITECTURE.md) |
| Ship | [RELEASE_CHECKLIST.md](./RELEASE_CHECKLIST.md) · [CHANGELOG.md](./CHANGELOG.md) |

## 1. Product identity

| Field | Value |
|-------|--------|
| **Final game name** | **ToyBox Blasters** |
| **Genre** | Hybrid-casual **squad shooter runner** |
| **Visual style** | Colorful **animated 3D toy / chibi** characters and props (see **`ART_DIRECTION.md`**) |
| **Target platforms** | **iOS** and **Android** (portrait primary) |
| **Engine** | **Unity** (2022.3 LTS baseline) |
| **Backend preference** | **Firebase** (Auth, Firestore/RTDB, Remote Config, Analytics, Cloud Functions as needed) |

## 2. One-sentence pitch

**Run a growing squad of chibi toy blasters through a giant bedroom, shoot goofy intruders, smash numbered cardboard obstacles, and defeat a dust-bunny boss to earn coins for permanent upgrades.**

## 3. Core player fantasy

You are the **captain of a toy squad** charging across a child’s bedroom floor. Drag to steer, pass **+/- gates** to grow or trade power, **auto-fire** as your squad swells, break **numbered obstacles** that demand firepower, clear **slimey toy-mess enemies**, beat a **boss**, then spend **coins** on lasting power so the next run feels stronger.

## 4. First-world theme

**World 1 — Bedroom Floor**

- Setting: oversized bedroom / toy-room floor (rugs, floorboards, furniture legs as skyline).
- Tone: playful, safe, Saturday-morning toy commercial.
- Boss: **Dust Bunny King** (fluffy under-bed guardian).
- Props: cardboard boxes, building blocks, toy chests, scattered coins.

## 5. Differentiation (vs. crowd runners / generic shooters)

1. **Toy-room fantasy** — cohesive bedroom diorama instead of abstract stick crowds.
2. **Squad shooter readability** — visible projectiles and enemy hit reactions tuned for mobile portrait.
3. **Risk gates** — positive and negative upgrade gates in one lane (meaningful choices, not only +1).
4. **Numbered obstacles** — breakable HP blocks that teach squad DPS scaling.
5. **Boss spectacle at hybrid-casual pace** — short levels, chunky boss telegraphs, 2–4 minute sessions.
6. **Meta loop clarity** — coins fund permanent stat toys (damage, fire rate, starting squad) with Firebase-ready live ops hooks.

## 6. Out of scope (Task 001)

- Playable level/scene (Phase 2+).
- Live Firebase project wiring (interfaces and docs only).
- Final art, audio, monetization SDK integration.

## 7. Target audience (Task 003)

See **[AUDIENCE_AND_PERSONAS.md](./AUDIENCE_AND_PERSONAS.md)** for full personas and review table.

| Topic | Locked value |
|-------|----------------|
| **Primary segment** | Mobile hybrid-casual **18–34**; secondary teens 13–17 and parents |
| **Classification** | **General audience** (E10+/PEGI 3+ style) — **not** child-directed / COPPA-primary |
| **Session length** | **2–4 min** per run; **8–15 min** daily for engaged players |
| **Monetization tolerance** | Hybrid, low pressure MVP: optional rewarded ads; cosmetic/convenience IAP; no PvP / no pay-to-win power in V1 |
| **Personas** | Casual Casey, Progression Pat, Collector Chris, Ad-watcher Avery |

**Unity config:** `TargetAudienceConfig.asset` via **ToyBox Blasters → Product → Create Target Audience Config**.

## 8. Success metrics (future)

- D1 retention target TBD after soft launch planning.
- Session length target: **2–4 minutes** per run (aligned with Task 003).

## 8. Release scope (Task 002)

MVP, soft launch, production/global scope, feature priorities, dependencies, V1 exclusions, and success criteria are defined in:

- **`PROJECT_DOCS/RELEASE_SCOPE.md`** (primary)
- **`ReleaseScopeConfig`** ScriptableObject (`Assets/_ToyBoxBlasters/ScriptableObjects/Config/`)

Validate in Unity: **ToyBox Blasters → Validate Release Scope**.

## 9. Monetization strategy (Task 007)

Hybrid monetization (rewarded opt-in, between-run interstitials, cosmetic/convenience IAP, no pay-to-win) is defined in:

- **`PROJECT_DOCS/MONETIZATION_STRATEGY.md`** (primary)
- **`MonetizationStrategyConfig`** ScriptableObject (`Assets/_ToyBoxBlasters/ScriptableObjects/Config/`)

Validate in Unity: **ToyBox Blasters → Validate Monetization Strategy**. Live ad/IAP SDK integration is Phase 2 / soft launch+.
