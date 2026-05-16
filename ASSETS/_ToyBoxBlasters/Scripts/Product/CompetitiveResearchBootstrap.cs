using UnityEngine;

namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// Optional dev hook: logs competitive research summary when a config is assigned.
    /// </summary>
    public sealed class CompetitiveResearchBootstrap : MonoBehaviour
    {
        [SerializeField] CompetitiveResearchConfig config;

        void Awake()
        {
            if (config == null)
            {
                CompetitiveResearchDebug.LogValidation(false, "CompetitiveResearchBootstrap: no config assigned.");
                return;
            }

            CompetitiveResearchDebug.LogSummary(config);
            CompetitiveResearchDebug.LogMatrixPreview(config);
            var passed = CompetitiveResearchValidator.Validate(config, out var report);
            CompetitiveResearchDebug.LogValidation(passed, report);
        }
    }
}
