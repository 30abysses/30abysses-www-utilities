using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Abstracts;

namespace _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Renderers
{
    internal class WwwRootRenderer : OrganizationalContainerRenderer
    {
        public WwwRootRenderer(WwwRoot input) : base(input) { }

        protected override string GetHtmlTitle() => OrganizationInfo[0].ItemInfo.Title;
    }
}
