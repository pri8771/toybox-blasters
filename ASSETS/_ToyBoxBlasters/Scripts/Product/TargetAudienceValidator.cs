using System.Collections.Generic;
using System.Text;

namespace ToyBoxBlasters.Product
{
    public static class TargetAudienceValidator
    {
        public static bool Validate(TargetAudienceConfig config, out string report)
        {
            var errors = new List<string>();
            if (config == null)
            {
                report = "TargetAudienceConfig is null.";
                return false;
            }

            RequireMatch(errors, "Primary segment", config.PrimaryPlayerSegment, AudiencePersonaDefaults.PrimarySegment);
            RequireNonEmpty(errors, "Secondary segments", config.SecondarySegments);
            RequireMatch(errors, "Age positioning", config.AgePositioning, AudiencePersonaDefaults.AgePositioning);

            if (config.AudienceClassification != AudiencePersonaDefaults.Classification)
                errors.Add(
                    $"Audience classification must be {AudiencePersonaDefaults.Classification} (general audience, not child-directed).");

            RequireNonEmpty(errors, "Classification rationale", config.ClassificationRationale);

            ValidateSessionLength(errors, config);
            RequireNonEmpty(errors, "Monetization model", config.MonetizationModel);
            RequireNonEmpty(errors, "Monetization tolerance", config.MonetizationToleranceSummary);

            if (config.MotivationLoops == null || config.MotivationLoops.Count < 4)
                errors.Add("At least 4 motivation loops required.");

            ValidatePersonas(errors, config);

            if (errors.Count == 0)
            {
                report = "Target audience validation passed (Task 003).";
                return true;
            }

            var sb = new StringBuilder();
            foreach (var e in errors)
                sb.AppendLine("- ").Append(e);
            report = sb.ToString();
            return false;
        }

        static void ValidateSessionLength(List<string> errors, TargetAudienceConfig config)
        {
            if (config.SessionLengthPerRunMinutesMin <= 0f || config.SessionLengthPerRunMinutesMax <= 0f)
                errors.Add("Per-run session length bounds must be positive.");

            if (config.SessionLengthPerRunMinutesMin > config.SessionLengthPerRunMinutesMax)
                errors.Add("Per-run session min cannot exceed max.");

            if (config.SessionLengthPerRunMinutesMin != AudiencePersonaDefaults.SessionLengthPerRunMinutesMin
                || config.SessionLengthPerRunMinutesMax != AudiencePersonaDefaults.SessionLengthPerRunMinutesMax)
                errors.Add(
                    $"Per-run session length must be {AudiencePersonaDefaults.SessionLengthPerRunMinutesMin}-{AudiencePersonaDefaults.SessionLengthPerRunMinutesMax} minutes.");

            if (config.SessionLengthDailyMinutesMin <= 0f || config.SessionLengthDailyMinutesMax <= 0f)
                errors.Add("Daily session length bounds must be positive.");

            if (config.SessionLengthDailyMinutesMin > config.SessionLengthDailyMinutesMax)
                errors.Add("Daily session min cannot exceed max.");
        }

        static void ValidatePersonas(List<string> errors, TargetAudienceConfig config)
        {
            if (config.Personas == null || config.Personas.Count < 4)
            {
                errors.Add("At least 4 personas required (Casual, Progression, Collector, Ad-watcher).");
                return;
            }

            var requiredIds = new[]
            {
                AudiencePersonaDefaults.PersonaIdCasual,
                AudiencePersonaDefaults.PersonaIdProgression,
                AudiencePersonaDefaults.PersonaIdCollector,
                AudiencePersonaDefaults.PersonaIdAdWatcher
            };

            foreach (var requiredId in requiredIds)
            {
                var found = false;
                foreach (var persona in config.Personas)
                {
                    if (persona == null || persona.Id != requiredId)
                        continue;

                    found = true;
                    RequireNonEmpty(errors, $"Persona '{requiredId}' name", persona.DisplayName);
                    RequireNonEmpty(errors, $"Persona '{requiredId}' description", persona.Description);
                    RequireNonEmpty(errors, $"Persona '{requiredId}' goals", persona.Goals);
                    RequireNonEmpty(errors, $"Persona '{requiredId}' frustrations", persona.Frustrations);
                    RequireNonEmpty(errors, $"Persona '{requiredId}' monetization behavior", persona.MonetizationBehavior);
                    RequireNonEmpty(errors, $"Persona '{requiredId}' monetization tolerance", persona.MonetizationTolerance);
                    RequireNonEmpty(errors, $"Persona '{requiredId}' session pattern", persona.SessionPattern);
                    break;
                }

                if (!found)
                    errors.Add($"Missing required persona id: {requiredId}.");
            }
        }

        static void RequireNonEmpty(List<string> errors, string label, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                errors.Add($"{label} is empty.");
        }

        static void RequireMatch(List<string> errors, string label, string actual, string expected)
        {
            if (string.IsNullOrWhiteSpace(actual))
            {
                errors.Add($"{label} is empty.");
                return;
            }

            if (actual.Trim() != expected.Trim())
                errors.Add($"{label} mismatch. Expected locked Task 003 value.");
        }
    }
}
