using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _30abysses.WWW.Utilities.UpdateWebsite.Renderer
{
    public abstract class AbstractRenderer
    {
        public abstract string GetPseudoInputFilePath();
        public abstract string GetOutputFileContents();
    }
}
