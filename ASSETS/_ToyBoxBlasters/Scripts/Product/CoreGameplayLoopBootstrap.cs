using UnityEngine;

namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// Optional dev hook: logs all ten loop summaries when assigned a config.
    /// </summary>
    public sealed class CoreGameplayLoopBootstrap : MonoBehaviour
    {
        [SerializeField] CoreGameplayLoopConfig config;

        void Awake()
        {
            if (config == null)
            {
                CoreGameplayLoopDebug.LogValidation(false, "CoreGameplayLoopBootstrap: no config assigned.");
                return;
            }

            CoreGameplayLoopDebug.LogSummary(config);
            var passed = CoreGameplayLoopValidator.Validate(config, out var report);
            CoreGameplayLoopDebug.LogValidation(passed, report);
        }
    }
}
