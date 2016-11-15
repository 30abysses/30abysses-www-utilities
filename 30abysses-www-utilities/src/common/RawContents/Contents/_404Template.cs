using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using System.IO;

namespace _30abysses.WWW.Utilities.Common.RawContents.Contents
{
    public class _404Template : Item, IVisitable
    {
        public _404Template(string path, WwwRoot container) : base(path, container) { }

        public static _404Template Get(WwwRoot container)
        {
            var path = System.IO.Path.Combine(container.Path, "404.html");
            return File.Exists(path) ? new _404Template(path, container) : null;
        }

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            visitor.Leave(this);
        }
    }
}
