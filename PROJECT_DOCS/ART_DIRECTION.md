# Art Direction — ToyBox Blasters

**Task 008** — Phase 1 art direction lock (documentation + `ArtDirectionConfig`).  
**Status:** Locked for placeholder and first-world production planning.  
**Canonical code:** `ArtDirectionConfig` at `Assets/_ToyBoxBlasters/ScriptableObjects/Config/ArtDirectionConfig.asset`  
**Art bible (palette summary):** [ART_BIBLE.md](./ART_BIBLE.md)  
**Palette hex source of truth:** `Assets/PlaceholderPack/DesignSpecs/art_bible_placeholder.md`

---

## 1. Mood board

### Textual direction

ToyBox Blasters reads like a **Saturday-morning toy commercial** shot on a **bedroom floor at golden morning light**: warm, safe, tactile, and slightly oversized. Characters feel **Pixar-adjacent** in warmth (rounded forms, expressive poses) but stay **mobile-readable**—no micro-detail that dies at phone scale. Materials suggest **plastic, felt, cardboard, and plush**—never realistic grit, rust, or gore.

**Keywords:** playful, chunky, saturated-but-soft, bounce, confetti reward, “my toy came alive.”

### Reference list (study, do not copy)

| Reference | What to borrow |
|-----------|----------------|
| **Toy commercials (80s–00s)** | Hero lighting, primary-color pops, clear product silhouette |
| **Pixar / Disney TV warmth** | Emotional readability, squash-stretch personality, family-safe tone |
| **Bedroom morning light** | Soft key from window side, warm fill, gentle ceiling bounce |
| **Fall Guys (toy-like contestants)** | Silhouette clarity, bouncy locomotion, readable team color |
| **Clash Mini** | Chibi proportions, bold team colors, simple VFX language |
| **Nintendo toy aesthetics** (Mario toy lines, Kirby plush ads) | Rounded edges, ink outlines on marketing art, high contrast icons |

### Mood tiles (placeholder stand-ins)

No paid reference boards in repo. Use **PlaceholderPack SVGs** as mood tiles:

| Tile | SVG | Mood cue |
|------|-----|----------|
| Hero warmth | `SVG/Characters/hero_chibi_placeholder.svg` | Chibi captain, toy blue + yellow accent |
| Playful menace | `SVG/Enemies/slime_enemy.svg` | Gooey mess, not horror |
| Cozy threat | `SVG/Enemies/dust_bunny_boss.svg` | Fluffy boss, soft gray + purple fluff |
| Reward pop | `SVG/Icons/coin.svg` | Gold confetti economy |
| Choice moment | `SVG/Gates/gate_positive.svg` / `gate_negative.svg` | Clear good/bad read |
| Home scale | `SVG/Obstacles/cardboard_box.svg` | Kraft “furniture canyon” prop |
| UI chunk | `SVG/UI/button_primary.svg` / `panel_rounded.svg` | Rounded, high-contrast HUD |

See also: `Assets/_ToyBoxBlasters/Art/MoodBoard/README.md`

---

## 2. Character proportions

| Rule | Value |
|------|--------|
| **Style** | Chibi toy soldier |
| **Total height** | **2.5–3 head heights** (heads tall, not realistic 7–8) |
| **Hands / feet** | **Oversized** (~1.2× proportional) for gesture read |
| **Head** | ~35–40% of body height; large eyes (production), simple dots (placeholder) |
| **Torso** | Short, barrel-shaped; backpack/blaster readable from behind |
| **Silhouette test** | Hero + squad readable at **44 pt** width on **390 pt** portrait reference (≈11% screen width) |
| **Squad** | Same rig as hero; **15–20% smaller** scale (`PFB_SquadMember_Placeholder`) |

**Placeholder prefabs:** `PFB_HeroChibi_Placeholder`, `PFB_SquadMember_Placeholder`

---

## 3. Color palette

Extended from art bible. Categories: **Primary**, **Secondary**, **UI**, **Feedback**.

### Primary (brand / heroes)

| Role | Hex | Use |
|------|-----|-----|
| Toy blue | `#4FC3F7` | Hero, squad, friendly UI accents |
| Warm yellow | `#FFD54F` | Hero accent, highlights, morning sun |

### Secondary (world / enemies / props)

| Role | Hex | Use |
|------|-----|-----|
| Slime green | `#66BB6A` | Slime enemy body |
| Dust gray | `#9E9E9E` | Dust bunny body |
| Dust purple | `#B39DDB` | Boss fluff accent |
| Kraft brown | `#A1887F` | Cardboard obstacles, floor props |
| Floor wood | `#8D6E63` | Floorboards |
| Rug blush | `#F48FB1` | Rug pattern accent |

### UI

