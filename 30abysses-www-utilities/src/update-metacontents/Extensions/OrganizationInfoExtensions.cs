using _30abysses.WWW.Utilities.Common.MetaContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using System.Collections.Generic;
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

        internal static OrganizationInfo GetOrganizationInfo(this Item item)
        {
            if (cache.ContainsKey(item)) { return cache[item]; }
            var organizationInfo = new OrganizationInfo();
            var containerOrganizationInfo = item.Container.GetOrganizationInfo();
            organizationInfo.AddRange(containerOrganizationInfo.Select(node => new OrganizationInfo.Node(node.ItemInfo, node.RelativePath)));
            organizationInfo.Last().RelativePath = "./";
            organizationInfo.Add(new OrganizationInfo.Node(item.GetItemInfo(), string.Empty));
            cache.Add(item, organizationInfo);
            return organizationInfo;
        }

        private static readonly IDictionary<Item, OrganizationInfo> cache = new Dictionary<Item, OrganizationInfo>();
    }
}
