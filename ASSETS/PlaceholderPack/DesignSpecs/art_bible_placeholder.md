# ToyBox Blasters — Placeholder Art Bible

Early prototype visuals for the bedroom/toy-room first world. Replace with production art without changing prefab names or registry keys.

**Full art direction (Task 008):** `PROJECT_DOCS/ART_DIRECTION.md`  
**Runtime config:** `ArtDirectionConfig` via **ToyBox Blasters → Art → Create Art Direction Config**

## Palette (hex)

Core swatches below; extended primary/secondary/UI/feedback table in `ART_DIRECTION.md` §3 and `ArtDirectionConfig` palette.

| Role | Color | Hex |
|------|-------|-----|
| Hero / squad | Toy blue | `#4FC3F7` |
| Hero accent | Warm yellow | `#FFD54F` |
| Slime enemy | Slime green | `#66BB6A` |
| Dust bunny boss | Soft gray | `#9E9E9E` |
| Boss accent | Dust purple | `#B39DDB` |
| Positive gate | Mint green | `#81C784` |
| Negative gate | Coral red | `#EF5350` |
| Cardboard box | Kraft brown | `#A1887F` |
| Coin | Gold | `#FFCA28` |
| Gem | Amethyst | `#AB47BC` |
| Primary button | Play orange | `#FF9800` |
| UI panel | Soft panel blue | `#E3F2FD` |
| Outline / toy edge | Ink | `#37474F` |
| Floor wood | Floor wood | `#8D6E63` |
| Rug blush | Rug accent | `#F48FB1` |
| Damage flash | Hit feedback | `#FF7043` |
| Heal / shield | Buff VFX | `#4DD0E1` |
| Sky warm | Bedroom ceiling | `#FFF8E1` |
| HUD text | Body on panels | `#263238` |

## Shape language

- Rounded, chunky silhouettes (toy/chibi).
- Thick outlines on 2D UI; soft shadows on 3D placeholders.
- Bedroom scale: hero ~1 unit tall; enemies similar or slightly larger for bosses.

## Placeholder mapping

| Asset file | Use |
|------------|-----|
| `hero_chibi_placeholder.svg` | Player + squad members |
| `slime_enemy.svg` | Basic slime |
| `dust_bunny_boss.svg` | World 1 boss |
| `gate_positive.svg` / `gate_negative.svg` | Upgrade gates |
| `cardboard_box.svg` | Numbered obstacles |
| `coin.svg` / `gem.svg` | Pickups + HUD icons |
| `button_primary.svg` / `panel_rounded.svg` | UI reference |

## Replacement policy

Keep prefab names (`PFB_*_Placeholder`) and `PlaceholderArtId` enum stable. Swap meshes/sprites/materials only.

## Prefab ↔ requirements

See `PROJECT_DOCS/ART_DIRECTION.md` § “Art requirements ↔ placeholder prefabs” and `ArtDirectionConfig.artRequirements` in Unity.
