using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _30abysses.WWW.Utilities.Common.RawContents.Contents
{
    public class Day : OrganizationalContainer, IVisitable
    {
        public IEnumerable<Topic> Topics { get; }

        public Day(string path, Month container) : base(path, container) { Topics = Topic.Get(this); }

        public static IEnumerable<Day> Get(Month container) =>
            Directory.GetDirectories(container.Path, "??")
            .Where(path => DD.IsMatch(System.IO.Path.GetFileName(path)))
            .Select(path => new Day(path, container))
            .ToArray();

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            foreach (var topic in Topics) { ((IVisitable) topic).Accept(visitor); }
            visitor.Leave(this);
        }

        public static Regex DD { get; } = new Regex(@"\d{2}");
    }
}
