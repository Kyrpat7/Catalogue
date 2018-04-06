using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stasiewski.Catalogue.Core;

namespace Stasiewski.Catalogue.Interfaces
{
    public interface IGraphicCard
    {
        DirectXVersion directXSupport { get; set; }
        IProducer Producer { get; set; }
        string Model { get; set; }
        string Series { get; set; }
        int Memory { get; set; }
    }
}
