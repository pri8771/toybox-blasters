using System.Collections.Generic;
using System.Linq;

namespace ToyBoxBlasters.Product.Monetization
{
    /// <summary>Read-only IAP catalog from <see cref="MonetizationStrategyConfig"/>.</summary>
    public sealed class ConfigIapCatalog : IIapCatalog
    {
        readonly MonetizationStrategyConfig _config;

        public ConfigIapCatalog(MonetizationStrategyConfig config)
        {
            _config = config;
        }

        public IReadOnlyList<IapSkuEntry> AllSkus =>
            _config?.IapSkus ?? (IReadOnlyList<IapSkuEntry>)new List<IapSkuEntry>();

        public bool TryGetSku(string skuId, out IapSkuEntry sku)
        {
            sku = null;
            if (string.IsNullOrWhiteSpace(skuId) || _config?.IapSkus == null)
                return false;

            foreach (var entry in _config.IapSkus)
            {
                if (entry == null || entry.SkuId != skuId)
                    continue;
                sku = entry;
                return true;
            }

            return false;
        }

        public IReadOnlyList<IapSkuEntry> GetSkusByType(IapSkuType type)
        {
            if (_config?.IapSkus == null)
                return new List<IapSkuEntry>();

            return _config.IapSkus.Where(s => s != null && s.SkuType == type).ToList();
        }
    }
}
