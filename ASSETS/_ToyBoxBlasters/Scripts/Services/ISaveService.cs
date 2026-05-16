using ToyBoxBlasters.Core.Save;

namespace ToyBoxBlasters.Services
{
    public interface ISaveService
    {
        bool HasLoaded { get; }
        LocalSaveEnvelope Envelope { get; }

        bool Load();
        bool Save();

        PlayerProfileSaveData Profile => Envelope?.profile;
        GameSettingsSaveData Settings => Envelope?.settings;
        LevelProgressSaveData Progress => Envelope?.progress;
    }
}
