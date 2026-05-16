using UnityEngine;

namespace ToyBoxBlasters.Product.Monetization
{
    /// <summary>Optional dev hook: assign config in Inspector and press Play for console summary.</summary>
    public sealed class MonetizationStrategyBootstrap : MonoBehaviour
    {
        [SerializeField] MonetizationStrategyConfig config;

        void Start()
        {
            if (config == null)
            {
                MonetizationStrategyDebug.LogValidation(false, "MonetizationStrategyBootstrap: config not assigned.");
                return;
            }

            var passed = MonetizationStrategyValidator.Validate(config, out var report);
            MonetizationStrategyDebug.LogValidation(passed, report);
            MonetizationStrategyDebug.LogSummary(config);

            var policy = new ConfigAdsPlacementPolicy(config);
            var catalog = new ConfigIapCatalog(config);
            if (MonetizationStrategyDebug.VerboseLogging)
            {
                Debug.Log(
                    $"[ToyBoxBlasters:Monetization] Stub policy interstitial@victory: " +
                    $"{policy.CanShowInterstitial(AdPlacementId.VictoryReturnToMenu, 1, 5)} | " +
                    $"Catalog SKUs: {catalog.AllSkus.Count}");
            }
        }
    }
}
