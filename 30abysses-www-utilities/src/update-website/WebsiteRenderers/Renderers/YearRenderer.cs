using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Abstracts;
using System;
using System.IO;

namespace _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Renderers
{
    public class YearRenderer : AbstractRenderer<Year>
    {
        public YearRenderer(Year input) : base(input) { }

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

        public override string GetPseudoInputFilePath() => Path.Combine(Input.Path, IndexHtmlFilename);
    }
}
