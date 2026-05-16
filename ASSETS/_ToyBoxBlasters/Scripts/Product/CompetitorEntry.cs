using System;
using UnityEngine;

namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// One competitor or industry research row for Task 004 competitive matrix.
    /// </summary>
    [Serializable]
    public sealed class CompetitorEntry
    {
        [SerializeField] string name = string.Empty;
        [SerializeField] CompetitorCategory category = CompetitorCategory.CrowdArmyVsCastle;

        [TextArea(2, 5)]
        [SerializeField] string strengths = string.Empty;

        [TextArea(2, 5)]
        [SerializeField] string weaknesses = string.Empty;

        [TextArea(2, 4)]
        [SerializeField] string monetizationNotes = string.Empty;

        public string Name => name ?? string.Empty;
        public CompetitorCategory Category => category;
        public string Strengths => strengths ?? string.Empty;
        public string Weaknesses => weaknesses ?? string.Empty;
        public string MonetizationNotes => monetizationNotes ?? string.Empty;

#if UNITY_EDITOR
        public CompetitorEntry(
            string competitorName,
            CompetitorCategory competitorCategory,
            string competitorStrengths,
            string competitorWeaknesses,
            string monetization = "")
        {
            name = competitorName;
            category = competitorCategory;
            strengths = competitorStrengths;
            weaknesses = competitorWeaknesses;
            monetizationNotes = monetization;
        }
#endif
    }
}
