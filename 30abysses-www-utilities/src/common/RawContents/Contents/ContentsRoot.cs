using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using System.IO;
using SysIoPath = System.IO.Path;

namespace _30abysses.WWW.Utilities.Common.RawContents.Contents
{
    public class ContentsRoot : Container, IVisitable
    {
        public WwwRoot WwwRoot { get; }

        public ContentsRoot(string path) : base(path, null)
        {
            var itemPath = SysIoPath.Combine(Path, WwwRoot.Filename);
            WwwRoot = Directory.Exists(itemPath) ? new WwwRoot(itemPath, this) : null;
        }

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            ((IVisitable) WwwRoot).Accept(visitor);
            visitor.Leave(this);
        }
    }
}
