#if UNITY_EDITOR
using ToyBoxBlasters.Product;
using UnityEditor;
using UnityEngine;

namespace ToyBoxBlasters.Editor.Product
{
    public static class ReleaseScopeSetupEditor
    {
        const string ConfigFolder = "Assets/_ToyBoxBlasters/ScriptableObjects/Config";
        const string ConfigPath = ConfigFolder + "/ReleaseScopeConfig.asset";

        [MenuItem("ToyBox Blasters/Product/Create Release Scope Config")]
        public static void CreateReleaseScopeConfig()
        {
            EnsureFolder();
            var existing = AssetDatabase.LoadAssetAtPath<ReleaseScopeConfig>(ConfigPath);
            if (existing != null)
            {
                EditorUtility.DisplayDialog("ToyBox Blasters", "ReleaseScopeConfig already exists.", "OK");
                Selection.activeObject = existing;
                return;
            }

            var config = ScriptableObject.CreateInstance<ReleaseScopeConfig>();
            config.ApplyDefaults();
            AssetDatabase.CreateAsset(config, ConfigPath);
            AssetDatabase.SaveAssets();
            EditorUtility.DisplayDialog("ToyBox Blasters", "Created ReleaseScopeConfig with Task 002 defaults.", "OK");
            Selection.activeObject = config;
        }

        [MenuItem("ToyBox Blasters/Product/Reset Release Scope To Defaults")]
        public static void ResetToDefaults()
        {
            var config = AssetDatabase.LoadAssetAtPath<ReleaseScopeConfig>(ConfigPath);
            if (config == null)
            {
                CreateReleaseScopeConfig();
                return;
            }

            Undo.RecordObject(config, "Reset Release Scope");
            config.ApplyDefaults();
            EditorUtility.SetDirty(config);
            AssetDatabase.SaveAssets();
        }

        [MenuItem("ToyBox Blasters/Validate Release Scope")]
        public static void ValidateReleaseScope()
        {
            var config = AssetDatabase.LoadAssetAtPath<ReleaseScopeConfig>(ConfigPath);
            if (config == null)
            {
                var create = EditorUtility.DisplayDialog(
                    "ToyBox Blasters",
                    "ReleaseScopeConfig not found. Create it now?",
                    "Create",
                    "Cancel");
                if (create)
                    CreateReleaseScopeConfig();
                return;
            }

            var passed = ReleaseScopeValidator.Validate(config, out var report);
            ReleaseScopeDebug.LogValidation(passed, report);
            EditorUtility.DisplayDialog("Validate Release Scope", report, "OK");
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
