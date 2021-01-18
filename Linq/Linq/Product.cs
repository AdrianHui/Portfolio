using System;
using System.Collections.Generic;
using System.Text;

namespace Linq
{
    public class Product
    {
        public string Name { get; set; }

#pragma warning disable CA2227 // Collection properties should be read only
        public ICollection<Feature> Features { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
