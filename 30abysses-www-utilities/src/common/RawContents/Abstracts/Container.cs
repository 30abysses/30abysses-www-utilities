using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _30abysses.WWW.Utilities.Common.RawContents.Abstracts
{
    public abstract class Container : Item
    {
        public Container(string path, Container container) : base(path, container) { }
    }
}
