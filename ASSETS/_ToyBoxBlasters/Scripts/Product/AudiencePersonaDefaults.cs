using System.Collections.Generic;

namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// Canonical Task 003 values. Keep in sync with PROJECT_DOCS/AUDIENCE_AND_PERSONAS.md and PRD.md.
    /// </summary>
    public static class AudiencePersonaDefaults
    {
        public const string PrimarySegment =
            "Mobile hybrid-casual players 18-34 who enjoy short-session arcade runners with light strategy (gates/squad growth)";

        public const string SecondarySegments =
            "Secondary reach: teens 13-17; parents of younger players who co-play or approve installs";

        public const string AgePositioning =
            "Core 18-34; accessible to teens; family-friendly toy visuals without dark themes";

        public const AudienceClassification Classification = AudienceClassification.GeneralAudience;

        public const string ClassificationRationale =
            "General audience (E10+/PEGI 3+ style): toy aesthetic appeals to kids but mechanics and monetization " +
            "target broad casual mobile players. NOT child-directed (no COPPA-only design). No chat; avoid dark themes.";

        public const float SessionLengthPerRunMinutesMin = 2f;
        public const float SessionLengthPerRunMinutesMax = 4f;
        public const float SessionLengthDailyMinutesMin = 8f;
        public const float SessionLengthDailyMinutesMax = 15f;

        public const string MonetizationModel =
            "Hybrid: optional rewarded ads for boosts; interstitials between runs (soft launch+); " +
            "IAP for cosmetics and convenience (no pay-to-win power; no PvP in V1); low pressure in MVP";

        public const string MonetizationToleranceSummary =
            "Low pressure in MVP; rewarded ads optional; interstitials post-soft-launch; cosmetic/convenience IAP acceptable";

        public static readonly string[] MotivationLoops =
        {
            "Mastery — clear levels and readable combat feedback",
            "Collection — cosmetics and meta toys",
            "Progression — permanent upgrades and gate optimization",
            "Novelty — new bedroom-adjacent worlds post-launch",
            "Social proof — leaderboards optional post-launch"
        };

        public const string PersonaIdCasual = "casual_casey";
        public const string PersonaIdProgression = "progression_pat";
        public const string PersonaIdCollector = "collector_chris";
        public const string PersonaIdAdWatcher = "ad_watcher_avery";

        public static readonly IReadOnlyList<PersonaSeed> Personas = new[]
        {
            new PersonaSeed(
                PersonaIdCasual,
                "Casual Casey",
                "Plays during micro-moments (waiting in line, short breaks). Wants instant fun without tutorials or grind.",
                "Clear a fun level in under 4 minutes; feel squad power grow; no commitment between sessions",
                "Long tutorials, forced daily login, confusing gate math, slow ad skips",
                "Watches rewarded ads only when reward is obvious and skip is fast; ignores most IAP",
                "Low — tolerates ads if skip is fast; avoids subscriptions",
                "1-2 runs per session, several times per week; 2-4 min per run"),
            new PersonaSeed(
                PersonaIdProgression,
                "Progression Pat",
                "Optimizes gate choices and meta upgrades. Compares run efficiency and permanent stat gains.",
                "Maximize coins per run; pick optimal +/- gates; unlock permanent damage/fire-rate toys",
                "Opaque gate outcomes, paywalls on core power, runs that feel samey without meta growth",
                "Light IAP for convenience bundles or starter packs; engages rewarded ads for boost currency",
                "Medium — convenience IAP ok; rejects pay-to-win power",
                "3-5 runs per day when engaged; 8-15 min daily total; studies gate routes"),
            new PersonaSeed(
                PersonaIdCollector,
                "Collector Chris",
                "Motivated by toy skins, trails, and squad flair. Shares screenshots of rare looks.",
                "Unlock and show off cosmetic sets; complete bedroom-themed collections",
                "Pay-only exclusives with no earn path, cluttered shop UI, skins that clip or look cheap",
                "Cosmetic IAP primary spend; occasional battle pass if fairly priced",
                "Medium-high for cosmetics only — no power purchases",
                "Daily login for shop rotation; 1-3 runs to earn currency toward skins"),
            new PersonaSeed(
                PersonaIdAdWatcher,
                "Ad-watcher Avery",
                "Treats rewarded ads as part of the economy. Revives and bonus currency feel fair when ad-funded.",
                "Revive after boss fail; double coins; free chest spins via rewarded placements",
                "Forced unskippable ads mid-run, unclear ad rewards, interstitials too frequent in MVP",
                "High rewarded ad engagement; low IAP unless extreme value",
                "High for rewarded — low for interstitials unless spaced between runs",
                "2-4 runs with 1-2 rewarded ads per session; returns when daily ad bonuses reset")
        };

        public readonly struct PersonaSeed
        {
            public PersonaSeed(
                string id,
                string name,
                string description,
                string goals,
                string frustrations,
                string monetizationBehavior,
                string monetizationTolerance,
                string sessionPattern)
            {
                Id = id;
                Name = name;
                Description = description;
                Goals = goals;
                Frustrations = frustrations;
                MonetizationBehavior = monetizationBehavior;
                MonetizationTolerance = monetizationTolerance;
                SessionPattern = sessionPattern;
            }

            public string Id { get; }
            public string Name { get; }
            public string Description { get; }
            public string Goals { get; }
            public string Frustrations { get; }
            public string MonetizationBehavior { get; }
            public string MonetizationTolerance { get; }
            public string SessionPattern { get; }
        }
    }
}
