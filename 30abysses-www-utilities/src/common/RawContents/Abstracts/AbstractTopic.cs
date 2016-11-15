using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using _30abysses.WWW.Utilities.Common.RawContents.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _30abysses.WWW.Utilities.Common.RawContents.Abstracts
{
    public class AbstractTopic : Item
    {
        public new Day Container { get; }
        public ContentMetadata ContentMetadata { get; }
        public AssetContainer AssetContainer { get; }
        public TopicTemplate TopicTemplate => Container.TopicTemplate;
        public LogoTemplate LogoTemplate => Container.LogoTemplate;

        public AbstractTopic(string path, Day container) : base(path, container)
        {
            Container = container;
            ContentMetadata = ContentMetadata.Get(this, container.ContentMetadata);
        }

        protected void Accept(ContentVisitor visitor)
        {
            if (ContentMetadata?.Owner == this) { ((IVisitable) ContentMetadata).Accept(visitor); }
            if (AssetContainer?.Owner == this) { ((IVisitable) AssetContainer).Accept(visitor); }
        }
    }
}
