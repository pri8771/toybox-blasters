#if UNITY_EDITOR
using ToyBoxBlasters.Product;
using UnityEditor;

namespace ToyBoxBlasters.Editor.Product
{
    [InitializeOnLoad]
    public static class ReleaseScopeValidationEditor
    {
        const string ConfigPath = "Assets/_ToyBoxBlasters/ScriptableObjects/Config/ReleaseScopeConfig.asset";

        static ReleaseScopeValidationEditor()
        {
            EditorApplication.delayCall += RunSilentValidationOnce;
        }

        static void RunSilentValidationOnce()
        {
            EditorApplication.delayCall -= RunSilentValidationOnce;
            var config = AssetDatabase.LoadAssetAtPath<ReleaseScopeConfig>(ConfigPath);
            if (config == null)
                return;

            var passed = ReleaseScopeValidator.Validate(config, out var report);
            ReleaseScopeDebug.LogValidation(passed, report);
        }
    }
}
#endif
