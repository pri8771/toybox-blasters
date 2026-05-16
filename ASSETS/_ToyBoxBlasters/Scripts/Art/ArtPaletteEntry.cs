using System;
using UnityEngine;

namespace ToyBoxBlasters.Art
{
    [Serializable]
    public sealed class ArtPaletteEntry
    {
        public string roleId = string.Empty;
        public string displayName = string.Empty;
        public string hex = "#FFFFFF";
        public ArtPaletteCategory category = ArtPaletteCategory.Primary;

        public bool TryParseColor(out Color color)
        {
            color = default;
            if (string.IsNullOrWhiteSpace(hex))
                return false;
            var s = hex.Trim();
            if (!s.StartsWith("#", StringComparison.Ordinal))
                s = "#" + s;
            return ColorUtility.TryParseHtmlString(s, out color);
        }
    }
}
