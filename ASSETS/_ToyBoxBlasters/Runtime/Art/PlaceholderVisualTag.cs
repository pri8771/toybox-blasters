using UnityEngine;

namespace ToyBoxBlasters.Art
{
    public sealed class PlaceholderVisualTag : MonoBehaviour
    {
        [SerializeField] PlaceholderArtId artId;

        public PlaceholderArtId ArtId => artId;

        public void SetArtId(PlaceholderArtId id) => artId = id;
    }
}
