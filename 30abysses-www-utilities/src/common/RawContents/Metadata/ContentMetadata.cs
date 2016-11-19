using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;

namespace _30abysses.WWW.Utilities.Common.RawContents.Metadata
{
    public class ContentMetadata : AbstractMetadata<Item>, IVisitable
    {
        public ContentMetadata Fallback { get; }

        internal ContentMetadata(string path, Container container, Item owner, ContentMetadata fallback) : base(path, container, owner) { Fallback = fallback; }

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            visitor.Leave(this);
        }

        internal const string FilenameExtension = ".metadata.json";
    }
}
