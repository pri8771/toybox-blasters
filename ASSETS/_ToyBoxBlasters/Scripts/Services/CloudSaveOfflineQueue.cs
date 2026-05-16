using System.Collections.Generic;
using ToyBoxBlasters.Core.Save;

namespace ToyBoxBlasters.Services
{
    /// <summary>
    /// In-memory offline write buffer until Firebase wiring flushes on connectivity.
    /// </summary>
    public sealed class CloudSaveOfflineQueue
    {
        readonly List<PendingCloudSaveEntry> _pending = new();

        public void Enqueue(string userId, LocalSaveEnvelope envelope)
        {
            if (string.IsNullOrWhiteSpace(userId) || envelope == null)
                return;

            _pending.Add(new PendingCloudSaveEntry(userId, envelope, System.DateTime.UtcNow.Ticks));
        }

        public IReadOnlyList<PendingCloudSaveEntry> PeekAll() => _pending;

        public void Clear() => _pending.Clear();
    }
}
