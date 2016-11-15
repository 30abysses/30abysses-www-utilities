using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _30abysses.WWW.Utilities.Common.RawContents.Contents
{
    public class Year : OrganizationalContainer, IVisitable
    {
        public IEnumerable<Month> Months { get; }

        public Year(string path, Zone container) : base(path, container) { Months = Month.Get(this); }

        public static IEnumerable<Year> Get(Zone container) =>
            Directory.GetDirectories(container.Path, "????")
            .Where(path => YYYY.IsMatch(System.IO.Path.GetFileName(path)))
            .Select(path => new Year(path, container))
            .ToArray();

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            Accept(visitor);
            foreach (var month in Months) { ((IVisitable) month).Accept(visitor); }
            visitor.Leave(this);
        }

        public static Regex YYYY { get; } = new Regex(@"\d{4}");
    }
}
