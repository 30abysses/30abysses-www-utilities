using _30abysses.WWW.Utilities.Common;
using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Metadata;

namespace _30abysses.WWW.Utilities.UpdateMetaContents
{
    public class UpdateMetaContentsVisitor : ContentVisitor
    {
        public UpdateMetaContentsVisitor(string rootInputDirectoryPath, string rootOutputDirectoryPath)
        {
            contentIO = new ContentIO(rootInputDirectoryPath, rootOutputDirectoryPath);
            contentMetadataInfoCache = new ContentMetadataInfoCache();
        }

        public override void Visit(ContentsRoot contentsRoot) => contentIO.CreateOutputDirectory(contentsRoot.Path);

        public override void Visit(WwwRoot wwwRoot)
        {
            contentIO.CreateOutputDirectory(wwwRoot.Path);
            wwwRootAssetContainer = wwwRoot.AssetContainer;
        }

        public override void Visit(ContentMetadata contentMetadata) => contentIO.CopyFileToOutputDirectory(contentMetadata.Path);

        public override void Visit(IndexTemplate indexTemplate) => contentIO.CopyFileToOutputDirectory(indexTemplate.Path);

        public override void Visit(LogoTemplate logoTemplate) => contentIO.CopyFileToOutputDirectory(logoTemplate.Path);

        public override void Visit(TopicTemplate topicTemplate) => contentIO.CopyFileToOutputDirectory(topicTemplate.Path);

        public override void Visit(_404Template _404Template) => contentIO.CopyFileToOutputDirectory(_404Template.Path);

        public override void Visit(AssetContainer assetContainer) => contentIO.CopyDirectoryToOutputDirectory(assetContainer.Path);

        public override void Visit(Zone zone) => contentIO.CreateOutputDirectory(zone.Path);

        public override void Visit(Year year) => contentIO.CreateOutputDirectory(year.Path);

        public override void Visit(Month month) => contentIO.CreateOutputDirectory(month.Path);

        public override void Visit(Day day) => contentIO.CreateOutputDirectory(day.Path);

        public override void Visit(Topic topic) => contentIO.CopyFileToOutputDirectory(topic.Path);

        public override void Visit(MetaTopic metaTopic) => contentIO.CopyFileToOutputDirectory(metaTopic.Path);

        private readonly ContentIO contentIO;
        private AssetContainer wwwRootAssetContainer;
        private readonly ContentMetadataInfoCache contentMetadataInfoCache;
    }
}
