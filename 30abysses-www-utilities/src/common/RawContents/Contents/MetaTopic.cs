using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using System.IO;

namespace _30abysses.WWW.Utilities.Common.RawContents.Contents
{
    public class MetaTopic : AbstractTopic, IVisitable
    {
        public Topic Topic { get; }

        public MetaTopic(string path, Container container, Topic topic) : base(path, container) { Topic = topic; }

        public static MetaTopic Get(Topic topic)
        {
            var path = System.IO.Path.ChangeExtension(topic.Path, ".meta.md");
            return File.Exists(path) ? new MetaTopic(path, topic.Container, topic) : null;
        }

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            Accept(visitor);
            visitor.Leave(this);
        }
    }
}
