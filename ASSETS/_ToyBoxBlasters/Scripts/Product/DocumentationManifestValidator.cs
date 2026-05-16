using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ToyBoxBlasters.Product
{
    public static class DocumentationManifestValidator
    {
        public static bool Validate(
            DocumentationManifestConfig config,
            string projectRootFullPath,
            out string report)
        {
            var errors = new List<string>();
            if (config == null)
            {
                report = "DocumentationManifestConfig is null.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(projectRootFullPath))
            {
                report = "Project root path is empty.";
                return false;
            }

            if (config.Entries == null || config.Entries.Count == 0)
            {
                errors.Add("No documentation entries in manifest.");
            }
            else
            {
                var seenIds = new HashSet<string>();
                var missingRequired = 0;
                var missingOptional = 0;
                var present = 0;

                foreach (var entry in config.Entries)
                {
                    if (entry == null)
                    {
                        errors.Add("Null manifest entry.");
                        continue;
                    }

                    if (string.IsNullOrWhiteSpace(entry.DocId))
                        errors.Add("Entry missing docId.");
                    else if (!seenIds.Add(entry.DocId))
                        errors.Add($"Duplicate docId: {entry.DocId}.");

                    if (string.IsNullOrWhiteSpace(entry.RelativePath))
                    {
                        errors.Add($"Entry '{entry.DocId}' missing relativePath.");
                        continue;
                    }

                    var fullPath = Path.GetFullPath(Path.Combine(projectRootFullPath, entry.RelativePath));
                    if (File.Exists(fullPath))
                    {
                        present++;
                        continue;
                    }

                    if (entry.Required)
                    {
                        missingRequired++;
                        errors.Add($"Missing required doc: {entry.RelativePath} ({entry.DocId}).");
                    }
                    else
                    {
                        missingOptional++;
                    }
                }

                if (errors.Count == 0)
                {
                    report =
                        $"Documentation manifest validation passed (Task 010). " +
                        $"{present} file(s) on disk; {missingOptional} optional missing.";
                    return true;
                }

                report = BuildReport(errors, present, missingRequired, missingOptional);
                return false;
            }

            report = BuildReport(errors, 0, 0, 0);
            return false;
        }

        static string BuildReport(List<string> errors, int present, int missingRequired, int missingOptional)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Documentation validation failed — {missingRequired} required missing, {missingOptional} optional missing, {present} present.");
            foreach (var e in errors)
                sb.AppendLine("- ").Append(e);
            return sb.ToString();
        }
    }
}
