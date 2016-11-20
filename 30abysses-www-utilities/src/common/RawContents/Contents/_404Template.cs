using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;

namespace _30abysses.WWW.Utilities.Common.RawContents.Contents
{
    public class _404Template : Item, IVisitable
    {
        internal _404Template(string path, WwwRoot container) : base(path, container) { }

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            visitor.Leave(this);
        }

        internal const string Filename = "404.html";
    }
}
