using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _30abysses.WWW.Utilities.Common.RawContents.Contents
{
    public class Month : OrganizationalContainer, IVisitable
    {
        public IEnumerable<Day> Days { get; }

        public Month(string path, Year container) : base(path, container)
        {
            Days = Day.Get(this);
        }

        internal static IEnumerable<Month> Get(Year container)
        {
            return Directory.GetDirectories(container.Path, "??")
                .Where(path => MM.IsMatch(System.IO.Path.GetFileName(path)))
                .Select(path => new Month(path, container))
                .ToArray();
        }

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            foreach (var day in Days) { ((IVisitable) day).Accept(visitor); }
            visitor.Leave(this);
        }

        public static Regex MM { get; } = new Regex(@"\d{2}");
    }
}
