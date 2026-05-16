# Economy Design — ToyBox Blasters

**Version:** 1.0 (Task 006, indexed Task 010)  
**Status:** Locked for Phase 1 planning  
**Config:** `EconomyPhilosophyConfig` — **ToyBox Blasters → Product → Create Economy Philosophy Config**  
**Code defaults:** `EconomyPhilosophyDefaults.cs` (keep in sync)

## See also

- [MONETIZATION_STRATEGY.md](./MONETIZATION_STRATEGY.md) — ads, IAP, KPIs (Task 007)
- [CORE_GAMEPLAY_LOOP.md](./CORE_GAMEPLAY_LOOP.md) — coin fail rule (50%), session timing
- [RELEASE_SCOPE.md](./RELEASE_SCOPE.md) — MVP coins-only; gems soft launch+
- [AUDIENCE_AND_PERSONAS.md](./AUDIENCE_AND_PERSONAS.md) — monetization tolerance

> **Alias:** [ECONOMY_PHILOSOPHY.md](./ECONOMY_PHILOSOPHY.md) redirects here for legacy paths and code comments.

---

## Philosophy summary

Hybrid-casual **general-audience** economy: **coins** drive permanent meta power in **2–4 min** runs; **gems** and **Bedroom Tokens** are optional monetization/LiveOps layers (documented in V1, gameplay **coins-only in MVP**). No pay-to-win power bundles. Tuning via Firebase Remote Config; sinks before new sources; anti-inflation curves.

---

## Currencies

| Currency | Kind | MVP | Role |
|----------|------|-----|------|
| **Coins** | Soft | Yes | Meta upgrades (damage, fire rate, starting squad) |
| **Gems** | Premium | Soft launch+ | Cosmetics, convenience — not required to progress V1 |
| **Bedroom Tokens** | Event | Production | LiveOps seasonal shop; expires end of event |

Full rows: `EconomyPhilosophyConfig` → currencies list.

---

## Coin sources & sinks (summary)

**Sources (MVP+):** level complete, obstacle breaks, enemy kills, boss bonus; soft launch adds daily login, rewarded 2× end-of-run, achievements.

**Sinks (MVP):** upgrade damage, fire rate, starting squad; production adds gate reroll, continue run.

**Tuning:** all numeric values TBD in ScriptableObjects / Remote Config — see config asset, not duplicated here.

---

## Gem & event flows

Documented in config (`gem_source_*`, `gem_sink_*`, `event_*`). Gems never sole power progression in V1.

---

## Ad reward policy

| Rule | Value |
|------|--------|
| Rewarded 2× coins | +50–100% of run total; diminishing returns same day |
| Rewarded daily cap | 5–8 (Remote Config) |
| Interstitials | **Between runs only** — never mid-combat or boss patterns |

---

## Anti-inflation principles

1. Escalating coin costs per meta upgrade level (Remote Config caps).
2. Diminishing returns on repeat rewarded 2× same day.
3. Remote Config hard max clamps on earn rates and IAP grants.
4. **Sink before source** — new coin source ships with matching sink same release train.
5. Event tokens **burn** at event end (optional reduced coin conversion).

---

## Validation

**ToyBox Blasters → Validate Economy Philosophy** (after creating config asset).
