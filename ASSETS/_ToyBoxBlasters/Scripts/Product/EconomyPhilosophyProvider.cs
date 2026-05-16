using UnityEngine;

namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// Runtime holder for economy philosophy config. Assign on bootstrap or service locator later.
    /// </summary>
    public sealed class EconomyPhilosophyProvider : MonoBehaviour, IEconomyPhilosophyProvider
    {
        [SerializeField] EconomyPhilosophyConfig config;

        public EconomyPhilosophyConfig Config => config;
        public bool IsValid => config != null && EconomyPhilosophyValidator.Validate(config, out _);

        public bool TryGetCurrency(CurrencyKind kind, out CurrencyDefinitionEntry entry)
        {
            entry = null;
            return config != null && config.TryGetCurrency(kind, out entry);
        }

        void OnValidate()
        {
            if (config == null)
                return;

            EconomyPhilosophyValidator.Validate(config, out var report);
            EconomyPhilosophyDebug.LogValidation(IsValid, report);
        }
    }
}
