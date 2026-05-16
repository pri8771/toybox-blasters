using ToyBoxBlasters.Art;
using UnityEngine;

namespace ToyBoxBlasters.Editor.Art
{
    internal static class PlaceholderArtPalette
    {
        internal readonly struct Spec
        {
            public Spec(
                PlaceholderArtId id,
                string prefabName,
                string sourceSvg,
                Color color,
                PrimitiveType primitive,
                Vector3 scale,
                bool uiPrefab)
            {
                Id = id;
                PrefabName = prefabName;
                SourceSvg = sourceSvg;
                Color = color;
                Primitive = primitive;
                Scale = scale;
                UiPrefab = uiPrefab;
            }

            public PlaceholderArtId Id { get; }
            public string PrefabName { get; }
            public string SourceSvg { get; }
            public Color Color { get; }
            public PrimitiveType Primitive { get; }
            public Vector3 Scale { get; }
            public bool UiPrefab { get; }
        }

        internal static readonly Spec[] All =
        {
            new(PlaceholderArtId.HeroChibi, "PFB_HeroChibi_Placeholder", "hero_chibi_placeholder.svg",
                Hex("#4FC3F7"), PrimitiveType.Capsule, new Vector3(0.8f, 1f, 0.8f), false),
            new(PlaceholderArtId.SquadMember, "PFB_SquadMember_Placeholder", "hero_chibi_placeholder.svg",
                Hex("#4FC3F7"), PrimitiveType.Capsule, new Vector3(0.65f, 0.85f, 0.65f), false),
            new(PlaceholderArtId.SlimeEnemy, "PFB_SlimeEnemy_Placeholder", "slime_enemy.svg",
                Hex("#66BB6A"), PrimitiveType.Sphere, new Vector3(1.1f, 0.75f, 1.1f), false),
            new(PlaceholderArtId.DustBunnyBoss, "PFB_DustBunnyBoss_Placeholder", "dust_bunny_boss.svg",
                Hex("#9E9E9E"), PrimitiveType.Sphere, new Vector3(1.6f, 1.4f, 1.6f), false),
            new(PlaceholderArtId.GatePositive, "PFB_GatePositive_Placeholder", "gate_positive.svg",
                Hex("#81C784"), PrimitiveType.Cube, new Vector3(1.2f, 2.4f, 0.35f), false),
            new(PlaceholderArtId.GateNegative, "PFB_GateNegative_Placeholder", "gate_negative.svg",
                Hex("#EF5350"), PrimitiveType.Cube, new Vector3(1.2f, 2.4f, 0.35f), false),
            new(PlaceholderArtId.CardboardBox, "PFB_CardboardBox_Placeholder", "cardboard_box.svg",
                Hex("#A1887F"), PrimitiveType.Cube, new Vector3(1f, 1f, 1f), false),
            new(PlaceholderArtId.CoinPickup, "PFB_CoinPickup_Placeholder", "coin.svg",
                Hex("#FFCA28"), PrimitiveType.Cylinder, new Vector3(0.6f, 0.12f, 0.6f), false),
            new(PlaceholderArtId.GemPickup, "PFB_GemPickup_Placeholder", "gem.svg",
                Hex("#AB47BC"), PrimitiveType.Cube, new Vector3(0.5f, 0.7f, 0.5f), false),
            new(PlaceholderArtId.UiButtonPrimary, "PFB_UI_ButtonPrimary_Placeholder", "button_primary.svg",
                Hex("#FF9800"), PrimitiveType.Cube, new Vector3(2f, 0.5f, 0.1f), true),
            new(PlaceholderArtId.UiPanelRounded, "PFB_UI_PanelRounded_Placeholder", "panel_rounded.svg",
                Hex("#E3F2FD"), PrimitiveType.Cube, new Vector3(2.4f, 1.6f, 0.08f), true),
        };

        static Color Hex(string hex)
        {
            ColorUtility.TryParseHtmlString(hex, out var c);
            return c;
        }
    }
}
