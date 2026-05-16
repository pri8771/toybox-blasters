using System;
using System.Collections.Generic;
using UnityEngine;

namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// One layer of the core gameplay loop stack (Task 005).
    /// </summary>
    [Serializable]
    public sealed class LoopDefinitionEntry
    {
        public GameplayLoopType loopType;
        public string displayName = string.Empty;

        [TextArea(1, 3)]
        public string summary = string.Empty;

        [TextArea(3, 8)]
        public string description = string.Empty;

        [Tooltip("Doc key for mermaid diagram in PROJECT_DOCS/CORE_GAMEPLAY_LOOP.md")]
        public string mermaidDiagramId = string.Empty;

        public LoopImplementationPhase implementationPhase = LoopImplementationPhase.Mvp;

        [Tooltip("Primary personas this loop serves (Task 003 ids)")]
        public List<string> personaIds = new();

        [Tooltip("Ordered beats or steps in this loop")]
        public List<string> keyBeats = new();

        [Tooltip("Future ScriptableObject tuning keys — no magic numbers in code")]
        public List<string> tuningConfigKeys = new();

        [Range(0f, 100f)]
        public float partialCoinsOnFailPercent;

        public GameplayLoopType LoopType => loopType;
        public string DisplayName => displayName ?? string.Empty;
        public string Summary => summary ?? string.Empty;
        public string Description => description ?? string.Empty;
        public string MermaidDiagramId => mermaidDiagramId ?? string.Empty;
        public LoopImplementationPhase ImplementationPhase => implementationPhase;
        public IReadOnlyList<string> PersonaIds => personaIds ?? new List<string>();
        public IReadOnlyList<string> KeyBeats => keyBeats ?? new List<string>();
        public IReadOnlyList<string> TuningConfigKeys => tuningConfigKeys ?? new List<string>();
        public float PartialCoinsOnFailPercent => partialCoinsOnFailPercent;
    }
}
