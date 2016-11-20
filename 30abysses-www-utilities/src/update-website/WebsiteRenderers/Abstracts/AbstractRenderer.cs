namespace _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Abstracts
{
    public abstract class AbstractRenderer<T>
    {
        public T Input { get; }

        public AbstractRenderer(T input) { Input = input; }

        public abstract string GetPseudoInputFilePath();
        public abstract string GetOutputFileContents();
        protected abstract string GetHtmlTitle();
        protected abstract string GetHtmlNavigation();
        protected abstract string GetHtmlContents();

        public const string HtmlTitleSuffix = " @ 30abysses (卅淵)";
        public const string IndexHtmlFilename = "index.html";
        public const string HtmlExtensionFilename = ".html";
    }
}
