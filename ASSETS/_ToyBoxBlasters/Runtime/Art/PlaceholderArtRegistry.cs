using System.Collections.Generic;
using UnityEngine;

namespace ToyBoxBlasters.Art
{
    [CreateAssetMenu(
        fileName = "PlaceholderArtRegistry",
        menuName = "ToyBox Blasters/Art/Placeholder Art Registry")]
    public sealed class PlaceholderArtRegistry : ScriptableObject
    {
        [SerializeField] List<PlaceholderArtEntry> entries = new();

        readonly Dictionary<PlaceholderArtId, GameObject> _lookup = new();

        void OnEnable() => RebuildLookup();

        public void RebuildLookup()
        {
            _lookup.Clear();
            foreach (var entry in entries)
            {
                if (entry?.prefab == null)
                    continue;
                _lookup[entry.id] = entry.prefab;
            }
        }

        public bool TryGetPrefab(PlaceholderArtId id, out GameObject prefab) =>
            _lookup.TryGetValue(id, out prefab);

        public IReadOnlyList<PlaceholderArtEntry> Entries => entries;

#if UNITY_EDITOR
        public List<PlaceholderArtEntry> EditorEntries => entries;
#endif
    }
}
