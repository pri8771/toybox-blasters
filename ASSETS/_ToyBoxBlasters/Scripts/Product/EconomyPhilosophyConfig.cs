using System.Collections.Generic;
using UnityEngine;

namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// Task 006 — currencies, sources/sinks, ads, IAP ladder, anti-inflation rules.
    /// MVP implements coins in gameplay later; gems/event documented here for soft launch+.
    /// </summary>
    [CreateAssetMenu(
        fileName = "EconomyPhilosophyConfig",
        menuName = "ToyBox Blasters/Product/Economy Philosophy Config")]
    public sealed class EconomyPhilosophyConfig : ScriptableObject
    {
        [Header("Task 006")]
        [SerializeField] string taskId = EconomyPhilosophyDefaults.TaskId;
        [SerializeField] string philosophyVersion = EconomyPhilosophyDefaults.PhilosophyVersion;

        [TextArea(3, 6)]
        [SerializeField] string philosophySummary = EconomyPhilosophyDefaults.PhilosophySummary;

        [Header("Currencies (3)")]
        [SerializeField] List<CurrencyDefinitionEntry> currencies = new();

        [Header("Coin flows")]
        [SerializeField] List<EconomyFlowEntry> coinSources = new();
        [SerializeField] List<EconomyFlowEntry> coinSinks = new();

        [Header("Gem flows (not required V1 progress)")]
        [SerializeField] List<EconomyFlowEntry> gemSources = new();
        [SerializeField] List<EconomyFlowEntry> gemSinks = new();

        [Header("Event currency — Bedroom Tokens")]
        [SerializeField] List<EconomyFlowEntry> eventCurrencyFlows = new();

        [Header("IAP value ladder (no pay-to-win V1)")]
        [SerializeField] List<EconomyFlowEntry> iapOffers = new();

        [Header("Ad reward policy")]
        [Range(0f, 200f)]
        [SerializeField] float rewardedCoinBonusPercentMin = EconomyPhilosophyDefaults.RewardedCoinBonusPercentMin;

        [Range(0f, 200f)]
        [SerializeField] float rewardedCoinBonusPercentMax = EconomyPhilosophyDefaults.RewardedCoinBonusPercentMax;

        [SerializeField] int rewardedDailyCapMin = EconomyPhilosophyDefaults.RewardedDailyCapMin;
        [SerializeField] int rewardedDailyCapMax = EconomyPhilosophyDefaults.RewardedDailyCapMax;

        [SerializeField] bool rewardedOffersRevive = true;
        [SerializeField] bool rewardedOffersCoinDouble = true;

        [TextArea(2, 3)]
        [SerializeField] string interstitialPlacementRule = EconomyPhilosophyDefaults.InterstitialPlacementRule;

        [Header("Anti-inflation")]
        [SerializeField] List<string> antiInflationPrinciples = new();

        public string TaskId => taskId ?? string.Empty;
        public string PhilosophyVersion => philosophyVersion ?? string.Empty;
        public string PhilosophySummary => philosophySummary ?? string.Empty;
        public IReadOnlyList<CurrencyDefinitionEntry> Currencies => currencies ?? new List<CurrencyDefinitionEntry>();
        public IReadOnlyList<EconomyFlowEntry> CoinSources => coinSources ?? new List<EconomyFlowEntry>();
        public IReadOnlyList<EconomyFlowEntry> CoinSinks => coinSinks ?? new List<EconomyFlowEntry>();
        public IReadOnlyList<EconomyFlowEntry> GemSources => gemSources ?? new List<EconomyFlowEntry>();
        public IReadOnlyList<EconomyFlowEntry> GemSinks => gemSinks ?? new List<EconomyFlowEntry>();
        public IReadOnlyList<EconomyFlowEntry> EventCurrencyFlows => eventCurrencyFlows ?? new List<EconomyFlowEntry>();
        public IReadOnlyList<EconomyFlowEntry> IapOffers => iapOffers ?? new List<EconomyFlowEntry>();
        public float RewardedCoinBonusPercentMin => rewardedCoinBonusPercentMin;
        public float RewardedCoinBonusPercentMax => rewardedCoinBonusPercentMax;
        public int RewardedDailyCapMin => rewardedDailyCapMin;
        public int RewardedDailyCapMax => rewardedDailyCapMax;
        public bool RewardedOffersRevive => rewardedOffersRevive;
        public bool RewardedOffersCoinDouble => rewardedOffersCoinDouble;
        public string InterstitialPlacementRule => interstitialPlacementRule ?? string.Empty;
        public IReadOnlyList<string> AntiInflationPrinciples => antiInflationPrinciples ?? new List<string>();

        public bool TryGetCurrency(CurrencyKind kind, out CurrencyDefinitionEntry entry)
        {
            entry = null;
            if (currencies == null)
                return false;

            foreach (var currency in currencies)
            {
                if (currency != null && currency.Kind == kind)
                {
                    entry = currency;
                    return true;
                }
            }

            return false;
        }

#if UNITY_EDITOR
        public void ApplyDefaults()
        {
            taskId = EconomyPhilosophyDefaults.TaskId;
            philosophyVersion = EconomyPhilosophyDefaults.PhilosophyVersion;
            philosophySummary = EconomyPhilosophyDefaults.PhilosophySummary;
            currencies = EconomyPhilosophyDefaults.CreateDefaultCurrencies();
            coinSources = EconomyPhilosophyDefaults.CreateDefaultCoinSources();
            coinSinks = EconomyPhilosophyDefaults.CreateDefaultCoinSinks();
            gemSources = EconomyPhilosophyDefaults.CreateDefaultGemSources();
            gemSinks = EconomyPhilosophyDefaults.CreateDefaultGemSinks();
            eventCurrencyFlows = EconomyPhilosophyDefaults.CreateDefaultEventFlows();
            iapOffers = EconomyPhilosophyDefaults.CreateDefaultIapOffers();
            rewardedCoinBonusPercentMin = EconomyPhilosophyDefaults.RewardedCoinBonusPercentMin;
            rewardedCoinBonusPercentMax = EconomyPhilosophyDefaults.RewardedCoinBonusPercentMax;
            rewardedDailyCapMin = EconomyPhilosophyDefaults.RewardedDailyCapMin;
            rewardedDailyCapMax = EconomyPhilosophyDefaults.RewardedDailyCapMax;
            rewardedOffersRevive = true;
            rewardedOffersCoinDouble = true;
            interstitialPlacementRule = EconomyPhilosophyDefaults.InterstitialPlacementRule;
            antiInflationPrinciples = EconomyPhilosophyDefaults.CreateAntiInflationPrinciples();
        }
#endif
    }
}
