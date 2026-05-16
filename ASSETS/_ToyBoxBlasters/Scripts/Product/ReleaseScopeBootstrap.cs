using UnityEngine;

namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// Optional: logs release scope summary in dev builds when assigned a config.
    /// </summary>
    public sealed class ReleaseScopeBootstrap : MonoBehaviour
    {
        [SerializeField] ReleaseScopeConfig config;

        void Awake()
        {
            if (config == null)
            {
                ReleaseScopeDebug.LogValidation(false, "ReleaseScopeBootstrap: no config assigned.");
                return;
            }

            ReleaseScopeDebug.LogSummary(config);
            var passed = ReleaseScopeValidator.Validate(config, out var report);
            ReleaseScopeDebug.LogValidation(passed, report);
        }
    }
}
