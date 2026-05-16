using System.Collections.Generic;
using UnityEngine;

namespace ToyBoxBlasters.Art
{
    /// <summary>
    /// Task 008 — locked art direction for Bedroom Floor and placeholder pipeline.
    /// </summary>
    [CreateAssetMenu(
        fileName = "ArtDirectionConfig",
        menuName = "ToyBox Blasters/Art/Art Direction Config")]
    public sealed class ArtDirectionConfig : ScriptableObject
    {
        [Header("1 — Mood board")]
        [TextArea(3, 6)]
        [SerializeField] string moodBoardSummary = ArtDirectionDefaults.MoodBoardSummary;

        [Header("2 — Character proportions")]
        [SerializeField] float characterHeadHeightsMin = ArtDirectionDefaults.CharacterHeadHeightsMin;
        [SerializeField] float characterHeadHeightsMax = ArtDirectionDefaults.CharacterHeadHeightsMax;
        [SerializeField] float characterHandFootScale = ArtDirectionDefaults.CharacterHandFootScale;
        [SerializeField] float silhouetteTestWidthPt = ArtDirectionDefaults.SilhouetteTestWidthPt;

        [Header("3 — Color palette")]
        [SerializeField] List<ArtPaletteEntry> palette = new();

        [Header("4 — Enemy style")]
        [TextArea(2, 4)]
        [SerializeField] string enemyStyleSummary = ArtDirectionDefaults.EnemyStyleSummary;

        [Header("5 — Environment scale (meters)")]
        [SerializeField] float playerHeightMeters = ArtDirectionDefaults.PlayerHeightMeters;
        [SerializeField] float lanePlayableWidthMeters = ArtDirectionDefaults.LanePlayableWidthMeters;
        [SerializeField] float laneVisualWidthMeters = ArtDirectionDefaults.LaneVisualWidthMeters;

        [Header("6 — UI style")]
        [TextArea(2, 4)]
        [SerializeField] string uiStyleSummary = ArtDirectionDefaults.UiStyleSummary;

        [Header("7 — VFX style")]
        [TextArea(2, 4)]
        [SerializeField] string vfxStyleSummary = ArtDirectionDefaults.VfxStyleSummary;

        [Header("8 — Animation personality")]
        [TextArea(2, 4)]
        [SerializeField] string animationPersonalitySummary = ArtDirectionDefaults.AnimationPersonalitySummary;

        [Header("9 — Bedroom Floor checklist")]
        [SerializeField] List<string> bedroomFloorChecklist = new();

        [Header("10 — Pipeline")]
        [TextArea(2, 4)]
        [SerializeField] string pipelineSummary = ArtDirectionDefaults.PipelineSummary;

        [Header("Prefab ↔ art requirements")]
        [SerializeField] List<ArtRequirementEntry> artRequirements = new();

        public string MoodBoardSummary => moodBoardSummary ?? string.Empty;
        public float CharacterHeadHeightsMin => characterHeadHeightsMin;
        public float CharacterHeadHeightsMax => characterHeadHeightsMax;
        public float CharacterHandFootScale => characterHandFootScale;
        public float SilhouetteTestWidthPt => silhouetteTestWidthPt;
        public IReadOnlyList<ArtPaletteEntry> Palette => palette ?? new List<ArtPaletteEntry>();
        public string EnemyStyleSummary => enemyStyleSummary ?? string.Empty;
        public float PlayerHeightMeters => playerHeightMeters;
        public float LanePlayableWidthMeters => lanePlayableWidthMeters;
        public float LaneVisualWidthMeters => laneVisualWidthMeters;
        public string UiStyleSummary => uiStyleSummary ?? string.Empty;
        public string VfxStyleSummary => vfxStyleSummary ?? string.Empty;
        public string AnimationPersonalitySummary => animationPersonalitySummary ?? string.Empty;
        public IReadOnlyList<string> BedroomFloorChecklist => bedroomFloorChecklist ?? new List<string>();
        public string PipelineSummary => pipelineSummary ?? string.Empty;
        public IReadOnlyList<ArtRequirementEntry> ArtRequirements => artRequirements ?? new List<ArtRequirementEntry>();

#if UNITY_EDITOR
        public void ApplyDefaults()
        {
            moodBoardSummary = ArtDirectionDefaults.MoodBoardSummary;
            characterHeadHeightsMin = ArtDirectionDefaults.CharacterHeadHeightsMin;
            characterHeadHeightsMax = ArtDirectionDefaults.CharacterHeadHeightsMax;
            characterHandFootScale = ArtDirectionDefaults.CharacterHandFootScale;
            silhouetteTestWidthPt = ArtDirectionDefaults.SilhouetteTestWidthPt;
            palette = ArtDirectionDefaults.CreateDefaultPalette();
            enemyStyleSummary = ArtDirectionDefaults.EnemyStyleSummary;
            playerHeightMeters = ArtDirectionDefaults.PlayerHeightMeters;
            lanePlayableWidthMeters = ArtDirectionDefaults.LanePlayableWidthMeters;
            laneVisualWidthMeters = ArtDirectionDefaults.LaneVisualWidthMeters;
            uiStyleSummary = ArtDirectionDefaults.UiStyleSummary;
            vfxStyleSummary = ArtDirectionDefaults.VfxStyleSummary;
            animationPersonalitySummary = ArtDirectionDefaults.AnimationPersonalitySummary;
            bedroomFloorChecklist = new List<string>(ArtDirectionDefaults.BedroomFloorChecklist);
            pipelineSummary = ArtDirectionDefaults.PipelineSummary;
            artRequirements = ArtDirectionDefaults.CreateDefaultArtRequirements();
        }
#endif
    }
}
