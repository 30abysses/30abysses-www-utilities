using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _30abysses.WWW.Utilities.Common.RawContents.Contents
{
    public class Month : OrganizationalContainer, IVisitable
    {
        public IEnumerable<Day> Days { get; }

        public Month(string path, Year container) : base(path, container) { Days = Day.Get(this); }

        public static IEnumerable<Month> Get(Year container) =>
            Directory.GetDirectories(container.Path, "??")
            .Where(path => MM.IsMatch(System.IO.Path.GetFileName(path)))
            .Select(path => new Month(path, container))
            .ToArray();

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            Accept(visitor);
            foreach (var day in Days) { ((IVisitable) day).Accept(visitor); }
            visitor.Leave(this);
        }

        public static readonly Regex MM = new Regex(@"\d{2}");
    }
}
