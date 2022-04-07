#if UNITY_EDITOR
using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace CyberBuggy.CreateProjectStructure
{
    public static class DefaultFoldersMenu 
    {
        private static string dataPath = Application.dataPath;

        private static DirectorySet[] _defaultDirectorySets = new[] 
            {new DirectorySet("_Developers", new[] {"KaitoMajima", "Bemesko"}),
            new DirectorySet(Application.productName, new[] {"Art", "Audio", "Levels", "Timeline", "Scripts"}),
            new DirectorySet(Path.Combine(Application.productName, "Art"), new[] {"Materials", "Fonts", "Sprites", "VFX"}),
            new DirectorySet(Path.Combine(Application.productName, "Art", "VFX"), new[] {"PostProcessingAssets", "Shaders", "ParticleEffects"}),
            new DirectorySet(Path.Combine(Application.productName, "Audio"), new[] {"Music", "SFX"}),
            new DirectorySet(Path.Combine(Application.productName, "Levels"), new[] {"Scenes", "Prefabs"}),
            new DirectorySet(Path.Combine(Application.productName, "Timeline"), new[] {"Cutscenes", "Signals"}),
            new DirectorySet(Path.Combine(Application.productName, "Scripts"), new[] {"AI", "Gameplay", "Tools", "ScriptableObjects"})};

        [MenuItem("Tools/CyberBuggy/Create Project Structure/Set Default Folders")]
        public static void SetDefaultFolders()
        {
            foreach (var directorySet in _defaultDirectorySets)
                CreateDirectories(directorySet.root, directorySet.directories);
        }

        private static void CreateDirectories(string root, string[] dirs)
        {
            var rootPath = Path.Combine(dataPath, root);

            foreach (var createdDirectory in dirs)
                Directory.CreateDirectory(Path.Combine(rootPath, createdDirectory));
            
            AssetDatabase.Refresh();
        }
    }
    [Serializable]
    public class DirectorySet
    {
        public string root;
        public string[] directories;

        public DirectorySet(string root, string[] directories)
        {
            this.root = root;
            this.directories = directories;
        }
    }
}

#endif