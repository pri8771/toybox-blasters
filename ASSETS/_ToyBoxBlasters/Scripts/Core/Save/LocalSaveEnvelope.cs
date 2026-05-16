using System;

namespace ToyBoxBlasters.Core.Save
{
    [Serializable]
    public sealed class LocalSaveEnvelope
    {
        public int schemaVersion = 1;
        public PlayerProfileSaveData profile = new();
        public GameSettingsSaveData settings = new();
        public LevelProgressSaveData progress = new();
    }
}
