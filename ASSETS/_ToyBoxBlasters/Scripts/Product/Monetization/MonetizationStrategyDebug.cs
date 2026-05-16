using UnityEngine;

namespace ToyBoxBlasters.Product.Monetization
{
    public static class MonetizationStrategyDebug
    {
        public static bool VerboseLogging =
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            true;
#else
            false;
#endif

        public static void LogSummary(MonetizationStrategyConfig config)
        {
            if (!VerboseLogging || config == null)
                return;

            var rules = config.AdFrequencyRules;
            Debug.Log(
                $"[ToyBoxBlasters:Monetization] {config.StrategySummary}\n" +
                $"Placements: {config.AdPlacements?.Count ?? 0} | V1 SKUs: {CountV1Skus(config)} | " +
                $"Interstitial min gap: {rules?.MinInterstitialIntervalSeconds}s | " +
                $"Rewarded/day cap: {rules?.MaxRewardedPerDay}");
        }

        public static void LogValidation(bool passed, string report)
        {
            if (!VerboseLogging)
                return;

            if (passed)
                Debug.Log($"[ToyBoxBlasters:Monetization] {report}");
            else
                Debug.LogWarning($"[ToyBoxBlasters:Monetization] Validation failed:\n{report}");
        }

        static int CountV1Skus(MonetizationStrategyConfig config)
        {
            var count = 0;
            if (config?.IapSkus == null)
                return 0;
            foreach (var s in config.IapSkus)
            {
                if (s != null && s.EnabledInV1)
                    count++;
            }

            return count;
        }
    }
}
