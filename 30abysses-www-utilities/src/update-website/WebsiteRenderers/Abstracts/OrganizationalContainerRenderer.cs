using _30abysses.WWW.Utilities.Common.MetaContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Abstracts
{
    internal abstract class OrganizationalContainerRenderer : AbstractRenderer<OrganizationalContainer>
    {
        public OrganizationalContainerRenderer(OrganizationalContainer input) : base(input)
        {
            contentMetadataInfo = JsonConvert.DeserializeObject<ContentMetadataInfo>(File.ReadAllText(Input.Path + ContentMetadataInfo.FilenameExtension, Encoding.UTF8));
            indexInfo = JsonConvert.DeserializeObject<IndexInfo>(File.ReadAllText(Input.Path + IndexInfo.FilenameExtension, Encoding.UTF8));
            organizationInfo = JsonConvert.DeserializeObject<OrganizationInfo>(File.ReadAllText(Input.Path + OrganizationInfo.FilenameExtension, Encoding.UTF8));
            wwwRootAssetContainerInfo = JsonConvert.DeserializeObject<WwwRootAssetContainerInfo>(File.ReadAllText(Input.Path + WwwRootAssetContainerInfo.FilenameExtension, Encoding.UTF8));
        }

        internal override string GetOutputFileContents()
        {
            var htmlTemplate = new StringBuilder(File.ReadAllText(Input.IndexTemplate.Path, Encoding.UTF8));
            htmlTemplate.Replace(GetWwwTag("wwwroot.assets"), wwwRootAssetContainerInfo.RelativePath);
            htmlTemplate.Replace(GetWwwTag("logo"), File.ReadAllText(Input.LogoTemplate.Path, Encoding.UTF8));
            htmlTemplate.Replace(GetWwwTag("navigation"), GetHtmlNavigation());
            htmlTemplate.Replace(GetWwwTag("title"), GetHtmlTitle());
            htmlTemplate.Replace(GetWwwTag("contents"), GetHtmlContents());
            foreach (var keyValue in contentMetadataInfo) { htmlTemplate.Replace(GetWwwTag(keyValue.Key), keyValue.Value); }
            return htmlTemplate.ToString();
        }

        private static string GetWwwTag(string key) => "{[www-contents]." + key + "}";

        internal override string GetPseudoInputFilePath() => Path.Combine(Input.Path, IndexHtmlFilename);

        protected readonly ContentMetadataInfo contentMetadataInfo;
        protected readonly IndexInfo indexInfo;
        protected readonly OrganizationInfo organizationInfo;
        protected readonly WwwRootAssetContainerInfo wwwRootAssetContainerInfo;
    }
}
