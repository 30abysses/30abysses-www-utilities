using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Abstracts;

namespace _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Renderers
{
    internal class ZoneRenderer : OrganizationalContainerRenderer
    {
        public ZoneRenderer(Zone input) : base(input) { }

        protected override string GetHtmlTitle() => $"{OrganizationInfo[1].ItemInfo.Title} @ {OrganizationInfo[0].ItemInfo.Title}";
    }
}
