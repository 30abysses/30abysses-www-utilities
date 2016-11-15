using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _30abysses.WWW.Utilities.Common.RawContents.Contents;

namespace _30abysses.WWW.Utilities.Common.RawContents.Abstracts
{
    public abstract class ContentVisitor
    {
        internal void Visit(ContentsRoot contentsRoot)
        {
            throw new NotImplementedException();
        }

        internal void Leave(ContentsRoot contentsRoot)
        {
            throw new NotImplementedException();
        }
    }
}
