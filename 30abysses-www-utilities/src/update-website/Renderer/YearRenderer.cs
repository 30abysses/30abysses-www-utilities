using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using System.IO;

namespace _30abysses.WWW.Utilities.UpdateWebsite.Renderer
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
