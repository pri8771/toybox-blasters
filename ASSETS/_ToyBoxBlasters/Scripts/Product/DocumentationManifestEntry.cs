using System;
using UnityEngine;

namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// One row in the master documentation manifest (Task 010).
    /// Paths are relative to the Unity project root (parent of Assets/).
    /// </summary>
    [Serializable]
    public sealed class DocumentationManifestEntry
    {
        [SerializeField] string docId = string.Empty;
        [SerializeField] string relativePath = string.Empty;
        [SerializeField] bool required = true;
        [SerializeField] string taskId = string.Empty;
        [SerializeField] string owner = "Product";
        [SerializeField] string lastUpdated = string.Empty;

        public DocumentationManifestEntry() { }

        public DocumentationManifestEntry(
            string docId,
            string relativePath,
            bool required,
            string taskId,
            string owner,
            string lastUpdated)
        {
            this.docId = docId;
            this.relativePath = relativePath;
            this.required = required;
            this.taskId = taskId;
            this.owner = owner;
            this.lastUpdated = lastUpdated;
        }

        public string DocId => docId ?? string.Empty;
        public string RelativePath => relativePath ?? string.Empty;
        public bool Required => required;
        public string TaskId => taskId ?? string.Empty;
        public string Owner => owner ?? string.Empty;
        public string LastUpdated => lastUpdated ?? string.Empty;
    }
}
