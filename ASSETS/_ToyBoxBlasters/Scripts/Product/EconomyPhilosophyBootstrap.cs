using UnityEngine;

namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// Optional dev bootstrap — logs economy summary in Editor/Development builds.
    /// </summary>
    public sealed class EconomyPhilosophyBootstrap : MonoBehaviour
    {
        [SerializeField] EconomyPhilosophyConfig config;

        void Start()
        {
            if (config == null)
                return;

            var passed = EconomyPhilosophyValidator.Validate(config, out var report);
            EconomyPhilosophyDebug.LogValidation(passed, report);
            EconomyPhilosophyDebug.LogSummary(config);
            EconomyPhilosophyDebug.LogCurrencyMatrix(config);
        }
    }
}
