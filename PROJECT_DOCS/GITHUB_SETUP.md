# GitHub Repository Setup — ToyBox Blasters

**Task 012** — Phase 2 repository scaffolding. Remote creation is optional; local git + docs are the source of truth until you push.

## Placeholder remote

```
https://github.com/YOUR_ORG/toybox-blasters
```

Replace `YOUR_ORG` with your GitHub user or organization name.

## Prerequisites

- [Git](https://git-scm.com/) installed
- [GitHub CLI](https://cli.github.com/) (`gh`) optional but recommended
- Unity 2022.3 LTS (see root `README.md`)

## 1. Verify local git

From the project root:

```bash
git status
git branch -a
```

Expected default branch: **`main`**. Integration branch: **`dev`** (created locally in Task 012).

## 2. Authenticate GitHub CLI (optional)

```bash
gh auth status
```

If not logged in:

```bash
gh auth login
```

## 3. Create the remote repository

### Option A — `gh` (recommended when authenticated)

**Public** (default for open prototypes):

```bash
gh repo create toybox-blasters --source=. --public --remote=origin --description "ToyBox Blasters — hybrid-casual squad shooter runner (Unity, iOS/Android)"
```

**Private** (if you prefer):

```bash
gh repo create toybox-blasters --source=. --private --remote=origin --description "ToyBox Blasters — hybrid-casual squad shooter runner (Unity, iOS/Android)"
```

Then push (no force push to `main`):

```bash
git push -u origin main
git push -u origin dev
```

### Option B — GitHub web UI

1. Go to [github.com/new](https://github.com/new).
2. Repository name: `toybox-blasters`.
3. Do **not** initialize with README (this repo already has one).
4. Add remote and push:

```bash
git remote add origin https://github.com/YOUR_ORG/toybox-blasters.git
git push -u origin main
git push -u origin dev
```

## 4. Branch protection (recommended after first push)

On GitHub: **Settings → Branches → Add rule**

| Branch | Suggested rule |
|--------|----------------|
| `main` | Require PR, no direct pushes, require status checks when CI exists |
| `dev` | Require PR for merges from `feature/*` |

See [BRANCHING.md](./BRANCHING.md) for workflow.

## 5. Secrets and Unity artifacts

Never commit:

- `google-services.json`, `GoogleService-Info.plist`, `firebase_options.json`
- `.env` / `.env.*`
- `Library/`, `Temp/`, `Logs/`, `UserSettings/`, build outputs

Root `.gitignore` enforces these patterns.

## 6. Validate in Unity (optional)

**ToyBox Blasters → Project → Validate GitHub Setup** — checks `.gitignore` and `.github/` templates.

## TODO (manual)

- [ ] Replace `YOUR_ORG` in remote URL and this doc when org is known
- [ ] Run `gh repo create` or web UI steps above if remote does not exist
- [ ] Enable branch protection on `main` after CI (Task 013+) is wired
- [ ] Add CI badge to root `README.md` when workflow exists

## Related docs

- [BRANCHING.md](./BRANCHING.md)
- [RELEASE_TAGS.md](./RELEASE_TAGS.md)
- [README.md](./README.md) — documentation index
