using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Metadata;
using System;
using System.Collections.Generic;

namespace _30abysses.WWW.Utilities.Common.MetaContents.Contents
{
    public class WwwRootAssetContainerInfo : Dictionary<string, string>
    {
        public static WwwRootAssetContainerInfo New(OrganizationalContainer organizationalContainer, AssetContainer wwwRootAssetContainer)
        {
            var wwwRootAssetContainerInfo = new WwwRootAssetContainerInfo();
            wwwRootAssetContainerInfo[wwwroot_assets] = new Uri(organizationalContainer.Path).MakeRelativeUri(new Uri(wwwRootAssetContainer.Path)).ToString();
            return wwwRootAssetContainerInfo;
        }

        public static WwwRootAssetContainerInfo New(WwwRootAssetContainerInfo containerWwwRootAssetContainerInfo)
        {
            var wwwRootAssetContainerInfo = new WwwRootAssetContainerInfo();
            wwwRootAssetContainerInfo[wwwroot_assets] = containerWwwRootAssetContainerInfo[wwwroot_assets] + "../";
            return wwwRootAssetContainerInfo;
        }

        private const string wwwroot_assets = "wwwroot.assets";
    }
}
