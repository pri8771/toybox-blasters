# Analytics Specification — ToyBox Blasters

**Version:** 1.0 (Task 010)  
**Status:** Event taxonomy locked for implementation; **no SDK wiring in MVP**  
**Implementation:** `IAnalyticsService` → Firebase Analytics (soft launch+)

## See also

- [TECH_DESIGN.md](./TECH_DESIGN.md) — Firebase Analytics row
- [MONETIZATION_STRATEGY.md](./MONETIZATION_STRATEGY.md) — ad/IAP events
- [CORE_GAMEPLAY_LOOP.md](./CORE_GAMEPLAY_LOOP.md) — LiveOps funnel hooks
- [RELEASE_SCOPE.md](./RELEASE_SCOPE.md) — `firebase_analytics` feature (soft launch P0)

---

## Naming conventions

| Rule | Value |
|------|--------|
| Event names | `snake_case`, max 40 chars |
| Param names | `snake_case`, max 40 chars |
| String param values | max 100 chars |
| User properties | set once per session where noted |

Prefix economy Remote Config keys with `economy_` (see `CurrencyDefinitionEntry`).

---

## Core funnel events

| Event | When | Parameters |
|-------|------|------------|
| `session_start` | App foreground | `session_id`, `build_version`, `platform` |
| `session_end` | App background | `session_id`, `duration_sec` |
| `level_start` | Run begins | `level_id`, `world_id`, `attempt_index` |
| `level_complete` | Boss/level cleared | `level_id`, `duration_sec`, `coins_earned` |
| `level_fail` | Squad wiped | `level_id`, `fail_reason`, `coins_earned`, `partial_coins_banked` |
| `meta_upgrade_purchase` | Coin sink | `upgrade_id`, `level_after`, `coin_cost` |

---

## Gameplay events

| Event | When | Parameters |
|-------|------|------------|
| `gate_pass` | Squad crosses gate | `gate_id`, `gate_polarity`, `squad_delta` |
| `obstacle_destroyed` | Numbered box breaks | `obstacle_id`, `hp_remaining` |
| `enemy_killed` | Slime/wave kill | `enemy_type`, `level_id` |
| `boss_phase` | Boss state change | `boss_id`, `phase_index` |

---

## Monetization events

| Event | When | Parameters |
|-------|------|------------|
| `ad_request` | Ad load requested | `placement_id`, `ad_kind` |
| `ad_impression` | Ad shown | `placement_id`, `ad_kind`, `network` |
| `ad_reward_complete` | Rewarded grant | `placement_id`, `reward_type`, `reward_amount` |
| `iap_purchase` | Store success | `sku_id`, `price_usd`, `currency_code` |
| `iap_restore` | Restore tapped | `sku_count_restored` |

`placement_id` values align with `AdPlacementId` enum (`EndRun2xCoins`, etc.).

---

## LiveOps & Remote Config

| Event | When | Parameters |
|-------|------|------------|
| `remote_config_fetch` | RC success/fail | `status`, `fetch_time_ms` |
| `liveops_event_join` | Player enters event | `event_id`, `event_version` |
| `liveops_reward_claim` | Milestone claimed | `event_id`, `reward_id` |

---

## Firebase mapping

| Spec event | Firebase `logEvent` name | Notes |
|------------|--------------------------|--------|
| All above | Same `snake_case` name | Use `Parameter` API |
| `level_start` | `level_start` | Also log Firebase recommended `level` param if using GA4 level reporting |
| `iap_purchase` | `purchase` optional alias | Prefer custom `iap_purchase` + revenue params for hybrid-casual dashboards |

**User properties (examples):** `player_segment`, `days_since_install`, `meta_damage_level`, `ads_removed` (bool).

---

## Privacy & audience

General-audience product ([AUDIENCE_AND_PERSONAS.md](./AUDIENCE_AND_PERSONAS.md)); no child-directed data collection patterns. No PII in event params; use hashed or server-generated ids for `user_id` when Auth is live.

---

## Validation (Phase 2+)

- Debug menu: log events to console in dev builds
- Firebase DebugView on soft launch builds
- Event checklist in [RELEASE_CHECKLIST.md](./RELEASE_CHECKLIST.md) soft launch section
