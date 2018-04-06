using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stasiewski.Catalogue.Interfaces;
using Stasiewski.Catalogue.Core;

namespace Stasiewski.Catalogue.DAO
{
    public class DAOMock : IDAO
    {
        private List<IProducer> producers;
        private List<IGraphicCard> cards;

        public DAOMock()
        {
            producers = new List<IProducer>();
            producers.Add(new Producer { Name = "Testowy", Country = "Mockland", City = "Mock", Street = "Nonexistance" });

            cards = new List<IGraphicCard>();
            cards.Add(new GraphicCard { Model = "Dosyc szybki", directXSupport = DirectXVersion.DirectX10, Memory = 512, Series = "Dobra seria", Producer = producers[0] });
        }

        public IEnumerable<IGraphicCard> getProductsDataset()
        {
            return cards;
        }
        public IEnumerable<IProducer> getProducersDataset()
        {
            return producers;
        }
    }
}
