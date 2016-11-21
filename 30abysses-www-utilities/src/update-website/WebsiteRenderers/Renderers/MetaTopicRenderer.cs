using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Abstracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;

namespace _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Renderers
{
    internal class MetaTopicRenderer : AbstractTopicRenderer
    {
        internal MetaTopicRenderer(MetaTopic input) : base(input) { this.input = input; }

        protected override string GetHtmlTitle() => $"{OrganizationInfo[6].ItemInfo.Title} @ {OrganizationInfo[1].ItemInfo.Title} {OrganizationInfo[2].ItemInfo.Title}-{OrganizationInfo[3].ItemInfo.Title}-{OrganizationInfo[4].ItemInfo.Title} @ {OrganizationInfo[0].ItemInfo.Title}";

        protected override string GetHtmlNavigation()
        {
            var htmlBuilder = new StringBuilder();
            htmlBuilder.Append("<code>");
            foreach (var node in OrganizationInfo.Take(5)) { htmlBuilder.Append($"<a href=\"{node.RelativePath}index.html\">{HtmlEncoder.Default.Encode(node.ItemInfo.Name)}</a> / "); }

            htmlBuilder.Append($" <a href=\"{Path.GetFileNameWithoutExtension(input.Topic.Path) + HtmlExtensionFilename}\">{HtmlEncoder.Default.Encode(OrganizationInfo[5].ItemInfo.Name)}</a> ");
            htmlBuilder.Append(HtmlEncoder.Default.Encode(OrganizationInfo[6].ItemInfo.Name));
            htmlBuilder.Append("</code>");
            return htmlBuilder.ToString();
        }

        private readonly MetaTopic input;
    }
}
