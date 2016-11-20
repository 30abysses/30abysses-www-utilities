using _30abysses.WWW.Utilities.Common;
using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Metadata;
using _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Renderers;

namespace _30abysses.WWW.Utilities.UpdateWebsite
{
    public class UpdateWebsiteVisitor : ContentVisitor
    {
        public UpdateWebsiteVisitor(string rootInputDirectoryPath, string rootOutputDirectoryPath) { contentIO = new ContentIO(rootInputDirectoryPath, rootOutputDirectoryPath); }

        public override void Visit(WwwRoot wwwRoot) => contentIO.CreateOutputDirectory(wwwRoot.Path);

        public override void Visit(AssetContainer assetContainer) => contentIO.CopyDirectoryToOutputDirectory(assetContainer.Path);

        public override void Visit(Zone zone) => contentIO.CreateOutputDirectory(zone.Path);

        public override void Visit(Year year) => contentIO.CreateOutputDirectory(year.Path);

        public override void Visit(Month month) => contentIO.CreateOutputDirectory(month.Path);

        public override void Visit(Day day) => contentIO.CreateOutputDirectory(day.Path);

        public override void Visit(Topic topic) => contentIO.CopyFileToOutputDirectory(topic.Path);

        public override void Visit(MetaTopic metaTopic) => contentIO.CopyFileToOutputDirectory(metaTopic.Path);

        public override void Leave(MetaTopic metaTopic)
        {
            var renderer = new MetaTopicRenderer(metaTopic);
            contentIO.CreateOutputFile(renderer.GetPseudoInputFilePath(), renderer.GetOutputFileContents());
        }

        public override void Leave(Topic topic)
        {
            var renderer = new TopicRenderer(topic);
            contentIO.CreateOutputFile(renderer.GetPseudoInputFilePath(), renderer.GetOutputFileContents());
        }

        public override void Leave(Day day)
        {
            var renderer = new DayRenderer(day);
            contentIO.CreateOutputFile(renderer.GetPseudoInputFilePath(), renderer.GetOutputFileContents());
        }

        public override void Leave(Month month)
        {
            var renderer = new MonthRenderer(month);
            contentIO.CreateOutputFile(renderer.GetPseudoInputFilePath(), renderer.GetOutputFileContents());
        }

        public override void Leave(Year year)
        {
            var renderer = new YearRenderer(year);
            contentIO.CreateOutputFile(renderer.GetPseudoInputFilePath(), renderer.GetOutputFileContents());
        }

        public override void Leave(Zone zone)
        {
            var renderer = new ZoneRenderer(zone);
            contentIO.CreateOutputFile(renderer.GetPseudoInputFilePath(), renderer.GetOutputFileContents());
        }

        public override void Leave(_404Template _404Template)
        {
            var renderer = new _404TemplateRenderer(_404Template);
            contentIO.CreateOutputFile(renderer.GetPseudoInputFilePath(), renderer.GetOutputFileContents());
        }

        public override void Leave(WwwRoot wwwRoot)
        {
            var renderer = new WwwRootRenderer(wwwRoot);
            contentIO.CreateOutputFile(renderer.GetPseudoInputFilePath(), renderer.GetOutputFileContents());
        }

        private readonly ContentIO contentIO;
    }
}
