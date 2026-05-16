using UnityEngine;

namespace ToyBoxBlasters.Art
{
    public interface IPlaceholderArtProvider
    {
        bool TryInstantiate(PlaceholderArtId id, Vector3 position, Quaternion rotation, Transform parent, out GameObject instance);
        bool TryGetPrefab(PlaceholderArtId id, out GameObject prefab);
    }
}
