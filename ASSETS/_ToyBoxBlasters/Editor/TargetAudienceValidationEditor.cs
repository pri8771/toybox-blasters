#if UNITY_EDITOR
using ToyBoxBlasters.Product;
using UnityEditor;

namespace ToyBoxBlasters.Editor.Product
{
    [InitializeOnLoad]
    public static class TargetAudienceValidationEditor
    {
        const string ConfigPath = "Assets/_ToyBoxBlasters/ScriptableObjects/Config/TargetAudienceConfig.asset";

        static TargetAudienceValidationEditor()
        {
            EditorApplication.delayCall += RunSilentValidationOnce;
        }

        static void RunSilentValidationOnce()
        {
            EditorApplication.delayCall -= RunSilentValidationOnce;
            var config = AssetDatabase.LoadAssetAtPath<TargetAudienceConfig>(ConfigPath);
            if (config == null)
                return;

            var passed = TargetAudienceValidator.Validate(config, out var report);
            TargetAudienceDebug.LogValidation(passed, report);
        }
    }
}
#endif
