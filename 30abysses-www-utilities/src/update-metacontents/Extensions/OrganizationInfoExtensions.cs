using _30abysses.WWW.Utilities.Common.MetaContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _30abysses.WWW.Utilities.UpdateMetaContents.Extensions
{
    internal static class OrganizationInfoExtensions
    {
        internal static void InitializeOrganizationInfoExtensions(this WwwRoot wwwRoot) { cache.Add(wwwRoot, new OrganizationInfo() { new OrganizationInfo.Node(wwwRoot.GetItemInfo(), string.Empty) }); }

        internal static OrganizationInfo GetOrganizationInfo(this Container organizationalContainer)
        {
            if (cache.ContainsKey(organizationalContainer)) { return cache[organizationalContainer]; }
            var organizationInfo = new OrganizationInfo();
            var containerOrganizationInfo = organizationalContainer.Container.GetOrganizationInfo();
            organizationInfo.AddRange(containerOrganizationInfo.Select(node => new OrganizationInfo.Node(node.ItemInfo, "../" + node.RelativePath)));
            organizationInfo.Add(new OrganizationInfo.Node(organizationalContainer.GetItemInfo(), string.Empty));
            cache.Add(organizationalContainer, organizationInfo);
            return organizationInfo;
        }

        internal static OrganizationInfo GetOrganizationInfo(this Topic topic)
        {
            if (cache.ContainsKey(topic)) { return cache[topic]; }
            var organizationInfo = topic.GetContainerOrganizationInfo();
            organizationInfo.Add(new OrganizationInfo.Node(topic.GetItemInfo(), string.Empty));
            var metaTopic = topic.MetaTopic;
            if (metaTopic != null) { organizationInfo.Add(new OrganizationInfo.Node(metaTopic.GetItemInfo(), Path.GetFileName(metaTopic.Path))); }
            cache.Add(topic, organizationInfo);
            return organizationInfo;
        }

        internal static OrganizationInfo GetOrganizationInfo(this MetaTopic metaTopic)
        {
            if (cache.ContainsKey(metaTopic)) { return cache[metaTopic]; }
            var organizationInfo = metaTopic.GetContainerOrganizationInfo();
            var topic = metaTopic.Topic;
            organizationInfo.Add(new OrganizationInfo.Node(topic.GetItemInfo(), Path.GetFileName(topic.Path)));
            organizationInfo.Add(new OrganizationInfo.Node(metaTopic.GetItemInfo(), string.Empty));
            cache.Add(metaTopic, organizationInfo);
            return organizationInfo;
        }

        internal static OrganizationInfo GetOrganizationInfo(this _404Template _404Template)
        {
            if (cache.ContainsKey(_404Template)) { return cache[_404Template]; }
            var organizationInfo = _404Template.GetContainerOrganizationInfo();
            organizationInfo.Add(new OrganizationInfo.Node(_404Template.GetItemInfo(), string.Empty));
            cache.Add(_404Template, organizationInfo);
            return organizationInfo;
        }

        private static OrganizationInfo GetContainerOrganizationInfo(this Item item)
        {
            var organizationInfo = new OrganizationInfo();
            var containerOrganizationInfo = item.Container.GetOrganizationInfo();
            organizationInfo.AddRange(containerOrganizationInfo.Select(node => new OrganizationInfo.Node(node.ItemInfo, node.RelativePath)));
            organizationInfo.Last().RelativePath = "./";
            return organizationInfo;
        }

        private static readonly IDictionary<Item, OrganizationInfo> cache = new Dictionary<Item, OrganizationInfo>();
    }
}
