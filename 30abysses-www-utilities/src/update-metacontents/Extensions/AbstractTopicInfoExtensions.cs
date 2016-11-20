using _30abysses.WWW.Utilities.Common.MetaContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using System.Collections.Generic;

namespace _30abysses.WWW.Utilities.UpdateMetaContents.Extensions
{
    internal static class AbstractTopicInfoExtensions
    {
        internal static AbstractTopicInfo GetAbstractTopicInfo(this AbstractTopic abstractTopic)
        {
            if (cache.ContainsKey(abstractTopic)) { return cache[abstractTopic]; }
            var abstractTopicInfo = new AbstractTopicInfo(abstractTopic);
            cache.Add(abstractTopic, abstractTopicInfo);
            return abstractTopicInfo;
        }

        private static readonly IDictionary<AbstractTopic, AbstractTopicInfo> cache = new Dictionary<AbstractTopic, AbstractTopicInfo>();
    }
}
