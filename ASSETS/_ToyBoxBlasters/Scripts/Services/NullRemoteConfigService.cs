using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ToyBoxBlasters.Services
{
    public sealed class NullRemoteConfigService : IRemoteConfigService
    {
        readonly Dictionary<string, string> _cache = new()
        {
            { RemoteConfigKeys.EconomyCoinMultiplier, "1.0" },
            { RemoteConfigKeys.EconomyUpgradeCostScale, "1.0" },
            { RemoteConfigKeys.AdsInterstitialCadenceLevels, "3" },
            { RemoteConfigKeys.AdsRewardedEnabled, "false" },
            { RemoteConfigKeys.FeatureBossRush, "false" },
            { RemoteConfigKeys.FeatureDailyLogin, "false" }
        };

        public bool HasCache { get; private set; }

        public Task FetchAndCacheAsync(CancellationToken cancellationToken = default)
        {
            HasCache = true;
            return Task.CompletedTask;
        }

        public bool TryGetString(string key, out string value) => _cache.TryGetValue(key, out value);

        public bool TryGetBool(string key, out bool value)
        {
            value = false;
            if (!TryGetString(key, out var raw))
                return false;
            value = raw == "1" || raw.Equals("true", System.StringComparison.OrdinalIgnoreCase);
            return true;
        }

        public bool TryGetDouble(string key, out double value)
        {
            value = 0;
            if (!TryGetString(key, out var raw))
                return false;
            return double.TryParse(raw, out value);
        }

        public IReadOnlyDictionary<string, string> GetCachedSnapshot() => _cache;
    }
}
