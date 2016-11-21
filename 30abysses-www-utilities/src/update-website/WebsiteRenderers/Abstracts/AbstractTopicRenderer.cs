using _30abysses.WWW.Utilities.Common.MetaContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using Markdig;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;

namespace _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Abstracts
{
    internal abstract class AbstractTopicRenderer : AbstractRenderer
    {
        internal AbstractTopicRenderer(AbstractTopic input) : base(input)
        {
            this.input = input;
            abstractTopicInfo = JsonConvert.DeserializeObject<AbstractTopicInfo>(File.ReadAllText(input.Path + AbstractTopicInfo.FilenameExtension, Encoding.UTF8));
        }

        internal override string GetOutputFileContents()
        {
            var htmlTemplate = new StringBuilder(File.ReadAllText(((OrganizationalContainer) input.Container).TopicTemplate.Path, Encoding.UTF8));
            htmlTemplate.Replace(WwwContents_WwwRootAssets, WwwRootAssetContainerInfo.RelativePath);
            htmlTemplate.Replace(WwwContents_Logo, File.ReadAllText(((OrganizationalContainer) input.Container).LogoTemplate.Path, Encoding.UTF8));
            htmlTemplate.Replace(WwwContents_Navigation, GetHtmlNavigation());
            htmlTemplate.Replace(WwwContents_Title, HtmlEncoder.Default.Encode(GetHtmlTitle()));
            htmlTemplate.Replace(WwwContents_Contents, GetHtmlContents());

            htmlTemplate.Replace(GetWwwContentsId("license.title"), abstractTopicInfo.Title);
            htmlTemplate.Replace(GetWwwContentsId("license.URL"), abstractTopicInfo.AuthorUri.ToString());
            htmlTemplate.Replace(GetWwwContentsId("license.author"), $"<a href=\"{abstractTopicInfo.AuthorUri}\">{HtmlEncoder.Default.Encode($"{abstractTopicInfo.AuthorName} <{abstractTopicInfo.AuthorEmail}>")}</a>");

            foreach (var keyValue in ContentMetadataInfo) { htmlTemplate.Replace(GetWwwContentsId(keyValue.Key), keyValue.Value); }
            return htmlTemplate.ToString();
        }

        internal override string GetPseudoInputFilePath() => Path.ChangeExtension(input.Path, HtmlExtensionFilename);

        protected override string GetHtmlContents() => Markdown.ToHtml(string.Join(Environment.NewLine, File.ReadLines(input.Path, Encoding.UTF8).Skip(3)));

        private readonly AbstractTopicInfo abstractTopicInfo;
        private readonly AbstractTopic input;
    }
}
