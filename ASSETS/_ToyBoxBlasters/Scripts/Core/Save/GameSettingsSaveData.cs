using System;

namespace ToyBoxBlasters.Core.Save
{
    [Serializable]
    public sealed class GameSettingsSaveData
    {
        public float masterVolume = 1f;
        public float musicVolume = 1f;
        public float sfxVolume = 1f;
        public bool hapticsEnabled = true;
    }
}
