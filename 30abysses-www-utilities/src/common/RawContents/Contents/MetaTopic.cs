using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;

namespace _30abysses.WWW.Utilities.Common.RawContents.Contents
{
    public class MetaTopic : AbstractTopic, IVisitable
    {
        internal MetaTopic(string path, Container container, Topic topic) : base(path, container) { this.topic = topic; }

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            Accept(visitor);
            visitor.Leave(this);
        }

        internal const string FilenameExtension = ".meta.md";

        private readonly Topic topic;
    }
}
