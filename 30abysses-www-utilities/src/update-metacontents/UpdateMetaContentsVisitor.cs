﻿using _30abysses.WWW.Utilities.Common;
using _30abysses.WWW.Utilities.Common.MetaContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Metadata;
using _30abysses.WWW.Utilities.UpdateMetaContents.Extensions;

namespace _30abysses.WWW.Utilities.UpdateMetaContents
{
    internal class UpdateMetaContentsVisitor : ContentVisitor
    {
        internal UpdateMetaContentsVisitor(string rootInputDirectoryPath, string rootOutputDirectoryPath)
        {
            contentIO = new ContentIO(rootInputDirectoryPath, rootOutputDirectoryPath);
            indexInfoCache = new IndexInfoCache();
        }

        public override void Visit(ContentsRoot contentsRoot) => contentIO.CreateOutputDirectory(contentsRoot.Path);

        public override void Visit(WwwRoot wwwRoot)
        {
            wwwRoot.InitializeItemInfoExtensions();
            wwwRoot.InitializeWwwRootAssetContainerInfoExtensions();
            wwwRoot.InitializeContentMetadataInfoExtensions();
            wwwRoot.InitializeOrganizationInfoExtensions();
            Visit(wwwRoot);
        }

        public override void Visit(ContentMetadata contentMetadata) => Visit(contentMetadata);

        public override void Visit(IndexTemplate indexTemplate) => Visit(indexTemplate);

        public override void Visit(LogoTemplate logoTemplate) => Visit(logoTemplate);

        public override void Visit(TopicTemplate topicTemplate) => Visit(topicTemplate);

        public override void Visit(_404Template _404Template)
        {
            _404Template.InitializeItemInfoExtensions();
            Visit(_404Template);
        }

        public override void Visit(AssetContainer assetContainer) => contentIO.CopyDirectoryToOutputDirectory(assetContainer.Path);

        public override void Visit(Zone zone)
        {
            zone.InitializeItemInfoExtensions();
            Visit(zone);
        }

        public override void Visit(Year year)
        {
            year.InitializeItemInfoExtensions();
            Visit(year);
        }

        public override void Visit(Month month)
        {
            month.InitializeItemInfoExtensions();
            Visit(month);
        }

        public override void Visit(Day day)
        {
            day.InitializeItemInfoExtensions();
            Visit(day);
        }

        public override void Visit(Topic topic)
        {
            topic.InitializeItemInfoExtensions();
            Visit(topic);
        }

        public override void Visit(MetaTopic metaTopic)
        {
            metaTopic.InitializeItemInfoExtensions();
            Visit(metaTopic);
        }

        public override void Leave(MetaTopic metaTopic) => Leave(metaTopic);

        public override void Leave(Topic topic) => Leave(topic);

        public override void Leave(Day day)
        {
            indexInfoCache.Add(day);
            Leave(day);
        }

        public override void Leave(Month month)
        {
            indexInfoCache.Add(month, month.Days);
            Leave(month);
        }

        public override void Leave(Year year)
        {
            indexInfoCache.Add(year, year.Months);
            Leave(year);
        }

        public override void Leave(Zone zone)
        {
            indexInfoCache.Add(zone, zone.Years);
            Leave(zone);
        }

        public override void Leave(WwwRoot wwwRoot)
        {
            indexInfoCache.Add(wwwRoot, wwwRoot.Zones);
            Leave(wwwRoot);
        }

        private void Visit(OrganizationalContainer organizationalContainer) => contentIO.CreateOutputDirectory(organizationalContainer.Path);

        private void Visit(Item item) => contentIO.CopyFileToOutputDirectory(item.Path);

        private void Visit<T>(AbstractMetadata<T> abstractMetadata) => contentIO.CopyFileToOutputDirectory(abstractMetadata.Path);

        private void Leave(OrganizationalContainer organizationalContainer)
        {
            contentIO.CreateOutputFile(IndexInfo.GetPseudoInputFilePath(organizationalContainer.Path), indexInfoCache[organizationalContainer].GetOutputFileContents());
            contentIO.CreateOutputFile(organizationalContainer.Path + WwwRootAssetContainerInfo.FilenameExtension, organizationalContainer.GetWwwRootAssetContainerInfo().GetOutputFileContents());
            contentIO.CreateOutputFile(organizationalContainer.Path + OrganizationInfo.FilenameExtension, organizationalContainer.GetOrganizationInfo().GetOutputFileContents());
            Leave(organizationalContainer, organizationalContainer.ContentMetadata);
        }

        private void Leave(AbstractTopic abstractTopic)
        {
            contentIO.CreateOutputFile(abstractTopic.Path + AbstractTopicInfo.FilenameExtension, abstractTopic.GetAbstractTopicInfo().GetOutputFileContents());
            Leave((Item) abstractTopic);
        }

        private void Leave(Item item)
        {
            contentIO.CreateOutputFile(item.Path + WwwRootAssetContainerInfo.FilenameExtension, item.GetWwwRootAssetContainerInfo().GetOutputFileContents());
            contentIO.CreateOutputFile(item.Path + OrganizationInfo.FilenameExtension, item.GetOrganizationInfo().GetOutputFileContents());
            Leave(item, ((OrganizationalContainer) item.Container).ContentMetadata);
        }

        private void Leave(Item item, ContentMetadata itemContentMetadata) => contentIO.CreateOutputFile(item.Path + ContentMetadataInfo.FilenameExtension, itemContentMetadata.GetContentMetadataInfo().GetOutputFileContents());

        private readonly ContentIO contentIO;
        private readonly IndexInfoCache indexInfoCache;
    }
}
