using UnityEngine;

namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// Optional scene object: logs audience summary in dev builds when assigned a config.
    /// </summary>
    public sealed class TargetAudienceBootstrap : MonoBehaviour
    {
        [SerializeField] TargetAudienceConfig config;

        void Awake()
        {
            if (config == null)
            {
                TargetAudienceDebug.LogValidation(false, "TargetAudienceBootstrap: no config assigned.");
                return;
            }

            TargetAudienceDebug.LogSummary(config);
            var passed = TargetAudienceValidator.Validate(config, out var report);
            TargetAudienceDebug.LogValidation(passed, report);
        }
    }
}
