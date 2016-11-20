using Newtonsoft.Json;

namespace _30abysses.WWW.Utilities.Common.MetaContents.Contents
{
    public class WwwRootAssetContainerInfo
    {
        public string GetOutputFileContents() => JsonConvert.SerializeObject(this, Formatting.Indented);

        public const string FilenameExtension = ".www-root-asset-container-info.json";

        public string RelativePath;
    }
}
