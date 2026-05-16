#if UNITY_EDITOR
using System.IO;
using ToyBoxBlasters.Product;
using UnityEditor;
using UnityEngine;

namespace ToyBoxBlasters.Editor.Product
{
    public static class DocumentationManifestSetupEditor
    {
        const string ConfigFolder = "Assets/_ToyBoxBlasters/ScriptableObjects/Config";
        const string ConfigPath = ConfigFolder + "/DocumentationManifestConfig.asset";

        [MenuItem("ToyBox Blasters/Documentation/Create Documentation Manifest Config")]
        public static void CreateDocumentationManifestConfig()
        {
            EnsureFolder();
            var existing = AssetDatabase.LoadAssetAtPath<DocumentationManifestConfig>(ConfigPath);
            if (existing != null)
            {
                EditorUtility.DisplayDialog("ToyBox Blasters", "DocumentationManifestConfig already exists.", "OK");
                Selection.activeObject = existing;
                return;
            }

            var config = ScriptableObject.CreateInstance<DocumentationManifestConfig>();
            config.ApplyDefaults();
            AssetDatabase.CreateAsset(config, ConfigPath);
            AssetDatabase.SaveAssets();
            EditorUtility.DisplayDialog("ToyBox Blasters", "Created DocumentationManifestConfig with Task 010 defaults.", "OK");
            Selection.activeObject = config;
        }

        [MenuItem("ToyBox Blasters/Documentation/Reset Documentation Manifest To Defaults")]
        public static void ResetToDefaults()
        {
            var config = AssetDatabase.LoadAssetAtPath<DocumentationManifestConfig>(ConfigPath);
            if (config == null)
            {
                CreateDocumentationManifestConfig();
                return;
            }

            Undo.RecordObject(config, "Reset Documentation Manifest");
            config.ApplyDefaults();
            EditorUtility.SetDirty(config);
            AssetDatabase.SaveAssets();
        }

        [MenuItem("ToyBox Blasters/Documentation/Create Missing Doc Stubs")]
        public static void CreateMissingDocStubs()
        {
            var config = AssetDatabase.LoadAssetAtPath<DocumentationManifestConfig>(ConfigPath);
            if (config == null)
            {
                var create = EditorUtility.DisplayDialog(
                    "ToyBox Blasters",
                    "DocumentationManifestConfig not found. Create it now?",
                    "Create",
                    "Cancel");
                if (create)
                    CreateDocumentationManifestConfig();
                config = AssetDatabase.LoadAssetAtPath<DocumentationManifestConfig>(ConfigPath);
                if (config == null)
                    return;
            }

            var root = DocumentationManifestPaths.ProjectRoot;
            var created = 0;
            var skipped = 0;

            foreach (var entry in config.Entries)
            {
                if (entry == null || string.IsNullOrWhiteSpace(entry.RelativePath))
                    continue;

                var fullPath = Path.GetFullPath(Path.Combine(root, entry.RelativePath));
                if (File.Exists(fullPath))
                {
                    skipped++;
                    continue;
                }

                var dir = Path.GetDirectoryName(fullPath);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                var title = Path.GetFileNameWithoutExtension(entry.RelativePath).Replace('_', ' ');
                var body =
                    $"# {title}\n\n" +
                    $"**Status:** Stub created by Task 010 documentation tooling.\n" +
                    $"**Task:** {entry.TaskId}\n" +
                    $"**Owner:** {entry.Owner}\n\n" +
                    "See **[PROJECT_DOCS/README.md](./README.md)** for the master index.\n";
                File.WriteAllText(fullPath, body);
                created++;
            }

            AssetDatabase.Refresh();
            EditorUtility.DisplayDialog(
                "Create Missing Doc Stubs",
                $"Created {created} stub(s). Skipped {skipped} existing file(s).",
                "OK");
        }

        static void EnsureFolder()
        {
            if (!AssetDatabase.IsValidFolder("Assets/_ToyBoxBlasters/ScriptableObjects"))
                AssetDatabase.CreateFolder("Assets/_ToyBoxBlasters", "ScriptableObjects");
            if (!AssetDatabase.IsValidFolder("Assets/_ToyBoxBlasters/ScriptableObjects/Config"))
                AssetDatabase.CreateFolder("Assets/_ToyBoxBlasters/ScriptableObjects", "Config");
        }
    }
}
#endif
