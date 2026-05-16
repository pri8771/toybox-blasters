#if UNITY_EDITOR
using ToyBoxBlasters.Product;
using UnityEditor;

namespace ToyBoxBlasters.Editor.Product
{
    [InitializeOnLoad]
    public static class GameConceptValidationEditor
    {
        const string ConfigPath = "Assets/_ToyBoxBlasters/ScriptableObjects/Config/GameConceptConfig.asset";

        static GameConceptValidationEditor()
        {
            EditorApplication.delayCall += RunSilentValidationOnce;
        }

        static void RunSilentValidationOnce()
        {
            EditorApplication.delayCall -= RunSilentValidationOnce;
            var config = AssetDatabase.LoadAssetAtPath<GameConceptConfig>(ConfigPath);
            if (config == null)
                return;

            var passed = GameConceptValidator.Validate(config, out var report);
            GameConceptDebug.LogValidation(passed, report);
        }
    }
}
#endif
