using _30abysses.WWW.Utilities.Common;
using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Contents;

namespace _30abysses.WWW.Utilities.UpdateMetaContents
{
    public class UpdateMetaContentsVisitor : ContentVisitor
    {
        public ContentIO ContentIO { get; }

        public UpdateMetaContentsVisitor(string rootInputDirectoryPath, string rootOutputDirectoryPath)
        {
            ContentIO = new ContentIO(rootInputDirectoryPath, rootOutputDirectoryPath);
        }

        public override void Visit(ContentsRoot contentsRoot) => ContentIO.CreateOutputDirectory(contentsRoot.Path);
    }
}
