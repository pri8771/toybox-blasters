#if UNITY_EDITOR
using ToyBoxBlasters.Product;
using UnityEditor;
using UnityEngine;

namespace ToyBoxBlasters.Editor.Product
{
    public static class CoreGameplayLoopSetupEditor
    {
        const string ConfigFolder = "Assets/_ToyBoxBlasters/ScriptableObjects/Config";
        const string ConfigPath = ConfigFolder + "/CoreGameplayLoopConfig.asset";

        [MenuItem("ToyBox Blasters/Product/Create Core Gameplay Loop Config")]
        public static void CreateCoreGameplayLoopConfig()
        {
            EnsureFolder();
            var existing = AssetDatabase.LoadAssetAtPath<CoreGameplayLoopConfig>(ConfigPath);
            if (existing != null)
            {
                EditorUtility.DisplayDialog("ToyBox Blasters", "CoreGameplayLoopConfig already exists.", "OK");
                Selection.activeObject = existing;
                return;
            }

            var config = ScriptableObject.CreateInstance<CoreGameplayLoopConfig>();
            config.ApplyDefaults();
            AssetDatabase.CreateAsset(config, ConfigPath);
            AssetDatabase.SaveAssets();
            EditorUtility.DisplayDialog(
                "ToyBox Blasters",
                "Created CoreGameplayLoopConfig with Task 005 defaults (10 loops).",
                "OK");
            Selection.activeObject = config;
        }

        [MenuItem("ToyBox Blasters/Product/Reset Core Gameplay Loop To Defaults")]
        public static void ResetToDefaults()
        {
            var config = AssetDatabase.LoadAssetAtPath<CoreGameplayLoopConfig>(ConfigPath);
            if (config == null)
            {
                CreateCoreGameplayLoopConfig();
                return;
            }

            Undo.RecordObject(config, "Reset Core Gameplay Loop");
            config.ApplyDefaults();
            EditorUtility.SetDirty(config);
            AssetDatabase.SaveAssets();
        }

        [MenuItem("ToyBox Blasters/Validate Core Gameplay Loop")]
        public static void ValidateCoreGameplayLoop()
        {
            var config = AssetDatabase.LoadAssetAtPath<CoreGameplayLoopConfig>(ConfigPath);
            if (config == null)
            {
                var create = EditorUtility.DisplayDialog(
                    "ToyBox Blasters",
                    "CoreGameplayLoopConfig not found. Create it now?",
                    "Create",
                    "Cancel");
                if (create)
                    CreateCoreGameplayLoopConfig();
                return;
            }

            var passed = CoreGameplayLoopValidator.Validate(config, out var report);
            CoreGameplayLoopDebug.LogValidation(passed, report);

            EditorUtility.DisplayDialog(
                passed ? "Validate Core Gameplay Loop" : "Validate Core Gameplay Loop — FAILED",
                report,
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
