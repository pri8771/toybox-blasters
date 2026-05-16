#if UNITY_EDITOR
using System.Text;
using ToyBoxBlasters.Art;
using UnityEditor;
using UnityEngine;

namespace ToyBoxBlasters.Editor.Art
{
    /// <summary>
    /// Logs palette swatches to the Console for quick visual review in Editor.
    /// </summary>
    public static class ArtDirectionPreview
    {
        const string ConfigPath = "Assets/_ToyBoxBlasters/ScriptableObjects/Config/ArtDirectionConfig.asset";

        [MenuItem("ToyBox Blasters/Art/Preview Art Direction Palette")]
        public static void PreviewPalette()
        {
            var config = AssetDatabase.LoadAssetAtPath<ArtDirectionConfig>(ConfigPath);
            if (config == null)
            {
                Debug.LogWarning("[ToyBoxBlasters:ArtDirection] ArtDirectionConfig not found. Run Create Art Direction Config first.");
                return;
            }

            var sb = new StringBuilder();
            sb.AppendLine("[ToyBoxBlasters:ArtDirection] Palette swatches (Task 008):");

            foreach (var entry in config.Palette)
            {
                if (entry == null)
                    continue;

                if (!entry.TryParseColor(out var color))
                {
                    sb.AppendLine($"  ? {entry.displayName} ({entry.roleId}) invalid hex {entry.hex}");
                    continue;
                }

                var block = ColorBlock(color);
                sb.AppendLine(
                    $"  {block} {entry.displayName,-16} [{entry.category,-9}] {entry.hex} ({entry.roleId})");
            }

            Debug.Log(sb.ToString());
        }

        static string ColorBlock(Color color)
        {
            var r = Mathf.Clamp(Mathf.RoundToInt(color.r * 255f), 0, 255);
            var g = Mathf.Clamp(Mathf.RoundToInt(color.g * 255f), 0, 255);
            var b = Mathf.Clamp(Mathf.RoundToInt(color.b * 255f), 0, 255);
            return $"<color=#{r:X2}{g:X2}{b:X2}>██</color>";
        }
    }
}
#endif
