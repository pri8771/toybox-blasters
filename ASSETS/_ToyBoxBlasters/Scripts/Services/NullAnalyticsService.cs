using System.Collections.Generic;
using UnityEngine;

namespace ToyBoxBlasters.Services
{
    public sealed class NullAnalyticsService : IAnalyticsService
    {
        public void LogEvent(string eventName, IReadOnlyDictionary<string, object> parameters = null)
        {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            Debug.Log($"[Analytics] {eventName}");
#endif
        }

        public void SetUserProperty(string name, string value)
        {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            Debug.Log($"[Analytics] user_property {name}={value}");
#endif
        }
    }
}
