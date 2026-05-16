#if UNITY_EDITOR
using ToyBoxBlasters.Product;
using UnityEditor;

namespace ToyBoxBlasters.Editor.Product
{
    [InitializeOnLoad]
    public static class DocumentationManifestValidationEditor
    {
        const string ConfigPath = "Assets/_ToyBoxBlasters/ScriptableObjects/Config/DocumentationManifestConfig.asset";

        static DocumentationManifestValidationEditor()
        {
            EditorApplication.delayCall += RunSilentValidationOnce;
        }

        static void RunSilentValidationOnce()
        {
            EditorApplication.delayCall -= RunSilentValidationOnce;
            var config = AssetDatabase.LoadAssetAtPath<DocumentationManifestConfig>(ConfigPath);
            if (config == null)
                return;

            var passed = DocumentationManifestValidator.Validate(
                config,
                DocumentationManifestPaths.ProjectRoot,
                out var report);
            if (!passed)
                UnityEngine.Debug.LogWarning($"[ToyBox Blasters] Documentation manifest: {report}");
        }

        [MenuItem("ToyBox Blasters/Documentation/Validate Documentation System")]
        public static void ValidateDocumentationSystem()
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
                    DocumentationManifestSetupEditor.CreateDocumentationManifestConfig();
                config = AssetDatabase.LoadAssetAtPath<DocumentationManifestConfig>(ConfigPath);
                if (config == null)
                    return;
            }

            var passed = DocumentationManifestValidator.Validate(
                config,
                DocumentationManifestPaths.ProjectRoot,
                out var report);

            EditorUtility.DisplayDialog(
                passed ? "Validate Documentation System" : "Validate Documentation System — Issues",
                report,
                "OK");
        }
    }
}
#endif
