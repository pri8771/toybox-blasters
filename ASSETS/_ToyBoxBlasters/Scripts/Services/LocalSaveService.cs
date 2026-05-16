using System.IO;
using ToyBoxBlasters.Core.Save;
using UnityEngine;

namespace ToyBoxBlasters.Services
{
    /// <summary>
    /// JSON file save under persistentDataPath (Task 009 local save stub).
    /// </summary>
    public sealed class LocalSaveService : ISaveService
    {
        public const string DefaultFileName = "toybox_local_save.json";

        readonly string _filePath;
        LocalSaveEnvelope _envelope = new();

        public LocalSaveService(string fileName = null)
        {
            var name = string.IsNullOrWhiteSpace(fileName) ? DefaultFileName : fileName;
            _filePath = Path.Combine(Application.persistentDataPath, name);
        }

        public bool HasLoaded { get; private set; }
        public LocalSaveEnvelope Envelope => _envelope;

        public bool Load()
        {
            if (!File.Exists(_filePath))
            {
                _envelope = new LocalSaveEnvelope();
                HasLoaded = true;
                return true;
            }

            try
            {
                var json = File.ReadAllText(_filePath);
                _envelope = JsonUtility.FromJson<LocalSaveEnvelope>(json) ?? new LocalSaveEnvelope();
                HasLoaded = true;
                return true;
            }
            catch (IOException ex)
            {
                Debug.LogWarning($"[LocalSave] Load failed: {ex.Message}");
                return false;
            }
        }

        public bool Save()
        {
            try
            {
                var json = JsonUtility.ToJson(_envelope, prettyPrint: true);
                File.WriteAllText(_filePath, json);
                return true;
            }
            catch (IOException ex)
            {
                Debug.LogWarning($"[LocalSave] Save failed: {ex.Message}");
                return false;
            }
        }
    }
}
