using UnityEngine;

namespace ToyBoxBlasters.Art
{
    /// <summary>
    /// Resolves placeholder prefabs from <see cref="PlaceholderArtRegistry"/>.
    /// </summary>
    public sealed class PlaceholderArtProvider : IPlaceholderArtProvider
    {
        readonly PlaceholderArtRegistry _registry;

        public PlaceholderArtProvider(PlaceholderArtRegistry registry)
        {
            _registry = registry;
            _registry?.RebuildLookup();
        }

        public bool TryGetPrefab(PlaceholderArtId id, out GameObject prefab) =>
            _registry != null && _registry.TryGetPrefab(id, out prefab);

        public bool TryInstantiate(
            PlaceholderArtId id,
            Vector3 position,
            Quaternion rotation,
            Transform parent,
            out GameObject instance)
        {
            instance = null;
            if (!TryGetPrefab(id, out var prefab) || prefab == null)
            {
                PlaceholderArtDebug.LogMissing(id);
                return false;
            }

            instance = Object.Instantiate(prefab, position, rotation, parent);
            return true;
        }
    }
}
