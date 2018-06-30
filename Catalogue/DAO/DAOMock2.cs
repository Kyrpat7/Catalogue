using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stasiewski.Catalogue.Interfaces;
using Stasiewski.Catalogue.Core;

namespace Stasiewski.Catalogue.DAO
{
    public class DAOMock2 : IDAO
    {
        private List<IProducer> _producers;
        private List<IGraphicCard> _cards;

        public DAOMock2()
        {
            _producers = new List<IProducer>();
            _producers.Add(new Producer { Name = "NVIDIA Corporation", Country = "USA", City = "Santa Clara", Street = "San Tomas Expressway" });

            _cards = new List<IGraphicCard>();
            _cards.Add(new GraphicCard { Model = "GTX 1050", DirectXSupport = DirectXVersion.DirectX11, Memory = 2048, Series = "Nvidia GeForce", Producer = _producers[0] });
        }

        public IEnumerable<IGraphicCard> getProductsDataset()
        {
            return _cards;
        }
        public IEnumerable<IProducer> getProducersDataset()
        {
            return _producers;
        }

        public IGraphicCard CreateNewProduct()
        {
            IGraphicCard _new = new GraphicCard();
            return _new;
        }

        public IProducer CreateNewProducer()
        {
            IProducer _new = new Producer();
            return _new;
        }
    }
}
