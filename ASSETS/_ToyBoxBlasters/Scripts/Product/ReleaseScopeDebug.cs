using UnityEngine;

namespace ToyBoxBlasters.Product
{
    public static class ReleaseScopeDebug
    {
        public static bool VerboseLogging =
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            true;
#else
            false;
#endif

        public static void LogSummary(ReleaseScopeConfig config)
        {
            if (!VerboseLogging || config == null)
                return;

            var featureCount = config.Features?.Count ?? 0;
            Debug.Log(
                $"[ToyBoxBlasters:Scope] MVP: {config.MvpScopeSummary}\n" +
                $"Features: {featureCount} | First playable: {config.FirstPlayablePrototypeGoal}");
        }

        public static void LogValidation(bool passed, string report)
        {
            if (!VerboseLogging)
                return;

            if (passed)
                Debug.Log($"[ToyBoxBlasters:Scope] {report}");
            else
                Debug.LogWarning($"[ToyBoxBlasters:Scope] Validation failed:\n{report}");
        }
    }
}
