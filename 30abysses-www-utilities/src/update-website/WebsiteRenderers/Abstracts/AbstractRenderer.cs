namespace _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Abstracts
{
    internal abstract class AbstractRenderer<T>
    {
        protected T Input { get; }

        protected AbstractRenderer(T input) { Input = input; }

        internal abstract string GetPseudoInputFilePath();
        internal abstract string GetOutputFileContents();
        protected abstract string GetHtmlTitle();
        protected abstract string GetHtmlNavigation();
        protected abstract string GetHtmlContents();

        protected const string HtmlExtensionFilename = ".html";
    }
}
