using System;

namespace ToyBoxBlasters.Core.Save
{
    [Serializable]
    public sealed class LevelProgressSaveData
    {
        public int highestLevelUnlocked = 1;
        public int totalCoins;
        public int metaDamageLevel;
        public int metaFireRateLevel;
        public int metaStartingSquadLevel;
    }
}
