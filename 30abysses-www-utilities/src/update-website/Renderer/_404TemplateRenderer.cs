using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _30abysses.WWW.Utilities.Common.RawContents.Contents;

namespace _30abysses.WWW.Utilities.UpdateWebsite.Renderer
{
    public class _404TemplateRenderer : AbstractRenderer
    {
        private _404Template _404Template;

        public _404TemplateRenderer(_404Template _404Template)
        {
            this._404Template = _404Template;
        }

        public override string GetOutputFileContents()
        {
            throw new NotImplementedException();
        }

        public override string GetPseudoInputFilePath()
        {
            throw new NotImplementedException();
        }
    }
}
