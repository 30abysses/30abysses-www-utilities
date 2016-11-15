namespace _30abysses.WWW.Utilities.Common.RawContents.Abstracts
{
    public abstract class AbstractMetadata<T> : Item
    {
        public T Owner { get; }

        public AbstractMetadata(string path, Container container, T owner) : base(path, container) { Owner = owner; }
    }
}
