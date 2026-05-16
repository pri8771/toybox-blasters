using System;
using UnityEngine;

namespace ToyBoxBlasters.Product.Monetization
{
    [Serializable]
    public sealed class AdPlacementEntry
    {
        [SerializeField] AdPlacementId placementId = AdPlacementId.Unknown;
        [SerializeField] AdPlacementKind kind = AdPlacementKind.Rewarded;
        [SerializeField] string displayName = string.Empty;

        [TextArea(2, 4)]
        [SerializeField] string description = string.Empty;

        [SerializeField] bool enabledInV1 = true;
        [SerializeField] bool postV1Only;
        [SerializeField] string economySourceOrSinkLink = string.Empty;

        public AdPlacementId PlacementId => placementId;
        public AdPlacementKind Kind => kind;
        public string DisplayName => displayName ?? string.Empty;
        public string Description => description ?? string.Empty;
        public bool EnabledInV1 => enabledInV1;
        public bool PostV1Only => postV1Only;
        public string EconomySourceOrSinkLink => economySourceOrSinkLink ?? string.Empty;

        public AdPlacementEntry(
            AdPlacementId placementId,
            AdPlacementKind kind,
            string displayName,
            string description,
            bool enabledInV1,
            bool postV1Only,
            string economyLink)
        {
            this.placementId = placementId;
            this.kind = kind;
            this.displayName = displayName;
            this.description = description;
            this.enabledInV1 = enabledInV1;
            this.postV1Only = postV1Only;
            economySourceOrSinkLink = economyLink;
        }

        public AdPlacementEntry()
        {
        }
    }
}
