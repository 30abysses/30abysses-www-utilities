using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _30abysses.WWW.Utilities.UpdateWebsite
{
    public class UpdateWebsiteVisitor : ContentVisitor
    {
        private string outputDirectoryPath;
        private string path;

        public UpdateWebsiteVisitor(string path, string outputDirectoryPath)
        {
            this.path = path;
            this.outputDirectoryPath = outputDirectoryPath;
        }
    }
}
