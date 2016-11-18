using _30abysses.WWW.Utilities.Common.MetaContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using System.Collections.Generic;

namespace _30abysses.WWW.Utilities.UpdateMetaContents
{
    public class AbstractTopicInfoCache
    {
        public AbstractTopicInfoCache() { cache = new Dictionary<AbstractTopic, AbstractTopicInfo>(); }

        public void Add(AbstractTopic abstractTopic) => cache[abstractTopic] = AbstractTopicInfo.New(abstractTopic);

        public AbstractTopicInfo this[AbstractTopic key] { get { return cache[key]; } }

        private readonly IDictionary<AbstractTopic, AbstractTopicInfo> cache;
    }
}
