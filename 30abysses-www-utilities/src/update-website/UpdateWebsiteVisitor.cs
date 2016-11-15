using _30abysses.WWW.Utilities.Common;
using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Metadata;

namespace _30abysses.WWW.Utilities.UpdateWebsite
{
    public class UpdateWebsiteVisitor : ContentVisitor
    {
        public ContentIO ContentIO { get; }
        public string WwwRootAssetContainerPath { get; private set; }

        public UpdateWebsiteVisitor(string rootInputDirectoryPath, string rootOutputDirectoryPath) { ContentIO = new ContentIO(rootInputDirectoryPath, rootOutputDirectoryPath); }

        public override void Visit(WwwRoot wwwRoot)
        {
            WwwRootAssetContainerPath = wwwRoot.AssetContainer.Path;
            ContentIO.CreateOutputDirectory(wwwRoot.Path);
        }

        public override void Visit(AssetContainer assetContainer) => ContentIO.CopyDirectoryToOutputDirectory(assetContainer.Path);

        public override void Visit(Zone zone) => ContentIO.CreateOutputDirectory(zone.Path);

        public override void Visit(Year year) => ContentIO.CreateOutputDirectory(year.Path);

        public override void Visit(Month month) => ContentIO.CreateOutputDirectory(month.Path);

        public override void Visit(Day day) => ContentIO.CreateOutputDirectory(day.Path);
    }
}
