using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using System.IO;

namespace _30abysses.WWW.Utilities.Common.RawContents.Metadata
{
    public class AssetContainer : AbstractMetadata<Item>, IVisitable
    {
        public AssetContainer(string path, Container container, Item owner) : base(path, container, owner) { }

        public static AssetContainer Get(WwwRoot owner)
        {
            var path = System.IO.Path.Combine(owner.Path, ".assets");
            return Directory.Exists(path) ? new AssetContainer(path, owner, owner) : null;
        }

        public static AssetContainer Get(AbstractTopic owner)
        {
            var path = System.IO.Path.Combine(owner.Container.Path, System.IO.Path.GetFileNameWithoutExtension(owner.Path));
            return Directory.Exists(path) ? new AssetContainer(path, owner.Container, owner) : null;
        }

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            visitor.Leave(this);
        }
    }
}
