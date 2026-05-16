using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ToyBoxBlasters.Services
{
    public interface IRemoteConfigService
    {
        bool HasCache { get; }
        Task FetchAndCacheAsync(CancellationToken cancellationToken = default);
        bool TryGetString(string key, out string value);
        bool TryGetBool(string key, out bool value);
        bool TryGetDouble(string key, out double value);
        IReadOnlyDictionary<string, string> GetCachedSnapshot();
    }
}
