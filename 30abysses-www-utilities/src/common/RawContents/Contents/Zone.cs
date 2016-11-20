using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using SysIoPath = System.IO.Path;

namespace _30abysses.WWW.Utilities.Common.RawContents.Contents
{
    public class Zone : OrganizationalContainer, IVisitable
    {
        public IEnumerable<Year> Years { get; }

        internal Zone(string path, WwwRoot container) : base(path, container)
        {
            Years = Directory.GetDirectories(Path, Year.FilenamePattern)
                .Where(filePath => Year.FilenameRegex.IsMatch(SysIoPath.GetFileName(filePath)))
                .Select(filePath => new Year(filePath, this))
                .ToArray();
        }

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            Accept(visitor);
            foreach (var year in Years) { ((IVisitable) year).Accept(visitor); }
            visitor.Leave(this);
        }

        internal const string FilenamePattern = "*";
        internal static readonly Regex FilenameRegex = new Regex(@"^[a-zA-Z_0-9][a-zA-Z_0-9.]+$", RegexOptions.CultureInvariant);
    }
}
