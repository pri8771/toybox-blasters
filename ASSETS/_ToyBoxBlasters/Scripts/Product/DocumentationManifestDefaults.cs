using System.Collections.Generic;

namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// Canonical doc paths for Task 010. Keep in sync with PROJECT_DOCS/README.md.
    /// </summary>
    public static class DocumentationManifestDefaults
    {
        public const string ManifestVersion = "1.0 (Task 010)";
        public const string TaskId = "Task 010 — Master Documentation System (Phase 1 capstone)";

        public static List<DocumentationManifestEntry> CreateDefaultEntries()
        {
            const string o = "Product";
            const string d = "2026-05-16";
            return new List<DocumentationManifestEntry>
            {
                E("readme_root", "README.md", true, "010", o, d),
                E("docs_index", "PROJECT_DOCS/README.md", true, "010", o, d),
                E("prd", "PROJECT_DOCS/PRD.md", true, "001", o, d),
                E("tech_design", "PROJECT_DOCS/TECH_DESIGN.md", true, "001", "Engineering", d),
                E("tech_architecture", "PROJECT_DOCS/TECHNICAL_ARCHITECTURE.md", true, "010", "Engineering", d),
                E("gameplay_design", "PROJECT_DOCS/GAMEPLAY_DESIGN.md", true, "005", "Design", d),
                E("core_loop", "PROJECT_DOCS/CORE_GAMEPLAY_LOOP.md", true, "005", "Design", d),
                E("economy_design", "PROJECT_DOCS/ECONOMY_DESIGN.md", true, "006", "Economy", d),
                E("economy_philosophy_alias", "PROJECT_DOCS/ECONOMY_PHILOSOPHY.md", false, "006", "Economy", d),
                E("monetization_strategy", "PROJECT_DOCS/MONETIZATION_STRATEGY.md", true, "007", "Monetization", d),
                E("art_bible", "PROJECT_DOCS/ART_BIBLE.md", true, "008", "Art", d),
                E("art_direction", "PROJECT_DOCS/ART_DIRECTION.md", true, "008", "Art", d),
                E("analytics_spec", "PROJECT_DOCS/ANALYTICS_SPEC.md", true, "010", "Data", d),
                E("release_scope", "PROJECT_DOCS/RELEASE_SCOPE.md", true, "002", o, d),
                E("release_checklist", "PROJECT_DOCS/RELEASE_CHECKLIST.md", true, "010", o, d),
                E("audience", "PROJECT_DOCS/AUDIENCE_AND_PERSONAS.md", true, "003", o, d),
                E("competitive", "PROJECT_DOCS/COMPETITIVE_RESEARCH.md", true, "004", o, d),
                E("asset_setup", "PROJECT_DOCS/ASSET_SETUP.md", true, "001", "Art", d),
                E("open_bugs", "PROJECT_DOCS/OPEN_BUGS.md", true, "010", "QA", d),
                E("bug_tracker", "PROJECT_DOCS/BUG_TRACKER.md", false, "010", "QA", d),
                E("changelog", "PROJECT_DOCS/CHANGELOG.md", true, "010", o, d),
                E("implementation_log", "PROJECT_DOCS/IMPLEMENTATION_LOG.md", true, "010", o, d),
                E("feature_backlog", "PROJECT_DOCS/FEATURE_BACKLOG.md", true, "010", o, d),
                E("tech_decisions", "PROJECT_DOCS/TECH_DECISIONS.md", true, "010", "Engineering", d),
                E("master_cursor", "00_MASTER/000_MASTER_CURSOR_INSTRUCTIONS.md", true, "010", o, d),
                E("placeholder_art_bible", "Assets/PlaceholderPack/DesignSpecs/art_bible_placeholder.md", false, "001", "Art", d)
            };
        }

        static DocumentationManifestEntry E(
            string id,
            string path,
            bool required,
            string taskId,
            string owner,
            string lastUpdated) =>
            new(id, path, required, taskId, owner, lastUpdated);
    }
}
