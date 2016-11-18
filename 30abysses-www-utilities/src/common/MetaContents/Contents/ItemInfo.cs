using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using System.IO;

namespace _30abysses.WWW.Utilities.Common.MetaContents.Contents
{
    public class ItemInfo
    {
        public string Name { get; }
        public string Title { get; }

        public ItemInfo(string name, string title)
        {
            Name = name;
            Title = title;
        }

        public static ItemInfo New(WwwRoot wwwRoot) => new ItemInfo("www.30abysses.com", "30abysses (卅淵)");

        public static ItemInfo New(OrganizationalContainer organizationalContainer)
        {
            var name = Path.GetFileName(organizationalContainer.Path);
            return new ItemInfo(name, name);
        }

        public static ItemInfo New(_404Template _404Template) => new ItemInfo(_404Name, _404Name);

        public static ItemInfo New(Topic topic, AbstractTopicInfo abstractTopicInfo) => new ItemInfo(abstractTopicInfo.Title, abstractTopicInfo.Title);

        public static ItemInfo New(MetaTopic metaTopic, AbstractTopicInfo abstractTopicInfo) => new ItemInfo(".meta", abstractTopicInfo.Title);

        private const string _404Name = "Error 404 (Not Found)";
    }
}
