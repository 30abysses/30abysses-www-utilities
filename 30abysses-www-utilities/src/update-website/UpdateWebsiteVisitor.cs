using _30abysses.WWW.Utilities.Common;
using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Metadata;
using _30abysses.WWW.Utilities.UpdateWebsite.WebsiteRenderers.Renderers;

namespace _30abysses.WWW.Utilities.UpdateWebsite
{
    public class UpdateWebsiteVisitor : ContentVisitor
    {
        public ContentIO ContentIO { get; }

        public UpdateWebsiteVisitor(string rootInputDirectoryPath, string rootOutputDirectoryPath) { ContentIO = new ContentIO(rootInputDirectoryPath, rootOutputDirectoryPath); }

        public override void Visit(WwwRoot wwwRoot) => ContentIO.CreateOutputDirectory(wwwRoot.Path);

        public override void Visit(AssetContainer assetContainer) => ContentIO.CopyDirectoryToOutputDirectory(assetContainer.Path);

        public override void Visit(Zone zone) => ContentIO.CreateOutputDirectory(zone.Path);

        public override void Visit(Year year) => ContentIO.CreateOutputDirectory(year.Path);

        public override void Visit(Month month) => ContentIO.CreateOutputDirectory(month.Path);

        public override void Visit(Day day) => ContentIO.CreateOutputDirectory(day.Path);

        public override void Leave(MetaTopic metaTopic)
        {
            var renderer = new MetaTopicRenderer(metaTopic);
            ContentIO.CreateOutputFile(renderer.GetPseudoInputFilePath(), renderer.GetOutputFileContents());
        }

        public override void Leave(Topic topic)
        {
            var renderer = new TopicRenderer(topic);
            ContentIO.CreateOutputFile(renderer.GetPseudoInputFilePath(), renderer.GetOutputFileContents());
        }

        public override void Leave(Day day)
        {
            var renderer = new DayRenderer(day);
            ContentIO.CreateOutputFile(renderer.GetPseudoInputFilePath(), renderer.GetOutputFileContents());
        }

        public override void Leave(Month month)
        {
            var renderer = new MonthRenderer(month);
            ContentIO.CreateOutputFile(renderer.GetPseudoInputFilePath(), renderer.GetOutputFileContents());
        }

        public override void Leave(Year year)
        {
            var renderer = new YearRenderer(year);
            ContentIO.CreateOutputFile(renderer.GetPseudoInputFilePath(), renderer.GetOutputFileContents());
        }

        public override void Leave(Zone zone)
        {
            var renderer = new ZoneRenderer(zone);
            ContentIO.CreateOutputFile(renderer.GetPseudoInputFilePath(), renderer.GetOutputFileContents());
        }

        public override void Leave(_404Template _404Template)
        {
            var renderer = new _404TemplateRenderer(_404Template);
            ContentIO.CreateOutputFile(renderer.GetPseudoInputFilePath(), renderer.GetOutputFileContents());
        }

        public override void Leave(WwwRoot wwwRoot)
        {
            var renderer = new WwwRootRenderer(wwwRoot);
            ContentIO.CreateOutputFile(renderer.GetPseudoInputFilePath(), renderer.GetOutputFileContents());
        }
    }
}
