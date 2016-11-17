using _30abysses.WWW.Utilities.Common.MetaContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Metadata;
using System.Collections.Generic;

namespace _30abysses.WWW.Utilities.UpdateMetaContents
{
    public class WwwRootAssetContainerInfoCache
    {
        public WwwRootAssetContainerInfoCache(AssetContainer wwwRootAssetContainer)
        {
            this.wwwRootAssetContainer = wwwRootAssetContainer;
            cache = new Dictionary<Item, WwwRootAssetContainerInfo>();
        }

        public void Add(OrganizationalContainer organizationalContainer)
        {
            var container = organizationalContainer.Container;
            cache[organizationalContainer] = cache.ContainsKey(container) ? WwwRootAssetContainerInfo.New(cache[container]) : WwwRootAssetContainerInfo.New(organizationalContainer, wwwRootAssetContainer);
        }

        public void Add(Item item) => cache[item] = cache[item.Container];

        private readonly AssetContainer wwwRootAssetContainer;
        private readonly IDictionary<Item, WwwRootAssetContainerInfo> cache;
    }
}
