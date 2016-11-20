using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Abstracts;
using System.IO;

namespace _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Renderers
{
    internal class MetaTopicRenderer : AbstractRenderer<MetaTopic>
    {
        internal MetaTopicRenderer(MetaTopic input) : base(input) { }

        protected override string GetHtmlContents() => string.Empty;
        protected override string GetHtmlNavigation() => string.Empty;
        protected override string GetHtmlTitle() => string.Empty;
        internal override string GetOutputFileContents() => string.Empty;

        internal override string GetPseudoInputFilePath() => Path.ChangeExtension(Input.Path, HtmlExtensionFilename);
    }
}
