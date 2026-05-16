using System.Collections.Generic;

namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// Task 004 canonical competitive research. Keep in sync with PROJECT_DOCS/COMPETITIVE_RESEARCH.md.
    /// </summary>
    public static class CompetitiveResearchDefaults
    {
        public const string TaskId = "Task 004 — Competitive Research (Phase 1)";
        public const string ResearchVersion = "1.0";

        /// <summary>PRD section 5 — differentiation bullets (locked).</summary>
        public static readonly string[] ToyBoxDifferentiators =
        {
            "Toy-room fantasy — cohesive bedroom diorama vs abstract stick crowds (PRD §5.1)",
            "Squad shooter readability — visible projectiles and hit reactions in portrait (PRD §5.2)",
            "Risk gates — positive and negative upgrade gates in one lane (PRD §5.3)",
            "Numbered obstacles — breakable HP blocks teaching squad DPS scaling (PRD §5.4)",
            "Boss spectacle at hybrid-casual pace — 2–4 min sessions, chunky telegraphs (PRD §5.5)",
            "Meta loop clarity — coins fund permanent stat toys; Firebase-ready live ops (PRD §5.6)"
        };

        public static readonly string MonetizationIndustrySummary =
            "Interstitials every 2–3 level fails or session ends; rewarded opt-in for revive, 2x coins, " +
            "or gate reroll; battle pass on roadmap post-soft-launch; no-ads IAP and starter packs at global.";

        public static readonly string AdCreativeIndustrySummary =
            "UA creatives exaggerate gate math (+999), before/after squad size, and fail-state humor; " +
            "ToyBox should show toy-room gates and readable squad VFX without misleading power levels.";

        public static readonly string VisualOpportunitySummary =
            "Cohesive toy-room diorama, readable portrait squad VFX, boss personality (Dust Bunny King), " +
            "and numbered cardboard obstacles as signature readable beats.";

        public static readonly string GenreWeaknessSummary =
            "Shallow combat depth, ad fatigue, visual/mechanical sameness, unclear meta, " +
            "and performance issues on low-end Android devices.";

#if UNITY_EDITOR
        public static List<CompetitorEntry> CreateDefaultCompetitors()
        {
            return new List<CompetitorEntry>
            {
                new CompetitorEntry(
                    "Mob Control (Voodoo)",
                    CompetitorCategory.CrowdArmyVsCastle,
                    "Crowd multiplier clarity; gate branch choices; army vs castle payoff; fast session loop.",
                    "Abstract theme; shallow shooting; sameness vs other crowd runners; heavy ad pressure.",
                    "Frequent interstitials; rewarded continue; IAP bundles; live ops events (industry observation)."),

                new CompetitorEntry(
                    "Archero / Archero 2",
                    CompetitorCategory.RoomRogueliteShooter,
                    "Room-based roguelite pacing; skill + build variety; permanent gear meta; strong retention hooks.",
                    "Hero-centric not squad; no runner gates; longer rooms than hybrid-casual target; ad/IAP depth can overwhelm.",
                    "Energy/stamina optional; gear gacha; battle pass; rewarded revives (public store listings)."),

                new CompetitorEntry(
                    "Survivor.io",
                    CompetitorCategory.HordeSurvival,
                    "Horde pressure and in-run level-up fantasy; long escalation; weapon evolution readability.",
                    "Top-down not forward runner; session length often exceeds 2–4 min; weak lane/gate fantasy.",
                    "Rewarded revives; interstitials between runs; seasonal passes and cosmetics (industry observation)."),

                new CompetitorEntry(
                    "Count Masters",
                    CompetitorCategory.RunnerGateMath,
                    "Instant gate +/- math readability; crowd scale spectacle; low tutorial friction.",
                    "Minimal shooting; abstract crowds; little boss identity; shallow meta.",
                    "Interstitial after fail; rewarded multiply finish rewards (industry observation)."),

                new CompetitorEntry(
                    "Join Clash / Join Clash 3D",
                    CompetitorCategory.RunnerGateMath,
                    "Merge/collect then fight boss beat; color-team clarity; satisfying stack growth.",
                    "Combat is stat check; repetitive levels; ad creative often overpromises math.",
                    "Heavy interstitial cadence; IAP no-ads (public store listings)."),

                new CompetitorEntry(
                    "Last War: Survival (hybrid)",
                    CompetitorCategory.SquadGrowthShooter,
                    "Squad growth + shooting hybrid; 4X/meta depth for whales; strong UA spend category.",
                    "Not pure hybrid-casual session length; UI complexity; paywalls obscure casual loop.",
                    "Starter packs, battle pass, rewarded speedups; interstitials in casual layers (industry observation)."),

                new CompetitorEntry(
                    "Hybrid-casual monetization norms",
                    CompetitorCategory.HybridCasualMonetization,
                    "Proven cadence: interstitial on fail/exit, rewarded opt-in, battle pass, no-ads IAP, starter packs.",
                    "Ad fatigue if frequency too high before fun hook; IAP clutter in MVP hurts conversion.",
                    MonetizationIndustrySummary),

                new CompetitorEntry(
                    "UA ad creative patterns",
                    CompetitorCategory.AdCreativePattern,
                    "Hyperbolic gate math, squad size before/after, fail humor drive CTR in category.",
                    "Misleading creatives hurt store rating; players bounce when gameplay mismatches ads.",
                    AdCreativeIndustrySummary),

                new CompetitorEntry(
                    "Genre weakness aggregate",
                    CompetitorCategory.GenreWeaknessAggregate,
                    "Establishes baseline players tolerate for hybrid-casual runners.",
                    GenreWeaknessSummary,
                    "Opportunity for ToyBox to differentiate on clarity and theme."),

                new CompetitorEntry(
                    "Visual opportunity — toy room",
                    CompetitorCategory.VisualOpportunity,
                    VisualOpportunitySummary,
                    "Competitors often use gray armies or stick crowds; bedroom diorama is underused.",
                    "Art cost higher than abstract — mitigated with placeholder → production swap pipeline."),

                new CompetitorEntry(
                    "ToyBox Blasters (target)",
                    CompetitorCategory.ToyBoxDifferentiator,
                    string.Join("; ", ToyBoxDifferentiators),
                    "Must prove fun in first 30s without relying on misleading UA; scope discipline for MVP.",
                    "Soft launch: interstitial interface only; global: rewarded + no-ads IAP per RELEASE_SCOPE.md.")
            };
        }
#endif
    }
}
