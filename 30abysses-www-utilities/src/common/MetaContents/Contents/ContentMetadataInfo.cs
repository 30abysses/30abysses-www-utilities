using _30abysses.WWW.Utilities.Common.RawContents.Metadata;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _30abysses.WWW.Utilities.Common.MetaContents.Contents
{
    public class ContentMetadataInfo : Dictionary<string, string>
    {
        public ContentMetadataInfo() { }

        public ContentMetadataInfo(ContentMetadata contentMetadata) : base(ReadContentMetadata(contentMetadata)) { }

        public ContentMetadataInfo(ContentMetadataInfo fallbackContentMetadataInfo, ContentMetadata contentMetadata) : base(fallbackContentMetadataInfo) { foreach (var keyValue in ReadContentMetadata(contentMetadata)) { this[keyValue.Key] = keyValue.Value; } }

        public string GetOutputFileContents() => JsonConvert.SerializeObject(this, Formatting.Indented);

        public const string FilenameExtension = ".metadata-info.json";

        private static IDictionary<string, string> ReadContentMetadata(ContentMetadata contentMetadata) => JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(contentMetadata.Path, Encoding.UTF8));
    }
}
