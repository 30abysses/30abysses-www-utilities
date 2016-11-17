using _30abysses.WWW.Utilities.Common.MetaContents.Metadata;
using _30abysses.WWW.Utilities.Common.RawContents.Metadata;
using System.Collections.Generic;

namespace _30abysses.WWW.Utilities.UpdateMetaContents
{
    public class ContentMetadataInfoCache
    {
        public ContentMetadataInfoCache() { cache = new Dictionary<ContentMetadata, ContentMetadataInfo>(); }

        public void Add(ContentMetadata contentMetadata)
        {
            if (cache.ContainsKey(contentMetadata)) { return; }
            var fallbackContentMetadata = contentMetadata.Fallback;
            ContentMetadataInfo fallbackContentMetadataInfo = null;
            if (fallbackContentMetadata != null) { fallbackContentMetadataInfo = cache.ContainsKey(fallbackContentMetadata) ? cache[fallbackContentMetadata] : null; }
            cache.Add(contentMetadata, ContentMetadataInfo.New(contentMetadata, fallbackContentMetadataInfo));
        }

        public ContentMetadataInfo this[ContentMetadata key] { get { return cache[key]; } }

        private readonly IDictionary<ContentMetadata, ContentMetadataInfo> cache;
    }
}
