using System;

namespace ToyBoxBlasters.Core.Save
{
    [Serializable]
    public sealed class PlayerProfileSaveData
    {
        public string displayName = "Captain";
        public string equippedCosmeticId = string.Empty;
        public string[] unlockedCosmeticIds = Array.Empty<string>();
        public long lastCloudSyncUtcTicks;
    }
}
