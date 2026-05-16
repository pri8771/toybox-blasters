using System;
using UnityEngine;

namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// Serializable player persona for Task 003 audience definition.
    /// </summary>
    [Serializable]
    public sealed class PersonaEntry
    {
        [SerializeField] string id = string.Empty;
        [SerializeField] string displayName = string.Empty;

        [TextArea(2, 4)]
        [SerializeField] string description = string.Empty;

        [TextArea(2, 4)]
        [SerializeField] string goals = string.Empty;

        [TextArea(2, 4)]
        [SerializeField] string frustrations = string.Empty;

        [TextArea(2, 3)]
        [SerializeField] string monetizationBehavior = string.Empty;

        [SerializeField] string monetizationTolerance = string.Empty;

        [TextArea(2, 3)]
        [SerializeField] string sessionPattern = string.Empty;

        public string Id => id ?? string.Empty;
        public string DisplayName => displayName ?? string.Empty;
        public string Description => description ?? string.Empty;
        public string Goals => goals ?? string.Empty;
        public string Frustrations => frustrations ?? string.Empty;
        public string MonetizationBehavior => monetizationBehavior ?? string.Empty;
        public string MonetizationTolerance => monetizationTolerance ?? string.Empty;
        public string SessionPattern => sessionPattern ?? string.Empty;

#if UNITY_EDITOR
        public PersonaEntry(
            string personaId,
            string name,
            string personaDescription,
            string personaGoals,
            string personaFrustrations,
            string monetization,
            string tolerance,
            string session)
        {
            id = personaId;
            displayName = name;
            description = personaDescription;
            goals = personaGoals;
            frustrations = personaFrustrations;
            monetizationBehavior = monetization;
            monetizationTolerance = tolerance;
            sessionPattern = session;
        }
#endif
    }
}
