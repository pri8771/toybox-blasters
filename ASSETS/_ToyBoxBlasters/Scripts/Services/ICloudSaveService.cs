using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToyBoxBlasters.Core.Save;

namespace ToyBoxBlasters.Services
{
    public interface ICloudSaveService
    {
        Task<bool> LoadAsync(string userId, LocalSaveEnvelope intoEnvelope, CancellationToken cancellationToken = default);
        Task<bool> SaveAsync(string userId, LocalSaveEnvelope envelope, CancellationToken cancellationToken = default);
        void QueueOfflineWrite(string userId, LocalSaveEnvelope envelope);
        IReadOnlyList<PendingCloudSaveEntry> GetPendingQueue();
    }
}
