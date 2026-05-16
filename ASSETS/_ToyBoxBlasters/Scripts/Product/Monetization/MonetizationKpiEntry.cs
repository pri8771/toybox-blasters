using System;
using UnityEngine;

namespace ToyBoxBlasters.Product.Monetization
{
    [Serializable]
    public sealed class MonetizationKpiEntry
    {
        [SerializeField] string metricId = string.Empty;
        [SerializeField] string displayName = string.Empty;

        [TextArea(2, 4)]
        [SerializeField] string targetDescription = string.Empty;

        [SerializeField] string baselineTbd = "TBD — set after soft launch cohort";

        [TextArea(2, 3)]
        [SerializeField] string guardrailNote = string.Empty;

        public string MetricId => metricId ?? string.Empty;
        public string DisplayName => displayName ?? string.Empty;
        public string TargetDescription => targetDescription ?? string.Empty;
        public string BaselineTbd => baselineTbd ?? string.Empty;
        public string GuardrailNote => guardrailNote ?? string.Empty;

        public MonetizationKpiEntry(
            string metricId,
            string displayName,
            string targetDescription,
            string guardrailNote)
        {
            this.metricId = metricId;
            this.displayName = displayName;
            this.targetDescription = targetDescription;
            this.guardrailNote = guardrailNote;
        }

        public MonetizationKpiEntry()
        {
        }
    }
}
