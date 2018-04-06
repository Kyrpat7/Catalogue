using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stasiewski.Catalogue.Interfaces
{
    public interface IProducer
    {
        string Name { get; set; }
        string Country { get; set; }
        string City { get; set; }
        string Street { get; set; }
    }
}
