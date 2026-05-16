# Placeholder Pack (prompt: `/ASSETS`)

This folder mirrors the zip layout from `001_ASSET_USAGE_PROMPT_FOR_CURSOR`.

On **case-insensitive** volumes (default macOS), Unity's `Assets/` folder cannot coexist with a separate root `/ASSETS` directory — use this path as the canonical pack inside the Unity project.

On **case-sensitive** CI/Linux, you may optionally add a root `ASSETS/` symlink to `Assets/PlaceholderPack` for prompt parity.
