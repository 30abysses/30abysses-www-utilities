﻿using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using System.IO;
using System.Text.RegularExpressions;
using SysIoPath = System.IO.Path;

namespace _30abysses.WWW.Utilities.Common.RawContents.Contents
{
    public class Topic : AbstractTopic, IVisitable
    {
        public MetaTopic MetaTopic { get; }

        internal Topic(string path, Day container) : base(path, container)
        {
            var itemPath = SysIoPath.ChangeExtension(Path, MetaTopic.FilenameExtension);
            MetaTopic = File.Exists(itemPath) ? new MetaTopic(itemPath, Container, this) : null;
        }

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            Accept(visitor);
            ((IVisitable) MetaTopic)?.Accept(visitor);
            visitor.Leave(this);
        }

        internal const string FilenamePattern = "*.md";
        internal static readonly Regex FilenameRegex = new Regex(@"^[a-z_0-9.-]+\.md$", RegexOptions.CultureInvariant);
    }
}
