using System.Collections.Generic;

namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// Canonical Task 005 loop definitions. Keep in sync with PROJECT_DOCS/CORE_GAMEPLAY_LOOP.md.
    /// </summary>
    public static class CoreGameplayLoopDefaults
    {
        public const string WorldName = "Bedroom Floor";
        public const string BossName = "Dust Bunny King";

        /// <summary>Primary fail condition for MVP. Timer fail is post-MVP optional.</summary>
        public const string FailureRuleSummary =
            "Run ends when squad count reaches 0 (all toy blasters destroyed by enemies, boss, or lethal hazards). " +
            "Optional level timer may be added post-MVP via LevelTimingConfig — not required for Task 005.";

        /// <summary>Coins banked on fail screen before meta spend (design %).</summary>
        public const float PartialCoinsOnFailPercent = 50f;

        public const float RunLengthMinutesMin = 2f;
        public const float RunLengthMinutesMax = 4f;
        public const float SessionLengthMinutesMin = 8f;
        public const float SessionLengthMinutesMax = 15f;
        public const int RunsPerSessionMin = 1;
        public const int RunsPerSessionMax = 3;

        public const string GemsAvailability =
            "Coins are primary meta currency in MVP. Gems optional soft launch+ for shop rotations and cosmetics.";

        public static List<LoopDefinitionEntry> CreateDefaultLoops()
        {
            return new List<LoopDefinitionEntry>
            {
                L(
                    GameplayLoopType.MomentToMoment,
                    "Moment-to-moment",
                    "Auto-run forward, drag steer, squad auto-fire, dodge/spread, readable +/- gates.",
                    "The captain never stops charging across the bedroom floor. The player drags horizontally to steer " +
                    "the squad within lane bounds while every toy blaster auto-fires at the nearest threats. Moment-to-moment " +
                    "tension comes from gate readability (color/icon/size), enemy telegraphs, and choosing when to thread " +
                    "through negative gates for a trade-off. Squad members spread slightly for dodge readability; collisions " +
                    "compress the formation. All numeric tuning lives in gate, weapon, and squad ScriptableObjects.",
                    "loop_moment",
                    LoopImplementationPhase.Mvp,
                    new[]
                    {
                        "Auto-forward runner along spline/lane",
                        "Drag horizontal → steer squad across lane width",
                        "Squad auto-targets enemies in arc; VFX for hits",
                        "Pass +/- gates — instant squad/stat change feedback",
                        "Dodge slime projectiles / spread on hazard telegraph",
                        "Read gate labels at portrait distance (icon + number)"
                    },
                    Persona(AudiencePersonaDefaults.PersonaIdCasual, AudiencePersonaDefaults.PersonaIdProgression),
                    new[] { "SquadConfig", "WeaponToyConfig", "GateDefinitionConfig", "RunnerSpeedConfig" }),

                L(
                    GameplayLoopType.Level,
                    "Level loop",
                    "Start → gates → enemies → obstacles → mini-spike → boss → victory coin burst.",
                    "A single Bedroom Floor level is a 2–4 minute authored beat sequence: intro run, teaching gates, " +
                    "slime waves, numbered cardboard obstacles that gate DPS checks, a short difficulty spike (mini-spike), " +
                    "then the Dust Bunny King boss arena. Victory grants a coin burst and returns to results. MVP: 1 vertical " +
                    "slice level; soft launch: 5–10 tuned levels per RELEASE_SCOPE.",
                    "loop_level",
                    LoopImplementationPhase.Mvp,
                    new[]
                    {
                        "Level start — squad spawns at meta starting size",
                        "Gate corridor — +/- choices",
                        "Enemy wave — slime placeholders",
                        "Obstacle lane — shoot numbered cardboard HP to zero",
                        "Mini-spike — denser wave or dual obstacle",
                        "Boss — Dust Bunny patterns (telegraphed)",
                        "Victory — coin burst + results UI"
                    },
                    Persona(AudiencePersonaDefaults.PersonaIdCasual, AudiencePersonaDefaults.PersonaIdProgression),
                    new[] { "LevelSequenceConfig", "ObstacleHpConfig", "BossPatternConfig", "CoinRewardConfig" }),

                L(
                    GameplayLoopType.Session,
                    "Session loop",
                    "Menu → 1–3 runs → meta spend → optional ad → exit (2–4 min/run, 8–15 min session).",
                    "A typical session opens on the bedroom hub menu. The player launches 1–3 runs (Casual Casey) or more " +
                    "when optimizing (Progression Pat). Between runs they spend coins on permanent toys, skim upgrade previews, " +
                    "and optionally watch a rewarded ad for 2× coins or a revive (interfaces only in MVP). Session ends when " +
                    "the player exits to OS — target 8–15 minutes total engagement aligned with Task 003 personas.",
                    "loop_session",
                    LoopImplementationPhase.Mvp,
                    new[]
                    {
                        "Main menu / bedroom hub",
                        "Play → load level",
                        "Run loop (2–4 min)",
                        "Results → coins to wallet",
                        "Meta shop visit (optional between runs)",
                        "Optional rewarded ad prompt (soft launch+ behavior)",
                        "Exit app or return later"
                    },
                    Persona(
                        AudiencePersonaDefaults.PersonaIdCasual,
                        AudiencePersonaDefaults.PersonaIdProgression,
                        AudiencePersonaDefaults.PersonaIdAdWatcher),
                    new[] { "SessionEconomyConfig", "MenuFlowConfig" }),

                L(
                    GameplayLoopType.LongTermProgression,
                    "Long-term progression",
                    "Permanent upgrades (damage, fire rate, starting squad); world unlocks post-V1; player level optional.",
                    "Coins fund permanent stat toys in the meta shop — damage, fire rate, and starting squad size for MVP (3 upgrades). " +
                    "World 2+ (Kitchen Counter, Backyard) unlock after V1 per RELEASE_SCOPE. Optional account player level " +
                    "can gate cosmetics or live ops — soft launch+ only; not required for vertical slice.",
                    "loop_longterm",
                    LoopImplementationPhase.Mvp,
                    new[]
                    {
                        "Earn coins across runs",
                        "Purchase permanent stat upgrades",
                        "Feel power ramp on next run",
                        "Post-V1: unlock new worlds",
                        "Optional: player level for battle pass hooks"
                    },
                    Persona(AudiencePersonaDefaults.PersonaIdProgression, AudiencePersonaDefaults.PersonaIdCollector),
                    new[] { "MetaUpgradeConfig", "WorldUnlockConfig", "PlayerLevelConfig" }),

                L(
                    GameplayLoopType.RewardTiming,
                    "Reward timing",
                    "Instant hit feedback, gate dopamine, level-end coin burst, meta purchase satisfaction, daily login soft launch+.",
                    "Rewards are staged for hybrid-casual dopamine without slot-machine overload: hit-stop/light VFX on enemy kills, " +
                    "gate fanfare on squad changes, chunky coin shower at level end, shop purchase sparkle on meta buy. Daily login " +
                    "streak and calendar gifts are soft launch+ via Firebase Remote Config hooks — documented, not MVP.",
                    "loop_reward",
                    LoopImplementationPhase.Mvp,
                    new[]
                    {
                        "Hit feedback — damage numbers / flash",
                        "Gate pass — squad pop + SFX",
                        "Obstacle break — cardboard crumble",
                        "Boss phase — milestone sting",
                        "Victory coin burst",
                        "Meta purchase confirmation juice",
                        "Daily login — soft launch+"
                    },
                    Persona(AudiencePersonaDefaults.PersonaIdCasual, AudiencePersonaDefaults.PersonaIdCollector),
                    new[] { "JuiceConfig", "CoinBurstConfig", "DailyLoginConfig" }),

                L(
                    GameplayLoopType.FailureRetry,
                    "Failure / retry",
                    "Squad wipe → fail screen → retry same level or home → keep partial coins (50% design default).",
                    FailureRuleSummary + " Fail screen offers Retry (same level seed) or Home (bedroom menu). " +
                    "Coins collected during the run are partially kept: " + PartialCoinsOnFailPercent +
                    "% of in-run pickups bank to meta wallet (tunable in CoreGameplayLoopConfig). " +
                    "Boss overwhelm and enemy swarm are primary fail fantasies — no continue-with-IAP in MVP.",
                    "loop_failure",
                    LoopImplementationPhase.Mvp,
                    new[]
                    {
                        "Squad count hits 0",
                        "Fail screen — reason + coins earned",
                        "Apply partial coin retention %",
                        "Retry → reload level",
                        "Home → menu with wallet updated"
                    },
                    Persona(AudiencePersonaDefaults.PersonaIdCasual, AudiencePersonaDefaults.PersonaIdAdWatcher),
                    new[] { "FailureScreenConfig", "CoinRetentionConfig" },
                    partialCoinsPercent: PartialCoinsOnFailPercent),

                L(
                    GameplayLoopType.Upgrade,
                    "Upgrade loop",
                    "Earn coins → shop permanent stats → next run stronger.",
                    "The meta loop closes when permanent upgrades change the next run's starting power. MVP ships three upgrades: " +
                    "squad damage, squad fire rate, starting squad size. UI shows before/after previews. No pay-to-win IAP on " +
                    "core stats — IAP reserved for cosmetics/convenience per audience definition.",
                    "loop_upgrade",
                    LoopImplementationPhase.Mvp,
                    new[]
                    {
                        "Collect coins in level",
                        "Return to meta shop",
                        "Spend on permanent stat row",
                        "Next run applies upgraded baselines"
                    },
                    Persona(AudiencePersonaDefaults.PersonaIdProgression),
                    new[] { "MetaUpgradeConfig", "ShopUiConfig" }),

                L(
                    GameplayLoopType.AdReward,
                    "Ad reward loop",
                    "Optional rewarded = 2× coins / revive once; interstitial between runs soft launch+; MVP: interfaces only.",
                    "MVP documents IAdService / IRewardedAdPlacement interfaces without SDK wiring. Rewarded placements: " +
                    "double level coins on results, one revive per run on fail (Ad-watcher Avery persona). Interstitials fire " +
                    "between runs only after soft launch, capped per session via Remote Config. No ads mid-run in MVP.",
                    "loop_ad",
                    LoopImplementationPhase.DesignedOnly,
                    new[]
                    {
                        "Results screen — optional 2× coins rewarded",
                        "Fail screen — optional revive rewarded",
                        "Between runs — interstitial (soft launch+)",
                        "Session cap on interstitials"
                    },
                    Persona(AudiencePersonaDefaults.PersonaIdAdWatcher),
                    new[] { "AdPlacementConfig", "IAdService", "IRewardedAdPlacement" }),

                L(
                    GameplayLoopType.Cosmetic,
                    "Cosmetic loop",
                    "Earn/buy skins for hero/squad/trails; no power; production scope.",
                    "Cosmetics cover hero toy shell, squad tint, projectile trail, and victory pose — zero gameplay stats. " +
                    "Earn path via coins/events; buy path via IAP in production. Collector Chris persona primary. " +
                    "MVP: document + config only; first skin pipeline in production per RELEASE_SCOPE.",
                    "loop_cosmetic",
                    LoopImplementationPhase.DesignedOnly,
                    new[]
                    {
                        "Earn coins or event currency",
                        "Shop rotation — cosmetic rows",
                        "Equip skin — visual only",
                        "Show off in results / screenshot share"
                    },
                    Persona(AudiencePersonaDefaults.PersonaIdCollector),
                    new[] { "CosmeticCatalogConfig", "SkinEquipConfig" }),

                L(
                    GameplayLoopType.LiveOps,
                    "LiveOps loop",
                    "Remote config events, weekend multipliers, limited skins; Firebase hooks; post-soft-launch.",
                    "Live ops layer uses Firebase Remote Config + Analytics events: weekend coin multipliers, gate modifier " +
                    "weekends, limited-time bedroom skins, and boss modifier experiments. Cloud Functions optional for " +
                    "leaderboards. Not implemented in MVP — interfaces and config keys documented for soft launch wiring.",
                    "loop_liveops",
                    LoopImplementationPhase.DesignedOnly,
                    new[]
                    {
                        "Fetch Remote Config on session start",
                        "Apply event multipliers to rewards",
                        "Limited skin banner in shop",
                        "Analytics funnel for event participation",
                        "Sunset event — revert defaults"
                    },
                    Persona(AudiencePersonaDefaults.PersonaIdCollector, AudiencePersonaDefaults.PersonaIdProgression),
                    new[] { "IRemoteConfigService", "LiveOpsEventConfig", "IAnalyticsService" })
            };
        }

        static LoopDefinitionEntry L(
            GameplayLoopType type,
            string name,
            string summary,
            string description,
            string diagramId,
            LoopImplementationPhase phase,
            string[] beats,
            string[] personas,
            string[] tuningKeys,
            float partialCoinsPercent = 0f) =>
            new()
            {
                loopType = type,
                displayName = name,
                summary = summary,
                description = description,
                mermaidDiagramId = diagramId,
                implementationPhase = phase,
                keyBeats = new List<string>(beats),
                personaIds = personas != null ? new List<string>(personas) : new List<string>(),
                tuningConfigKeys = tuningKeys != null ? new List<string>(tuningKeys) : new List<string>(),
                partialCoinsOnFailPercent = partialCoinsPercent
            };

        static string[] Persona(params string[] ids) => ids;
    }
}
