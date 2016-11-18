using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace _30abysses.WWW.Utilities.Common.MetaContents.Contents
{
    public class IndexInfo : List<IndexInfoNode>
    {
        public static IndexInfo New(IEnumerable<Topic> topics)
        {
            var indexInfo = new IndexInfo();
            indexInfo.AddRange(topics.Select(topic => IndexInfoNode.New(topic)));
            return indexInfo;
        }

        public static string GetPseudoInputFilePath(string path) => path + ".index-info.json";

        public string GetOutputFileContents() => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
