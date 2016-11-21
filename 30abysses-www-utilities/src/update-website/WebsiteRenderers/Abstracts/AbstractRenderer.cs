using _30abysses.WWW.Utilities.Common.MetaContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;

namespace _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Abstracts
{
    internal abstract class AbstractRenderer
    {
        protected OrganizationInfo OrganizationInfo { get; }
        protected ContentMetadataInfo ContentMetadataInfo { get; }
        protected WwwRootAssetContainerInfo WwwRootAssetContainerInfo { get; }

        protected AbstractRenderer(Item input)
        {
            ContentMetadataInfo = JsonConvert.DeserializeObject<ContentMetadataInfo>(File.ReadAllText(input.Path + ContentMetadataInfo.FilenameExtension, Encoding.UTF8));
            OrganizationInfo = JsonConvert.DeserializeObject<OrganizationInfo>(File.ReadAllText(input.Path + OrganizationInfo.FilenameExtension, Encoding.UTF8));
            WwwRootAssetContainerInfo = JsonConvert.DeserializeObject<WwwRootAssetContainerInfo>(File.ReadAllText(input.Path + WwwRootAssetContainerInfo.FilenameExtension, Encoding.UTF8));
        }

        internal abstract string GetPseudoInputFilePath();
        internal abstract string GetOutputFileContents();
        protected abstract string GetHtmlTitle();
        protected abstract string GetHtmlContents();

        protected virtual string GetHtmlNavigation()
        {
            var htmlBuilder = new StringBuilder();
            htmlBuilder.Append("<code>");
            foreach (var node in OrganizationInfo.Take(OrganizationInfo.Count - 1)) { htmlBuilder.Append($"<a href=\"{node.RelativePath}index.html\">{HtmlEncoder.Default.Encode(node.ItemInfo.Name)}</a> / "); }
            htmlBuilder.Append(HtmlEncoder.Default.Encode(OrganizationInfo.Last().ItemInfo.Name));
            htmlBuilder.Append("</code>");
            return htmlBuilder.ToString();
        }

        protected static string GetWwwContentsId(string key) => "{[www-contents]." + key + "}";

        protected static readonly string WwwContents_WwwRootAssets = GetWwwContentsId("wwwroot.assets");
        protected static readonly string WwwContents_Logo = GetWwwContentsId("logo");
        protected static readonly string WwwContents_Navigation = GetWwwContentsId("navigation");
        protected static readonly string WwwContents_Title = GetWwwContentsId("title");
        protected static readonly string WwwContents_Contents = GetWwwContentsId("contents");

        protected const string HtmlExtensionFilename = ".html";
    }
}
