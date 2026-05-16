# Master Cursor Instructions — ToyBox Blasters

## Non-negotiable project rules

1. Build in Unity with C#.
2. Target iOS and Android (portrait default).
3. Use Firebase for backend unless a prompt says otherwise.
4. Keep the game playable after every task.
5. Avoid breaking existing working systems.
6. Clean, modular, testable code; ScriptableObjects for configs; interfaces for backend/ads/analytics/IAP.
7. No hardcoded balancing in code — use configs.
8. Update `PROJECT_DOCS/` after each task; debug hooks in dev builds.
9. Placeholder art from `Assets/PlaceholderPack/` (prompt: `/ASSETS`).
10. Never commit real Firebase or store secrets.

## Folder conventions

| Path | Purpose |
|------|---------|
| `Assets/_ToyBoxBlasters/Scripts` | Gameplay and product C# |
| `Assets/_ToyBoxBlasters/ScriptableObjects` | Config assets |
| `Assets/_ToyBoxBlasters/Prefabs` | Prefabs |
| `Assets/_ToyBoxBlasters/Art` | Art pipeline (legacy Runtime/Art — migrate gradually) |
| `PROJECT_DOCS/` | PRD, design, logs, bugs, backlog |

## Product identity (locked Task 001)

See `PROJECT_DOCS/PRD.md` and `ScriptableObjects/Config/GameConceptConfig.asset`.
