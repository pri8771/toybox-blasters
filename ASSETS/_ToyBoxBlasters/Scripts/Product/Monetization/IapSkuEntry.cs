using System;
using UnityEngine;

namespace ToyBoxBlasters.Product.Monetization
{
    [Serializable]
    public sealed class IapSkuEntry
    {
        [SerializeField] string skuId = string.Empty;
        [SerializeField] IapSkuType skuType = IapSkuType.CoinPack;
        [SerializeField] string displayName = string.Empty;

        [TextArea(2, 4)]
        [SerializeField] string description = string.Empty;

        [SerializeField] float priceUsd;
        [SerializeField] bool enabledInV1 = true;
        [SerializeField] bool firstOfferWindowOnly;
        [SerializeField] int offerWindowHours;

        [Header("Grants (design placeholders)")]
        [SerializeField] int grantCoins;
        [SerializeField] int grantGems;
        [SerializeField] string grantCosmeticId = string.Empty;

        [Range(0, 50)]
        [SerializeField] int bonusPercentVsGrinding;

        [SerializeField] string economyPhilosophyLink = string.Empty;

        public string SkuId => skuId ?? string.Empty;
        public IapSkuType SkuType => skuType;
        public string DisplayName => displayName ?? string.Empty;
        public string Description => description ?? string.Empty;
        public float PriceUsd => priceUsd;
        public bool EnabledInV1 => enabledInV1;
        public bool FirstOfferWindowOnly => firstOfferWindowOnly;
        public int OfferWindowHours => offerWindowHours;
        public int GrantCoins => grantCoins;
        public int GrantGems => grantGems;
        public string GrantCosmeticId => grantCosmeticId ?? string.Empty;
        public int BonusPercentVsGrinding => bonusPercentVsGrinding;
        public string EconomyPhilosophyLink => economyPhilosophyLink ?? string.Empty;

        public IapSkuEntry(
            string skuId,
            IapSkuType skuType,
            string displayName,
            string description,
            float priceUsd,
            bool enabledInV1,
            bool firstOfferWindowOnly,
            int offerWindowHours,
            int grantCoins,
            int grantGems,
            string grantCosmeticId,
            int bonusPercentVsGrinding,
            string economyLink)
        {
            this.skuId = skuId;
            this.skuType = skuType;
            this.displayName = displayName;
            this.description = description;
            this.priceUsd = priceUsd;
            this.enabledInV1 = enabledInV1;
            this.firstOfferWindowOnly = firstOfferWindowOnly;
            this.offerWindowHours = offerWindowHours;
            this.grantCoins = grantCoins;
            this.grantGems = grantGems;
            this.grantCosmeticId = grantCosmeticId;
            this.bonusPercentVsGrinding = bonusPercentVsGrinding;
            economyPhilosophyLink = economyLink;
        }

        public IapSkuEntry()
        {
        }
    }
}
