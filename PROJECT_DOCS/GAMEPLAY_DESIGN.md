# Gameplay Design — ToyBox Blasters

**Version:** 1.1 (Tasks 001 + 005, indexed Task 010)  
**Index:** [README.md](./README.md)

Aligned with **Task 001** product lock. **Task 005** expands the full ten-layer loop stack in **[CORE_GAMEPLAY_LOOP.md](./CORE_GAMEPLAY_LOOP.md)** and `CoreGameplayLoopConfig`.

## Core loop (summary)

See **`PROJECT_DOCS/CORE_GAMEPLAY_LOOP.md`** for mermaid diagrams, fail rules, session timing, and review table.

1. **Run** forward automatically along a lane.
2. **Steer** left/right (drag).
3. **Interact** with +/- upgrade gates.
4. **Combat** — squad auto-shoots enemies.
5. **Obstacles** — shoot numbered cardboard until destroyed.
6. **Boss** — pattern-based dust bunny fight.
7. **Reward** — coins (gems optional soft launch+). Sources: level complete, kills, obstacles, boss — see **[ECONOMY_PHILOSOPHY.md](./ECONOMY_PHILOSOPHY.md)**.
8. **Meta** — spend coins on permanent upgrades (damage, fire rate, starting squad); retry. Gem/cosmetic sinks are post-V1 per economy doc.

**Failure (MVP):** squad wiped → fail screen → retry or home → **50%** partial coins retained.

## Controls

| Input | Action |
|-------|--------|
| Drag horizontal | Move squad across lane width |
| (Future) Tap | Active ability / pause menu |

## Squad rules (high level)

- Starting squad size from meta upgrade.
- Gates modify count, fire rate, or weapon toy type.
- Negative gates trade power for speed or currency — designer-tuned in ScriptableObjects.

## World 1 content sketch

Prefab names and art requirements: **`PROJECT_DOCS/ART_DIRECTION.md`** (Task 008) + `ArtDirectionConfig`.

| Element | Placeholder asset |
|---------|-------------------|
| Hero / squad | `PFB_HeroChibi_Placeholder`, `PFB_SquadMember_Placeholder` |
| Slime enemy | `PFB_SlimeEnemy_Placeholder` |
| Boss | `PFB_DustBunnyBoss_Placeholder` |
| Gates | `PFB_GatePositive_Placeholder`, `PFB_GateNegative_Placeholder` |
| Obstacle | `PFB_CardboardBox_Placeholder` |
| Pickups | `PFB_CoinPickup_Placeholder` |

## Economy (Task 006)

| Topic | Doc / config |
|-------|----------------|
| Currencies, sources/sinks, ads, IAP, anti-inflation | [ECONOMY_PHILOSOPHY.md](./ECONOMY_PHILOSOPHY.md) |
| Authoritative data | `EconomyPhilosophyConfig` + `EconomyPhilosophyDefaults` |
| MVP | **Coins only** in gameplay; gems / Bedroom Tokens documented for soft launch+ |

## Tuning philosophy

All numeric values in **ScriptableObjects** under `Assets/_ToyBoxBlasters/ScriptableObjects/` — never magic numbers in gameplay code.

## See also

- [CORE_GAMEPLAY_LOOP.md](./CORE_GAMEPLAY_LOOP.md) — mermaid stack, fail rules, session timing, review table
- [ECONOMY_DESIGN.md](./ECONOMY_DESIGN.md) — coins on fail (50%), currency phasing
- [RELEASE_SCOPE.md](./RELEASE_SCOPE.md) — first playable §9 Economy tuning uses Firebase **Remote Config** keys from `EconomyPhilosophyConfig` (e.g. `economy_coins_*`).
