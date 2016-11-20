using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Abstracts;
using System;
using System.IO;

namespace _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Renderers
{
    public class DayRenderer : AbstractRenderer<Day>
    {
        public DayRenderer(Day input) : base(input) { }

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

        public override string GetOutputFileContents()
        {
            throw new NotImplementedException();
        }

        public override string GetPseudoInputFilePath() => Path.Combine(Input.Path, IndexHtmlFilename);
    }
}
