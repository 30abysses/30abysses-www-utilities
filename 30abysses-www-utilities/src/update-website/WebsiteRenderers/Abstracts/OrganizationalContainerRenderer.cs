using _30abysses.WWW.Utilities.Common.MetaContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;

namespace _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Abstracts
{
    internal abstract class OrganizationalContainerRenderer : AbstractRenderer
    {
        public OrganizationalContainerRenderer(OrganizationalContainer input) : base(input)
        {
            this.input = input;
            indexInfo = JsonConvert.DeserializeObject<IndexInfo>(File.ReadAllText(input.Path + IndexInfo.FilenameExtension, Encoding.UTF8));
        }

        protected override string GetHtmlContents()
        {
            var htmlBuilder = new StringBuilder();
            htmlBuilder.Append("<ul>");
            foreach (var node in indexInfo.OrderByDescending(node => node.TopicOrganizationInfo[2].ItemInfo.Name + node.TopicOrganizationInfo[3].ItemInfo.Name + node.TopicOrganizationInfo[4].ItemInfo.Name))
            {
                htmlBuilder.Append("<li>");
                htmlBuilder.Append($"<code>{HtmlEncoder.Default.Encode(node.TopicOrganizationInfo[1].ItemInfo.Name)} {HtmlEncoder.Default.Encode(node.TopicOrganizationInfo[2].ItemInfo.Name)}-{HtmlEncoder.Default.Encode(node.TopicOrganizationInfo[3].ItemInfo.Name)}-{HtmlEncoder.Default.Encode(node.TopicOrganizationInfo[4].ItemInfo.Name)} </code>");
                htmlBuilder.Append($"<a href=\"{node.TopicInfo.AuthorUri}\">{HtmlEncoder.Default.Encode(node.TopicOrganizationInfo[5].ItemInfo.Name)}</a>");
                if (node.MetaTopicInfo != null) { htmlBuilder.Append($"<code> </code><a href=\"{node.MetaTopicInfo.AuthorUri}\">{HtmlEncoder.Default.Encode(node.MetaTopicOrganizationInfo[5].ItemInfo.Name)}</a>"); }
                htmlBuilder.Append("</li>");
            }
            htmlBuilder.Append("</ul>");
            return htmlBuilder.ToString();
        }

        internal override string GetOutputFileContents()
        {
            var htmlTemplate = new StringBuilder(File.ReadAllText(input.IndexTemplate.Path, Encoding.UTF8));
            htmlTemplate.Replace(WwwContents_WwwRootAssets, WwwRootAssetContainerInfo.RelativePath);
            htmlTemplate.Replace(WwwContents_Logo, File.ReadAllText(input.LogoTemplate.Path, Encoding.UTF8));
            htmlTemplate.Replace(WwwContents_Navigation, GetHtmlNavigation());
            htmlTemplate.Replace(WwwContents_Title, HtmlEncoder.Default.Encode(GetHtmlTitle()));
            htmlTemplate.Replace(WwwContents_Contents, GetHtmlContents());
            foreach (var keyValue in ContentMetadataInfo) { htmlTemplate.Replace(GetWwwContentsId(keyValue.Key), keyValue.Value); }
            return htmlTemplate.ToString();
        }

        internal override string GetPseudoInputFilePath() => Path.Combine(input.Path, "index.html");

        private readonly IndexInfo indexInfo;
        private readonly OrganizationalContainer input;
    }
}
