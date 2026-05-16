using System.Collections.Generic;

namespace ToyBoxBlasters.Services
{
    public interface IAnalyticsService
    {
        void LogEvent(string eventName, IReadOnlyDictionary<string, object> parameters = null);
        void SetUserProperty(string name, string value);
    }
}
