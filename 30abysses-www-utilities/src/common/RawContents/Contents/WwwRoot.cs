﻿using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using _30abysses.WWW.Utilities.Common.RawContents.Metadata;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _30abysses.WWW.Utilities.Common.RawContents.Contents
{
    public class WwwRoot : OrganizationalContainer, IVisitable
    {
        public _404WebPage _404WebPage { get; }
        public AssetContainer AssetContainer { get; }
        public IEnumerable<Zone> Zones { get; }

        public WwwRoot(string path, ContentsRoot container) : base(path, container)
        {
            AssetContainer = AssetContainer.Get(this);
            _404WebPage = _404WebPage.Get(this);
            Zones = Zone.Get(this);
        }

        internal WwwRoot Get(ContentsRoot container)
        {
            var path = System.IO.Path.Combine(container.Path, "WwwRoot");
            return Directory.Exists(path) ? new WwwRoot(path, container) : null;
        }

        void IVisitable.Accept(ContentVisitor visitor)
        {
            visitor.Visit(this);
            Accept(visitor);
            ((IVisitable) _404WebPage).Accept(visitor);
            ((IVisitable) AssetContainer).Accept(visitor);
            foreach (var zone in Zones) { ((IVisitable) zone).Accept(visitor); }
            visitor.Leave(this);
        }
    }
}
