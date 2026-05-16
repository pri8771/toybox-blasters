# Technical Design — ToyBox Blasters

**Version:** 1.1 (Task 001, cross-linked Task 010)  
**Task 001** stack confirmation. System diagrams, doc manifest, and assembly map: **[TECHNICAL_ARCHITECTURE.md](./TECHNICAL_ARCHITECTURE.md)**.

## Platform & engine

| Item | Choice |
|------|--------|
| Engine | Unity **2022.3 LTS** |
| Languages | C# |
| Orientation | Portrait (primary) |
| Mobile targets | iOS 14+, Android API 24+ (adjust in export settings later) |
| Render | URP recommended when render pipeline is added; primitives OK for prototype |

## Backend — Firebase (preferred)

Use **interface-first** services; Firebase is the default implementation path.

| Capability | Firebase product | Abstraction |
|------------|------------------|-------------|
| Auth | Firebase Auth | `IAuthService` |
| Player data | Firestore | `IPlayerProfileRepository` |
| Remote tuning | Remote Config | `IRemoteConfigService` |
| Analytics | Firebase Analytics | `IAnalyticsService` |
| Cloud logic | Cloud Functions | server-side only |

**Secrets:** use placeholder `firebase/google-services.json.example` instructions in repo; never commit production keys (see `.gitignore`).

## Module layout

```
Assets/_ToyBoxBlasters/
  Scripts/           # Product + gameplay C#
  ScriptableObjects/ # GameConceptConfig, balance configs
  Prefabs/           # Gameplay prefabs (generated art prefabs may stay under Art/)
  Art/               # Placeholder art pipeline
  Editor/            # Setup & validation menus
```

## Product config

- `GameConceptConfig` ScriptableObject — single source for name, genre, pitch, fantasy, world theme, differentiation.
- Validated via **ToyBox Blasters → Validate Game Concept** (Editor).
- `CoreGameplayLoopConfig` ScriptableObject — ten loop layers (Task 005); see `CORE_GAMEPLAY_LOOP.md`.
- Validated via **ToyBox Blasters → Validate Core Gameplay Loop** (Editor).
- `ArtDirectionConfig` ScriptableObject — palette, scale, Bedroom checklist, prefab requirements (Task 008); see `ART_DIRECTION.md`.
- Validated via **ToyBox Blasters → Validate Art Direction** (Editor).

## Compile & playability (Task 001)

- No gameplay scene required; project must compile with Scripts + existing Art assemblies.
- Placeholder art menu remains independent.

## See also

- [TECHNICAL_ARCHITECTURE.md](./TECHNICAL_ARCHITECTURE.md) — architecture overview, config layer, Firebase interfaces
- [ANALYTICS_SPEC.md](./ANALYTICS_SPEC.md) — event taxonomy (Task 010)
- [PROJECT_DOCS/README.md](./README.md) — master documentation index
