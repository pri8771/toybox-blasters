using System.Collections.Generic;

namespace ToyBoxBlasters.Product.Monetization
{
    /// <summary>
    /// Canonical Task 007 values. Keep in sync with PROJECT_DOCS/MONETIZATION_STRATEGY.md
    /// and economy sources/sinks (Task 006 / ECONOMY_PHILOSOPHY.md when present).
    /// </summary>
    public static class MonetizationStrategyDefaults
    {
        public const string StrategySummary =
            "Hybrid-casual monetization: optional rewarded boosts, low-pressure interstitials between runs only, " +
            "cosmetic/convenience IAP, no pay-to-win (no PvP). MVP has no live ads/IAP SDK; config + interfaces only.";

        public const string EconomyAlignmentNote =
            "Coins: primary meta currency (runs, 2x rewarded, coin packs). Gems: soft currency for cosmetics/convenience — " +
            "never sole power progression in V1. No-ads removes interstitials only; rewarded stay optional.";

        public const float MinInterstitialIntervalSeconds = 90f;
        public const float MaxInterstitialIntervalSeconds = 120f;
        public const int MaxInterstitialsPerSession = 4;
        public const int MaxRewardedPerDay = 6;
        public const float RewardedCooldownSeconds = 30f;
        public const int NewPlayerGraceRunsNoInterstitial = 3;

        public const float NoAdsPriceUsd = 4.99f;
        public const float StarterPackPriceUsd = 2.99f;
        public const int StarterPackOfferWindowHours = 72;

        public const string BattlePassV1Note =
            "Battle pass: soft launch+ seasons (4–6 weeks), free + premium track, cosmetics + currency. " +
            "Document-only in V1 — no SKU enabled until post-global roadmap.";

        public const string FamilyFriendlyDisclosure =
            "Disclose ads and purchases clearly; restore purchases on iOS/Android; no dark patterns; " +
            "rewarded buttons labeled optional; interstitials never during combat.";

        public static AdFrequencyRules CreateDefaultFrequencyRules() => new();

        public static IReadOnlyList<AdPlacementId> RequiredRewardedPlacementIds { get; } = new[]
        {
            AdPlacementId.EndRun2xCoins,
            AdPlacementId.ReviveOncePerRun,
            AdPlacementId.DailyBonusChest
        };

        public static IReadOnlyList<AdPlacementId> RequiredInterstitialPlacementIds { get; } = new[]
        {
            AdPlacementId.FailScreenContinueHome,
            AdPlacementId.VictoryReturnToMenu
        };

        public static List<AdPlacementEntry> CreateDefaultAdPlacements()
        {
            return new List<AdPlacementEntry>
            {
                new(
                    AdPlacementId.EndRun2xCoins,
                    AdPlacementKind.Rewarded,
                    "End of run — 2× coins",
                    "Optional rewarded after results screen; doubles run coin payout (respect daily cap).",
                    true,
                    false,
                    "Source: run coins (sink if skipped). See economy: coin_run_reward"),
                new(
                    AdPlacementId.ReviveOncePerRun,
                    AdPlacementKind.Rewarded,
                    "Revive once per run",
                    "Optional rewarded revive at fail point; max once per run.",
                    true,
                    false,
                    "Sink: failed run progress; Source: continue run state"),
                new(
                    AdPlacementId.DailyBonusChest,
                    AdPlacementKind.Rewarded,
                    "Daily bonus chest",
                    "Once per calendar day; coins/gems/cosmetic shard roll.",
                    true,
                    false,
                    "Source: daily_login_reward"),
                new(
                    AdPlacementId.GatePreviewReroll,
                    AdPlacementKind.Rewarded,
                    "Gate preview reroll (post-V1)",
                    "Optional reroll next gate preview; not in V1 build.",
                    false,
                    true,
                    "Sink: gate RNG; Source: player choice quality"),
                new(
                    AdPlacementId.FailScreenContinueHome,
                    AdPlacementKind.Interstitial,
                    "Fail screen → Home",
                    "After fail screen when player taps Continue/Home; not during level or boss.",
                    true,
                    false,
                    "N/A — monetization surface only"),
                new(
                    AdPlacementId.VictoryReturnToMenu,
                    AdPlacementKind.Interstitial,
                    "Victory → Main menu",
                    "After victory flow when returning to menu; not mid-level.",
                    true,
                    false,
                    "N/A — monetization surface only")
            };
        }

