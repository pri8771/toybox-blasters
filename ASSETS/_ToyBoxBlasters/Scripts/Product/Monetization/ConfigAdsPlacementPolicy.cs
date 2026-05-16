namespace ToyBoxBlasters.Product.Monetization
{
    /// <summary>Config-driven policy stub for dev/tests — not a live ad SDK.</summary>
    public sealed class ConfigAdsPlacementPolicy : IAdsPlacementPolicy
    {
        readonly MonetizationStrategyConfig _config;

        public ConfigAdsPlacementPolicy(MonetizationStrategyConfig config)
        {
            _config = config;
        }

        public bool CanShowInterstitial(AdPlacementId placementId, int completedRunsThisSession, int totalRunsLifetime)
        {
            if (_config == null || placementId == AdPlacementId.Unknown)
                return false;

            var rules = _config.AdFrequencyRules;
            if (rules == null)
                return false;

            if (totalRunsLifetime < rules.NewPlayerGraceRunsNoInterstitial)
                return false;

            if (placementId != AdPlacementId.FailScreenContinueHome &&
                placementId != AdPlacementId.VictoryReturnToMenu)
                return false;

            if (rules.BlockInterstitialMidLevel || rules.BlockInterstitialDuringBoss)
            {
                // Mid-level/boss blocks enforced by caller never requesting those placements.
            }

            return completedRunsThisSession < rules.MaxInterstitialsPerSession;
        }

        public bool CanShowRewarded(AdPlacementId placementId, int rewardedShownToday)
        {
            if (_config == null || placementId == AdPlacementId.Unknown)
                return false;

            var rules = _config.AdFrequencyRules;
            if (rules == null)
                return false;

            if (rewardedShownToday >= rules.MaxRewardedPerDay)
                return false;

            foreach (var p in _config.AdPlacements)
            {
                if (p == null || p.PlacementId != placementId)
                    continue;
                if (!p.EnabledInV1 && !p.PostV1Only)
                    return false;
                if (p.PostV1Only)
                    return false;
                return p.Kind == AdPlacementKind.Rewarded;
            }

            return false;
        }

        public float SecondsUntilNextInterstitialAllowed(float secondsSinceLastInterstitial)
        {
            if (_config?.AdFrequencyRules == null)
                return float.MaxValue;

            var min = _config.AdFrequencyRules.MinInterstitialIntervalSeconds;
            var remaining = min - secondsSinceLastInterstitial;
            return remaining > 0f ? remaining : 0f;
        }
    }
}
