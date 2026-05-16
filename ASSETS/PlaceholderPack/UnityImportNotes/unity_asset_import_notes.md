# Unity Asset Import Notes — ToyBox Blasters

## Source of truth

Canonical pack: `Assets/PlaceholderPack/` (prompt `/ASSETS`; on Linux you may symlink `ASSETS` → this folder). Unity consumes copies under:

- `Assets/_ToyBoxBlasters/Art/SourceSVG/` — synced SVG sources
- `Assets/_ToyBoxBlasters/Art/Prefabs/Placeholders/` — generated prefabs
- `Assets/_ToyBoxBlasters/UI/Prefabs/Placeholders/` — UI-related prefabs

## Preferred: Unity Vector Graphics

1. Install **Vector Graphics** (`com.unity.vectorgraphics`) via Package Manager.
2. Run menu: **ToyBox Blasters → Setup Placeholder Art**.
3. Editor copies SVGs, sets Texture Type to **Sprite (2D and UI)** where applicable, and builds prefabs with `SpriteRenderer`.

## Fallback: Primitives + materials

If Vector Graphics is missing or import fails:

1. Same menu builds **primitive placeholder prefabs** (capsules, cubes, quads) tinted per `art_bible_placeholder.md`.
2. Gameplay must reference `PlaceholderArtRegistry` (ScriptableObject), not mesh paths directly.

## PNG conversion (optional manual path)

```bash
# Example with Inkscape (developer machine only)
inkscape ASSETS/SVG/Icons/coin.svg --export-filename=Assets/_ToyBoxBlasters/Art/Textures/coin.png -w 128 -h 128
```

Assign exported PNGs as Sprites and re-run **Regenerate Prefabs From Sprites** (future menu; use Setup for now).

## Naming

| Prefab | Purpose |
|--------|---------|
| `PFB_HeroChibi_Placeholder` | Player / squad |
| `PFB_SlimeEnemy_Placeholder` | Slime |
| `PFB_DustBunnyBoss_Placeholder` | Boss |
| `PFB_GatePositive_Placeholder` | Positive gate |
| `PFB_GateNegative_Placeholder` | Negative gate |
| `PFB_CardboardBox_Placeholder` | Obstacle |
| `PFB_CoinPickup_Placeholder` | World coin |
| `PFB_GemPickup_Placeholder` | World gem |
| `PFB_UI_ButtonPrimary_Placeholder` | UI button ref |
| `PFB_UI_PanelRounded_Placeholder` | UI panel ref |

## Do not block gameplay

All systems should resolve visuals through `IPlaceholderArtProvider` / `PlaceholderArtRegistry`. Missing art falls back to colored primitives automatically in dev builds.
