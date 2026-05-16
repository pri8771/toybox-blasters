#if UNITY_EDITOR
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace ToyBoxBlasters.Editor.Project
{
    /// <summary>
    /// Task 012 — validates local GitHub scaffolding (.gitignore, .github templates).
    /// </summary>
    public static class GitHubSetupValidationEditor
    {
        const string GitIgnorePath = ".gitignore";
        const string GitHubReadme = ".github/README.md";
        const string PullRequestTemplate = ".github/pull_request_template.md";
        const string BugTemplate = ".github/ISSUE_TEMPLATE/bug_report.md";
        const string FeatureTemplate = ".github/ISSUE_TEMPLATE/feature_request.md";

        [MenuItem("ToyBox Blasters/Project/Validate GitHub Setup")]
        public static void ValidateGitHubSetup()
        {
            var root = Path.GetFullPath(Path.Combine(Application.dataPath, ".."));
            var report = new StringBuilder();
            var pass = true;

            void Check(bool ok, string label)
            {
                report.AppendLine(ok ? $"[PASS] {label}" : $"[FAIL] {label}");
                if (!ok) pass = false;
            }

            var gitIgnore = Path.Combine(root, GitIgnorePath);
            Check(File.Exists(gitIgnore), $"{GitIgnorePath} exists");
            if (File.Exists(gitIgnore))
            {
                var text = File.ReadAllText(gitIgnore);
                Check(text.Contains("Library") || text.Contains("[Ll]ibrary"), ".gitignore ignores Library/");
                Check(text.Contains("google-services.json"), ".gitignore ignores Firebase google-services.json");
                Check(text.Contains("UserSettings") || text.Contains("[Uu]ser[Ss]ettings"), ".gitignore ignores UserSettings/");
            }

            Check(File.Exists(Path.Combine(root, GitHubReadme)), GitHubReadme);
            Check(File.Exists(Path.Combine(root, PullRequestTemplate)), PullRequestTemplate);
            Check(File.Exists(Path.Combine(root, BugTemplate)), BugTemplate);
            Check(File.Exists(Path.Combine(root, FeatureTemplate)), FeatureTemplate);
            Check(File.Exists(Path.Combine(root, "PROJECT_DOCS", "GITHUB_SETUP.md")), "PROJECT_DOCS/GITHUB_SETUP.md");
            Check(File.Exists(Path.Combine(root, "PROJECT_DOCS", "BRANCHING.md")), "PROJECT_DOCS/BRANCHING.md");

            var summary = pass ? "GitHub setup validation passed." : "GitHub setup validation failed — see Console.";
            Debug.Log($"[ToyBox Blasters] {summary}\n{report}");
            EditorUtility.DisplayDialog("ToyBox Blasters — GitHub Setup", $"{summary}\n\n{report}", "OK");
        }
    }
}
#endif
