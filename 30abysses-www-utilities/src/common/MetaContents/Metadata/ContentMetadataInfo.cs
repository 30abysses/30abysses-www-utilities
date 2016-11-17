using _30abysses.WWW.Utilities.Common.RawContents.Metadata;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _30abysses.WWW.Utilities.Common.MetaContents.Metadata
{
    public class ContentMetadataInfo : Dictionary<string, string>
    {
        public static ContentMetadataInfo New(ContentMetadata contentMetadata, ContentMetadataInfo fallbackContentMetadataInfo)
        {
            var contentMetadataInfo = new ContentMetadataInfo();
            if (fallbackContentMetadataInfo != null) { Merge(fallbackContentMetadataInfo, contentMetadataInfo); }
            Merge(JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(contentMetadata.Path, Encoding.UTF8)), contentMetadataInfo);
            return contentMetadataInfo;
        }

        public string GetOutputFileContents() => JsonConvert.SerializeObject(this, Formatting.Indented);

        public string GetPseudoInputFilePath(string path) => path + ".metadata-info.json";

        private static void Merge<K, V>(IDictionary<K, V> from, IDictionary<K, V> to) { foreach (var keyValue in from) { to[keyValue.Key] = keyValue.Value; } }
    }
}
