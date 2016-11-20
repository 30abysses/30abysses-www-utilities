namespace _30abysses.WWW.Utilities.Common.RawContents.Abstracts
{
    public abstract class Item
    {
        public string Path { get; }
        public Container Container { get; }

        protected Item(string path, Container container)
        {
            Path = path;
            Container = container;
        }
    }
}
