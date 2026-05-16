# Asset Setup — Task 001

## Goal

Establish consistent, replaceable placeholder visuals from `/ASSETS` for all prototype gameplay and UI references.

## Repo layout

```
Assets/PlaceholderPack/   # Canonical pack (prompt: /ASSETS)
  SVG/
  DesignSpecs/
  UnityImportNotes/
Assets/_ToyBoxBlasters/
  Art/          # World placeholders + registry
  UI/           # UI placeholder prefabs
```

## Unity workflow

1. Open project in Unity 2022.3+.
2. **ToyBox Blasters → Setup Placeholder Art**
3. Confirm `Assets/_ToyBoxBlasters/Art/Config/PlaceholderArtRegistry.asset` lists all `PlaceholderArtId` entries.

## Prefab naming

| ID | Prefab |
|----|--------|
| HeroChibi | `PFB_HeroChibi_Placeholder` |
| SquadMember | `PFB_SquadMember_Placeholder` |
| SlimeEnemy | `PFB_SlimeEnemy_Placeholder` |
| DustBunnyBoss | `PFB_DustBunnyBoss_Placeholder` |
| GatePositive | `PFB_GatePositive_Placeholder` |
| GateNegative | `PFB_GateNegative_Placeholder` |
| CardboardBox | `PFB_CardboardBox_Placeholder` |
| CoinPickup | `PFB_CoinPickup_Placeholder` |
| GemPickup | `PFB_GemPickup_Placeholder` |
| UiButtonPrimary | `PFB_UI_ButtonPrimary_Placeholder` |
| UiPanelRounded | `PFB_UI_PanelRounded_Placeholder` |

## Acceptance checks

- [ ] Menu **Setup Placeholder Art** completes without errors
- [ ] All 11 prefabs exist under Art/UI Prefabs/Placeholders
- [ ] Registry asset has non-null prefab per enum value
- [ ] Colors match `Assets/PlaceholderPack/DesignSpecs/art_bible_placeholder.md`
- [ ] Gameplay code references `IPlaceholderArtProvider` only (no direct prefab paths)
- [ ] Re-running setup is idempotent (safe to run again)

## Replace final art later

Swap mesh/sprite/material on the same prefab names; keep `PlaceholderArtId` and registry keys unchanged.
