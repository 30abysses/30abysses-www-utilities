using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using SysIoPath = System.IO.Path;

namespace _30abysses.WWW.Utilities.Common.RawContents.Contents
{
    public class Day : OrganizationalContainer, IVisitable
    {
        public IEnumerable<Topic> Topics { get; }

        internal Day(string path, Month container) : base(path, container)
        {
            Topics = Directory.GetFiles(Path, Topic.FilenamePattern)
                .Where(filePath => Topic.FilenameRegex.IsMatch(SysIoPath.GetFileName(filePath)))
                .Select(filePath => new Topic(filePath, this))
                .ToArray();
        }

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            Accept(visitor);
            foreach (var topic in Topics) { ((IVisitable) topic).Accept(visitor); }
            visitor.Leave(this);
        }

        internal const string FilenamePattern = "??";
        internal static readonly Regex FilenameRegex = new Regex(@"^[0-3][0-9]$", RegexOptions.CultureInvariant);
    }
}
