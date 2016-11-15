using _30abysses.WWW.Utilities.Common;
using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Metadata;

namespace _30abysses.WWW.Utilities.UpdateMetaContents
{
    public class UpdateMetaContentsVisitor : ContentVisitor
    {
        public ContentIO ContentIO { get; }

        public UpdateMetaContentsVisitor(string rootInputDirectoryPath, string rootOutputDirectoryPath) { ContentIO = new ContentIO(rootInputDirectoryPath, rootOutputDirectoryPath); }

        public override void Visit(ContentsRoot contentsRoot) => ContentIO.CreateOutputDirectory(contentsRoot.Path);

        public override void Visit(WwwRoot wwwRoot) => ContentIO.CreateOutputDirectory(wwwRoot.Path);

        public override void Visit(ContentMetadata contentMetadata) => ContentIO.CopyFileToOutputDirectory(contentMetadata.Path);

        public override void Visit(IndexTemplate indexTemplate) => ContentIO.CopyFileToOutputDirectory(indexTemplate.Path);

        public override void Visit(LogoTemplate logoTemplate) => ContentIO.CopyFileToOutputDirectory(logoTemplate.Path);

        public override void Visit(TopicTemplate topicTemplate) => ContentIO.CopyFileToOutputDirectory(topicTemplate.Path);

        public override void Visit(_404Template _404Template) => ContentIO.CopyFileToOutputDirectory(_404Template.Path);

        public override void Visit(AssetContainer assetContainer) => ContentIO.CopyDirectoryToOutputDirectory(assetContainer.Path);

        public override void Visit(Zone zone) => ContentIO.CreateOutputDirectory(zone.Path);

        public override void Visit(Year year) => ContentIO.CreateOutputDirectory(year.Path);

        public override void Visit(Month month) => ContentIO.CreateOutputDirectory(month.Path);

        public override void Visit(Day day) => ContentIO.CreateOutputDirectory(day.Path);

        public override void Visit(Topic topic) => ContentIO.CopyFileToOutputDirectory(topic.Path);

        public override void Visit(MetaTopic metaTopic) => ContentIO.CopyFileToOutputDirectory(metaTopic.Path);
    }
}
