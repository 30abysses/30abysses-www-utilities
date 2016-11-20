using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;

namespace _30abysses.WWW.Utilities.Common.RawContents.Metadata
{
    public class AssetContainer : AbstractMetadata<Item>, IVisitable
    {
        internal AssetContainer(string path, Container container, Item owner) : base(path, container, owner) { }

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            visitor.Leave(this);
        }

        public const string Filename = ".assets";
    }
}
