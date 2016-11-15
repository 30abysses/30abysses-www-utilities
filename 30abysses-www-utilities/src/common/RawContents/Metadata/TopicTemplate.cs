using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using System.IO;

namespace _30abysses.WWW.Utilities.Common.RawContents.Metadata
{
    public class TopicTemplate : AbstractMetadata<OrganizationalContainer>, IVisitable
    {
        public TopicTemplate(string path, Container container, OrganizationalContainer owner) : base(path, container, owner) { }

        public static TopicTemplate Get(OrganizationalContainer owner, TopicTemplate fallback)
        {
            var path = owner.Path + ".topic.html";
            return File.Exists(path) ? new TopicTemplate(path, owner.Container, owner) : fallback;
        }

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            visitor.Leave(this);
        }
    }
}
