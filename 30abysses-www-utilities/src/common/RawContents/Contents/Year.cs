using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using SysIoPath = System.IO.Path;

namespace _30abysses.WWW.Utilities.Common.RawContents.Contents
{
    public class Year : OrganizationalContainer, IVisitable
    {
        public IEnumerable<Month> Months { get; }

        internal Year(string path, Zone container) : base(path, container)
        {
            Months = Directory.GetDirectories(Path, Month.FilenamePattern)
                .Where(filePath => Month.FilenameRegex.IsMatch(SysIoPath.GetFileName(filePath)))
                .Select(filePath => new Month(filePath, this))
                .ToArray();
        }

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            Accept(visitor);
            foreach (var month in Months) { ((IVisitable) month).Accept(visitor); }
            visitor.Leave(this);
        }

        internal const string FilenamePattern = "????";
        internal static readonly Regex FilenameRegex = new Regex(@"^[1-9][0-9]{3}$", RegexOptions.CultureInvariant);
    }
}
