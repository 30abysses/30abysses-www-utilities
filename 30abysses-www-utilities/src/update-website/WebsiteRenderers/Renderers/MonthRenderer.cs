﻿using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Abstracts;

namespace _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Renderers
{
    internal class MonthRenderer : OrganizationalContainerRenderer
    {
        public MonthRenderer(Month input) : base(input) { }

        protected override string GetHtmlContents() => "C-c-c-contents";
        protected override string GetHtmlNavigation() => "N-n-n-navigation";
        protected override string GetHtmlTitle() => "T-t-t-title";
    }
}
