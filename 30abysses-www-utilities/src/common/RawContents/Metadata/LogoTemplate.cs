using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using System.IO;

namespace _30abysses.WWW.Utilities.Common.RawContents.Metadata
{
    public class LogoTemplate : AbstractMetadata<OrganizationalContainer>, IVisitable
    {
        public LogoTemplate(string path, Container container, OrganizationalContainer owner) : base(path, container, owner) { }

        public static LogoTemplate Get(OrganizationalContainer owner, LogoTemplate fallback)
        {
            var path = owner.Path + ".logo.svg";
            return File.Exists(path) ? new LogoTemplate(path, owner.Container, owner) : fallback;
        }

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            visitor.Leave(this);
        }
    }
}
