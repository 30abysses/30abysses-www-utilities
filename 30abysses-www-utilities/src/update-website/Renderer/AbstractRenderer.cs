namespace _30abysses.WWW.Utilities.UpdateWebsite.Renderer
{
    public abstract class AbstractRenderer<T>
    {
        public static string HtmlTitleSuffix { get; } = " @ 30abysses (卅淵)";
        public static string IndexHtmlFilename { get; } = "index.html";
        public static string HtmlExtensionFilename { get; } = ".html";
        public T Input { get; }

        public AbstractRenderer(T input) { Input = input; }

        public abstract string GetPseudoInputFilePath();
        public abstract string GetOutputFileContents();
        public abstract string GetHtmlTitle();
        public abstract string GetHtmlContents();
        public abstract string GetHtmlNavigation();
    }
}
