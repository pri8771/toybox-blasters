using System.Collections.Generic;

namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// Task 002 canonical scope. Keep in sync with PROJECT_DOCS/RELEASE_SCOPE.md.
    /// </summary>
    public static class ReleaseScopeDefaults
    {
        public const string MvpScopeSummary =
            "World 1 Bedroom: runner, steer, squad auto-fire, +/- gates, numbered obstacles, " +
            "slimes, 1 boss, coins, 3 meta upgrades, placeholder art, play/retry UI.";

        public const string SoftLaunchScopeSummary =
            "5-10 tuned levels, Firebase Analytics + Remote Config, balancing pass, " +
            "crash reporting, interstitial ad interfaces, TestFlight / Internal Testing builds.";

        public const string ProductionScopeSummary =
            "20+ levels, IAP shop, rewarded ads, live ops events, production VFX/audio, " +
            "EN + 1 language, ASO assets, retention and UA metric tuning.";

        public const string FirstPlayablePrototypeGoal =
            "Single vertical slice: run, steer, 1 gate, auto-fire vs 1 slime, break 1 obstacle, " +
            "reach lane end in under 3 minutes using placeholder art only.";

        public static readonly string[] V1Excluded =
        {
            "PvP or social features",
            "Guilds, clans, or chat",
            "Multiple concurrent live-op frameworks at launch",
            "More than 2 languages at global launch",
            "Console or PC ports",
            "User-generated content",
            "Deep narrative campaign with cutscenes",
            "Second world at global launch (roadmap only)",
            "Real-money gambling-style mechanics"
        };

        public static readonly string[] PostLaunchAdditions =
        {
            "World 2+ (Kitchen Counter, Backyard, etc.)",
            "Battle pass / season pass",
            "Daily quests and retention streaks",
            "Cosmetic squad skins (IAP)",
            "Leaderboards / async ghost runs",
            "Elite enemies and boss modifiers",
            "Cloud save cross-device",
            "Push notification retention hooks",
            "Advanced A/B experiment framework",
            "Referral / influencer campaigns"
        };

        public static readonly string[] ProductionSuccessCriteria =
        {
            "D1 retention >= 25% (refine after soft launch)",
            "Crash-free sessions >= 99.5%",
            "Average session length 2-4 minutes",
            "Store rating >= 4.2 on iOS and Android",
            "UA ROAS target TBD post soft launch",
            "World 1 level 1-5 boss reach rate >= 60%",
            "Cold load time < 5s on mid-tier Android"
        };

        public static List<FeatureScopeEntry> CreateDefaultFeatures()
        {
            return new List<FeatureScopeEntry>
            {
                F("runner_forward", "Auto-forward runner", FeaturePriority.P0, ReleasePhase.Mvp, true),
                F("drag_steer", "Drag left/right steering", FeaturePriority.P0, ReleasePhase.Mvp, true, "runner_forward"),
                F("squad_autofire", "Squad growth + auto-fire", FeaturePriority.P0, ReleasePhase.Mvp, true, "runner_forward"),
                F("upgrade_gates", "+/- upgrade gates", FeaturePriority.P0, ReleasePhase.Mvp, true, "runner_forward"),
                F("numbered_obstacles", "Numbered breakable obstacles", FeaturePriority.P0, ReleasePhase.Mvp, true, "squad_autofire"),
                F("slime_enemies", "Slime enemy type", FeaturePriority.P0, ReleasePhase.Mvp, true, "squad_autofire"),
                F("boss_dust_bunny", "Dust Bunny boss", FeaturePriority.P0, ReleasePhase.Mvp, true, "slime_enemies", "numbered_obstacles"),
                F("coins_pickup", "Coin pickups", FeaturePriority.P0, ReleasePhase.Mvp, true, "runner_forward"),
                F("meta_upgrades_x3", "3 permanent meta upgrades", FeaturePriority.P0, ReleasePhase.Mvp, true, "coins_pickup"),
                F("placeholder_art", "Placeholder art pipeline", FeaturePriority.P0, ReleasePhase.Mvp, true),
                F("basic_ui_play_retry", "Play / retry / HUD UI", FeaturePriority.P0, ReleasePhase.Mvp, true, "runner_forward"),
                F("world1_bedroom", "World 1 Bedroom content", FeaturePriority.P0, ReleasePhase.Mvp, true, "placeholder_art", "boss_dust_bunny"),
                F("local_save_optional", "Local save (offline)", FeaturePriority.P2, ReleasePhase.Mvp, false, "meta_upgrades_x3"),

                F("levels_5_10", "5-10 tuned levels", FeaturePriority.P0, ReleasePhase.SoftLaunch, true, "world1_bedroom"),
                F("balancing_pass", "Economy and combat balancing", FeaturePriority.P0, ReleasePhase.SoftLaunch, true, "levels_5_10", "meta_upgrades_x3"),
                F("firebase_analytics", "Firebase Analytics", FeaturePriority.P0, ReleasePhase.SoftLaunch, true),
                F("firebase_remote_config", "Firebase Remote Config", FeaturePriority.P0, ReleasePhase.SoftLaunch, true, "firebase_analytics"),
                F("crash_reporting", "Crash reporting (Crashlytics)", FeaturePriority.P0, ReleasePhase.SoftLaunch, true),
                F("ads_interstitial_interface", "Interstitial ads interface", FeaturePriority.P1, ReleasePhase.SoftLaunch, true),
                F("store_test_builds", "TestFlight / Internal Testing", FeaturePriority.P0, ReleasePhase.SoftLaunch, true, "levels_5_10", "crash_reporting"),

                F("levels_20_plus", "20+ levels at global launch", FeaturePriority.P0, ReleasePhase.Production, true, "levels_5_10"),
                F("iap_shop", "IAP shop", FeaturePriority.P0, ReleasePhase.Production, true, "meta_upgrades_x3"),
                F("ads_rewarded", "Rewarded video ads", FeaturePriority.P1, ReleasePhase.Production, true, "ads_interstitial_interface"),
                F("live_ops_events", "Live ops events (Remote Config)", FeaturePriority.P1, ReleasePhase.Production, true, "firebase_remote_config"),
                F("production_vfx_audio", "Production VFX and audio", FeaturePriority.P1, ReleasePhase.Production, true, "levels_20_plus"),
                F("localization_en_plus_one", "Localization EN + 1", FeaturePriority.P1, ReleasePhase.Production, true, "basic_ui_play_retry"),
                F("aso_store_assets", "ASO and store listing assets", FeaturePriority.P1, ReleasePhase.Production, true),
                F("retention_tuning", "Retention and session tuning", FeaturePriority.P1, ReleasePhase.Production, true, "firebase_analytics", "levels_20_plus")
            };
        }

        static FeatureScopeEntry F(
            string id,
            string name,
            FeaturePriority priority,
            ReleasePhase phase,
            bool mustHave,
            params string[] deps)
        {
            return new FeatureScopeEntry
            {
                id = id,
                displayName = name,
                priority = priority,
                releasePhase = phase,
                mustHave = mustHave,
                dependencies = deps.Length > 0 ? new List<string>(deps) : new List<string>()
            };
        }
    }
}
