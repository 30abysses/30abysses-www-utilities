using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Abstracts;
using System;
using System.IO;

namespace _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Renderers
{
    internal class MonthRenderer : AbstractRenderer<Month>
    {
        public MonthRenderer(Month input) : base(input) { }

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

        internal override string GetPseudoInputFilePath() => Path.Combine(Input.Path, IndexHtmlFilename);
    }
}
