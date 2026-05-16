using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToyBoxBlasters.Art
{
    public static class ArtDirectionValidator
    {
        public static bool Validate(ArtDirectionConfig config, out string report)
        {
            var errors = new List<string>();
            if (config == null)
            {
                report = "ArtDirectionConfig is null.";
                return false;
            }

            RequireNonEmpty(errors, "Mood board summary", config.MoodBoardSummary);
            RequireNonEmpty(errors, "Enemy style summary", config.EnemyStyleSummary);
            RequireNonEmpty(errors, "UI style summary", config.UiStyleSummary);
            RequireNonEmpty(errors, "VFX style summary", config.VfxStyleSummary);
            RequireNonEmpty(errors, "Animation personality summary", config.AnimationPersonalitySummary);
            RequireNonEmpty(errors, "Pipeline summary", config.PipelineSummary);

            if (config.CharacterHeadHeightsMin < ArtDirectionDefaults.CharacterHeadHeightsMin - 0.01f ||
                config.CharacterHeadHeightsMax > ArtDirectionDefaults.CharacterHeadHeightsMax + 0.01f)
            {
                errors.Add(
                    $"Character head heights should stay within {ArtDirectionDefaults.CharacterHeadHeightsMin}–" +
                    $"{ArtDirectionDefaults.CharacterHeadHeightsMax} range.");
            }

            if (config.CharacterHeadHeightsMin > config.CharacterHeadHeightsMax)
                errors.Add("Character head heights min cannot exceed max.");

            if (config.CharacterHandFootScale < 1f)
                errors.Add("Hand/foot scale should be >= 1 for chibi readability.");

            if (config.PlayerHeightMeters <= 0f)
                errors.Add("Player height must be positive.");
            if (config.LanePlayableWidthMeters <= 0f)
                errors.Add("Lane playable width must be positive.");

            ValidatePalette(config, errors);
            ValidateBedroomChecklist(config, errors);
            ValidateArtRequirements(config, errors);

            if (errors.Count == 0)
            {
                report = BuildSuccessReport(config);
                return true;
            }

            var sb = new StringBuilder();
            foreach (var e in errors)
                sb.AppendLine("- ").Append(e);
            report = sb.ToString();
            return false;
        }

        static void ValidatePalette(ArtDirectionConfig config, List<string> errors)
        {
            var palette = config.Palette?.ToList() ?? new List<ArtPaletteEntry>();
            if (palette.Count < ArtDirectionDefaults.MinimumPaletteEntries)
            {
                errors.Add(
                    $"Palette entry count {palette.Count} < {ArtDirectionDefaults.MinimumPaletteEntries}.");
            }

            var roleIds = new HashSet<string>();
            var hasPrimary = false;
            var hasUi = false;
            var hasFeedback = false;

            foreach (var entry in palette)
            {
                if (entry == null || string.IsNullOrWhiteSpace(entry.roleId))
                {
                    errors.Add("Palette entry with empty roleId.");
                    continue;
                }

                if (!roleIds.Add(entry.roleId.Trim()))
                    errors.Add($"Duplicate palette roleId: {entry.roleId}");

                if (!entry.TryParseColor(out _))
                    errors.Add($"Invalid hex for palette role '{entry.roleId}': {entry.hex}");

                switch (entry.category)
                {
                    case ArtPaletteCategory.Primary:
                        hasPrimary = true;
                        break;
                    case ArtPaletteCategory.Ui:
                        hasUi = true;
                        break;
                    case ArtPaletteCategory.Feedback:
                        hasFeedback = true;
                        break;
                }
            }

            if (!hasPrimary)
                errors.Add("Palette missing Primary category entries.");
            if (!hasUi)
                errors.Add("Palette missing UI category entries.");
            if (!hasFeedback)
                errors.Add("Palette missing Feedback category entries.");
        }

        static void ValidateBedroomChecklist(ArtDirectionConfig config, List<string> errors)
        {
            var items = config.BedroomFloorChecklist?.Where(s => !string.IsNullOrWhiteSpace(s)).ToList()
                ?? new List<string>();
            if (items.Count < ArtDirectionDefaults.MinimumBedroomChecklistItems)
            {
                errors.Add(
                    $"Bedroom checklist items {items.Count} < {ArtDirectionDefaults.MinimumBedroomChecklistItems}.");
            }
        }

        static void ValidateArtRequirements(ArtDirectionConfig config, List<string> errors)
        {
            var rows = config.ArtRequirements?.ToList() ?? new List<ArtRequirementEntry>();
            if (rows.Count < ArtDirectionDefaults.MinimumArtRequirementRows)
            {
                errors.Add(
                    $"Art requirement rows {rows.Count} < {ArtDirectionDefaults.MinimumArtRequirementRows}.");
            }

            var seenIds = new HashSet<PlaceholderArtId>();
            var seenPrefabs = new HashSet<string>();

            foreach (var row in rows)
            {
                if (row == null)
                {
                    errors.Add("Null art requirement row.");
                    continue;
                }

                if (!seenIds.Add(row.artId))
                    errors.Add($"Duplicate PlaceholderArtId in requirements: {row.artId}");

                if (string.IsNullOrWhiteSpace(row.prefabName))
                {
                    errors.Add($"Empty prefab name for {row.artId}.");
                    continue;
                }

                if (!row.prefabName.StartsWith("PFB_"))
                    errors.Add($"Prefab '{row.prefabName}' should start with PFB_.");

                if (!seenPrefabs.Add(row.prefabName.Trim()))
                    errors.Add($"Duplicate prefab name: {row.prefabName}");

                if (string.IsNullOrWhiteSpace(row.sourceSvg))
                    errors.Add($"Missing source SVG for {row.prefabName}.");
            }

            foreach (PlaceholderArtId id in System.Enum.GetValues(typeof(PlaceholderArtId)))
            {
                if (!seenIds.Contains(id))
                    errors.Add($"Missing art requirement for PlaceholderArtId.{id}.");
            }
        }

        static string BuildSuccessReport(ArtDirectionConfig config)
        {
            var paletteCount = config.Palette?.Count ?? 0;
            var reqCount = config.ArtRequirements?.Count ?? 0;
            var bedroomCount = config.BedroomFloorChecklist?.Count ?? 0;
            return
                $"Art direction validation passed (Task 008). Palette={paletteCount}, " +
                $"requirements={reqCount}, bedroom checklist={bedroomCount}. " +
                $"Lane {config.LanePlayableWidthMeters}m playable @ {config.PlayerHeightMeters}m hero.";
        }

        static void RequireNonEmpty(List<string> errors, string label, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                errors.Add($"{label} is empty.");
        }
    }
}
