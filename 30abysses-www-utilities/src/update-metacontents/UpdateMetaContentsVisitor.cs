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
            organizationInfoCache = new OrganizationInfoCache();
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
            abstractTopicInfoCache.Add(topic);
            itemInfoCache.Add(topic, abstractTopicInfoCache[topic]);
            Visit(topic);
        }

        public override void Visit(MetaTopic metaTopic)
        {
            abstractTopicInfoCache.Add(metaTopic);
            itemInfoCache.Add(metaTopic, abstractTopicInfoCache[metaTopic]);
            Visit(metaTopic);
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
            Visit((Item) abstractTopic);
        }

        private void Leave(OrganizationalContainer organizationalContainer) => Leave(organizationalContainer, organizationalContainer.GetContentMetadata());

        private void Leave(Item item) => Leave(item, item.GetContentMetadata());

        private void Leave(Item item, ContentMetadata itemContentMetadata)
        {
            contentIO.CreateOutputFile(ContentMetadataInfo.GetPseudoInputFilePath(item.Path), contentMetadataInfoCache[itemContentMetadata].GetOutputFileContents());
            contentIO.CreateOutputFile(WwwRootAssetContainerInfo.GetPseudoInputFilePath(item.Path), wwwRootAssetContainerInfoCache[item].GetOutputFileContents());
            contentIO.CreateOutputFile(OrganizationInfo.GetPseudoInputFilePath(item.Path), organizationInfoCache[item].GetOutputFileContents());
        }

        private void Visit(OrganizationalContainer organizationalContainer)
        {
            contentIO.CreateOutputDirectory(organizationalContainer.Path);
            wwwRootAssetContainerInfoCache.Add(organizationalContainer);
            Visit(organizationalContainer, organizationalContainer.GetContentMetadata());
        }

        private void Visit(Item item)
        {
            contentIO.CopyFileToOutputDirectory(item.Path);
            wwwRootAssetContainerInfoCache.Add(item);
            Visit(item, item.GetContentMetadata());
        }

        private void Visit(Item item, ContentMetadata itemContentMetadata)
        {
            contentMetadataInfoCache.Add(itemContentMetadata);
            organizationInfoCache.Add(item, itemInfoCache[item]);
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
        private readonly OrganizationInfoCache organizationInfoCache;
    }

    public static class ExtensionMethods
    {
        public static ContentMetadata GetContentMetadata(this Item item) => ((OrganizationalContainer) item.Container).ContentMetadata;

        public static ContentMetadata GetContentMetadata(this OrganizationalContainer organizationalContainer) => organizationalContainer.ContentMetadata;
    }
}
