using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using _30abysses.WWW.Utilities.Common.RawContents.Metadata;
using System.IO;
using SysIoPath = System.IO.Path;

namespace _30abysses.WWW.Utilities.Common.RawContents.Abstracts
{
    public abstract class AbstractTopic : Item
    {
        protected AbstractTopic(string path, Container container) : base(path, container)
        {
            var itemPath = SysIoPath.Combine(Container.Path, SysIoPath.GetFileNameWithoutExtension(Path));
            assetContainer = Directory.Exists(path) ? new AssetContainer(path, Container, this) : null;
        }

        protected void Accept(ContentVisitor visitor) { ((IVisitable) assetContainer)?.Accept(visitor); }

        private readonly AssetContainer assetContainer;
    }
}
