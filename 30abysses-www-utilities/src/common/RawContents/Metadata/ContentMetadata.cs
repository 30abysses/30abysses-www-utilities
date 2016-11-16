using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using System.IO;

namespace _30abysses.WWW.Utilities.Common.RawContents.Metadata
{
    public class ContentMetadata : AbstractMetadata<Item>, IVisitable
    {
        public ContentMetadata Fallback { get; }

        public ContentMetadata(string path, Container container, Item owner, ContentMetadata fallback) : base(path, container, owner) { Fallback = fallback; }

        public static ContentMetadata Get(OrganizationalContainer owner, ContentMetadata fallback)
        {
            var path = owner.Path + ".metadata.json";
            return File.Exists(path) ? new ContentMetadata(path, owner.Container, owner, fallback) : fallback;
        }

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            visitor.Leave(this);
        }
    }
}
