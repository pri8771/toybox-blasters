using System.Collections.Generic;
using UnityEngine;

namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// Task 004 competitive research matrix. Author in Editor; validate via menu.
    /// </summary>
    [CreateAssetMenu(
        fileName = "CompetitiveResearchConfig",
        menuName = "ToyBox Blasters/Product/Competitive Research Config")]
    public sealed class CompetitiveResearchConfig : ScriptableObject
    {
        [Header("Task 004")]
        [SerializeField] string taskId = CompetitiveResearchDefaults.TaskId;
        [SerializeField] string researchVersion = CompetitiveResearchDefaults.ResearchVersion;

        [Header("Industry summaries")]
        [TextArea(2, 4)]
        [SerializeField] string monetizationIndustrySummary = CompetitiveResearchDefaults.MonetizationIndustrySummary;

        [TextArea(2, 4)]
        [SerializeField] string adCreativeIndustrySummary = CompetitiveResearchDefaults.AdCreativeIndustrySummary;

        [TextArea(2, 4)]
        [SerializeField] string visualOpportunitySummary = CompetitiveResearchDefaults.VisualOpportunitySummary;

        [TextArea(2, 4)]
        [SerializeField] string genreWeaknessSummary = CompetitiveResearchDefaults.GenreWeaknessSummary;

        [Header("PRD §5 differentiators")]
        [SerializeField] List<string> toyBoxDifferentiators = new(CompetitiveResearchDefaults.ToyBoxDifferentiators);

        [Header("Competitors & research rows")]
        [SerializeField] List<CompetitorEntry> competitors = new();

        public string TaskId => taskId ?? string.Empty;
        public string ResearchVersion => researchVersion ?? string.Empty;
        public string MonetizationIndustrySummary => monetizationIndustrySummary ?? string.Empty;
        public string AdCreativeIndustrySummary => adCreativeIndustrySummary ?? string.Empty;
        public string VisualOpportunitySummary => visualOpportunitySummary ?? string.Empty;
        public string GenreWeaknessSummary => genreWeaknessSummary ?? string.Empty;
        public IReadOnlyList<string> ToyBoxDifferentiators => toyBoxDifferentiators ?? new List<string>();
        public IReadOnlyList<CompetitorEntry> Competitors => competitors ?? new List<CompetitorEntry>();

#if UNITY_EDITOR
        public void ApplyDefaults()
        {
            taskId = CompetitiveResearchDefaults.TaskId;
            researchVersion = CompetitiveResearchDefaults.ResearchVersion;
            monetizationIndustrySummary = CompetitiveResearchDefaults.MonetizationIndustrySummary;
            adCreativeIndustrySummary = CompetitiveResearchDefaults.AdCreativeIndustrySummary;
            visualOpportunitySummary = CompetitiveResearchDefaults.VisualOpportunitySummary;
            genreWeaknessSummary = CompetitiveResearchDefaults.GenreWeaknessSummary;
            toyBoxDifferentiators = new List<string>(CompetitiveResearchDefaults.ToyBoxDifferentiators);
            competitors = CompetitiveResearchDefaults.CreateDefaultCompetitors();
        }
#endif
    }
}
