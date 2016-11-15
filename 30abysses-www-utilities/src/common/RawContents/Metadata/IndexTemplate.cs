using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using System.IO;

namespace _30abysses.WWW.Utilities.Common.RawContents.Metadata
{
    public class IndexTemplate : AbstractMetadata<OrganizationalContainer>, IVisitable
    {
        public IndexTemplate(string path, Container container, OrganizationalContainer owner) : base(path, container, owner) { }

        public static IndexTemplate Get(OrganizationalContainer owner, IndexTemplate fallback)
        {
            var path = owner.Path + ".index.html";
            return File.Exists(path) ? new IndexTemplate(path, owner.Container, owner) : fallback;
        }

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            visitor.Leave(this);
        }
    }
}
