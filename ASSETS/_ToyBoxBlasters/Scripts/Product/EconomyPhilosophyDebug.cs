using UnityEngine;

namespace ToyBoxBlasters.Product
{
    public static class EconomyPhilosophyDebug
    {
        public static bool VerboseLogging =
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            true;
#else
            false;
#endif

        public static void LogSummary(EconomyPhilosophyConfig config)
        {
            if (!VerboseLogging || config == null)
                return;

            Debug.Log(
                $"[ToyBoxBlasters:Economy] {config.TaskId} v{config.PhilosophyVersion}\n" +
                $"Coins MVP | Gems soft launch+ | Event: {EconomyPhilosophyDefaults.EventCurrencyDisplayName}\n" +
                $"Rewarded: {config.RewardedCoinBonusPercentMin}-{config.RewardedCoinBonusPercentMax}% bonus, " +
                $"cap {config.RewardedDailyCapMin}-{config.RewardedDailyCapMax}/day");
        }

        public static void LogValidation(bool passed, string report)
        {
            if (!VerboseLogging)
                return;

            if (passed)
                Debug.Log($"[ToyBoxBlasters:Economy] {report}");
            else
                Debug.LogWarning($"[ToyBoxBlasters:Economy] Validation failed:\n{report}");
        }

        public static void LogCurrencyMatrix(EconomyPhilosophyConfig config, int maxRows = 6)
        {
            if (!VerboseLogging || config == null)
                return;

            LogFlowList("Coin sources", config.CoinSources, maxRows);
            LogFlowList("Coin sinks", config.CoinSinks, maxRows);
        }

        static void LogFlowList(string label, System.Collections.Generic.IReadOnlyList<EconomyFlowEntry> flows, int maxRows)
        {
            if (flows == null)
                return;

            var count = Mathf.Min(maxRows, flows.Count);
            for (var i = 0; i < count; i++)
            {
                var flow = flows[i];
                if (flow == null)
                    continue;
                Debug.Log($"[ToyBoxBlasters:Economy] {label}: {flow.FlowId} ({flow.ReleasePhase})");
            }
        }
    }
}
