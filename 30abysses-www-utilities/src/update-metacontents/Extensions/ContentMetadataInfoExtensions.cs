using _30abysses.WWW.Utilities.Common.MetaContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Metadata;
using System.Collections.Generic;

namespace _30abysses.WWW.Utilities.UpdateMetaContents.Extensions
{
    internal static class ContentMetadataInfoExtensions
    {
        internal static void InitializeContentMetadataInfoExtensions(this WwwRoot wwwRoot)
        {
            var contentMetadata = wwwRoot.ContentMetadata;
            cache.Add(contentMetadata, new ContentMetadataInfo(contentMetadata));
        }

        internal static ContentMetadataInfo GetContentMetadataInfo(this ContentMetadata contentMetadata)
        {
            if (cache.ContainsKey(contentMetadata)) { return cache[contentMetadata]; }
            else
            {
                var fallbackContentMetadata = contentMetadata.Fallback;
                var contentMetadataInfo = fallbackContentMetadata == null ? new ContentMetadataInfo(contentMetadata) : new ContentMetadataInfo(GetContentMetadataInfo(contentMetadata.Fallback), contentMetadata);
                cache.Add(contentMetadata, contentMetadataInfo);
                return contentMetadataInfo;
            }
        }

        private static readonly IDictionary<ContentMetadata, ContentMetadataInfo> cache = new Dictionary<ContentMetadata, ContentMetadataInfo>();
    }
}
