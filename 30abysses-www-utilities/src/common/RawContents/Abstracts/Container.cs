namespace _30abysses.WWW.Utilities.Common.RawContents.Abstracts
{
    public abstract class Container : Item
    {
        public Container(string path, Container container) : base(path, container) { }
    }
}
