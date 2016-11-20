using Newtonsoft.Json;
using System.Collections.Generic;

namespace _30abysses.WWW.Utilities.Common.MetaContents.Contents
{
    public class OrganizationInfo : List<OrganizationInfo.Node>
    {
        public class Node
        {
            public Node() { }

            public Node(ItemInfo itemInfo, string relativePath)
            {
                ItemInfo = itemInfo;
                RelativePath = relativePath;
            }

            public ItemInfo ItemInfo;
            public string RelativePath;
        }

        public string GetOutputFileContents() => JsonConvert.SerializeObject(this, Formatting.Indented);

        public const string FilenameExtension = ".organization-info.json";
    }
}
