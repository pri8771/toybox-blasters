# Art Bible — ToyBox Blasters

**Version:** 1.0 (Task 008 + placeholder pack, indexed Task 010)  
**Status:** Locked for placeholder and World 1 planning

## See also (full detail — do not duplicate here)

| Topic | Document |
|-------|----------|
| Mood, proportions, VFX, world dressing | **[ART_DIRECTION.md](./ART_DIRECTION.md)** |
| Hex palette & SVG mapping | **[../Assets/PlaceholderPack/DesignSpecs/art_bible_placeholder.md](../Assets/PlaceholderPack/DesignSpecs/art_bible_placeholder.md)** |
| Unity config | `ArtDirectionConfig` — **ToyBox Blasters → Art → Create Art Direction Config** |
| Import / prefab pipeline | [ASSET_SETUP.md](./ASSET_SETUP.md) |

---

## Visual north star

Saturday-morning **toy commercial** on a **bedroom floor**: warm, safe, chunky chibi silhouettes, mobile-readable at portrait scale. Materials: plastic, felt, cardboard, plush — no gore or realistic grit.

---

## Palette quick reference

| Role | Hex |
|------|-----|
| Hero / squad | `#4FC3F7` |
| Hero accent | `#FFD54F` |
| Slime enemy | `#66BB6A` |
| Dust bunny boss | `#9E9E9E` / accent `#B39DDB` |
| Positive / negative gate | `#81C784` / `#EF5350` |
| Cardboard obstacle | `#A1887F` |
| Coin / gem | `#FFCA28` / `#AB47BC` |
| UI primary / panel | `#FF9800` / `#E3F2FD` |
| Outline | `#37474F` |

Full table and SVG file mapping: **art_bible_placeholder.md** (source of truth for hex).

---

## Shape & scale

- Rounded chunky silhouettes; thick outlines on UI.
- Hero ~1 unit; boss slightly larger for readability.
- Bedroom scale: props read as “furniture canyon” relative to squad.

---

## Placeholder replacement policy

Keep stable: `PFB_*_Placeholder` prefab names, `PlaceholderArtId` enum, registry keys. Swap meshes/sprites/materials only — see [ASSET_SETUP.md](./ASSET_SETUP.md).

---

## Production art handoff checklist

1. Match palette ±10% value shift max (`ArtDirectionConfig`).
2. Preserve prefab/registry IDs.
3. World 1 theme: Bedroom Floor per [PRD.md](./PRD.md).
