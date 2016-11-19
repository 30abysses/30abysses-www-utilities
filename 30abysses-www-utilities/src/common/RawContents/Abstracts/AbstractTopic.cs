﻿using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using _30abysses.WWW.Utilities.Common.RawContents.Metadata;

namespace _30abysses.WWW.Utilities.Common.RawContents.Abstracts
{
    public abstract class AbstractTopic : Item
    {
        protected AssetContainer AssetContainer { get; }

        protected AbstractTopic(string path, Container container) : base(path, container) { AssetContainer = AssetContainer.Get(this); }

        protected void Accept(ContentVisitor visitor) { ((IVisitable) AssetContainer)?.Accept(visitor); }
    }
}
