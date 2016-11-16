using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _30abysses.WWW.Utilities.Common.RawContents.Contents
{
    public class Topic : AbstractTopic, IVisitable
    {
        public MetaTopic MetaTopic { get; }

        public Topic(string path, Day container) : base(path, container) { MetaTopic = MetaTopic.Get(this); }

        public static IEnumerable<Topic> Get(Day container) =>
            Directory.GetFiles(container.Path, "*.md")
            .Where(path => !string.IsNullOrWhiteSpace(System.IO.Path.GetFileNameWithoutExtension(path)))
            .Select(path => new Topic(path, container))
            .ToArray();

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            Accept(visitor);
            ((IVisitable) MetaTopic)?.Accept(visitor);
            visitor.Leave(this);
        }
    }
}
