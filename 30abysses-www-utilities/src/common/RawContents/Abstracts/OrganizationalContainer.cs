using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using _30abysses.WWW.Utilities.Common.RawContents.Metadata;

namespace _30abysses.WWW.Utilities.Common.RawContents.Abstracts
{
    public abstract class OrganizationalContainer : Container
    {
        public ContentMetadata ContentMetadata { get; private set; }
        public IndexTemplate IndexTemplate { get; private set; }
        public LogoTemplate LogoTemplate { get; private set; }
        public TopicTemplate TopicTemplate { get; private set; }

        public OrganizationalContainer(string path, ContentsRoot container) : base(path, container) { Initialize(null); }

        public OrganizationalContainer(string path, OrganizationalContainer container) : base(path, container) { Initialize(container); }

        private void Initialize(OrganizationalContainer fallbackContainer)
        {
            ContentMetadata = ContentMetadata.Get(this, fallbackContainer?.ContentMetadata);
            IndexTemplate = IndexTemplate.Get(this, fallbackContainer?.IndexTemplate);
            LogoTemplate = LogoTemplate.Get(this, fallbackContainer?.LogoTemplate);
            TopicTemplate = TopicTemplate.Get(this, fallbackContainer?.TopicTemplate);
        }

        protected void Accept(ContentVisitor visitor)
        {
            if (ContentMetadata?.Owner == this) { ((IVisitable) ContentMetadata).Accept(visitor); }
            if (IndexTemplate?.Owner == this) { ((IVisitable) IndexTemplate).Accept(visitor); }
            if (LogoTemplate?.Owner == this) { ((IVisitable) LogoTemplate).Accept(visitor); }
            if (TopicTemplate?.Owner == this) { ((IVisitable) TopicTemplate).Accept(visitor); }
        }
    }
}
