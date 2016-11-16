using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Abstracts;
using System;

namespace _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Renderers
{
    public class _404TemplateRenderer : AbstractRenderer<_404Template>
    {
        public _404TemplateRenderer(_404Template input) : base(input) { }

        public override string GetHtmlContents()
        {
            throw new NotImplementedException();
        }

        public override string GetHtmlNavigation()
        {
            throw new NotImplementedException();
        }

        public override string GetHtmlTitle()
        {
            throw new NotImplementedException();
        }

        public override string GetOutputFileContents()
        {
            throw new NotImplementedException();
        }

        public override string GetPseudoInputFilePath() => Input.Path;
    }
}
