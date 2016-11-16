namespace _30abysses.WWW.Utilities.UpdateWebsite.Renderer
{
    public abstract class AbstractRenderer<T>
    {
        public string HtmlTitleSuffix { get; } = " @ 30abysses (卅淵)";
        public T Input { get; }

        public AbstractRenderer(T input) { Input = input; }

        public abstract string GetPseudoInputFilePath();
        public abstract string GetOutputFileContents();
        public abstract string GetHtmlTitle();
        public abstract string GetHtmlContents();
    }
}
