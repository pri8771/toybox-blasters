#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using ToyBoxBlasters.Art;
using UnityEditor;
using UnityEngine;

namespace ToyBoxBlasters.Editor.Art
{
    public static class PlaceholderArtSetupEditor
    {
        const string MenuPath = "ToyBox Blasters/Setup Placeholder Art";
        const string ArtRoot = "Assets/_ToyBoxBlasters/Art";
        const string UiRoot = "Assets/_ToyBoxBlasters/UI";
        const string SourceSvgFolder = ArtRoot + "/SourceSVG";
        const string ArtPrefabFolder = ArtRoot + "/Prefabs/Placeholders";
        const string UiPrefabFolder = UiRoot + "/Prefabs/Placeholders";
        const string MaterialFolder = ArtRoot + "/Materials/Placeholders";
        const string RegistryFolder = ArtRoot + "/Config";
        const string RegistryAssetPath = RegistryFolder + "/PlaceholderArtRegistry.asset";

        [MenuItem(MenuPath)]
        public static void SetupPlaceholderArt()
        {
            EnsureFolders();
            var copied = CopySourceSvgsFromPack();
            AssetDatabase.Refresh();

            var usedSprites = HasVectorGraphicsPackage() && TryBuildSpritePrefabs(copied, out var spriteCount);
            if (!usedSprites || spriteCount < PlaceholderArtPalette.All.Length)
            {
                PlaceholderArtDebug.LogSetup(
                    $"Using primitive placeholders (sprites: {spriteCount}/{PlaceholderArtPalette.All.Length}).");
                BuildPrimitivePrefabs();
            }

            CreateOrUpdateRegistry();
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            PlaceholderArtDebug.LogSetup("Placeholder art setup complete.");
            EditorUtility.DisplayDialog("ToyBox Blasters", "Placeholder art setup complete.", "OK");
        }

        static void EnsureFolders()
        {
            Directory.CreateDirectory(Path.Combine(Application.dataPath, "_ToyBoxBlasters/Art/SourceSVG"));
            Directory.CreateDirectory(Path.Combine(Application.dataPath, "_ToyBoxBlasters/Art/Prefabs/Placeholders"));
            Directory.CreateDirectory(Path.Combine(Application.dataPath, "_ToyBoxBlasters/UI/Prefabs/Placeholders"));
            Directory.CreateDirectory(Path.Combine(Application.dataPath, "_ToyBoxBlasters/Art/Materials/Placeholders"));
            Directory.CreateDirectory(Path.Combine(Application.dataPath, "_ToyBoxBlasters/Art/Config"));
            AssetDatabase.Refresh();
        }

        /// <summary>
        /// Resolves canonical SVG pack: repo /ASSETS, Assets/PlaceholderPack, or ART_SOURCE at project root.
        /// </summary>
        static string ResolveSourcePackPath()
        {
            var projectRoot = Path.GetFullPath(Path.Combine(Application.dataPath, ".."));
            var candidates = new[]
            {
                Path.Combine(projectRoot, "ASSETS"),
                Path.Combine(projectRoot, "ART_SOURCE"),
                Path.Combine(Application.dataPath, "PlaceholderPack")
            };

            foreach (var path in candidates)
            {
                if (Directory.Exists(path))
                    return path;
            }

            return null;
        }

        static Dictionary<string, string> CopySourceSvgsFromPack()
        {
            var map = new Dictionary<string, string>();
            var packRoot = ResolveSourcePackPath();
            if (packRoot == null)
            {
                Debug.LogError("[ToyBoxBlasters] No placeholder pack found. Expected ASSETS/, ART_SOURCE/, or Assets/PlaceholderPack/.");
                return map;
            }

            foreach (var spec in PlaceholderArtPalette.All)
            {
                var rel = FindSvgRelativePath(packRoot, spec.SourceSvg);
                if (rel == null)
                {
                    Debug.LogWarning($"[ToyBoxBlasters] SVG not found: {spec.SourceSvg} under {packRoot}");
                    continue;
                }

                var sourceFull = Path.Combine(packRoot, rel);
                var destRel = $"{SourceSvgFolder}/{Path.GetFileName(spec.SourceSvg)}";
                var destFull = Path.Combine(Application.dataPath, "..", destRel);
                Directory.CreateDirectory(Path.GetDirectoryName(destFull)!);
                File.Copy(sourceFull, destFull, true);
                map[spec.SourceSvg] = destRel.Replace('\\', '/');
            }

            return map;
        }

