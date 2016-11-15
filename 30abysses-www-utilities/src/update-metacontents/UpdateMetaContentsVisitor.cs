using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _30abysses.WWW.Utilities.UpdateMetaContents
{
    public class UpdateMetaContentsVisitor : ContentVisitor
    {
        private string outputDirectoryPath;
        private string path;

        public UpdateMetaContentsVisitor(string path, string outputDirectoryPath)
        {
            this.path = path;
            this.outputDirectoryPath = outputDirectoryPath;
        }
    }
}