| Role | Hex | Use |
|------|-----|-----|
| Play orange | `#FF9800` | Primary CTA (`button_primary.svg`) |
| Soft panel blue | `#E3F2FD` | Panels (`panel_rounded.svg`) |
| Ink outline | `#37474F` | Icons, text outlines, toy edge |
| HUD text | `#263238` | Body copy on light panels |

### Feedback (gameplay read)

| Role | Hex | Use |
|------|-----|-----|
| Positive gate | `#81C784` | Buff gates, success toasts |
| Negative gate | `#EF5350` | Debuff gates, danger telegraphs |
| Coin gold | `#FFCA28` | Pickups, coin burst VFX |
| Gem amethyst | `#AB47BC` | Premium pickup |
| Damage flash | `#FF7043` | Hit flash (no blood) |
| Heal / shield | `#4DD0E1` | Rare buff VFX |
| Sky warm | `#FFF8E1` | Ceiling / soft box gradient |

**Contrast:** UI text and icons must pass **WCAG AA** against panel fills (ink on soft panel blue, white on play orange).

---

## 4. Enemy style

### Slime (basic)

- **Gooey toy-mess**, wobbly silhouette, glossy jelly material (not biological horror).
- **Hurt states:** squash flatten → color shift + white flash → dissolve into confetti specks (green + gold).
- **No gore**, no liquids that read as blood.

**Prefab:** `PFB_SlimeEnemy_Placeholder` ← `slime_enemy.svg`

### Dust bunny (boss)

- **Fluffy felt/plush** spheres with purple accent tufts; under-bed guardian fantasy.
- **Hurt states:** puff scale pulse, gray→lavender flash, shed **dust motes** (particles, not gore).
- **Telegraphs:** wind-up squash before hop/charge; large shadow blob on floor.

**Prefab:** `PFB_DustBunnyBoss_Placeholder` ← `dust_bunny_boss.svg`

---

## 5. Environment scale

Toy-scale diorama: player is **~1 m tall** in fiction; room furniture is **canyon scale**.

| Element | Spec |
|---------|------|
| **Player height** | **1.0 Unity units** (1 m fiction) |
| **Lane playable width** | **4.5 m** (steer clamp) |
| **Lane visual width** | **6.0 m** (props, skirting) |
| **Obstacle / gate height** | **2.0–2.5 m** (readable gates) |
| **Boss height** | **~1.6 m** body (reads larger via fluff VFX) |
| **Floor segment length** | **12–18 m** per chunk (designer-authored) |
| **Furniture legs** | **8–15 m** tall as skyline silhouettes |
| **Camera** | Portrait, slight top-down (15–25°), hero lower-third |

**Scale test:** hero silhouette ≥ **44 pt** on 390 pt wide reference at default FOV.

---

## 6. UI style

- **Panels:** rounded corners (16–24 px ref), soft panel blue fill, ink outline optional.
- **Buttons:** chunky pill/capsule (`button_primary.svg`), play orange fill, **bold label ≤3 words**.
- **Typography:** rounded sans (production); placeholder uses Unity default with size hierarchy.
- **Icons:** coin/gem from SVG pack; thick outline, no thin strokes under 2 px @1x.
- **Minimal text:** prefer icons + numbers (squad count, obstacle HP).
- **Safe area:** respect iOS/Android notches; HUD inset **24 pt** minimum.

**Prefabs:** `PFB_UI_ButtonPrimary_Placeholder`, `PFB_UI_PanelRounded_Placeholder`

---

## 7. VFX style

| Category | Direction |
|----------|-----------|
| **Particles** | Chunky quads, few count, high saturation; avoid realistic smoke |
| **Coins** | Confetti + star burst, gold palette |
| **Impacts** | Squish ring + color flash; screen shake **light** on boss only |
| **Projectiles** | Toy dart / foam bullet trails; thick, slow-readable |
| **Death** | Pop + confetti, **never** blood pools |
| **Gates** | Vertical shimmer column; +/- icons floating |

**Banned:** blood, realistic gore, dark horror particles, excessive fullscreen blur.

---

## 8. Animation personality

| State | Direction |
|-------|-----------|
| **Idle** | Bouncy bob (sine Y ±3%), subtle weapon sway |
| **Run** | Exaggerated arm pump; squad staggered phase offset |
| **Hit react** | Squash 0.7 Y scale 0.1s → spring back; face flash |
| **Shoot** | Recoil snap + muzzle puff |
| **Victory** | Celebratory dance (2–3 beats), confetti spawn |
| **Boss** | Squash-before-jump telegraph; fluffy recovery |

Placeholder phase: primitive bob via script later; production uses humanoid rig.

---

## 9. First world art requirements — Bedroom Floor

Checklist for World 1 vertical slice and production handoff:

