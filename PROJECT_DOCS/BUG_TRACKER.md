# Bug Tracker — ToyBox Blasters

**Workflow doc (Task 010).** Active triage list: **[OPEN_BUGS.md](./OPEN_BUGS.md)**.

Use this file for severity workflow and history; keep `OPEN_BUGS.md` scannable for agents and daily standup.

---

## Severity definitions

| Severity | Definition | Response |
|----------|------------|----------|
| **P0** | Build broken, data loss, ship blocker | Fix before merge / release |
| **P1** | Major feature broken, no workaround | Fix in current sprint |
| **P2** | Minor feature / visual bug with workaround | Backlog |
| **P3** | Polish, typo, nice-to-have | Backlog / opportunistic |

---

## Status workflow

```
Open → In Progress → In Review → Resolved → Verified
                      ↘ Won't Fix / Duplicate
```

| Status | Meaning |
|--------|---------|
| Open | Confirmed, not assigned |
| In Progress | Owner actively fixing |
| In Review | PR / fix pending QA |
| Resolved | Fix merged; awaiting verify |
| Verified | Closed in target build |
| Won't Fix | Accepted risk |
| Duplicate | Link to canonical ID |

---

## Entry template

Copy into [OPEN_BUGS.md](./OPEN_BUGS.md) when filing:

```markdown
| BUG-XXX | Open | P1 | Short title | Owner | Link / notes |
```

---

## Archive

Move resolved rows from OPEN_BUGS to **Resolved** section with resolution note and task/PR reference.
