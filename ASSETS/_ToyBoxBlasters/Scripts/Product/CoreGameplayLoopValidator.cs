using System;
using System.Collections.Generic;
using System.Text;

namespace ToyBoxBlasters.Product
{
    public static class CoreGameplayLoopValidator
    {
        public static bool Validate(CoreGameplayLoopConfig config, out string report)
        {
            var errors = new List<string>();
            if (config == null)
            {
                report = "CoreGameplayLoopConfig is null.";
                return false;
            }

            RequireNonEmpty(errors, "Failure rule", config.FailureRuleSummary);
            if (config.PartialCoinsOnFailPercent < 0f || config.PartialCoinsOnFailPercent > 100f)
                errors.Add("Partial coins on fail must be 0–100%.");

            if (Math.Abs(config.PartialCoinsOnFailPercent - CoreGameplayLoopDefaults.PartialCoinsOnFailPercent) > 0.01f)
                errors.Add(
                    $"Partial coins on fail should match design default ({CoreGameplayLoopDefaults.PartialCoinsOnFailPercent}%).");

            ValidateTiming(errors, config);
            RequireNonEmpty(errors, "Gems availability note", config.GemsAvailability);

            if (config.Loops == null || config.Loops.Count == 0)
            {
                errors.Add("No loop definitions.");
            }
            else
            {
                ValidateAllLoopTypesPresent(errors, config);
                foreach (var loop in config.Loops)
                    ValidateLoopEntry(errors, loop, config);
            }

            if (errors.Count == 0)
            {
                report = "Core gameplay loop validation passed (Task 005) — all 10 loop types populated.";
                return true;
            }

            var sb = new StringBuilder();
            foreach (var e in errors)
                sb.AppendLine("- ").Append(e);
            report = sb.ToString();
            return false;
        }

        static void ValidateTiming(List<string> errors, CoreGameplayLoopConfig config)
        {
            if (config.RunLengthMinutesMin > config.RunLengthMinutesMax)
                errors.Add("Run length min cannot exceed max.");

            if (config.SessionLengthMinutesMin > config.SessionLengthMinutesMax)
                errors.Add("Session length min cannot exceed max.");

            if (config.RunsPerSessionMin > config.RunsPerSessionMax)
                errors.Add("Runs per session min cannot exceed max.");

            if (config.RunLengthMinutesMin < AudiencePersonaDefaults.SessionLengthPerRunMinutesMin - 0.01f)
                errors.Add("Run length min below audience definition (2 min).");

            if (config.RunLengthMinutesMax > AudiencePersonaDefaults.SessionLengthPerRunMinutesMax + 0.01f)
                errors.Add("Run length max above audience definition (4 min).");
        }

        static void ValidateAllLoopTypesPresent(List<string> errors, CoreGameplayLoopConfig config)
        {
            var seen = new HashSet<GameplayLoopType>();
            foreach (var loop in config.Loops)
            {
                if (loop == null)
                    continue;

                if (!seen.Add(loop.LoopType))
                    errors.Add($"Duplicate loop type: {loop.LoopType}.");
            }

            foreach (GameplayLoopType expected in Enum.GetValues(typeof(GameplayLoopType)))
            {
                if (!seen.Contains(expected))
                    errors.Add($"Missing loop type: {expected}.");
            }

            if (config.Loops.Count != 10)
                errors.Add($"Expected exactly 10 loop entries; found {config.Loops.Count}.");
        }

        static void ValidateLoopEntry(List<string> errors, LoopDefinitionEntry loop, CoreGameplayLoopConfig config)
        {
            if (loop == null)
            {
                errors.Add("Null loop entry in list.");
                return;
            }

            var label = loop.LoopType.ToString();
            RequireNonEmpty(errors, $"{label} display name", loop.DisplayName);
            RequireNonEmpty(errors, $"{label} summary", loop.Summary);
            RequireNonEmpty(errors, $"{label} description", loop.Description);
            RequireNonEmpty(errors, $"{label} mermaid diagram id", loop.MermaidDiagramId);

            if (loop.KeyBeats == null || loop.KeyBeats.Count < 2)
                errors.Add($"{label} needs at least 2 key beats.");

            switch (loop.LoopType)
            {
                case GameplayLoopType.MomentToMoment:
                    RequireContains(errors, label, loop.Summary, "auto");
                    RequireContains(errors, label, loop.Summary, "steer");
                    break;

                case GameplayLoopType.Level:
                    RequireContains(errors, label, loop.Summary, "boss");
                    break;

                case GameplayLoopType.FailureRetry:
                    if (Math.Abs(loop.PartialCoinsOnFailPercent - config.PartialCoinsOnFailPercent) > 0.01f)
                        errors.Add($"{label} partial coin % must match config global ({config.PartialCoinsOnFailPercent}%).");
                    break;

                case GameplayLoopType.AdReward:
                case GameplayLoopType.Cosmetic:
                case GameplayLoopType.LiveOps:
                    if (loop.ImplementationPhase == LoopImplementationPhase.Mvp)
                        errors.Add($"{label} must not be MVP phase — designed/soft launch only.");
                    break;
            }
        }

        static void RequireNonEmpty(List<string> errors, string label, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                errors.Add($"{label} is empty.");
        }

        static void RequireContains(List<string> errors, string label, string haystack, string needle)
        {
            if (string.IsNullOrWhiteSpace(haystack) ||
                haystack.IndexOf(needle, StringComparison.OrdinalIgnoreCase) < 0)
                errors.Add($"{label} summary should mention \"{needle}\".");
        }
    }
}
