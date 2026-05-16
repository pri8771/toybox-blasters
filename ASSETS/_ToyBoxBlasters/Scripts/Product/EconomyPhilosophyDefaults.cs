using System.Collections.Generic;

namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// Canonical Task 006 economy philosophy. Keep in sync with PROJECT_DOCS/ECONOMY_PHILOSOPHY.md.
    /// </summary>
    public static class EconomyPhilosophyDefaults
    {
        public const string TaskId = "Task 006 — Game Economy Philosophy (Phase 1)";
        public const string PhilosophyVersion = "1.0";

        public const string PhilosophySummary =
            "Hybrid-casual general-audience economy: coins drive permanent meta power in 2–4 min sessions; " +
            "gems and Bedroom Tokens are optional monetization/LiveOps layers (doc + config in V1, gameplay coins-only in MVP). " +
            "No pay-to-win power bundles. Tuning via Firebase Remote Config; sinks before new sources; anti-inflation curves.";

        public const string EventCurrencyDisplayName = "Bedroom Tokens";

        // --- Ad reward policy (subtask 8) ---
        public const float RewardedCoinBonusPercentMin = 50f;
        public const float RewardedCoinBonusPercentMax = 100f;
        public const int RewardedDailyCapMin = 5;
        public const int RewardedDailyCapMax = 8;
        public const string InterstitialPlacementRule =
            "Interstitials only between runs (results → menu / next level), never mid-combat or during boss patterns.";

        // --- Anti-inflation (subtask 10) ---
        public const string UpgradeCostCurveRule =
            "Permanent meta upgrades use escalating coin costs per level (exponential or stepped curve); " +
            "remote-config caps on max level and cost multiplier.";

        public const string AdDoubleDiminishingReturnsRule =
            "Repeat rewarded 2× end-of-run doubles apply diminishing bonus % per use same day (e.g. 100% → 75% → 50% floor).";

        public const string RemoteConfigCapRule =
            "All earn rates, IAP grants, ad caps, and upgrade costs expose Firebase Remote Config keys with hard server-side max clamps.";

        public const string SinkBeforeSourceRule =
            "When adding a new coin source, ship or schedule a matching sink (upgrade tier, cosmetic, event shop) in the same release train.";

        public const string EventCurrencyBurnRule =
            "Bedroom Tokens expire at event end; optional last-chance sink (cosmetic, booster, or conversion to coins at reduced rate) before burn.";

        public static List<CurrencyDefinitionEntry> CreateDefaultCurrencies()
        {
            return new List<CurrencyDefinitionEntry>
            {
                new(
                    CurrencyKind.SoftCoins,
                    "Coins",
                    "coins",
                    "Primary earn/spend for permanent meta upgrades (damage, fire rate, starting squad). MVP gameplay currency.",
                    ReleasePhase.Mvp,
                    eventExpires: false,
                    requiredV1: true,
                    "economy_coins_"),

                new(
                    CurrencyKind.PremiumGems,
                    "Gems",
                    "gems",
                    "Paid + rare earn; cosmetics, skips, event shop exclusives. NOT required to progress V1.",
                    ReleasePhase.SoftLaunch,
                    eventExpires: false,
                    requiredV1: false,
                    "economy_gems_"),

                new(
                    CurrencyKind.EventBedroomTokens,
                    EventCurrencyDisplayName,
                    "bedroom_tokens",
                    "Limited-time LiveOps currency for seasonal bedroom events; expires after event window.",
                    ReleasePhase.Production,
                    eventExpires: true,
                    requiredV1: false,
                    "economy_event_tokens_")
            };
        }

        public static List<EconomyFlowEntry> CreateDefaultCoinSources()
        {
            return new List<EconomyFlowEntry>
            {
                Flow("coin_source_level_complete", CurrencyKind.SoftCoins, EconomyFlowKind.Source,
                    "Level complete", "Victory payout after boss or level end.", ReleasePhase.Mvp, "TBD: 80–200 base + scaling"),
                Flow("coin_source_obstacle_break", CurrencyKind.SoftCoins, EconomyFlowKind.Source,
                    "Obstacle breaks", "Per numbered cardboard segment destroyed.", ReleasePhase.Mvp, "TBD: 2–8 per HP chunk"),
                Flow("coin_source_enemy_kill", CurrencyKind.SoftCoins, EconomyFlowKind.Source,
                    "Enemy kills", "Slime and wave enemies on death.", ReleasePhase.Mvp, "TBD: 1–5 per kill"),
                Flow("coin_source_boss_bonus", CurrencyKind.SoftCoins, EconomyFlowKind.Source,
                    "Boss bonus", "Dust Bunny King defeat chest burst.", ReleasePhase.Mvp, "TBD: 50–150 bonus"),
                Flow("coin_source_daily_login", CurrencyKind.SoftCoins, EconomyFlowKind.Source,
                    "Daily login", "Streak calendar grant.", ReleasePhase.SoftLaunch, "TBD: 25–100 by streak day"),
                Flow("coin_source_rewarded_ad_2x", CurrencyKind.SoftCoins, EconomyFlowKind.Source,
                    "Rewarded ad 2× end-of-run", "Optional double coins on results screen.", ReleasePhase.SoftLaunch,
                    "TBD: +50–100% of run total; diminishing returns same day"),
                Flow("coin_source_achievements", CurrencyKind.SoftCoins, EconomyFlowKind.Source,
                    "Achievements", "One-time or milestone achievement grants.", ReleasePhase.SoftLaunch, "TBD: 50–500 lump sums")
            };
        }

        public static List<EconomyFlowEntry> CreateDefaultCoinSinks()
        {
            return new List<EconomyFlowEntry>
            {
                Flow("coin_sink_upgrade_damage", CurrencyKind.SoftCoins, EconomyFlowKind.Sink,
                    "Upgrade — damage", "Permanent squad damage toy upgrade.", ReleasePhase.Mvp, "TBD: escalating curve L1–L20"),
                Flow("coin_sink_upgrade_fire_rate", CurrencyKind.SoftCoins, EconomyFlowKind.Sink,
                    "Upgrade — fire rate", "Permanent fire rate toy upgrade.", ReleasePhase.Mvp, "TBD: escalating curve"),
                Flow("coin_sink_upgrade_starting_squad", CurrencyKind.SoftCoins, EconomyFlowKind.Sink,
                    "Upgrade — starting squad", "Permanent starting squad size upgrade.", ReleasePhase.Mvp, "TBD: escalating curve"),
                Flow("coin_sink_gate_reroll", CurrencyKind.SoftCoins, EconomyFlowKind.Sink,
                    "Gate reroll (optional)", "Re-roll last gate outcome; post-V1 optional.", ReleasePhase.Production,
                    "TBD: 100–300 coins or gem alt"),
                Flow("coin_sink_continue_run", CurrencyKind.SoftCoins, EconomyFlowKind.Sink,
                    "Continue run once (optional)", "Single continue after squad wipe; optional soft currency sink.", ReleasePhase.Production,
                    "TBD: 150–400 coins; gem/revive ad alt")
            };
        }

        public static List<EconomyFlowEntry> CreateDefaultGemSources()
        {
            return new List<EconomyFlowEntry>
            {
                Flow("gem_source_iap_packs", CurrencyKind.PremiumGems, EconomyFlowKind.Source,
                    "IAP packs", "Store gem bundles $0.99–$19.99.", ReleasePhase.Production, "TBD: see IAP ladder"),
                Flow("gem_source_battle_pass", CurrencyKind.PremiumGems, EconomyFlowKind.Source,
                    "Battle pass tiers", "Free/premium track milestones.", ReleasePhase.Production, "TBD: 5–20 per tier"),
                Flow("gem_source_level_milestones", CurrencyKind.PremiumGems, EconomyFlowKind.Source,
                    "Rare level milestones", "Sparse gem drip on world/level milestones.", ReleasePhase.SoftLaunch, "TBD: 1–5 every N levels"),
                Flow("gem_source_event_rewards", CurrencyKind.PremiumGems, EconomyFlowKind.Source,
                    "Event rewards", "LiveOps completion grants.", ReleasePhase.Production, "TBD: event tables")
            };
        }

        public static List<EconomyFlowEntry> CreateDefaultGemSinks()
        {
            return new List<EconomyFlowEntry>
            {
                Flow("gem_sink_cosmetic_skins", CurrencyKind.PremiumGems, EconomyFlowKind.Sink,
                    "Cosmetic skins", "Squad toy skins — no combat stats.", ReleasePhase.Production, "TBD: 100–800 gems"),
                Flow("gem_sink_trail_vfx", CurrencyKind.PremiumGems, EconomyFlowKind.Sink,
                    "Trail VFX", "Projectile/trail cosmetics.", ReleasePhase.Production, "TBD: 50–400 gems"),
                Flow("gem_sink_no_ads_partial", CurrencyKind.PremiumGems, EconomyFlowKind.Sink,
                    "No-ads bundle partial", "Gem component of remove-ads / starter bundles.", ReleasePhase.Production, "Bundled with IAP"),
                Flow("gem_sink_event_shop", CurrencyKind.PremiumGems, EconomyFlowKind.Sink,
                    "Event shop exclusives", "Rotating LiveOps offers.", ReleasePhase.Production, "TBD: event pricing"),
                Flow("gem_sink_revive_convenience", CurrencyKind.PremiumGems, EconomyFlowKind.Sink,
                    "Revive convenience", "Gem revive when ad unavailable; weekly cap.", ReleasePhase.Production,
                    "TBD: 20–40 gems; cap 3–5/week via Remote Config")
            };
        }

        public static List<EconomyFlowEntry> CreateDefaultEventFlows()
        {
            return new List<EconomyFlowEntry>
            {
                Flow("event_source_liveops", CurrencyKind.EventBedroomTokens, EconomyFlowKind.Source,
                    "LiveOps event tasks", "Daily/weekly event objectives.", ReleasePhase.Production, "TBD: 10–50 per task"),
                Flow("event_sink_event_shop", CurrencyKind.EventBedroomTokens, EconomyFlowKind.Sink,
                    "Event shop", "Limited cosmetics and boosters.", ReleasePhase.Production, "TBD: token prices"),
                Flow("event_sink_end_burn", CurrencyKind.EventBedroomTokens, EconomyFlowKind.Sink,
                    "End-of-event burn", "Unspent tokens removed; optional conversion sink.", ReleasePhase.Production,
                    "Burn at event end; optional 50% coin conversion")
            };
        }

        public static List<EconomyFlowEntry> CreateDefaultIapOffers()
        {
            return new List<EconomyFlowEntry>
            {
                Flow("iap_remove_ads", CurrencyKind.PremiumGems, EconomyFlowKind.Sink,
                    "Remove ads", "$4.99 — no interstitials; rewarded remains opt-in.", ReleasePhase.Production, "$4.99"),
                Flow("iap_starter_pack", CurrencyKind.PremiumGems, EconomyFlowKind.Sink,
                    "Starter pack", "$2.99 — small gem + cosmetic; no power.", ReleasePhase.Production, "$2.99"),
                Flow("iap_gem_pack_small", CurrencyKind.PremiumGems, EconomyFlowKind.Sink,
                    "Gem pack — small", "$0.99 entry gem pack.", ReleasePhase.Production, "$0.99"),
                Flow("iap_gem_pack_large", CurrencyKind.PremiumGems, EconomyFlowKind.Sink,
                    "Gem pack — large", "$19.99 top gem pack.", ReleasePhase.Production, "$19.99"),
                Flow("iap_cosmetic_bundle", CurrencyKind.PremiumGems, EconomyFlowKind.Sink,
                    "Cosmetic bundle", "$4.99–$9.99 skin/VFX bundles; no stat power.", ReleasePhase.Production, "$4.99–$9.99")
            };
        }

        public static List<string> CreateAntiInflationPrinciples()
        {
            return new List<string>
            {
                UpgradeCostCurveRule,
                AdDoubleDiminishingReturnsRule,
                RemoteConfigCapRule,
                SinkBeforeSourceRule,
                EventCurrencyBurnRule
            };
        }

        static EconomyFlowEntry Flow(
            string id,
            CurrencyKind currency,
            EconomyFlowKind kind,
            string name,
            string description,
            ReleasePhase phase,
            string tuning,
            string rcKey = "")
        {
            return new EconomyFlowEntry(id, currency, kind, name, description, phase, tuning, rcKey);
        }
    }
}
