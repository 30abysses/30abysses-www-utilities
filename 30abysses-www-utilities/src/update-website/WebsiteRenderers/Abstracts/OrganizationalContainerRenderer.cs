using _30abysses.WWW.Utilities.Common.MetaContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;

namespace _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Abstracts
{
    internal abstract class OrganizationalContainerRenderer : AbstractRenderer<OrganizationalContainer>
    {
        protected ContentMetadataInfo ContentMetadataInfo { get; }
        protected IndexInfo IndexInfo { get; }
        protected OrganizationInfo OrganizationInfo { get; }
        protected WwwRootAssetContainerInfo WwwRootAssetContainerInfo { get; }

        public OrganizationalContainerRenderer(OrganizationalContainer input) : base(input)
        {
            ContentMetadataInfo = JsonConvert.DeserializeObject<ContentMetadataInfo>(File.ReadAllText(Input.Path + ContentMetadataInfo.FilenameExtension, Encoding.UTF8));
            IndexInfo = JsonConvert.DeserializeObject<IndexInfo>(File.ReadAllText(Input.Path + IndexInfo.FilenameExtension, Encoding.UTF8));
            OrganizationInfo = JsonConvert.DeserializeObject<OrganizationInfo>(File.ReadAllText(Input.Path + OrganizationInfo.FilenameExtension, Encoding.UTF8));
            WwwRootAssetContainerInfo = JsonConvert.DeserializeObject<WwwRootAssetContainerInfo>(File.ReadAllText(Input.Path + WwwRootAssetContainerInfo.FilenameExtension, Encoding.UTF8));
        }

        protected override string GetHtmlContents()
        {
            var htmlBuilder = new StringBuilder();
            htmlBuilder.Append("<ul>");
            foreach (var node in IndexInfo.OrderByDescending(node => node.TopicOrganizationInfo[2].ItemInfo.Name + node.TopicOrganizationInfo[3].ItemInfo.Name + node.TopicOrganizationInfo[4].ItemInfo.Name))
            {
                htmlBuilder.Append("<li>");
                htmlBuilder.Append($"<code>{HtmlEncoder.Default.Encode(node.TopicOrganizationInfo[1].ItemInfo.Name)} {HtmlEncoder.Default.Encode(node.TopicOrganizationInfo[2].ItemInfo.Name)}-{HtmlEncoder.Default.Encode(node.TopicOrganizationInfo[3].ItemInfo.Name)}-{HtmlEncoder.Default.Encode(node.TopicOrganizationInfo[4].ItemInfo.Name)} </code>");
                htmlBuilder.Append($"<a href=\"{Path.ChangeExtension(node.TopicInfo.Filename, HtmlExtensionFilename)}\">{HtmlEncoder.Default.Encode(node.TopicOrganizationInfo[5].ItemInfo.Name)}</a>");
                if (node.MetaTopicInfo != null) { htmlBuilder.Append($"<code> </code><a href=\"{Path.ChangeExtension(node.MetaTopicInfo.Filename, HtmlExtensionFilename)}\">{HtmlEncoder.Default.Encode(node.MetaTopicOrganizationInfo[5].ItemInfo.Name)}</a>"); }
                htmlBuilder.Append("</li>");
            }
            htmlBuilder.Append("</ul>");
            return htmlBuilder.ToString();
        }

        protected override string GetHtmlNavigation()
        {
            var htmlBuilder = new StringBuilder();
            htmlBuilder.Append("<code>");
            foreach (var node in OrganizationInfo.Take(OrganizationInfo.Count - 1)) { htmlBuilder.Append($"<a href=\"{node.RelativePath}index.html\">{HtmlEncoder.Default.Encode(node.ItemInfo.Name)}</a> / "); }
            htmlBuilder.Append(HtmlEncoder.Default.Encode(OrganizationInfo.Last().ItemInfo.Name));
            htmlBuilder.Append("</code>");
            return htmlBuilder.ToString();
        }

        internal override string GetOutputFileContents()
        {
            var htmlTemplate = new StringBuilder(File.ReadAllText(Input.IndexTemplate.Path, Encoding.UTF8));
            htmlTemplate.Replace(GetWwwTag("wwwroot.assets"), WwwRootAssetContainerInfo.RelativePath);
            htmlTemplate.Replace(GetWwwTag("logo"), File.ReadAllText(Input.LogoTemplate.Path, Encoding.UTF8));
            htmlTemplate.Replace(GetWwwTag("navigation"), GetHtmlNavigation());
            htmlTemplate.Replace(GetWwwTag("title"), HtmlEncoder.Default.Encode(GetHtmlTitle()));
            htmlTemplate.Replace(GetWwwTag("contents"), GetHtmlContents());
            foreach (var keyValue in ContentMetadataInfo) { htmlTemplate.Replace(GetWwwTag(keyValue.Key), keyValue.Value); }
            return htmlTemplate.ToString();
        }

        private static string GetWwwTag(string key) => "{[www-contents]." + key + "}";

        internal override string GetPseudoInputFilePath() => Path.Combine(Input.Path, "index.html");
    }
}
