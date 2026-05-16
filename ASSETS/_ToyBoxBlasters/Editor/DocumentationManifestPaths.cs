#if UNITY_EDITOR
using System.IO;
using UnityEngine;

namespace ToyBoxBlasters.Editor.Product
{
    internal static class DocumentationManifestPaths
    {
        public static string ProjectRoot =>
            Path.GetFullPath(Path.Combine(Application.dataPath, ".."));
    }
}
#endif
