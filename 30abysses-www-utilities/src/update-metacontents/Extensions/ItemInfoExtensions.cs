using _30abysses.WWW.Utilities.Common.MetaContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using System.Collections.Generic;
using System.IO;

namespace _30abysses.WWW.Utilities.UpdateMetaContents.Extensions
{
    internal static class ItemInfoExtensions
    {
        internal static void InitializeItemInfoExtensions(this WwwRoot wwwRoot) => cache.Add(wwwRoot, new ItemInfo("www.30abysses.com", "30abysses (卅淵)"));

        internal static void InitializeItemInfoExtensions(this OrganizationalContainer organizationalContainer)
        {
            var id = Path.GetFileName(organizationalContainer.Path);
            cache.Add(organizationalContainer, new ItemInfo(id, id));
        }

        internal static void InitializeItemInfoExtensions(this _404Template _404Template) => cache.Add(_404Template, new ItemInfo(_404Id, _404Id));

        internal static void InitializeItemInfoExtensions(this Topic topic)
        {
            var abstractTopicInfo = topic.GetAbstractTopicInfo();
            cache.Add(topic, new ItemInfo(abstractTopicInfo.Title, abstractTopicInfo.Title));
        }

        internal static void InitializeItemInfoExtensions(this MetaTopic metaTopic) => cache.Add(metaTopic, new ItemInfo(".meta", metaTopic.GetAbstractTopicInfo().Title));

        internal static ItemInfo GetItemInfo(this Item item) => cache[item];

        private static readonly IDictionary<Item, ItemInfo> cache = new Dictionary<Item, ItemInfo>();

        private const string _404Id = "Error 404 (Not Found)";
    }
}
