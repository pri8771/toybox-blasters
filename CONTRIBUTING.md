# Contributing to ToyBox Blasters

Thank you for helping build ToyBox Blasters. This is a Unity mobile project; please read the docs before large changes.

## Quick links

- [PROJECT_DOCS/README.md](./PROJECT_DOCS/README.md) — documentation index
- [PROJECT_DOCS/BRANCHING.md](./PROJECT_DOCS/BRANCHING.md) — branch workflow
- [00_MASTER/000_MASTER_CURSOR_INSTRUCTIONS.md](./00_MASTER/000_MASTER_CURSOR_INSTRUCTIONS.md) — project rules

## Getting started

1. Clone the repo (see root [README.md](./README.md)).
2. Open in **Unity 2022.3 LTS**.
3. Run **ToyBox Blasters → Setup Placeholder Art** once.
4. Create product configs via **ToyBox Blasters → Product** menus as needed.

## Branch workflow

- Base feature work on **`dev`**.
- Use `feature/<name>` branches; open PRs into `dev`.
- Release merges: `dev` → `main` with tags per [RELEASE_TAGS.md](./PROJECT_DOCS/RELEASE_TAGS.md).

## Code guidelines

- Modular C#; ScriptableObjects for configs; interfaces for backend/ads/IAP.
- No hardcoded balance — use config assets.
- No real Firebase or store secrets in commits.
- Update `PROJECT_DOCS/IMPLEMENTATION_LOG.md` for substantial tasks.

## Pull requests

Use the [pull request template](./.github/pull_request_template.md). Ensure Editor validation menus pass where relevant.

## Reporting issues

Use GitHub issue templates under [`.github/ISSUE_TEMPLATE/`](./.github/ISSUE_TEMPLATE/).
