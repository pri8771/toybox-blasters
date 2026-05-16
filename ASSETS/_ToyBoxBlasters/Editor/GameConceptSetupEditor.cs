#if UNITY_EDITOR
using ToyBoxBlasters.Product;
using UnityEditor;
using UnityEngine;

namespace ToyBoxBlasters.Editor.Product
{
    public static class GameConceptSetupEditor
    {
        const string ConfigFolder = "Assets/_ToyBoxBlasters/ScriptableObjects/Config";
        const string ConfigPath = ConfigFolder + "/GameConceptConfig.asset";

        [MenuItem("ToyBox Blasters/Product/Create Game Concept Config")]
        public static void CreateGameConceptConfig()
        {
            EnsureFolder();
            var existing = AssetDatabase.LoadAssetAtPath<GameConceptConfig>(ConfigPath);
            if (existing != null)
            {
                EditorUtility.DisplayDialog("ToyBox Blasters", "GameConceptConfig already exists.", "OK");
                Selection.activeObject = existing;
                return;
            }

            var config = ScriptableObject.CreateInstance<GameConceptConfig>();
            config.ApplyDefaults();
            AssetDatabase.CreateAsset(config, ConfigPath);
            AssetDatabase.SaveAssets();
            EditorUtility.DisplayDialog("ToyBox Blasters", "Created GameConceptConfig with Task 001 defaults.", "OK");
            Selection.activeObject = config;
        }

        [MenuItem("ToyBox Blasters/Product/Reset Game Concept To Defaults")]
        public static void ResetToDefaults()
        {
            var config = AssetDatabase.LoadAssetAtPath<GameConceptConfig>(ConfigPath);
            if (config == null)
            {
                CreateGameConceptConfig();
                return;
            }

            Undo.RecordObject(config, "Reset Game Concept");
            config.ApplyDefaults();
            EditorUtility.SetDirty(config);
            AssetDatabase.SaveAssets();
        }

        [MenuItem("ToyBox Blasters/Validate Game Concept")]
        public static void ValidateGameConcept()
        {
            var config = AssetDatabase.LoadAssetAtPath<GameConceptConfig>(ConfigPath);
            if (config == null)
            {
                var create = EditorUtility.DisplayDialog(
                    "ToyBox Blasters",
                    "GameConceptConfig not found. Create it now?",
                    "Create",
                    "Cancel");
                if (create)
                    CreateGameConceptConfig();
                return;
            }

            var passed = GameConceptValidator.Validate(config, out var report);
            GameConceptDebug.LogValidation(passed, report);

            if (passed)
                EditorUtility.DisplayDialog("Validate Game Concept", report, "OK");
            else
                EditorUtility.DisplayDialog("Validate Game Concept", report, "OK");
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
