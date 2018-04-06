using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Stasiewski.Catalogue.Interfaces;
using Stasiewski.Catalogue.DAO;

namespace Stasiewski.Catalogue.BL
{
    public class Query
    {
        public IDAO _dao { get; set; }
        public Query()
        {
            IDAO _dao = new DAOMock();
        }
        public IEnumerable<IProducer> getProducers()
        {
            if (_dao == null) _dao = new DAOMock();             //_dao posiada getter i setter, więc warto sprawdzić
            return _dao.getProducersDataset();
        }
        public IEnumerable<IGraphicCard> getProducts()
        {
            if (_dao == null) _dao = new DAOMock();
            return _dao.getProductsDataset();
        }
    }
}
