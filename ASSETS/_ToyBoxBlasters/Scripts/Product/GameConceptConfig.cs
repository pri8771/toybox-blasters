using System.Collections.Generic;
using UnityEngine;

namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// Locked product identity for Task 001. Author in Editor; reference at runtime via provider.
    /// </summary>
    [CreateAssetMenu(
        fileName = "GameConceptConfig",
        menuName = "ToyBox Blasters/Product/Game Concept Config")]
    public sealed class GameConceptConfig : ScriptableObject
    {
        [Header("Identity (Task 001)")]
        [SerializeField] string gameName = GameConceptDefaults.GameName;
        [SerializeField] string genre = GameConceptDefaults.Genre;
        [SerializeField] string visualStyle = GameConceptDefaults.VisualStyle;
        [SerializeField] string targetPlatforms = GameConceptDefaults.TargetPlatforms;
        [SerializeField] string engineName = GameConceptDefaults.EngineName;
        [SerializeField] string backendPreference = GameConceptDefaults.BackendPreference;

        [Header("Narrative")]
        [TextArea(2, 4)]
        [SerializeField] string oneSentencePitch = GameConceptDefaults.OneSentencePitch;

        [TextArea(3, 6)]
        [SerializeField] string corePlayerFantasy = GameConceptDefaults.CorePlayerFantasy;

        [SerializeField] string firstWorldName = GameConceptDefaults.FirstWorldName;

        [TextArea(2, 4)]
        [SerializeField] string firstWorldTheme = GameConceptDefaults.FirstWorldTheme;

        [Header("Differentiation")]
        [SerializeField] List<string> differentiationPoints = new(GameConceptDefaults.DifferentiationPoints);

        public string GameName => gameName ?? string.Empty;
        public string Genre => genre ?? string.Empty;
        public string VisualStyle => visualStyle ?? string.Empty;
        public string TargetPlatforms => targetPlatforms ?? string.Empty;
        public string EngineName => engineName ?? string.Empty;
        public string BackendPreference => backendPreference ?? string.Empty;
        public string OneSentencePitch => oneSentencePitch ?? string.Empty;
        public string CorePlayerFantasy => corePlayerFantasy ?? string.Empty;
        public string FirstWorldName => firstWorldName ?? string.Empty;
        public string FirstWorldTheme => firstWorldTheme ?? string.Empty;
        public IReadOnlyList<string> DifferentiationPoints => differentiationPoints ?? new List<string>();

#if UNITY_EDITOR
        public void ApplyDefaults()
        {
            gameName = GameConceptDefaults.GameName;
            genre = GameConceptDefaults.Genre;
            visualStyle = GameConceptDefaults.VisualStyle;
            targetPlatforms = GameConceptDefaults.TargetPlatforms;
            engineName = GameConceptDefaults.EngineName;
            backendPreference = GameConceptDefaults.BackendPreference;
            oneSentencePitch = GameConceptDefaults.OneSentencePitch;
            corePlayerFantasy = GameConceptDefaults.CorePlayerFantasy;
            firstWorldName = GameConceptDefaults.FirstWorldName;
            firstWorldTheme = GameConceptDefaults.FirstWorldTheme;
            differentiationPoints = new List<string>(GameConceptDefaults.DifferentiationPoints);
        }
#endif
    }
}