        public static List<IapSkuEntry> CreateDefaultIapSkus()
        {
            return new List<IapSkuEntry>
            {
                new(
                    "iap_no_ads",
                    IapSkuType.NoAds,
                    "Remove ads",
                    "Removes interstitials. Rewarded ads remain optional. Restore purchases supported.",
                    NoAdsPriceUsd,
                    true,
                    false,
                    0,
                    0,
                    0,
                    string.Empty,
                    0,
                    "Removes ad friction; does not grant power"),
                new(
                    "iap_starter_pack",
                    IapSkuType.StarterPack,
                    "Starter pack",
                    "One-time: gems + coins + exclusive toy skin (cosmetic). First 72h new-player offer.",
                    StarterPackPriceUsd,
                    true,
                    true,
                    StarterPackOfferWindowHours,
                    2500,
                    120,
                    "skin_starter_toy_exclusive",
                    15,
                    "Source: coins/gems/cosmetic; limited FOMO window"),
                new(
                    "iap_coin_small",
                    IapSkuType.CoinPack,
                    "Coin pouch",
                    "Small coin pack — ~10% bonus vs equivalent grinding time.",
                    0.99f,
                    true,
                    false,
                    0,
                    800,
                    0,
                    string.Empty,
                    10,
                    "Source: coins (meta upgrades sink)"),
                new(
                    "iap_coin_medium",
                    IapSkuType.CoinPack,
                    "Coin chest",
                    "Medium coin pack — ~15% bonus vs grinding.",
                    4.99f,
                    true,
                    false,
                    0,
                    5000,
                    0,
                    string.Empty,
                    15,
                    "Source: coins"),
                new(
                    "iap_coin_large",
                    IapSkuType.CoinPack,
                    "Coin vault",
                    "Large coin pack — ~25% bonus vs grinding.",
                    9.99f,
                    true,
                    false,
                    0,
                    12000,
                    0,
                    string.Empty,
                    25,
                    "Source: coins"),
                new(
                    "iap_gem_tier1",
                    IapSkuType.GemPack,
                    "Gem handful",
                    "Entry gem pack for cosmetics/convenience — not required for power.",
                    0.99f,
                    true,
                    false,
                    0,
                    0,
                    40,
                    string.Empty,
                    0,
                    "Source: gems (cosmetic shop sink)"),
                new(
                    "iap_gem_tier2",
                    IapSkuType.GemPack,
                    "Gem pouch",
                    "Mid gem pack.",
                    4.99f,
                    true,
                    false,
                    0,
                    0,
                    250,
                    string.Empty,
                    10,
                    "Source: gems"),
                new(
                    "iap_gem_tier3",
                    IapSkuType.GemPack,
                    "Gem chest",
                    "Large gem pack.",
                    9.99f,
                    true,
                    false,
                    0,
                    0,
                    550,
                    string.Empty,
                    15,
                    "Source: gems"),
                new(
                    "iap_gem_tier4",
                    IapSkuType.GemPack,
                    "Gem vault",
                    "Top gem pack.",
                    19.99f,
                    true,
                    false,
                    0,
                    0,
                    1200,
                    string.Empty,
                    20,
                    "Source: gems"),
                new(
                    "iap_cosmetic_hero_trail",
                    IapSkuType.CosmeticBundle,
                    "Hero + trail bundle",
                    "Hero skin + projectile trail — no gameplay stats.",
                    4.99f,
                    true,
                    false,
                    0,
                    0,
                    0,
                    "bundle_hero_trail_v1",
                    0,
                    "Sink: cosmetic inventory"),
                new(
                    "iap_cosmetic_squad_colors",
                    IapSkuType.CosmeticBundle,
                    "Squad color variants",
                    "Team tint variants for squad members.",
                    4.99f,
                    true,
                    false,
                    0,
                    0,
                    0,
                    "bundle_squad_colors_v1",
                    0,
                    "Sink: cosmetic inventory"),
                new(
                    "iap_cosmetic_bedroom_theme",
                    IapSkuType.CosmeticBundle,
                    "Bedroom theme pack",
                    "UI/ambient bedroom theme — production polish target.",
                    9.99f,
                    true,
                    false,
                    0,
                    0,
                    80,
                    "bundle_bedroom_theme_v1",
                    0,
                    "Sink: theme unlock"),
                new(
                    "iap_battle_pass_season",
                    IapSkuType.BattlePass,
                    "Battle pass (later)",
                    BattlePassV1Note,
                    7.99f,
                    false,
                    false,
                    0,
                    0,
                    0,
                    string.Empty,
                    0,
                    "Post-V1 — cosmetics + currency tracks")
            };
        }

        public static List<MonetizationKpiEntry> CreateDefaultKpis()
        {
            return new List<MonetizationKpiEntry>
            {
                new(
                    "arpdau",
                    "ARPDAU",
                    "Blended ad + IAP revenue per DAU. Target band TBD after soft launch.",
                    "Do not trade D1 retention for ARPDAU spikes >15% week-over-week without investigation"),
                new(
                    "ad_ltv",
                    "Ad LTV",
                    "Rewarded + interstitial eCPM × impressions per cohort D7/D30.",
                    "Cap interstitial frequency if eCPM chase hurts session length"),
                new(
                    "iap_conversion",
                    "IAP conversion %",
                    "% of DAU making any IAP (7-day rolling).",
                    "Starter pack should lift conversion without harming no-ads attach"),
                new(
                    "rewarded_opt_in",
                    "Rewarded opt-in %",
                    "% of eligible surfaces where player completes rewarded.",
                    "If opt-in <20% on 2× coins, revisit copy and reward size"),
                new(
                    "no_ads_attach",
                    "No-ads attach %",
                    "% of payers or D30 users owning no-ads SKU.",
                    "Interstitial load must drop to zero for owners"),
                new(
                    "retention_monetization",
                    "Retention vs monetization",
                    "D1/D7 retention vs ad/IAP intensity cohorts.",
                    "Guardrail: D1 retention must not drop >3pp vs low-monetization control")
            };
        }
    }
}
