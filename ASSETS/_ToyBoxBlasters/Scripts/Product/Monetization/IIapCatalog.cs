using System.Collections.Generic;

namespace ToyBoxBlasters.Product.Monetization
{
    /// <summary>Phase 1 stub — no store SDK. Backed by <see cref="MonetizationStrategyConfig"/> until IAP service exists.</summary>
    public interface IIapCatalog
    {
        IReadOnlyList<IapSkuEntry> AllSkus { get; }

        bool TryGetSku(string skuId, out IapSkuEntry sku);

        IReadOnlyList<IapSkuEntry> GetSkusByType(IapSkuType type);
    }
}
