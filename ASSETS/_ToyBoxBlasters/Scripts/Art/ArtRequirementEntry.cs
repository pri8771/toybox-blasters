using System;
using UnityEngine;

namespace ToyBoxBlasters.Art
{
    /// <summary>
    /// Links stable placeholder prefab names to Bedroom Floor / gameplay art requirements.
    /// </summary>
    [Serializable]
    public sealed class ArtRequirementEntry
    {
        public PlaceholderArtId artId;
        public string prefabName = string.Empty;
        public string sourceSvg = string.Empty;
        public string requirementSummary = string.Empty;
    }
}
