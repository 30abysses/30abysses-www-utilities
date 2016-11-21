using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Abstracts;

namespace _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Renderers
{
    internal class MonthRenderer : OrganizationalContainerRenderer
    {
        internal MonthRenderer(Month input) : base(input) { }

        protected override string GetHtmlTitle() => $"{OrganizationInfo[1].ItemInfo.Title} {OrganizationInfo[2].ItemInfo.Title}-{OrganizationInfo[3].ItemInfo.Title} @ {OrganizationInfo[0].ItemInfo.Title}";
    }
}
