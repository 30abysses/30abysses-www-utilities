using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using _30abysses.WWW.Utilities.Common.RawContents.Metadata;
using System.IO;

namespace _30abysses.WWW.Utilities.Common.RawContents.Abstracts
{
    public abstract class OrganizationalContainer : Container
    {
        public ContentMetadata ContentMetadata { get; private set; }
        public IndexTemplate IndexTemplate { get; private set; }
        public LogoTemplate LogoTemplate { get; private set; }
        public TopicTemplate TopicTemplate { get; private set; }

        protected OrganizationalContainer(string path, ContentsRoot container) : base(path, container) { Initialize(null); }

        protected OrganizationalContainer(string path, OrganizationalContainer container) : base(path, container) { Initialize(container); }

        private void Initialize(OrganizationalContainer fallbackContainer)
        {
            {
                var path = Path + ContentMetadata.FilenameExtension;
                var fallback = fallbackContainer?.ContentMetadata;
                ContentMetadata = File.Exists(path) ? new ContentMetadata(path, Container, this, fallback) : fallback;
            }

            {
                var path = Path + IndexTemplate.FilenameExtension;
                IndexTemplate = File.Exists(path) ? new IndexTemplate(path, Container, this) : fallbackContainer?.IndexTemplate;
            }

            {
                var path = Path + LogoTemplate.FilenameExtension;
                LogoTemplate = File.Exists(path) ? new LogoTemplate(path, Container, this) : fallbackContainer?.LogoTemplate;
            }

            {
                var path = Path + TopicTemplate.FilenameExtension;
                TopicTemplate = File.Exists(path) ? new TopicTemplate(path, Container, this) : fallbackContainer?.TopicTemplate;
            }
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
