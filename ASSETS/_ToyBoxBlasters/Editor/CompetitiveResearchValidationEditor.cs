#if UNITY_EDITOR
using ToyBoxBlasters.Product;
using UnityEditor;

namespace ToyBoxBlasters.Editor.Product
{
    [InitializeOnLoad]
    public static class CompetitiveResearchValidationEditor
    {
        const string ConfigPath = "Assets/_ToyBoxBlasters/ScriptableObjects/Config/CompetitiveResearchConfig.asset";

        static CompetitiveResearchValidationEditor()
        {
            EditorApplication.delayCall += RunSilentValidationOnce;
        }

        static void RunSilentValidationOnce()
        {
            EditorApplication.delayCall -= RunSilentValidationOnce;
            var config = AssetDatabase.LoadAssetAtPath<CompetitiveResearchConfig>(ConfigPath);
            if (config == null)
                return;

            var passed = CompetitiveResearchValidator.Validate(config, out var report);
            CompetitiveResearchDebug.LogValidation(passed, report);
        }
    }
}
#endif
