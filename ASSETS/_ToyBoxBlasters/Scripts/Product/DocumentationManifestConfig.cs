using System.Collections.Generic;
using UnityEngine;

namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// Master documentation manifest (Task 010). Editor validates files on disk.
    /// </summary>
    [CreateAssetMenu(
        fileName = "DocumentationManifestConfig",
        menuName = "ToyBox Blasters/Product/Documentation Manifest Config")]
    public sealed class DocumentationManifestConfig : ScriptableObject
    {
        [SerializeField] string manifestVersion = DocumentationManifestDefaults.ManifestVersion;
        [SerializeField] List<DocumentationManifestEntry> entries = new();

        public string ManifestVersion => manifestVersion ?? string.Empty;
        public IReadOnlyList<DocumentationManifestEntry> Entries => entries ?? new List<DocumentationManifestEntry>();

#if UNITY_EDITOR
        public void ApplyDefaults()
        {
            manifestVersion = DocumentationManifestDefaults.ManifestVersion;
            entries = DocumentationManifestDefaults.CreateDefaultEntries();
        }
#endif
    }
}