| # | Requirement | Placeholder / notes |
|---|-------------|-------------------|
| 1 | **Floor** — warm wood planks, subtle variation | Procedural / gray-brown mat; `#8D6E63` |
| 2 | **Rug** — oval/rect accent, blush pattern | Flat decal; `#F48FB1` accent |
| 3 | **Props** — cardboard box, blocks, toy chest silhouettes | `PFB_CardboardBox_Placeholder` + block primitives |
| 4 | **Skybox** — soft bedroom ceiling (not outdoor sky) | Warm gradient `#FFF8E1` → `#ECEFF1` |
| 5 | **Lighting** — warm key + cool fill, no harsh noir | URP warm main, ambient 0.4 |
| 6 | **Lane markers** — subtle floor wear / rug edge | Decal or vertex color |
| 7 | **Pickups** | `PFB_CoinPickup_Placeholder`, optional gem |
| 8 | **Gates** | `PFB_GatePositive_Placeholder`, `PFB_GateNegative_Placeholder` |
| 9 | **Enemies** | Slime + `PFB_DustBunnyBoss_Placeholder` at lane end |
| 10 | **HUD** | UI prefabs + ink text on panel blue |

---

## 10. Asset production pipeline

```
SVG (PlaceholderPack) → Vector Graphics import OR primitive tint fallback
    → Material / Sprite / Mesh
    → Prefab (PFB_*_Placeholder stable names)
    → PlaceholderArtRegistry
    → Rigged FBX + Animator (production)
    → Review gates → swap materials/meshes only
```

### Naming

| Stage | Pattern | Example |
|-------|---------|---------|
| Source SVG | `snake_case.svg` | `hero_chibi_placeholder.svg` |
| Placeholder prefab | `PFB_{Name}_Placeholder` | `PFB_HeroChibi_Placeholder` |
| Production prefab | `PFB_{Name}` | `PFB_HeroChibi` |
| Material | `MAT_{Name}` | `MAT_HeroChibi_Body` |
| FBX | `SK_{Name}.fbx` | `SK_HeroChibi.fbx` |
| Registry key | `PlaceholderArtId` enum | `HeroChibi` |

### Review gates

1. **Silhouette** — 44 pt phone test, portrait screenshot.
2. **Palette** — colors from `ArtDirectionConfig` / art bible only (±10% value shift max).
3. **Scale** — player 1 m, lane 4.5 m playable.
4. **Hurt/VFX** — no gore; feedback colors used.
5. **Prefab swap** — same `PlaceholderArtId` / prefab name; gameplay unchanged.

**Unity menu:** ToyBox Blasters → Setup Placeholder Art  
**Validate:** ToyBox Blasters → Validate Art Direction

---

## Art requirements ↔ placeholder prefabs

| Prefab | `PlaceholderArtId` | Source SVG | Bedroom / gameplay role |
|--------|-------------------|------------|-------------------------|
| `PFB_HeroChibi_Placeholder` | HeroChibi | `hero_chibi_placeholder.svg` | Player captain |
| `PFB_SquadMember_Placeholder` | SquadMember | `hero_chibi_placeholder.svg` | Squad follower |
| `PFB_SlimeEnemy_Placeholder` | SlimeEnemy | `slime_enemy.svg` | Basic enemy |
| `PFB_DustBunnyBoss_Placeholder` | DustBunnyBoss | `dust_bunny_boss.svg` | World 1 boss |
| `PFB_GatePositive_Placeholder` | GatePositive | `gate_positive.svg` | Buff gate |
| `PFB_GateNegative_Placeholder` | GateNegative | `gate_negative.svg` | Debuff gate |
| `PFB_CardboardBox_Placeholder` | CardboardBox | `cardboard_box.svg` | Numbered obstacle |
| `PFB_CoinPickup_Placeholder` | CoinPickup | `coin.svg` | Coin pickup |
| `PFB_GemPickup_Placeholder` | GemPickup | `gem.svg` | Gem pickup (soft launch+) |
| `PFB_UI_ButtonPrimary_Placeholder` | UiButtonPrimary | `button_primary.svg` | Primary CTA reference |
| `PFB_UI_PanelRounded_Placeholder` | UiPanelRounded | `panel_rounded.svg` | Panel reference |

---

## Task 008 review — pass/fail

| # | Subtask | Pass |
|---|---------|------|
| 1 | Mood board | ✅ |
| 2 | Character proportions | ✅ |
| 3 | Color palette | ✅ |
| 4 | Enemy style | ✅ |
| 5 | Environment scale | ✅ |
| 6 | UI style | ✅ |
| 7 | VFX style | ✅ |
| 8 | Animation personality | ✅ |
| 9 | Bedroom Floor checklist | ✅ |
| 10 | Asset pipeline | ✅ |

**Overall Task 008:** **PASS** — documentation, config, validator, Editor menus, mood board README, art bible cross-link.

**Next:** Phase 2 **first playable prototype** (per `RELEASE_SCOPE.md` §9) or dedicated art production pass (FBX + URP materials for Bedroom Floor).
