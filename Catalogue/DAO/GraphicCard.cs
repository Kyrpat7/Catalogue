using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stasiewski.Catalogue.Interfaces;
using Stasiewski.Catalogue.Core;

namespace Stasiewski.Catalogue.DAO
{
    public class GraphicCard : IGraphicCard
    {
        public DirectXVersion DirectXSupport { get; set; }
        public IProducer Producer { get; set; }
        public string Model { get; set; }
        public string Series { get; set; }
        public int Memory { get; set; }
    }
}
