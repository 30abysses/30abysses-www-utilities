using _30abysses.WWW.Utilities.Common.MetaContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using System.Collections.Generic;
using System.Linq;

namespace _30abysses.WWW.Utilities.UpdateMetaContents
{
    public class IndexInfoCache
    {
        public IndexInfoCache()
        {
            cache = new Dictionary<OrganizationalContainer, IndexInfo>();
        }

        public void Add(Day day) => cache[day] = IndexInfo.New(day.Topics);

        public void Add(OrganizationalContainer organizationalContainer, IEnumerable<OrganizationalContainer> childContainers)
        {
            var indexInfo = new IndexInfo();
            indexInfo.AddRange(childContainers.SelectMany(container => cache[container]));
            cache[organizationalContainer] = indexInfo;
        }

        public IndexInfo this[OrganizationalContainer key] { get { return cache[key]; } }

        private readonly IDictionary<OrganizationalContainer, IndexInfo> cache;
    }
}
