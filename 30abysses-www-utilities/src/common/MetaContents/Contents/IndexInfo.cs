using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace _30abysses.WWW.Utilities.Common.MetaContents.Contents
{
    public class IndexInfo : List<IndexInfo.Node>
    {
        public class Node
        {
            public Node() { }

            public Node(AbstractTopicInfo topicInfo, OrganizationInfo topicOrganizationInfo, AbstractTopicInfo metaTopicInfo, OrganizationInfo metaTopicOrganizationInfo)
            {
                TopicInfo = topicInfo;
                TopicOrganizationInfo = topicOrganizationInfo;
                MetaTopicInfo = metaTopicInfo;
                MetaTopicOrganizationInfo = metaTopicOrganizationInfo;
            }

            public AbstractTopicInfo TopicInfo;
            public OrganizationInfo TopicOrganizationInfo;
            public AbstractTopicInfo MetaTopicInfo;
            public OrganizationInfo MetaTopicOrganizationInfo;
        }

        public IndexInfo() { }

        public IndexInfo(IEnumerable<Node> nodes) : base(nodes) { }

        public IndexInfo(IEnumerable<IndexInfo> indexInfos) : base(indexInfos.SelectMany(indexInfo => indexInfo)) { }

        public string GetOutputFileContents() => JsonConvert.SerializeObject(this, Formatting.Indented);

        public const string FilenameExtension = ".index-info.json";
    }
}
