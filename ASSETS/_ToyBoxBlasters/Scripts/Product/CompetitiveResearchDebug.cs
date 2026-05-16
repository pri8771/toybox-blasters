using UnityEngine;

namespace ToyBoxBlasters.Product
{
    public static class CompetitiveResearchDebug
    {
        public static bool VerboseLogging =
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            true;
#else
            false;
#endif

        public static void LogSummary(CompetitiveResearchConfig config)
        {
            if (!VerboseLogging || config == null)
                return;

            var competitorCount = config.Competitors?.Count ?? 0;
            var diffCount = config.ToyBoxDifferentiators?.Count ?? 0;
            Debug.Log(
                $"[ToyBoxBlasters:Competitive] {config.TaskId} v{config.ResearchVersion} | " +
                $"{competitorCount} rows | {diffCount} differentiators (PRD §5)");
        }

        public static void LogValidation(bool passed, string report)
        {
            if (!VerboseLogging)
                return;

            if (passed)
                Debug.Log($"[ToyBoxBlasters:Competitive] {report}");
            else
                Debug.LogWarning($"[ToyBoxBlasters:Competitive] Validation failed:\n{report}");
        }

        public static void LogMatrixPreview(CompetitiveResearchConfig config, int maxRows = 5)
        {
            if (!VerboseLogging || config?.Competitors == null)
                return;

            var count = Mathf.Min(maxRows, config.Competitors.Count);
            for (var i = 0; i < count; i++)
            {
                var row = config.Competitors[i];
                if (row == null)
                    continue;
                Debug.Log($"[ToyBoxBlasters:Competitive] {row.Category}: {row.Name}");
            }
        }
    }
}
