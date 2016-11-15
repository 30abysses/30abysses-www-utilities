using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;

namespace _30abysses.WWW.Utilities.Common.RawContents.Contents
{
    public class ContentsRoot : Container, IVisitable
    {
        public WwwRoot WwwRoot { get; }

        public ContentsRoot(string path) : base(path, null) { WwwRoot = WwwRoot.Get(this); }

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            ((IVisitable) WwwRoot).Accept(visitor);
            visitor.Leave(this);
        }
    }
}
