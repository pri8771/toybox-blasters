using System.Collections.Generic;
using UnityEngine;

namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// Task 005 — all ten gameplay loop layers as data. Author in Editor; validate before commits.
    /// </summary>
    [CreateAssetMenu(
        fileName = "CoreGameplayLoopConfig",
        menuName = "ToyBox Blasters/Product/Core Gameplay Loop Config")]
    public sealed class CoreGameplayLoopConfig : ScriptableObject
    {
        [Header("Global rules (Task 005)")]
        [TextArea(2, 4)]
        [SerializeField] string failureRuleSummary = CoreGameplayLoopDefaults.FailureRuleSummary;

        [Range(0f, 100f)]
        [SerializeField] float partialCoinsOnFailPercent = CoreGameplayLoopDefaults.PartialCoinsOnFailPercent;

        [SerializeField] float runLengthMinutesMin = CoreGameplayLoopDefaults.RunLengthMinutesMin;
        [SerializeField] float runLengthMinutesMax = CoreGameplayLoopDefaults.RunLengthMinutesMax;
        [SerializeField] float sessionLengthMinutesMin = CoreGameplayLoopDefaults.SessionLengthMinutesMin;
        [SerializeField] float sessionLengthMinutesMax = CoreGameplayLoopDefaults.SessionLengthMinutesMax;
        [SerializeField] int runsPerSessionMin = CoreGameplayLoopDefaults.RunsPerSessionMin;
        [SerializeField] int runsPerSessionMax = CoreGameplayLoopDefaults.RunsPerSessionMax;

        [TextArea(1, 3)]
        [SerializeField] string gemsAvailability = CoreGameplayLoopDefaults.GemsAvailability;

        [Header("Loop layers (10 required)")]
        [SerializeField] List<LoopDefinitionEntry> loops = new();

        public string FailureRuleSummary => failureRuleSummary ?? string.Empty;
        public float PartialCoinsOnFailPercent => partialCoinsOnFailPercent;
        public float RunLengthMinutesMin => runLengthMinutesMin;
        public float RunLengthMinutesMax => runLengthMinutesMax;
        public float SessionLengthMinutesMin => sessionLengthMinutesMin;
        public float SessionLengthMinutesMax => sessionLengthMinutesMax;
        public int RunsPerSessionMin => runsPerSessionMin;
        public int RunsPerSessionMax => runsPerSessionMax;
        public string GemsAvailability => gemsAvailability ?? string.Empty;
        public IReadOnlyList<LoopDefinitionEntry> Loops => loops ?? new List<LoopDefinitionEntry>();

        public bool TryGetLoop(GameplayLoopType type, out LoopDefinitionEntry entry)
        {
            entry = null;
            if (loops == null)
                return false;

            foreach (var loop in loops)
            {
                if (loop != null && loop.LoopType == type)
                {
                    entry = loop;
                    return true;
                }
            }

            return false;
        }

#if UNITY_EDITOR
        public void ApplyDefaults()
        {
            failureRuleSummary = CoreGameplayLoopDefaults.FailureRuleSummary;
            partialCoinsOnFailPercent = CoreGameplayLoopDefaults.PartialCoinsOnFailPercent;
            runLengthMinutesMin = CoreGameplayLoopDefaults.RunLengthMinutesMin;
            runLengthMinutesMax = CoreGameplayLoopDefaults.RunLengthMinutesMax;
            sessionLengthMinutesMin = CoreGameplayLoopDefaults.SessionLengthMinutesMin;
            sessionLengthMinutesMax = CoreGameplayLoopDefaults.SessionLengthMinutesMax;
            runsPerSessionMin = CoreGameplayLoopDefaults.RunsPerSessionMin;
            runsPerSessionMax = CoreGameplayLoopDefaults.RunsPerSessionMax;
            gemsAvailability = CoreGameplayLoopDefaults.GemsAvailability;
            loops = CoreGameplayLoopDefaults.CreateDefaultLoops();
        }
#endif
    }
}
