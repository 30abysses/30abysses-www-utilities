using _30abysses.WWW.Utilities.Common.RawContents.Contents;

namespace _30abysses.WWW.Utilities.Common.MetaContents.Contents
{
    public class IndexInfoNode
    {
        public string Path { get; set; }

        public static IndexInfoNode New(Topic topic)
        {
            return new IndexInfoNode() { Path = topic.Path };
        }
    }
}
