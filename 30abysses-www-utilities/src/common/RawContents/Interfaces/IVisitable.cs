using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;

namespace _30abysses.WWW.Utilities.Common.RawContents.Interfaces
{
    public interface IVisitable
    {
        void Accept(ContentVisitor visitor);
    }
}
