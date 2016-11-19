using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using SysIoPath = System.IO.Path;

namespace _30abysses.WWW.Utilities.Common.RawContents.Contents
{
    public class Month : OrganizationalContainer, IVisitable
    {
        public IEnumerable<Day> Days { get; }

        internal Month(string path, Year container) : base(path, container)
        {
            Days = Directory.GetDirectories(container.Path, Day.FilenamePattern)
                .Where(filePath => Day.FilenameRegex.IsMatch(SysIoPath.GetFileName(filePath)))
                .Select(filePath => new Day(filePath, this))
                .ToArray();
        }

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            Accept(visitor);
            foreach (var day in Days) { ((IVisitable) day).Accept(visitor); }
            visitor.Leave(this);
        }

        internal const string FilenamePattern = "??";
        internal static readonly Regex FilenameRegex = new Regex(@"^[0-1][0-9]$", RegexOptions.CultureInvariant);
    }
}
