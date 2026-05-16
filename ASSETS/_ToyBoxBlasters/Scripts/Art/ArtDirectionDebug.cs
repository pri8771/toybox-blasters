using UnityEngine;

namespace ToyBoxBlasters.Art
{
    public static class ArtDirectionDebug
    {
        public static bool VerboseLogging =
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            true;
#else
            false;
#endif

        public static void LogSummary(ArtDirectionConfig config)
        {
            if (!VerboseLogging || config == null)
                return;

            Debug.Log(
                $"[ToyBoxBlasters:ArtDirection] {config.MoodBoardSummary}\n" +
                $"Hero {config.PlayerHeightMeters}m | Lane {config.LanePlayableWidthMeters}m | " +
                $"Heads {config.CharacterHeadHeightsMin}-{config.CharacterHeadHeightsMax}");
        }

        public static void LogValidation(bool passed, string report)
        {
            if (!VerboseLogging)
                return;

            if (passed)
                Debug.Log($"[ToyBoxBlasters:ArtDirection] {report}");
            else
                Debug.LogWarning($"[ToyBoxBlasters:ArtDirection] Validation failed:\n{report}");
        }
    }
}
