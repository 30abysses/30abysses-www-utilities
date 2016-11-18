using _30abysses.WWW.Utilities.Common.MetaContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using System.Collections.Generic;

namespace _30abysses.WWW.Utilities.UpdateMetaContents
{
    public class OrganizationInfoCache
    {
        public OrganizationInfoCache()
        {
            cache = new Dictionary<Item, OrganizationInfo>();
        }

        public void Add(Item item, ItemInfo itemInfo)
        {
            var container = item.Container;
            cache[item] = cache.ContainsKey(container) ? OrganizationInfo.New(cache[container], item, itemInfo) : OrganizationInfo.New(item, itemInfo);
        }

        public OrganizationInfo this[Item key] { get { return cache[key]; } }

        private readonly IDictionary<Item, OrganizationInfo> cache;
    }
}
