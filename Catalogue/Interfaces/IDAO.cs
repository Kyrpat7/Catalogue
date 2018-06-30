using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stasiewski.Catalogue.Interfaces
{
    public interface IDAO
    {
        IEnumerable<IGraphicCard> getProductsDataset();
        IEnumerable<IProducer> getProducersDataset();
        IGraphicCard CreateNewProduct();
        IProducer CreateNewProducer();
    }
}
