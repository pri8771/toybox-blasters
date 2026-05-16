using System;
using UnityEngine;

namespace ToyBoxBlasters.Product.Monetization
{
    /// <summary>Session and daily caps for ads. Tune via Remote Config in soft launch+.</summary>
    [Serializable]
    public sealed class AdFrequencyRules
    {
        [Header("Interstitial timing")]
        [Tooltip("Minimum seconds between interstitial impressions (design band 90–120).")]
        [SerializeField] float minInterstitialIntervalSeconds = MonetizationStrategyDefaults.MinInterstitialIntervalSeconds;

        [Tooltip("Maximum seconds between interstitials when eligible (upper band).")]
        [SerializeField] float maxInterstitialIntervalSeconds = MonetizationStrategyDefaults.MaxInterstitialIntervalSeconds;

        [SerializeField] int maxInterstitialsPerSession = MonetizationStrategyDefaults.MaxInterstitialsPerSession;

        [Header("Rewarded caps")]
        [SerializeField] int maxRewardedPerDay = MonetizationStrategyDefaults.MaxRewardedPerDay;

        [SerializeField] float rewardedCooldownSeconds = MonetizationStrategyDefaults.RewardedCooldownSeconds;

        [Header("New player grace")]
        [SerializeField] int newPlayerGraceRunsNoInterstitial = MonetizationStrategyDefaults.NewPlayerGraceRunsNoInterstitial;

        [Header("Forbidden contexts (policy flags)")]
        [SerializeField] bool blockInterstitialMidLevel = true;
        [SerializeField] bool blockInterstitialDuringBoss = true;

        public float MinInterstitialIntervalSeconds => minInterstitialIntervalSeconds;
        public float MaxInterstitialIntervalSeconds => maxInterstitialIntervalSeconds;
        public int MaxInterstitialsPerSession => maxInterstitialsPerSession;
        public int MaxRewardedPerDay => maxRewardedPerDay;
        public float RewardedCooldownSeconds => rewardedCooldownSeconds;
        public int NewPlayerGraceRunsNoInterstitial => newPlayerGraceRunsNoInterstitial;
        public bool BlockInterstitialMidLevel => blockInterstitialMidLevel;
        public bool BlockInterstitialDuringBoss => blockInterstitialDuringBoss;
    }
}
