using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Abstracts;
using System;

namespace _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Renderers
{
    internal class _404TemplateRenderer : AbstractRenderer<_404Template>
    {
        public _404TemplateRenderer(_404Template input) : base(input) { }

        protected override string GetHtmlContents()
        {
            throw new NotImplementedException();
        }

        protected override string GetHtmlNavigation()
        {
            throw new NotImplementedException();
        }

        protected override string GetHtmlTitle()
        {
            throw new NotImplementedException();
        }

        internal override string GetOutputFileContents()
        {
            throw new NotImplementedException();
        }

        internal override string GetPseudoInputFilePath() => Input.Path;
    }
}
