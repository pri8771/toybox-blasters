using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToyBoxBlasters.Core.Save;

namespace ToyBoxBlasters.Services
{
    public sealed class NullCloudSaveService : ICloudSaveService
    {
        readonly CloudSaveOfflineQueue _queue = new();

        public Task<bool> LoadAsync(string userId, LocalSaveEnvelope intoEnvelope, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(false);
        }

        public Task<bool> SaveAsync(string userId, LocalSaveEnvelope envelope, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
        }

        public void QueueOfflineWrite(string userId, LocalSaveEnvelope envelope) => _queue.Enqueue(userId, envelope);

        public IReadOnlyList<PendingCloudSaveEntry> GetPendingQueue() => _queue.PeekAll();
    }
}
