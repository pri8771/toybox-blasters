using System.Collections.Generic;
using UnityEngine;

namespace ToyBoxBlasters.Product.Monetization
{
    [CreateAssetMenu(
        fileName = "MonetizationStrategyConfig",
        menuName = "ToyBox Blasters/Product/Monetization Strategy Config")]
    public sealed class MonetizationStrategyConfig : ScriptableObject
    {
        [Header("Strategy (Task 007)")]
        [TextArea(2, 4)]
        [SerializeField] string strategySummary = MonetizationStrategyDefaults.StrategySummary;

        [TextArea(2, 4)]
        [SerializeField] string economyAlignmentNote = MonetizationStrategyDefaults.EconomyAlignmentNote;

        [TextArea(2, 4)]
        [SerializeField] string familyFriendlyDisclosure = MonetizationStrategyDefaults.FamilyFriendlyDisclosure;

        [TextArea(2, 4)]
        [SerializeField] string battlePassV1Note = MonetizationStrategyDefaults.BattlePassV1Note;

        [Header("Ad frequency")]
        [SerializeField] AdFrequencyRules adFrequencyRules = MonetizationStrategyDefaults.CreateDefaultFrequencyRules();

        [Header("Placements")]
        [SerializeField] List<AdPlacementEntry> adPlacements = new();

        [Header("IAP catalog")]
        [SerializeField] List<IapSkuEntry> iapSkus = new();

        [Header("KPIs")]
        [SerializeField] List<MonetizationKpiEntry> kpiTargets = new();

        public string StrategySummary => strategySummary ?? string.Empty;
        public string EconomyAlignmentNote => economyAlignmentNote ?? string.Empty;
        public string FamilyFriendlyDisclosure => familyFriendlyDisclosure ?? string.Empty;
        public string BattlePassV1Note => battlePassV1Note ?? string.Empty;
        public AdFrequencyRules AdFrequencyRules => adFrequencyRules;
        public IReadOnlyList<AdPlacementEntry> AdPlacements => adPlacements ?? new List<AdPlacementEntry>();
        public IReadOnlyList<IapSkuEntry> IapSkus => iapSkus ?? new List<IapSkuEntry>();
        public IReadOnlyList<MonetizationKpiEntry> KpiTargets => kpiTargets ?? new List<MonetizationKpiEntry>();

#if UNITY_EDITOR
        public void ApplyDefaults()
        {
            strategySummary = MonetizationStrategyDefaults.StrategySummary;
            economyAlignmentNote = MonetizationStrategyDefaults.EconomyAlignmentNote;
            familyFriendlyDisclosure = MonetizationStrategyDefaults.FamilyFriendlyDisclosure;
            battlePassV1Note = MonetizationStrategyDefaults.BattlePassV1Note;
            adFrequencyRules = MonetizationStrategyDefaults.CreateDefaultFrequencyRules();
            adPlacements = MonetizationStrategyDefaults.CreateDefaultAdPlacements();
            iapSkus = MonetizationStrategyDefaults.CreateDefaultIapSkus();
            kpiTargets = MonetizationStrategyDefaults.CreateDefaultKpis();
        }
#endif
    }
}
