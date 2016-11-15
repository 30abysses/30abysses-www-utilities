using System.IO;

namespace _30abysses.WWW.Utilities.Common
{
    public class ContentIO
    {
        public string RootInputDirectoryPath { get; }
        public string RootOutputDirectoryPath { get; }

        public ContentIO(string rootInputDirectoryPath, string rootOutputDirectoryPath)
        {
            RootInputDirectoryPath = rootInputDirectoryPath;
            RootOutputDirectoryPath = rootOutputDirectoryPath;
        }

        public void CreateOutputDirectory(string inputDirectoryPath) => Directory.CreateDirectory(GetOutputPath(inputDirectoryPath));

        public string GetOutputPath(string inputPath) => Path.Combine(RootOutputDirectoryPath, inputPath.Substring(RootInputDirectoryPath.Length).TrimStart(Path.DirectorySeparatorChar));

        public void CopyFileToOutputDirectory(string inputFilePath) => File.Copy(inputFilePath, GetOutputPath(inputFilePath), true);

        public void CopyDirectoryToOutputDirectory(string inputDirectoryPath)
        {
            CreateOutputDirectory(inputDirectoryPath);
            foreach (var path in Directory.EnumerateFiles(inputDirectoryPath)) { CopyFileToOutputDirectory(path); }
        }
    }
}
