using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToyBoxBlasters.Product
{
    public static class ReleaseScopeValidator
    {
        public const int MinimumMvpMustHaveFeatures = 10;
        public const int MinimumSoftLaunchMustHaveFeatures = 5;
        public const int MinimumProductionMustHaveFeatures = 5;

        public static bool Validate(ReleaseScopeConfig config, out string report)
        {
            var errors = new List<string>();
            if (config == null)
            {
                report = "ReleaseScopeConfig is null.";
                return false;
            }

            RequireNonEmpty(errors, "MVP scope summary", config.MvpScopeSummary);
            RequireNonEmpty(errors, "Soft launch scope summary", config.SoftLaunchScopeSummary);
            RequireNonEmpty(errors, "Production scope summary", config.ProductionScopeSummary);
            RequireNonEmpty(errors, "First playable prototype goal", config.FirstPlayablePrototypeGoal);

            if (config.V1Excluded == null || config.V1Excluded.Count < 3)
                errors.Add("At least 3 V1 exclusions required.");
            if (config.PostLaunchAdditions == null || config.PostLaunchAdditions.Count < 3)
                errors.Add("At least 3 post-launch items required.");
            if (config.ProductionSuccessCriteria == null || config.ProductionSuccessCriteria.Count < 3)
                errors.Add("At least 3 production success criteria required.");

            var features = config.Features?.ToList() ?? new List<FeatureScopeEntry>();
            if (features.Count == 0)
            {
                errors.Add("Feature list is empty.");
            }
            else
            {
                ValidateFeatures(features, errors);
            }

            if (errors.Count == 0)
            {
                report = BuildSuccessReport(config, features);
                return true;
            }

            var sb = new StringBuilder();
            foreach (var e in errors)
                sb.AppendLine("- ").Append(e);
            report = sb.ToString();
            return false;
        }

        static void ValidateFeatures(List<FeatureScopeEntry> features, List<string> errors)
        {
            var ids = new HashSet<string>();
            foreach (var f in features)
            {
                if (f == null || string.IsNullOrWhiteSpace(f.id))
                {
                    errors.Add("Feature with empty id found.");
                    continue;
                }

                if (!ids.Add(f.id.Trim()))
                    errors.Add($"Duplicate feature id: {f.id}");
            }

            foreach (var f in features)
            {
                if (f?.dependencies == null)
                    continue;
                foreach (var dep in f.dependencies)
                {
                    if (string.IsNullOrWhiteSpace(dep))
                        continue;
                    if (!ids.Contains(dep.Trim()))
                        errors.Add($"Feature '{f.id}' depends on unknown id '{dep}'.");
                }
            }

            if (HasCircularDependency(features, out var cycle))
                errors.Add($"Circular dependency detected: {cycle}");

            CountMustHave(features, ReleasePhase.Mvp, MinimumMvpMustHaveFeatures, errors);
            CountMustHave(features, ReleasePhase.SoftLaunch, MinimumSoftLaunchMustHaveFeatures, errors);
            CountMustHave(features, ReleasePhase.Production, MinimumProductionMustHaveFeatures, errors);

            if (!features.Any(f => f.id == "runner_forward"))
                errors.Add("Missing required feature id: runner_forward");
        }

        static void CountMustHave(
            List<FeatureScopeEntry> features,
            ReleasePhase phase,
            int minimum,
            List<string> errors)
        {
            var count = features.Count(f => f != null && f.releasePhase == phase && f.mustHave);
            if (count < minimum)
                errors.Add($"{phase} must-have feature count {count} < {minimum}.");
        }

        static bool HasCircularDependency(List<FeatureScopeEntry> features, out string cyclePath)
        {
            var graph = features
                .Where(f => f != null && !string.IsNullOrWhiteSpace(f.id))
                .ToDictionary(f => f.id.Trim(), f => f.dependencies ?? new List<string>());

            var visiting = new HashSet<string>();
            var visited = new HashSet<string>();

            foreach (var id in graph.Keys)
            {
                if (Dfs(id, graph, visiting, visited, new List<string>(), out cyclePath))
                    return true;
            }

            cyclePath = null;
            return false;
        }

        static bool Dfs(
            string id,
            Dictionary<string, List<string>> graph,
            HashSet<string> visiting,
            HashSet<string> visited,
            List<string> path,
            out string cyclePath)
        {
            if (visiting.Contains(id))
            {
                path.Add(id);
                cyclePath = string.Join(" -> ", path);
                return true;
            }

            if (visited.Contains(id))
            {
                cyclePath = null;
                return false;
            }

            visiting.Add(id);
            path.Add(id);

            if (graph.TryGetValue(id, out var deps))
            {
                foreach (var dep in deps)
                {
                    if (string.IsNullOrWhiteSpace(dep))
                        continue;
                    var trimmed = dep.Trim();
                    if (!graph.ContainsKey(trimmed))
                        continue;
                    if (Dfs(trimmed, graph, visiting, visited, path, out cyclePath))
                        return true;
                }
            }

            visiting.Remove(id);
            path.RemoveAt(path.Count - 1);
            visited.Add(id);
            cyclePath = null;
            return false;
        }

        static string BuildSuccessReport(ReleaseScopeConfig config, List<FeatureScopeEntry> features)
        {
            var mvp = features.Count(f => f.releasePhase == ReleasePhase.Mvp);
            var soft = features.Count(f => f.releasePhase == ReleasePhase.SoftLaunch);
            var prod = features.Count(f => f.releasePhase == ReleasePhase.Production);
            return $"Release scope validation passed (Task 002). Features: MVP={mvp}, SoftLaunch={soft}, Production={prod}. " +
                   $"V1 exclusions={config.V1Excluded.Count}, Post-launch={config.PostLaunchAdditions.Count}.";
        }

        static void RequireNonEmpty(List<string> errors, string label, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                errors.Add($"{label} is empty.");
        }
    }
}
