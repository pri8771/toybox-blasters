#if UNITY_EDITOR
using ToyBoxBlasters.Product;
using UnityEditor;
using UnityEngine;

namespace ToyBoxBlasters.Editor.Product
{
    public static class CompetitiveResearchSetupEditor
    {
        const string ConfigFolder = "Assets/_ToyBoxBlasters/ScriptableObjects/Config";
        const string ConfigPath = ConfigFolder + "/CompetitiveResearchConfig.asset";

        [MenuItem("ToyBox Blasters/Product/Create Competitive Research Config")]
        public static void CreateCompetitiveResearchConfig()
        {
            EnsureFolder();
            var existing = AssetDatabase.LoadAssetAtPath<CompetitiveResearchConfig>(ConfigPath);
            if (existing != null)
            {
                EditorUtility.DisplayDialog("ToyBox Blasters", "CompetitiveResearchConfig already exists.", "OK");
                Selection.activeObject = existing;
                return;
            }

            var config = ScriptableObject.CreateInstance<CompetitiveResearchConfig>();
            config.ApplyDefaults();
            AssetDatabase.CreateAsset(config, ConfigPath);
            AssetDatabase.SaveAssets();
            EditorUtility.DisplayDialog(
                "ToyBox Blasters",
                "Created CompetitiveResearchConfig with Task 004 defaults.",
                "OK");
            Selection.activeObject = config;
        }

        [MenuItem("ToyBox Blasters/Product/Reset Competitive Research To Defaults")]
        public static void ResetToDefaults()
        {
            var config = AssetDatabase.LoadAssetAtPath<CompetitiveResearchConfig>(ConfigPath);
            if (config == null)
            {
                CreateCompetitiveResearchConfig();
                return;
            }

            Undo.RecordObject(config, "Reset Competitive Research");
            config.ApplyDefaults();
            EditorUtility.SetDirty(config);
            AssetDatabase.SaveAssets();
        }

        [MenuItem("ToyBox Blasters/Validate Competitive Research")]
        public static void ValidateCompetitiveResearch()
        {
            var config = AssetDatabase.LoadAssetAtPath<CompetitiveResearchConfig>(ConfigPath);
            if (config == null)
            {
                var create = EditorUtility.DisplayDialog(
                    "ToyBox Blasters",
                    "CompetitiveResearchConfig not found. Create it now?",
                    "Create",
                    "Cancel");
                if (create)
                    CreateCompetitiveResearchConfig();
                return;
            }

            var passed = CompetitiveResearchValidator.Validate(config, out var report);
            CompetitiveResearchDebug.LogValidation(passed, report);
            EditorUtility.DisplayDialog("Validate Competitive Research", report, "OK");
        }

        static void EnsureFolder()
        {
            if (!AssetDatabase.IsValidFolder("Assets/_ToyBoxBlasters"))
                AssetDatabase.CreateFolder("Assets", "_ToyBoxBlasters");
            if (!AssetDatabase.IsValidFolder("Assets/_ToyBoxBlasters/ScriptableObjects"))
                AssetDatabase.CreateFolder("Assets/_ToyBoxBlasters", "ScriptableObjects");
            if (!AssetDatabase.IsValidFolder("Assets/_ToyBoxBlasters/ScriptableObjects/Config"))
                AssetDatabase.CreateFolder("Assets/_ToyBoxBlasters/ScriptableObjects", "Config");
        }
    }
}
#endif
