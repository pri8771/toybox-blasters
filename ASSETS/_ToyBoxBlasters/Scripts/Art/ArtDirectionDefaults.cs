using System.Collections.Generic;

namespace ToyBoxBlasters.Art
{
    /// <summary>
    /// Task 008 canonical art direction. Keep in sync with PROJECT_DOCS/ART_DIRECTION.md.
    /// </summary>
    public static class ArtDirectionDefaults
    {
        public const string MoodBoardSummary =
            "Saturday-morning toy commercial on a bedroom floor at golden morning light: " +
            "Pixar-adjacent warmth, chunky silhouettes, plastic/felt/cardboard materials, family-safe.";

        public const float CharacterHeadHeightsMin = 2.5f;
        public const float CharacterHeadHeightsMax = 3f;
        public const float CharacterHandFootScale = 1.2f;
        public const float SilhouetteTestWidthPt = 44f;
        public const float SilhouetteReferenceScreenWidthPt = 390f;

        public const float PlayerHeightMeters = 1f;
        public const float LanePlayableWidthMeters = 4.5f;
        public const float LaneVisualWidthMeters = 6f;

        public const string EnemyStyleSummary =
            "Slimes: gooey toy-mess, squash hurt, confetti death. Dust bunny: fluffy felt boss, " +
            "dust motes on hit. No gore or blood.";

        public const string UiStyleSummary =
            "Rounded panels (panel_rounded.svg), chunky play-orange buttons (button_primary.svg), " +
            "ink outlines, minimal text, WCAG AA contrast.";

        public const string VfxStyleSummary =
            "Chunky particles, confetti coins, squish impacts, color flashes. No realistic blood or horror VFX.";

        public const string AnimationPersonalitySummary =
            "Bouncy idle, exaggerated hit squash, light boss shake, celebratory victory dance with confetti.";

        public const string PipelineSummary =
            "SVG → Vector Graphics or primitive placeholder → stable PFB_*_Placeholder → registry → rigged FBX production.";

        public const int MinimumPaletteEntries = 16;
        public const int MinimumBedroomChecklistItems = 8;
        public const int MinimumArtRequirementRows = 11;

        public static readonly string[] BedroomFloorChecklist =
        {
            "Floor — warm wood planks (#8D6E63)",
            "Rug — blush accent pattern (#F48FB1)",
            "Props — cardboard box, blocks, toy chest silhouettes",
            "Skybox — soft bedroom ceiling (warm #FFF8E1 gradient)",
            "Lighting — warm key, cool fill, no harsh noir",
            "Lane markers — subtle wear / rug edge",
            "Pickups — coin (required), gem (soft launch+)",
            "Gates — positive mint / negative coral",
            "Enemies — slime horde + dust bunny boss",
            "HUD — panel blue + play orange CTA prefabs"
        };

        public static List<ArtPaletteEntry> CreateDefaultPalette()
        {
            return new List<ArtPaletteEntry>
            {
                P("hero_blue", "Toy blue", "#4FC3F7", ArtPaletteCategory.Primary),
                P("hero_yellow", "Warm yellow", "#FFD54F", ArtPaletteCategory.Primary),
                P("slime_green", "Slime green", "#66BB6A", ArtPaletteCategory.Secondary),
                P("dust_gray", "Dust gray", "#9E9E9E", ArtPaletteCategory.Secondary),
                P("dust_purple", "Dust purple", "#B39DDB", ArtPaletteCategory.Secondary),
                P("kraft_brown", "Kraft brown", "#A1887F", ArtPaletteCategory.Secondary),
                P("floor_wood", "Floor wood", "#8D6E63", ArtPaletteCategory.Secondary),
                P("rug_blush", "Rug blush", "#F48FB1", ArtPaletteCategory.Secondary),
                P("ui_play_orange", "Play orange", "#FF9800", ArtPaletteCategory.Ui),
                P("ui_panel_blue", "Soft panel blue", "#E3F2FD", ArtPaletteCategory.Ui),
                P("ui_ink", "Ink outline", "#37474F", ArtPaletteCategory.Ui),
                P("ui_text", "HUD text", "#263238", ArtPaletteCategory.Ui),
                P("gate_positive", "Positive gate", "#81C784", ArtPaletteCategory.Feedback),
                P("gate_negative", "Negative gate", "#EF5350", ArtPaletteCategory.Feedback),
                P("coin_gold", "Coin gold", "#FFCA28", ArtPaletteCategory.Feedback),
                P("gem_amethyst", "Gem amethyst", "#AB47BC", ArtPaletteCategory.Feedback),
                P("damage_flash", "Damage flash", "#FF7043", ArtPaletteCategory.Feedback),
                P("heal_shield", "Heal / shield", "#4DD0E1", ArtPaletteCategory.Feedback),
                P("sky_warm", "Sky warm", "#FFF8E1", ArtPaletteCategory.Feedback)
            };
        }

        public static List<ArtRequirementEntry> CreateDefaultArtRequirements()
        {
            return new List<ArtRequirementEntry>
            {
                R(PlaceholderArtId.HeroChibi, "PFB_HeroChibi_Placeholder", "hero_chibi_placeholder.svg",
                    "Player captain; chibi 2.5-3 heads; toy blue + yellow accent"),
                R(PlaceholderArtId.SquadMember, "PFB_SquadMember_Placeholder", "hero_chibi_placeholder.svg",
                    "Squad follower; 15-20% smaller than hero"),
                R(PlaceholderArtId.SlimeEnemy, "PFB_SlimeEnemy_Placeholder", "slime_enemy.svg",
                    "Gooey toy-mess enemy; squash hurt; confetti death"),
                R(PlaceholderArtId.DustBunnyBoss, "PFB_DustBunnyBoss_Placeholder", "dust_bunny_boss.svg",
                    "World 1 fluffy boss; dust motes on hit; telegraphed hops"),
                R(PlaceholderArtId.GatePositive, "PFB_GatePositive_Placeholder", "gate_positive.svg",
                    "Buff gate; mint column shimmer"),
                R(PlaceholderArtId.GateNegative, "PFB_GateNegative_Placeholder", "gate_negative.svg",
                    "Debuff gate; coral warning read"),
                R(PlaceholderArtId.CardboardBox, "PFB_CardboardBox_Placeholder", "cardboard_box.svg",
                    "Numbered obstacle; kraft brown bedroom prop"),
                R(PlaceholderArtId.CoinPickup, "PFB_CoinPickup_Placeholder", "coin.svg",
                    "Coin pickup + confetti burst palette"),
                R(PlaceholderArtId.GemPickup, "PFB_GemPickup_Placeholder", "gem.svg",
                    "Gem pickup (soft launch+ premium read)"),
                R(PlaceholderArtId.UiButtonPrimary, "PFB_UI_ButtonPrimary_Placeholder", "button_primary.svg",
                    "Primary CTA; play orange; ≤3 word labels"),
                R(PlaceholderArtId.UiPanelRounded, "PFB_UI_PanelRounded_Placeholder", "panel_rounded.svg",
                    "HUD panel; soft panel blue; rounded corners")
            };
        }

        static ArtPaletteEntry P(string roleId, string displayName, string hex, ArtPaletteCategory category)
        {
            return new ArtPaletteEntry
            {
                roleId = roleId,
                displayName = displayName,
                hex = hex,
                category = category
            };
        }

        static ArtRequirementEntry R(
            PlaceholderArtId id,
            string prefab,
            string svg,
            string summary)
        {
            return new ArtRequirementEntry
            {
                artId = id,
                prefabName = prefab,
                sourceSvg = svg,
                requirementSummary = summary
            };
        }
    }
}
