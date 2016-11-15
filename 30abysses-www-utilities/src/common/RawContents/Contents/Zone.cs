using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _30abysses.WWW.Utilities.Common.RawContents.Contents
{
    public class Zone : OrganizationalContainer, IVisitable
    {
        public IEnumerable<Year> Years { get; }

        public Zone(string path, WwwRoot container) : base(path, container) { Years = Year.Get(this); }

        public static IEnumerable<Zone> Get(WwwRoot container) =>
            Directory.GetDirectories(container.Path)
            .Where(path => !System.IO.Path.GetFileName(path).StartsWith("."))
            .Select(path => new Zone(path, container))
            .ToArray();

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            Accept(visitor);
            foreach (var year in Years) { ((IVisitable) year).Accept(visitor); }
            visitor.Leave(this);
        }
    }
}
