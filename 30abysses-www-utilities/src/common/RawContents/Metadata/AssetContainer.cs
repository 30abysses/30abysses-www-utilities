using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Contents;

namespace _30abysses.WWW.Utilities.Common.RawContents.Metadata
{
    public class AssetContainer
    {
        public AbstractTopic Owner { get; internal set; }

        internal AssetContainer Get(WwwRoot wwwRoot)
        {
            throw new NotImplementedException();
        }
    }
}
