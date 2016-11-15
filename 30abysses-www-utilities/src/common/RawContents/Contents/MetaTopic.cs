using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using System.IO;

namespace _30abysses.WWW.Utilities.Common.RawContents.Contents
{
    public class MetaTopic : AbstractTopic, IVisitable
    {
        public MetaTopic(string path, Day container) : base(path, container) { }

        public static MetaTopic Get(Topic owner)
        {
            var path = System.IO.Path.ChangeExtension(owner.Path, ".meta.md");
            return File.Exists(path) ? new MetaTopic(path, owner.Container) : null;
        }

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            visitor.Leave(this);
        }
    }
}
