using _30abysses.WWW.Utilities.Common.MetaContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using System.Collections.Generic;
using System.Linq;

namespace _30abysses.WWW.Utilities.UpdateMetaContents.Extensions
{
    internal static class IndexInfoExtensions
    {
        internal static void InitializeIndexInfoExtensions(this Day day) => cache.Add(day, new IndexInfo(day.Topics.Select(topic => new IndexInfo.Node(topic.GetAbstractTopicInfo(), topic.GetOrganizationInfo(), topic.MetaTopic?.GetAbstractTopicInfo(), topic.MetaTopic?.GetOrganizationInfo()))));

        internal static void InitializeIndexInfoExtensions(this Month month) => cache.Add(month, new IndexInfo(month.Days.Select(day => cache[day])));

        internal static void InitializeIndexInfoExtensions(this Year year) => cache.Add(year, new IndexInfo(year.Months.Select(month => cache[month])));

        internal static void InitializeIndexInfoExtensions(this Zone zone) => cache.Add(zone, new IndexInfo(zone.Years.Select(year => cache[year])));

        internal static void InitializeIndexInfoExtensions(this WwwRoot wwwRoot) => cache.Add(wwwRoot, new IndexInfo(wwwRoot.Zones.Select(zone => cache[zone])));

        internal static IndexInfo GetIndexInfo(this OrganizationalContainer organizationalContainer) => cache[organizationalContainer];

        private static readonly IDictionary<OrganizationalContainer, IndexInfo> cache = new Dictionary<OrganizationalContainer, IndexInfo>();
    }
}
