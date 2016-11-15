using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using _30abysses.WWW.Utilities.Common.RawContents.Metadata;
using System.Collections.Generic;
using System.IO;

namespace _30abysses.WWW.Utilities.Common.RawContents.Contents
{
    public class WwwRoot : OrganizationalContainer, IVisitable
    {
        public _404Template _404Template { get; }
        public AssetContainer AssetContainer { get; }
        public IEnumerable<Zone> Zones { get; }

        public WwwRoot(string path, ContentsRoot container) : base(path, container)
        {
            AssetContainer = AssetContainer.Get(this);
            _404Template = _404Template.Get(this);
            Zones = Zone.Get(this);
        }

        public static WwwRoot Get(ContentsRoot container)
        {
            var path = System.IO.Path.Combine(container.Path, "WwwRoot");
            return Directory.Exists(path) ? new WwwRoot(path, container) : null;
        }

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            Accept(visitor);
            ((IVisitable) _404Template).Accept(visitor);
            ((IVisitable) AssetContainer).Accept(visitor);
            foreach (var zone in Zones) { ((IVisitable) zone).Accept(visitor); }
            visitor.Leave(this);
        }
    }
}
