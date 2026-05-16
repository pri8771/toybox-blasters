using System;
using UnityEngine;

namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// One earn (source) or spend (sink) row in the economy philosophy matrix.
    /// </summary>
    [Serializable]
    public sealed class EconomyFlowEntry
    {
        [Tooltip("Stable id, e.g. coin_source_level_complete")]
        [SerializeField] string flowId = string.Empty;

        [SerializeField] CurrencyKind currency = CurrencyKind.SoftCoins;
        [SerializeField] EconomyFlowKind flowKind = EconomyFlowKind.Source;
        [SerializeField] string displayName = string.Empty;

        [TextArea(2, 4)]
        [SerializeField] string description = string.Empty;

        [SerializeField] ReleasePhase releasePhase = ReleasePhase.Mvp;

        [Tooltip("Placeholder tuning note — TBD in balance pass")]
        [SerializeField] string placeholderTuning = string.Empty;

        [SerializeField] string remoteConfigKey = string.Empty;

        public string FlowId => flowId ?? string.Empty;
        public CurrencyKind Currency => currency;
        public EconomyFlowKind FlowKind => flowKind;
        public string DisplayName => displayName ?? string.Empty;
        public string Description => description ?? string.Empty;
        public ReleasePhase ReleasePhase => releasePhase;
        public string PlaceholderTuning => placeholderTuning ?? string.Empty;
        public string RemoteConfigKey => remoteConfigKey ?? string.Empty;

#if UNITY_EDITOR
        public EconomyFlowEntry(
            string id,
            CurrencyKind currencyKind,
            EconomyFlowKind kind,
            string name,
            string flowDescription,
            ReleasePhase phase,
            string tuningPlaceholder,
            string rcKey = "")
        {
            flowId = id;
            currency = currencyKind;
            flowKind = kind;
            displayName = name;
            description = flowDescription;
            releasePhase = phase;
            placeholderTuning = tuningPlaceholder;
            remoteConfigKey = rcKey;
        }
#endif
    }
}
