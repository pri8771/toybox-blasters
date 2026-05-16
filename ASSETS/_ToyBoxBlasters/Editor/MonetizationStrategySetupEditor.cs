#if UNITY_EDITOR
using ToyBoxBlasters.Product.Monetization;
using UnityEditor;
using UnityEngine;

namespace ToyBoxBlasters.Editor.Product
{
    public static class MonetizationStrategySetupEditor
    {
        const string ConfigFolder = "Assets/_ToyBoxBlasters/ScriptableObjects/Config";
        const string ConfigPath = ConfigFolder + "/MonetizationStrategyConfig.asset";

        [MenuItem("ToyBox Blasters/Product/Create Monetization Strategy Config")]
        public static void CreateMonetizationStrategyConfig()
        {
            EnsureFolder();
            var existing = AssetDatabase.LoadAssetAtPath<MonetizationStrategyConfig>(ConfigPath);
            if (existing != null)
            {
                EditorUtility.DisplayDialog("ToyBox Blasters", "MonetizationStrategyConfig already exists.", "OK");
                Selection.activeObject = existing;
                return;
            }

            var config = ScriptableObject.CreateInstance<MonetizationStrategyConfig>();
            config.ApplyDefaults();
            AssetDatabase.CreateAsset(config, ConfigPath);
            AssetDatabase.SaveAssets();
            EditorUtility.DisplayDialog("ToyBox Blasters", "Created MonetizationStrategyConfig with Task 007 defaults.", "OK");
            Selection.activeObject = config;
        }

        [MenuItem("ToyBox Blasters/Product/Reset Monetization Strategy To Defaults")]
        public static void ResetToDefaults()
        {
            var config = AssetDatabase.LoadAssetAtPath<MonetizationStrategyConfig>(ConfigPath);
            if (config == null)
            {
                CreateMonetizationStrategyConfig();
                return;
            }

            Undo.RecordObject(config, "Reset Monetization Strategy");
            config.ApplyDefaults();
            EditorUtility.SetDirty(config);
            AssetDatabase.SaveAssets();
        }

        [MenuItem("ToyBox Blasters/Validate Monetization Strategy")]
        public static void ValidateMonetizationStrategy()
        {
            var config = AssetDatabase.LoadAssetAtPath<MonetizationStrategyConfig>(ConfigPath);
            if (config == null)
            {
                var create = EditorUtility.DisplayDialog(
                    "ToyBox Blasters",
                    "MonetizationStrategyConfig not found. Create it now?",
                    "Create",
                    "Cancel");
                if (create)
                    CreateMonetizationStrategyConfig();
                return;
            }

            var passed = MonetizationStrategyValidator.Validate(config, out var report);
            MonetizationStrategyDebug.LogValidation(passed, report);
            EditorUtility.DisplayDialog("Validate Monetization Strategy", report, "OK");
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
