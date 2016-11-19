using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;

namespace _30abysses.WWW.Utilities.Common.RawContents.Metadata
{
    public class LogoTemplate : AbstractMetadata<OrganizationalContainer>, IVisitable
    {
        public LogoTemplate(string path, Container container, OrganizationalContainer owner) : base(path, container, owner) { }

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            visitor.Leave(this);
        }

        internal const string FilenameExtension = ".logo.svg";
    }
}
