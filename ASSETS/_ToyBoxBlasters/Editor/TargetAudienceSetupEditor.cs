#if UNITY_EDITOR
using ToyBoxBlasters.Product;
using UnityEditor;
using UnityEngine;

namespace ToyBoxBlasters.Editor.Product
{
    public static class TargetAudienceSetupEditor
    {
        const string ConfigFolder = "Assets/_ToyBoxBlasters/ScriptableObjects/Config";
        const string ConfigPath = ConfigFolder + "/TargetAudienceConfig.asset";

        [MenuItem("ToyBox Blasters/Product/Create Target Audience Config")]
        public static void CreateTargetAudienceConfig()
        {
            EnsureFolder();
            var existing = AssetDatabase.LoadAssetAtPath<TargetAudienceConfig>(ConfigPath);
            if (existing != null)
            {
                EditorUtility.DisplayDialog("ToyBox Blasters", "TargetAudienceConfig already exists.", "OK");
                Selection.activeObject = existing;
                return;
            }

            var config = ScriptableObject.CreateInstance<TargetAudienceConfig>();
            config.ApplyDefaults();
            AssetDatabase.CreateAsset(config, ConfigPath);
            AssetDatabase.SaveAssets();
            EditorUtility.DisplayDialog("ToyBox Blasters", "Created TargetAudienceConfig with Task 003 defaults.", "OK");
            Selection.activeObject = config;
        }

        [MenuItem("ToyBox Blasters/Product/Reset Target Audience To Defaults")]
        public static void ResetToDefaults()
        {
            var config = AssetDatabase.LoadAssetAtPath<TargetAudienceConfig>(ConfigPath);
            if (config == null)
            {
                CreateTargetAudienceConfig();
                return;
            }

            Undo.RecordObject(config, "Reset Target Audience");
            config.ApplyDefaults();
            EditorUtility.SetDirty(config);
            AssetDatabase.SaveAssets();
        }

        [MenuItem("ToyBox Blasters/Validate Target Audience")]
        public static void ValidateTargetAudience()
        {
            var config = AssetDatabase.LoadAssetAtPath<TargetAudienceConfig>(ConfigPath);
            if (config == null)
            {
                var create = EditorUtility.DisplayDialog(
                    "ToyBox Blasters",
                    "TargetAudienceConfig not found. Create it now?",
                    "Create",
                    "Cancel");
                if (create)
                    CreateTargetAudienceConfig();
                return;
            }

            var passed = TargetAudienceValidator.Validate(config, out var report);
            TargetAudienceDebug.LogValidation(passed, report);
            EditorUtility.DisplayDialog("Validate Target Audience", report, "OK");
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
