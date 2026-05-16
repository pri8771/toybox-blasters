using UnityEngine;

namespace ToyBoxBlasters.Product
{
    public static class GameConceptDebug
    {
        public static bool VerboseLogging =
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            true;
#else
            false;
#endif

        public static void LogSummary(GameConceptConfig config)
        {
            if (!VerboseLogging || config == null)
                return;

            Debug.Log(
                $"[ToyBoxBlasters:Concept] {config.GameName} | {config.Genre} | {config.FirstWorldName}\n" +
                $"Pitch: {config.OneSentencePitch}");
        }

        public static void LogValidation(bool passed, string report)
        {
            if (!VerboseLogging)
                return;

            if (passed)
                Debug.Log($"[ToyBoxBlasters:Concept] {report}");
            else
                Debug.LogWarning($"[ToyBoxBlasters:Concept] Validation failed:\n{report}");
        }
    }
}
