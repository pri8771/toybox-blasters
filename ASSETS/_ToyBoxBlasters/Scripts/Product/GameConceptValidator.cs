using System.Collections.Generic;
using System.Text;

namespace ToyBoxBlasters.Product
{
    public static class GameConceptValidator
    {
        public static bool Validate(GameConceptConfig config, out string report)
        {
            var errors = new List<string>();
            if (config == null)
            {
                report = "GameConceptConfig is null.";
                return false;
            }

            RequireMatch(errors, "Game name", config.GameName, GameConceptDefaults.GameName);
            RequireMatch(errors, "Genre", config.Genre, GameConceptDefaults.Genre);
            RequireMatch(errors, "Visual style", config.VisualStyle, GameConceptDefaults.VisualStyle);
            RequireMatch(errors, "Target platforms", config.TargetPlatforms, GameConceptDefaults.TargetPlatforms);
            RequireMatch(errors, "Engine", config.EngineName, GameConceptDefaults.EngineName);
            RequireMatch(errors, "Backend", config.BackendPreference, GameConceptDefaults.BackendPreference);

            RequireNonEmpty(errors, "One-sentence pitch", config.OneSentencePitch);
            RequireNonEmpty(errors, "Core player fantasy", config.CorePlayerFantasy);
            RequireNonEmpty(errors, "First world name", config.FirstWorldName);
            RequireNonEmpty(errors, "First world theme", config.FirstWorldTheme);

            if (config.DifferentiationPoints == null || config.DifferentiationPoints.Count < 3)
                errors.Add("At least 3 differentiation points required.");

            if (errors.Count == 0)
            {
                report = "Game concept validation passed (Task 001).";
                return true;
            }

            var sb = new StringBuilder();
            foreach (var e in errors)
                sb.AppendLine("- ").Append(e);
            report = sb.ToString();
            return false;
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
                errors.Add($"{label} mismatch. Expected: \"{expected}\". Actual: \"{actual}\".");
        }
    }
}
