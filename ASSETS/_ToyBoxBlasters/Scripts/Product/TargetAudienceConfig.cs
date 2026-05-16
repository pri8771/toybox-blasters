using System.Collections.Generic;
using UnityEngine;

namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// Locked target audience and player personas for Task 003. Author in Editor; reference at runtime via provider.
    /// </summary>
    [CreateAssetMenu(
        fileName = "TargetAudienceConfig",
        menuName = "ToyBox Blasters/Product/Target Audience Config")]
    public sealed class TargetAudienceConfig : ScriptableObject
    {
        [Header("Segments (Task 003)")]
        [TextArea(2, 4)]
        [SerializeField] string primaryPlayerSegment = AudiencePersonaDefaults.PrimarySegment;

        [TextArea(2, 3)]
        [SerializeField] string secondarySegments = AudiencePersonaDefaults.SecondarySegments;

        [TextArea(2, 3)]
        [SerializeField] string agePositioning = AudiencePersonaDefaults.AgePositioning;

        [Header("Audience classification")]
        [SerializeField] AudienceClassification audienceClassification = AudiencePersonaDefaults.Classification;

        [TextArea(3, 5)]
        [SerializeField] string classificationRationale = AudiencePersonaDefaults.ClassificationRationale;

        [Header("Session length (minutes)")]
        [SerializeField] float sessionLengthPerRunMinutesMin = AudiencePersonaDefaults.SessionLengthPerRunMinutesMin;
        [SerializeField] float sessionLengthPerRunMinutesMax = AudiencePersonaDefaults.SessionLengthPerRunMinutesMax;
        [SerializeField] float sessionLengthDailyMinutesMin = AudiencePersonaDefaults.SessionLengthDailyMinutesMin;
        [SerializeField] float sessionLengthDailyMinutesMax = AudiencePersonaDefaults.SessionLengthDailyMinutesMax;

        [Header("Monetization")]
        [TextArea(2, 4)]
        [SerializeField] string monetizationModel = AudiencePersonaDefaults.MonetizationModel;

        [TextArea(2, 3)]
        [SerializeField] string monetizationToleranceSummary = AudiencePersonaDefaults.MonetizationToleranceSummary;

        [Header("Motivation loops")]
        [SerializeField] List<string> motivationLoops = new(AudiencePersonaDefaults.MotivationLoops);

        [Header("Personas")]
        [SerializeField] List<PersonaEntry> personas = new();

        public string PrimaryPlayerSegment => primaryPlayerSegment ?? string.Empty;
        public string SecondarySegments => secondarySegments ?? string.Empty;
        public string AgePositioning => agePositioning ?? string.Empty;
        public AudienceClassification AudienceClassification => audienceClassification;
        public string ClassificationRationale => classificationRationale ?? string.Empty;
        public float SessionLengthPerRunMinutesMin => sessionLengthPerRunMinutesMin;
        public float SessionLengthPerRunMinutesMax => sessionLengthPerRunMinutesMax;
        public float SessionLengthDailyMinutesMin => sessionLengthDailyMinutesMin;
        public float SessionLengthDailyMinutesMax => sessionLengthDailyMinutesMax;
        public string MonetizationModel => monetizationModel ?? string.Empty;
        public string MonetizationToleranceSummary => monetizationToleranceSummary ?? string.Empty;
        public IReadOnlyList<string> MotivationLoops => motivationLoops ?? new List<string>();
        public IReadOnlyList<PersonaEntry> Personas => personas ?? new List<PersonaEntry>();

#if UNITY_EDITOR
        public void ApplyDefaults()
        {
            primaryPlayerSegment = AudiencePersonaDefaults.PrimarySegment;
            secondarySegments = AudiencePersonaDefaults.SecondarySegments;
            agePositioning = AudiencePersonaDefaults.AgePositioning;
            audienceClassification = AudiencePersonaDefaults.Classification;
            classificationRationale = AudiencePersonaDefaults.ClassificationRationale;
            sessionLengthPerRunMinutesMin = AudiencePersonaDefaults.SessionLengthPerRunMinutesMin;
            sessionLengthPerRunMinutesMax = AudiencePersonaDefaults.SessionLengthPerRunMinutesMax;
            sessionLengthDailyMinutesMin = AudiencePersonaDefaults.SessionLengthDailyMinutesMin;
            sessionLengthDailyMinutesMax = AudiencePersonaDefaults.SessionLengthDailyMinutesMax;
            monetizationModel = AudiencePersonaDefaults.MonetizationModel;
            monetizationToleranceSummary = AudiencePersonaDefaults.MonetizationToleranceSummary;
            motivationLoops = new List<string>(AudiencePersonaDefaults.MotivationLoops);
            personas = BuildDefaultPersonas();
        }

        static List<PersonaEntry> BuildDefaultPersonas()
        {
            var list = new List<PersonaEntry>();
            foreach (var seed in AudiencePersonaDefaults.Personas)
            {
                list.Add(new PersonaEntry(
                    seed.Id,
                    seed.Name,
                    seed.Description,
                    seed.Goals,
                    seed.Frustrations,
                    seed.MonetizationBehavior,
                    seed.MonetizationTolerance,
                    seed.SessionPattern));
            }

            return list;
        }
#endif
    }
}
