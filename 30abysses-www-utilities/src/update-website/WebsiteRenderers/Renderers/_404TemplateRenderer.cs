using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Abstracts;

namespace _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Renderers
{
    internal class _404TemplateRenderer : AbstractRenderer<_404Template>
    {
        internal _404TemplateRenderer(_404Template input) : base(input) { }

        protected override string GetHtmlContents() => string.Empty;
        protected override string GetHtmlNavigation() => string.Empty;
        protected override string GetHtmlTitle() => string.Empty;
        internal override string GetOutputFileContents() => string.Empty;

        internal override string GetPseudoInputFilePath() => Input.Path;
    }
}
