using ToyBoxBlasters.Core.Save;

namespace ToyBoxBlasters.Services
{
    public sealed class PendingCloudSaveEntry
    {
        public string UserId { get; }
        public LocalSaveEnvelope Envelope { get; }
        public long QueuedUtcTicks { get; }

        public PendingCloudSaveEntry(string userId, LocalSaveEnvelope envelope, long queuedUtcTicks)
        {
            UserId = userId;
            Envelope = envelope;
            QueuedUtcTicks = queuedUtcTicks;
        }
    }
}
