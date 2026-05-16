using UnityEngine;

namespace ToyBoxBlasters.Product
{
    public static class TargetAudienceDebug
    {
        public static bool VerboseLogging =
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            true;
#else
            false;
#endif

        public static void LogSummary(TargetAudienceConfig config)
        {
            if (!VerboseLogging || config == null)
                return;

            Debug.Log(
                $"[ToyBoxBlasters:Audience] {config.PrimaryPlayerSegment}\n" +
                $"Classification: {config.AudienceClassification} | " +
                $"Run: {config.SessionLengthPerRunMinutesMin}-{config.SessionLengthPerRunMinutesMax} min | " +
                $"Personas: {config.Personas?.Count ?? 0}");
        }

        public static void LogValidation(bool passed, string report)
        {
            if (!VerboseLogging)
                return;

            if (passed)
                Debug.Log($"[ToyBoxBlasters:Audience] {report}");
            else
                Debug.LogWarning($"[ToyBoxBlasters:Audience] Validation failed:\n{report}");
        }
    }
}
