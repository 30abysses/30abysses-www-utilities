namespace _30abysses.WWW.Utilities.Common.RawContents.Abstracts
{
    public abstract class AbstractMetadata<T> : Item
    {
        internal T Owner { get; }

        protected AbstractMetadata(string path, Container container, T owner) : base(path, container) { Owner = owner; }
    }
}
