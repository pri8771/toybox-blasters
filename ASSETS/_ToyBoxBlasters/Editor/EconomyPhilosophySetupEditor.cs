#if UNITY_EDITOR
using ToyBoxBlasters.Product;
using UnityEditor;
using UnityEngine;

namespace ToyBoxBlasters.Editor.Product
{
    public static class EconomyPhilosophySetupEditor
    {
        const string ConfigFolder = "Assets/_ToyBoxBlasters/ScriptableObjects/Config";
        const string ConfigPath = ConfigFolder + "/EconomyPhilosophyConfig.asset";

        [MenuItem("ToyBox Blasters/Product/Create Economy Philosophy Config")]
        public static void CreateEconomyPhilosophyConfig()
        {
            EnsureFolder();
            var existing = AssetDatabase.LoadAssetAtPath<EconomyPhilosophyConfig>(ConfigPath);
            if (existing != null)
            {
                EditorUtility.DisplayDialog("ToyBox Blasters", "EconomyPhilosophyConfig already exists.", "OK");
                Selection.activeObject = existing;
                return;
            }

            var config = ScriptableObject.CreateInstance<EconomyPhilosophyConfig>();
            config.ApplyDefaults();
            AssetDatabase.CreateAsset(config, ConfigPath);
            AssetDatabase.SaveAssets();
            EditorUtility.DisplayDialog("ToyBox Blasters", "Created EconomyPhilosophyConfig with Task 006 defaults.", "OK");
            Selection.activeObject = config;
        }

        [MenuItem("ToyBox Blasters/Product/Reset Economy Philosophy To Defaults")]
        public static void ResetToDefaults()
        {
            var config = AssetDatabase.LoadAssetAtPath<EconomyPhilosophyConfig>(ConfigPath);
            if (config == null)
            {
                CreateEconomyPhilosophyConfig();
                return;
            }

            Undo.RecordObject(config, "Reset Economy Philosophy");
            config.ApplyDefaults();
            EditorUtility.SetDirty(config);
            AssetDatabase.SaveAssets();
        }

        [MenuItem("ToyBox Blasters/Validate Economy Philosophy")]
        public static void ValidateEconomyPhilosophy()
        {
            var config = AssetDatabase.LoadAssetAtPath<EconomyPhilosophyConfig>(ConfigPath);
            if (config == null)
            {
                var create = EditorUtility.DisplayDialog(
                    "ToyBox Blasters",
                    "EconomyPhilosophyConfig not found. Create it now?",
                    "Create",
                    "Cancel");
                if (create)
                    CreateEconomyPhilosophyConfig();
                return;
            }

            var passed = EconomyPhilosophyValidator.Validate(config, out var report);
            EconomyPhilosophyDebug.LogValidation(passed, report);
            EditorUtility.DisplayDialog("Validate Economy Philosophy", report, "OK");
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
