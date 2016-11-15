using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using _30abysses.WWW.Utilities.Common.RawContents.Metadata;

namespace _30abysses.WWW.Utilities.Common.RawContents.Abstracts
{
    public class AbstractTopic : Item
    {
        public new Day Container { get; }
        public AssetContainer AssetContainer { get; }

        public AbstractTopic(string path, Day container) : base(path, container)
        {
            Container = container;
        }

        protected void Accept(ContentVisitor visitor)
        {
            if (AssetContainer?.Owner == this) { ((IVisitable) AssetContainer).Accept(visitor); }
        }
    }
}
