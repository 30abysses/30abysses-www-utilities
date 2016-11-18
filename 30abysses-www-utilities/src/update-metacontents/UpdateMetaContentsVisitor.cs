using _30abysses.WWW.Utilities.Common;
using _30abysses.WWW.Utilities.Common.MetaContents.Contents;
using _30abysses.WWW.Utilities.Common.MetaContents.Metadata;
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
            itemInfoCache = new ItemInfoCache();
            abstractTopicInfoCache = new AbstractTopicInfoCache();
        }

        public override void Visit(ContentsRoot contentsRoot) => contentIO.CreateOutputDirectory(contentsRoot.Path);

        public override void Visit(WwwRoot wwwRoot)
        {
            wwwRootAssetContainerInfoCache = new WwwRootAssetContainerInfoCache(wwwRoot.AssetContainer);
            itemInfoCache.Add(wwwRoot);
            Visit(wwwRoot);
        }

        public override void Visit(ContentMetadata contentMetadata) => Visit(contentMetadata);

        public override void Visit(IndexTemplate indexTemplate) => Visit(indexTemplate);

        public override void Visit(LogoTemplate logoTemplate) => Visit(logoTemplate);

        public override void Visit(TopicTemplate topicTemplate) => Visit(topicTemplate);

        public override void Visit(_404Template _404Template)
        {
            itemInfoCache.Add(_404Template);
            Visit(_404Template);
        }

        public override void Visit(AssetContainer assetContainer) => contentIO.CopyDirectoryToOutputDirectory(assetContainer.Path);

        public override void Visit(Zone zone)
        {
            itemInfoCache.Add(zone);
            Visit(zone);
        }

        public override void Visit(Year year)
        {
            itemInfoCache.Add(year);
            Visit(year);
        }

        public override void Visit(Month month)
        {
            itemInfoCache.Add(month);
            Visit(month);
        }

        public override void Visit(Day day)
        {
            itemInfoCache.Add(day);
            Visit(day);
        }

        public override void Visit(Topic topic)
        {
            Visit(topic);
            itemInfoCache.Add(topic, abstractTopicInfoCache[topic]);
        }

        public override void Visit(MetaTopic metaTopic)
        {
            Visit(metaTopic);
            itemInfoCache.Add(metaTopic, abstractTopicInfoCache[metaTopic]);
        }

        public override void Leave(MetaTopic metaTopic) => Leave(metaTopic);

        public override void Leave(Topic topic) => Leave(topic);

        public override void Leave(Day day) => Leave(day);

        public override void Leave(Month month) => Leave(month);

        public override void Leave(Year year) => Leave(year);

        public override void Leave(Zone zone) => Leave(zone);

        public override void Leave(WwwRoot wwwRoot) => Leave(wwwRoot);

        private void Visit<T>(AbstractMetadata<T> abstractMetadata) => contentIO.CopyFileToOutputDirectory(abstractMetadata.Path);

        private void Visit(AbstractTopic abstractTopic)
        {
            abstractTopicInfoCache.Add(abstractTopic);
            Visit((Item) abstractTopic);
        }

        private void Leave(OrganizationalContainer organizationalContainer)
        {
            contentIO.CreateOutputFile(ContentMetadataInfo.GetPseudoInputFilePath(organizationalContainer.Path), contentMetadataInfoCache[organizationalContainer.ContentMetadata].GetOutputFileContents());
            contentIO.CreateOutputFile(WwwRootAssetContainerInfo.GetPseudoInputFilePath(organizationalContainer.Path), wwwRootAssetContainerInfoCache[organizationalContainer].GetOutputFileContents());
        }

        private void Leave(Item item)
        {
            contentIO.CreateOutputFile(ContentMetadataInfo.GetPseudoInputFilePath(item.Path), contentMetadataInfoCache[((OrganizationalContainer) item.Container).ContentMetadata].GetOutputFileContents());
            contentIO.CreateOutputFile(WwwRootAssetContainerInfo.GetPseudoInputFilePath(item.Path), wwwRootAssetContainerInfoCache[item].GetOutputFileContents());
        }

        private void Visit(OrganizationalContainer organizationalContainer)
        {
            contentIO.CreateOutputDirectory(organizationalContainer.Path);
            contentMetadataInfoCache.Add(organizationalContainer.ContentMetadata);
            wwwRootAssetContainerInfoCache.Add(organizationalContainer);
        }

        private void Visit(Item item)
        {
            contentIO.CopyFileToOutputDirectory(item.Path);
            contentMetadataInfoCache.Add(((OrganizationalContainer) item.Container).ContentMetadata);
            wwwRootAssetContainerInfoCache.Add(item);
        }

        private void Leave(AbstractTopic abstractTopic)
        {
            Leave((Item) abstractTopic);

            contentIO.CreateOutputFile(AbstractTopicInfo.GetPseudoInputFilePath(abstractTopic.Path), abstractTopicInfoCache[abstractTopic].GetOutputFileContents());
        }

        private readonly ContentIO contentIO;
        private readonly ContentMetadataInfoCache contentMetadataInfoCache;
        private WwwRootAssetContainerInfoCache wwwRootAssetContainerInfoCache;
        private readonly ItemInfoCache itemInfoCache;
        private readonly AbstractTopicInfoCache abstractTopicInfoCache;
    }
}
