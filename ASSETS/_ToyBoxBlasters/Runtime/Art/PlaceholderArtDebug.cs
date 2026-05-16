using UnityEngine;

namespace ToyBoxBlasters.Art
{
    public static class PlaceholderArtDebug
    {
        public static bool VerboseLogging =
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            true;
#else
            false;
#endif

        public static void LogMissing(PlaceholderArtId id)
        {
            if (!VerboseLogging)
                return;
            Debug.LogWarning($"[ToyBoxBlasters] Missing placeholder prefab for {id}. Run ToyBox Blasters → Setup Placeholder Art.");
        }

        public static void LogSetup(string message)
        {
            if (!VerboseLogging)
                return;
            Debug.Log($"[ToyBoxBlasters:Art] {message}");
        }
    }
}
