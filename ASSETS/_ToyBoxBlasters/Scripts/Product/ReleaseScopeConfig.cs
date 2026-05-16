using System.Collections.Generic;
using UnityEngine;

namespace ToyBoxBlasters.Product
{
    [CreateAssetMenu(
        fileName = "ReleaseScopeConfig",
        menuName = "ToyBox Blasters/Product/Release Scope Config")]
    public sealed class ReleaseScopeConfig : ScriptableObject
    {
        [Header("Phase summaries (Task 002)")]
        [TextArea(2, 4)]
        [SerializeField] string mvpScopeSummary = ReleaseScopeDefaults.MvpScopeSummary;

        [TextArea(2, 4)]
        [SerializeField] string softLaunchScopeSummary = ReleaseScopeDefaults.SoftLaunchScopeSummary;

        [TextArea(2, 4)]
        [SerializeField] string productionScopeSummary = ReleaseScopeDefaults.ProductionScopeSummary;

        [Header("Milestones")]
        [TextArea(2, 4)]
        [SerializeField] string firstPlayablePrototypeGoal = ReleaseScopeDefaults.FirstPlayablePrototypeGoal;

        [SerializeField] List<string> v1Excluded = new(ReleaseScopeDefaults.V1Excluded);
        [SerializeField] List<string> postLaunchAdditions = new(ReleaseScopeDefaults.PostLaunchAdditions);
        [SerializeField] List<string> productionSuccessCriteria = new(ReleaseScopeDefaults.ProductionSuccessCriteria);

        [Header("Features")]
        [SerializeField] List<FeatureScopeEntry> features = new();

        public string MvpScopeSummary => mvpScopeSummary ?? string.Empty;
        public string SoftLaunchScopeSummary => softLaunchScopeSummary ?? string.Empty;
        public string ProductionScopeSummary => productionScopeSummary ?? string.Empty;
        public string FirstPlayablePrototypeGoal => firstPlayablePrototypeGoal ?? string.Empty;
        public IReadOnlyList<string> V1Excluded => v1Excluded ?? new List<string>();
        public IReadOnlyList<string> PostLaunchAdditions => postLaunchAdditions ?? new List<string>();
        public IReadOnlyList<string> ProductionSuccessCriteria => productionSuccessCriteria ?? new List<string>();
        public IReadOnlyList<FeatureScopeEntry> Features => features ?? new List<FeatureScopeEntry>();

#if UNITY_EDITOR
        public void ApplyDefaults()
        {
            mvpScopeSummary = ReleaseScopeDefaults.MvpScopeSummary;
            softLaunchScopeSummary = ReleaseScopeDefaults.SoftLaunchScopeSummary;
            productionScopeSummary = ReleaseScopeDefaults.ProductionScopeSummary;
            firstPlayablePrototypeGoal = ReleaseScopeDefaults.FirstPlayablePrototypeGoal;
            v1Excluded = new List<string>(ReleaseScopeDefaults.V1Excluded);
            postLaunchAdditions = new List<string>(ReleaseScopeDefaults.PostLaunchAdditions);
            productionSuccessCriteria = new List<string>(ReleaseScopeDefaults.ProductionSuccessCriteria);
            features = ReleaseScopeDefaults.CreateDefaultFeatures();
        }
#endif
    }
}
