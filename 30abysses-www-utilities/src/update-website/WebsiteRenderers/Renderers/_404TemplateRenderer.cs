using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Abstracts;
using System;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;

namespace _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Renderers
{
    internal class _404TemplateRenderer : AbstractRenderer
    {
        internal _404TemplateRenderer(_404Template input) : base(input) { this.input = input; }

        protected override string GetHtmlContents() { throw new NotImplementedException(); }

        protected override string GetHtmlTitle() => $"{OrganizationInfo[1].ItemInfo.Title} @ {OrganizationInfo[0].ItemInfo.Title}";

        internal override string GetOutputFileContents()
        {
            var htmlTemplate = new StringBuilder(File.ReadAllText(input.Path, Encoding.UTF8));
            htmlTemplate.Replace(WwwContents_WwwRootAssets, WwwRootAssetContainerInfo.RelativePath);
            htmlTemplate.Replace(WwwContents_Logo, File.ReadAllText(((OrganizationalContainer) input.Container).LogoTemplate.Path, Encoding.UTF8));
            htmlTemplate.Replace(WwwContents_Navigation, GetHtmlNavigation());
            htmlTemplate.Replace(WwwContents_Title, HtmlEncoder.Default.Encode(GetHtmlTitle()));
            foreach (var keyValue in ContentMetadataInfo) { htmlTemplate.Replace(GetWwwContentsId(keyValue.Key), keyValue.Value); }
            return htmlTemplate.ToString();
        }

        internal override string GetPseudoInputFilePath() => input.Path;

        private readonly _404Template input;
    }
}
