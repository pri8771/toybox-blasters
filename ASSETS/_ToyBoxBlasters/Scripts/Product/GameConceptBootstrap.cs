using UnityEngine;

namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// Optional scene object: logs concept summary in dev builds when assigned a config.
    /// </summary>
    public sealed class GameConceptBootstrap : MonoBehaviour
    {
        [SerializeField] GameConceptConfig config;

        void Awake()
        {
            if (config == null)
            {
                GameConceptDebug.LogValidation(false, "GameConceptBootstrap: no config assigned.");
                return;
            }

            GameConceptDebug.LogSummary(config);
            var passed = GameConceptValidator.Validate(config, out var report);
            GameConceptDebug.LogValidation(passed, report);
        }
    }
}
