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
    }
}
