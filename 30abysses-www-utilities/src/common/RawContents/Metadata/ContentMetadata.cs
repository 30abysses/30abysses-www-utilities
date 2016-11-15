using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;

namespace _30abysses.WWW.Utilities.Common.RawContents.Metadata
{
    public class ContentMetadata
    {
        public Item Owner { get; internal set; }

        internal static ContentMetadata Get(OrganizationalContainer organizationalContainer, ContentMetadata contentMetadata)
        {
            throw new NotImplementedException();
        }

        internal static ContentMetadata Get(AbstractTopic abstractTopic, ContentMetadata metadata)
        {
            throw new NotImplementedException();
        }
    }
}
