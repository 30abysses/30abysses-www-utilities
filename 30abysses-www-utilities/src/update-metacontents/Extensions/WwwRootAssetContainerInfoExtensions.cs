using _30abysses.WWW.Utilities.Common.MetaContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Metadata;
using System.Collections.Generic;
using System.IO;

namespace _30abysses.WWW.Utilities.UpdateMetaContents.Extensions
{
    public static class WwwRootAssetContainerInfoExtensions
    {
        private static readonly IDictionary<Container, WwwRootAssetContainerInfo> cache = new Dictionary<Container, WwwRootAssetContainerInfo>();

        internal static void InitializeWwwRootAssetContainerInfoExtensions(this WwwRoot wwwRoot) { cache.Add(wwwRoot, new WwwRootAssetContainerInfo() { RelativePath = AssetContainer.Filename + Path.AltDirectorySeparatorChar }); }

        internal static WwwRootAssetContainerInfo GetWwwRootAssetContainerInfo(this Container container)
        {
            if (cache.ContainsKey(container)) { return cache[container]; }
            else
            {
                var wwwRootAssetContainerInfo = new WwwRootAssetContainerInfo() { RelativePath = "../" + GetWwwRootAssetContainerInfo(container.Container).RelativePath };
                cache.Add(container, wwwRootAssetContainerInfo);
                return wwwRootAssetContainerInfo;
            }
        }

        internal static WwwRootAssetContainerInfo GetWwwRootAssetContainerInfo(this Item item) => GetWwwRootAssetContainerInfo(item.Container);
    }
}
