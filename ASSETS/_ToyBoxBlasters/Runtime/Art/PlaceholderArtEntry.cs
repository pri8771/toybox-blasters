using System;
using UnityEngine;

namespace ToyBoxBlasters.Art
{
    [Serializable]
    public sealed class PlaceholderArtEntry
    {
        public PlaceholderArtId id;
        public GameObject prefab;
        [Tooltip("Source SVG filename under PlaceholderPack (for documentation and reimport).")]
        public string sourceSvgFileName;
    }
}
