#if UNITY_EDITOR
using ToyBoxBlasters.Product;
using UnityEditor;

namespace ToyBoxBlasters.Editor.Product
{
    [InitializeOnLoad]
    public static class EconomyPhilosophyValidationEditor
    {
        const string ConfigPath = "Assets/_ToyBoxBlasters/ScriptableObjects/Config/EconomyPhilosophyConfig.asset";

        static EconomyPhilosophyValidationEditor()
        {
            EditorApplication.delayCall += RunSilentValidationOnce;
        }

        static void RunSilentValidationOnce()
        {
            EditorApplication.delayCall -= RunSilentValidationOnce;
            var config = AssetDatabase.LoadAssetAtPath<EconomyPhilosophyConfig>(ConfigPath);
            if (config == null)
                return;

            var passed = EconomyPhilosophyValidator.Validate(config, out var report);
            EconomyPhilosophyDebug.LogValidation(passed, report);
        }
    }
}
#endif
