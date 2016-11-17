using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Metadata;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace _30abysses.WWW.Utilities.Common.MetaContents.Contents
{
    public class WwwRootAssetContainerInfo : Dictionary<string, string>
    {
        public static WwwRootAssetContainerInfo New(OrganizationalContainer organizationalContainer, AssetContainer wwwRootAssetContainer)
        {
            var wwwRootAssetContainerInfo = new WwwRootAssetContainerInfo();
            wwwRootAssetContainerInfo[wwwroot_assets] = new Uri(organizationalContainer.Path + Path.DirectorySeparatorChar).MakeRelativeUri(new Uri(wwwRootAssetContainer.Path + Path.DirectorySeparatorChar)).ToString();
            return wwwRootAssetContainerInfo;
        }

        public static WwwRootAssetContainerInfo New(WwwRootAssetContainerInfo containerWwwRootAssetContainerInfo)
        {
            var wwwRootAssetContainerInfo = new WwwRootAssetContainerInfo();
            wwwRootAssetContainerInfo[wwwroot_assets] = "../" + containerWwwRootAssetContainerInfo[wwwroot_assets];
            return wwwRootAssetContainerInfo;
        }

        private const string wwwroot_assets = "wwwroot.assets";

        public string GetPseudoInputFilePath(string path) => path + ".www-root-asset-container-info.json";

        public string GetOutputFileContents() => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
