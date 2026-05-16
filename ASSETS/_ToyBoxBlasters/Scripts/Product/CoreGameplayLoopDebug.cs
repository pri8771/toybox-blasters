using System.Text;
using UnityEngine;

namespace ToyBoxBlasters.Product
{
    public static class CoreGameplayLoopDebug
    {
        public static bool VerboseLogging =
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            true;
#else
            false;
#endif

        public static void LogSummary(CoreGameplayLoopConfig config)
        {
            if (!VerboseLogging || config == null)
                return;

            Debug.Log(
                $"[ToyBoxBlasters:Loop] {CoreGameplayLoopDefaults.WorldName} | " +
                $"Run {config.RunLengthMinutesMin}-{config.RunLengthMinutesMax} min | " +
                $"Fail: squad wipe, keep {config.PartialCoinsOnFailPercent}% coins\n" +
                BuildLoopIndex(config));
        }

        public static void LogValidation(bool passed, string report)
        {
            if (!VerboseLogging)
                return;

            if (passed)
                Debug.Log($"[ToyBoxBlasters:Loop] {report}");
            else
                Debug.LogWarning($"[ToyBoxBlasters:Loop] Validation failed:\n{report}");
        }

        static string BuildLoopIndex(CoreGameplayLoopConfig config)
        {
            var sb = new StringBuilder();
            foreach (var loop in config.Loops)
            {
                if (loop == null)
                    continue;
                sb.Append("  • ").Append(loop.LoopType).Append(": ").AppendLine(loop.Summary);
            }

            return sb.ToString();
        }
    }
}