        static string FindSvgRelativePath(string packRoot, string fileName)
        {
            foreach (var file in Directory.GetFiles(packRoot, fileName, SearchOption.AllDirectories))
                return Path.GetRelativePath(packRoot, file).Replace('\\', '/');
            return null;
        }

        static bool HasVectorGraphicsPackage()
        {
            var manifestPath = Path.Combine(Application.dataPath, "..", "Packages/manifest.json");
            if (!File.Exists(manifestPath))
                return false;
            return File.ReadAllText(manifestPath).Contains("com.unity.vectorgraphics");
        }

        static bool TryBuildSpritePrefabs(Dictionary<string, string> importedPaths, out int spriteCount)
        {
            spriteCount = 0;
            foreach (var spec in PlaceholderArtPalette.All)
            {
                if (!importedPaths.TryGetValue(spec.SourceSvg, out var assetPath))
                    return false;

                AssetDatabase.ImportAsset(assetPath, ImportAssetOptions.ForceUpdate);
                var sprite = LoadFirstSprite(assetPath);
                if (sprite == null)
                    return false;

                var folder = spec.UiPrefab ? UiPrefabFolder : ArtPrefabFolder;
                CreateSpritePrefab(spec, sprite, folder);
                spriteCount++;
            }

            return spriteCount > 0;
        }

        static Sprite LoadFirstSprite(string assetPath)
        {
            foreach (var a in AssetDatabase.LoadAllAssetsAtPath(assetPath))
            {
                if (a is Sprite s)
                    return s;
            }

            return null;
        }

        static void CreateSpritePrefab(PlaceholderArtPalette.Spec spec, Sprite sprite, string folder)
        {
            var go = new GameObject(spec.PrefabName);
            var sr = go.AddComponent<SpriteRenderer>();
            sr.sprite = sprite;
            sr.sortingOrder = spec.UiPrefab ? 100 : 0;
            var tag = go.AddComponent<PlaceholderVisualTag>();
            tag.SetArtId(spec.Id);
            SavePrefab(go, $"{folder}/{spec.PrefabName}.prefab");
            Object.DestroyImmediate(go);
        }

        static void BuildPrimitivePrefabs()
        {
            foreach (var spec in PlaceholderArtPalette.All)
            {
                var mat = GetOrCreateMaterial(spec);
                var folder = spec.UiPrefab ? UiPrefabFolder : ArtPrefabFolder;
                var go = GameObject.CreatePrimitive(spec.Primitive);
                go.name = spec.PrefabName;
                Object.DestroyImmediate(go.GetComponent<Collider>());
                go.transform.localScale = spec.Scale;
                go.GetComponent<Renderer>().sharedMaterial = mat;
                var tag = go.AddComponent<PlaceholderVisualTag>();
                tag.SetArtId(spec.Id);
                SavePrefab(go, $"{folder}/{spec.PrefabName}.prefab");
                Object.DestroyImmediate(go);
            }
        }

        static Material GetOrCreateMaterial(PlaceholderArtPalette.Spec spec)
        {
            var path = $"{MaterialFolder}/MAT_{spec.PrefabName}.mat";
            var existing = AssetDatabase.LoadAssetAtPath<Material>(path);
            if (existing != null)
                return existing;

            var shader = Shader.Find("Universal Render Pipeline/Lit") ?? Shader.Find("Standard");
            var mat = new Material(shader) { color = spec.Color };
            AssetDatabase.CreateAsset(mat, path);
            return mat;
        }

        static void SavePrefab(GameObject go, string assetPath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(Path.Combine(Application.dataPath, "..", assetPath))!);
            PrefabUtility.SaveAsPrefabAsset(go, assetPath);
        }

        static void CreateOrUpdateRegistry()
        {
            var registry = AssetDatabase.LoadAssetAtPath<PlaceholderArtRegistry>(RegistryAssetPath);
            if (registry == null)
            {
                registry = ScriptableObject.CreateInstance<PlaceholderArtRegistry>();
                AssetDatabase.CreateAsset(registry, RegistryAssetPath);
            }

            var list = registry.EditorEntries;
            list.Clear();
            foreach (var spec in PlaceholderArtPalette.All)
            {
                var folder = spec.UiPrefab ? UiPrefabFolder : ArtPrefabFolder;
                list.Add(new PlaceholderArtEntry
                {
                    id = spec.Id,
                    prefab = AssetDatabase.LoadAssetAtPath<GameObject>($"{folder}/{spec.PrefabName}.prefab"),
                    sourceSvgFileName = spec.SourceSvg
                });
            }

            EditorUtility.SetDirty(registry);
            registry.RebuildLookup();
        }
    }
}
#endif
