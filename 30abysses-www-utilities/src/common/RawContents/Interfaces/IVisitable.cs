using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _30abysses.WWW.Utilities.Common.RawContents.Interfaces
{
    public interface IVisitable
    {
        void Accept(ContentVisitor visitor);
    }
}
