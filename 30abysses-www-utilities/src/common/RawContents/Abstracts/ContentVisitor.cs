using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _30abysses.WWW.Utilities.Common.RawContents.Contents;

namespace _30abysses.WWW.Utilities.Common.RawContents.Abstracts
{
    public abstract class ContentVisitor
    {
        internal abstract void Visit(ContentsRoot contentsRoot);
        internal abstract void Leave(ContentsRoot contentsRoot);
        internal abstract void Visit(WwwRoot wwwRoot);
        internal abstract void Leave(WwwRoot wwwRoot);
    }
}
