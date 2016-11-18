using _30abysses.WWW.Utilities.Common.MetaContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using System.Collections.Generic;

namespace _30abysses.WWW.Utilities.UpdateMetaContents
{
    public class ItemInfoCache
    {
        public ItemInfoCache() { cache = new Dictionary<Item, ItemInfo>(); }

        public void Add(WwwRoot wwwRoot) => cache[wwwRoot] = ItemInfo.New(wwwRoot);

        public void Add(OrganizationalContainer organizationalContainer) => cache[organizationalContainer] = ItemInfo.New(organizationalContainer);

        public void Add(_404Template _404Template) => cache[_404Template] = ItemInfo.New(_404Template);

        public void Add(Topic topic, AbstractTopicInfo abstractTopicInfo) => cache[topic] = ItemInfo.New(topic, abstractTopicInfo);

        public void Add(MetaTopic metaTopic, AbstractTopicInfo abstractTopicInfo) => cache[metaTopic] = ItemInfo.New(metaTopic, abstractTopicInfo);

        public ItemInfo this[Item key] { get { return cache[key]; } }

        private readonly IDictionary<Item, ItemInfo> cache;
    }
}
