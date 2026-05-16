using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToyBoxBlasters.Product
{
    public static class CompetitiveResearchValidator
    {
        static readonly string[] RequiredCompetitorNames =
        {
            "Mob Control",
            "Archero",
            "Survivor.io",
            "Count Masters",
            "Join Clash",
            "Last War",
            "ToyBox Blasters"
        };

        static readonly CompetitorCategory[] RequiredCategories =
        {
            CompetitorCategory.CrowdArmyVsCastle,
            CompetitorCategory.RoomRogueliteShooter,
            CompetitorCategory.HordeSurvival,
            CompetitorCategory.RunnerGateMath,
            CompetitorCategory.SquadGrowthShooter,
            CompetitorCategory.HybridCasualMonetization,
            CompetitorCategory.AdCreativePattern,
            CompetitorCategory.GenreWeaknessAggregate,
            CompetitorCategory.VisualOpportunity,
            CompetitorCategory.ToyBoxDifferentiator
        };

        public static bool Validate(CompetitiveResearchConfig config, out string report)
        {
            var errors = new List<string>();
            if (config == null)
            {
                report = "CompetitiveResearchConfig is null.";
                return false;
            }

            RequireNonEmpty(errors, "Task id", config.TaskId);
            RequireNonEmpty(errors, "Research version", config.ResearchVersion);
            RequireNonEmpty(errors, "Monetization summary", config.MonetizationIndustrySummary);
            RequireNonEmpty(errors, "Ad creative summary", config.AdCreativeIndustrySummary);
            RequireNonEmpty(errors, "Visual opportunity summary", config.VisualOpportunitySummary);
            RequireNonEmpty(errors, "Genre weakness summary", config.GenreWeaknessSummary);

            if (config.ToyBoxDifferentiators == null || config.ToyBoxDifferentiators.Count < 6)
                errors.Add("At least 6 ToyBox differentiators required (PRD §5).");

            var competitors = config.Competitors;
            if (competitors == null || competitors.Count < 8)
                errors.Add("At least 8 competitor/research rows required.");

            if (competitors != null)
            {
                for (var i = 0; i < competitors.Count; i++)
                {
                    var entry = competitors[i];
                    if (entry == null)
                    {
                        errors.Add($"Competitor row {i} is null.");
                        continue;
                    }

                    RequireNonEmpty(errors, $"Competitor[{i}] name", entry.Name);
                    RequireNonEmpty(errors, $"Competitor[{i}] strengths", entry.Strengths);
                    RequireNonEmpty(errors, $"Competitor[{i}] weaknesses", entry.Weaknesses);
                }

                foreach (var requiredName in RequiredCompetitorNames)
                {
                    if (!competitors.Any(c =>
                            c != null &&
                            c.Name.IndexOf(requiredName, System.StringComparison.OrdinalIgnoreCase) >= 0))
                    {
                        errors.Add($"Missing competitor row containing \"{requiredName}\".");
                    }
                }

                var presentCategories = competitors
                    .Where(c => c != null)
                    .Select(c => c.Category)
                    .Distinct()
                    .ToHashSet();

                foreach (var category in RequiredCategories)
                {
                    if (!presentCategories.Contains(category))
                        errors.Add($"Missing research row for category {category}.");
                }
            }

            if (errors.Count == 0)
            {
                report = "Competitive research validation passed (Task 004).";
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
    }
}
