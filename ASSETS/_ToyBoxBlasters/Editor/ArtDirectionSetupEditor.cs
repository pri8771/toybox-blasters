#if UNITY_EDITOR
using ToyBoxBlasters.Art;
using UnityEditor;
using UnityEngine;

namespace ToyBoxBlasters.Editor.Art
{
    public static class ArtDirectionSetupEditor
    {
        const string ConfigFolder = "Assets/_ToyBoxBlasters/ScriptableObjects/Config";
        const string ConfigPath = ConfigFolder + "/ArtDirectionConfig.asset";

        [MenuItem("ToyBox Blasters/Art/Create Art Direction Config")]
        public static void CreateArtDirectionConfig()
        {
            EnsureFolder();
            var existing = AssetDatabase.LoadAssetAtPath<ArtDirectionConfig>(ConfigPath);
            if (existing != null)
            {
                EditorUtility.DisplayDialog("ToyBox Blasters", "ArtDirectionConfig already exists.", "OK");
                Selection.activeObject = existing;
                return;
            }

            var config = ScriptableObject.CreateInstance<ArtDirectionConfig>();
            config.ApplyDefaults();
            AssetDatabase.CreateAsset(config, ConfigPath);
            AssetDatabase.SaveAssets();
            EditorUtility.DisplayDialog("ToyBox Blasters", "Created ArtDirectionConfig with Task 008 defaults.", "OK");
            Selection.activeObject = config;
        }

        [MenuItem("ToyBox Blasters/Art/Reset Art Direction To Defaults")]
        public static void ResetToDefaults()
        {
            var config = AssetDatabase.LoadAssetAtPath<ArtDirectionConfig>(ConfigPath);
            if (config == null)
            {
                CreateArtDirectionConfig();
                return;
            }

            Undo.RecordObject(config, "Reset Art Direction");
            config.ApplyDefaults();
            EditorUtility.SetDirty(config);
            AssetDatabase.SaveAssets();
        }

        [MenuItem("ToyBox Blasters/Validate Art Direction")]
        public static void ValidateArtDirection()
        {
            var config = AssetDatabase.LoadAssetAtPath<ArtDirectionConfig>(ConfigPath);
            if (config == null)
            {
                var create = EditorUtility.DisplayDialog(
                    "ToyBox Blasters",
                    "ArtDirectionConfig not found. Create it now?",
                    "Create",
                    "Cancel");
                if (create)
                    CreateArtDirectionConfig();
                return;
            }

            var passed = ArtDirectionValidator.Validate(config, out var report);
            ArtDirectionDebug.LogValidation(passed, report);
            EditorUtility.DisplayDialog("Validate Art Direction", report, "OK");
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
