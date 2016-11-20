using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using _30abysses.WWW.Utilities.Common.RawContents.Metadata;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SysIoPath = System.IO.Path;

namespace _30abysses.WWW.Utilities.Common.RawContents.Contents
{
    public class WwwRoot : OrganizationalContainer, IVisitable
    {
        public IEnumerable<Zone> Zones { get; }

        internal WwwRoot(string path, ContentsRoot container) : base(path, container)
        {
            {
                var itemPath = SysIoPath.Combine(Path, AssetContainer.Filename);
                assetContainer = Directory.Exists(itemPath) ? new AssetContainer(itemPath, this, this) : null;
            }

            {
                var itemPath = SysIoPath.Combine(Path, _404Template.Filename);
                _404Template = File.Exists(itemPath) ? new _404Template(itemPath, this) : null;
            }

            {
                Zones = Directory.GetDirectories(Path, Zone.FilenamePattern)
                    .Where(filePath => Zone.FilenameRegex.IsMatch(SysIoPath.GetFileName(filePath)))
                    .Select(filePath => new Zone(filePath, this))
                    .ToArray();
            }
        }

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            Accept(visitor);
            ((IVisitable) _404Template).Accept(visitor);
            ((IVisitable) assetContainer).Accept(visitor);
            foreach (var zone in Zones) { ((IVisitable) zone).Accept(visitor); }
            visitor.Leave(this);
        }

        internal const string Filename = "WwwRoot";

        private readonly _404Template _404Template;
        private readonly AssetContainer assetContainer;
    }
}
