using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Stasiewski.Catalogue.Interfaces;
using Stasiewski.Catalogue.DAO;
using System.Runtime;
using System.Reflection;

namespace Stasiewski.Catalogue.BL
{
    public class Query
    {
        public IDAO _dao { get; set; }

        private string _DAOName;

        public Query(string name)
        {
            _DAOName = name;
            Assembly _a = Assembly.UnsafeLoadFrom(@"DAO.dll");
            Type _tp = null;
            foreach(var _t in _a.GetTypes())
            {
                if ( _t.ToString() == _DAOName )
                {
                    _tp = _t;
                    break;
                }
            }
            try
            {
                ConstructorInfo _ci = _tp.GetConstructor(Type.EmptyTypes);
                _dao = (IDAO)_ci.Invoke(Type.EmptyTypes);
            }
            catch(Exception e)
            {
                Console.WriteLine("Nastąpił bład w łaczeniu do bazy danych.");
            }
        }

        public Query() : this("Stasiewski.Catalogue.DAO.DAOMock")           //wartość domyślna w przypadku braku danych w 
        {
            
        }
        public IEnumerable<IProducer> getProducers()
        {
            if (_dao == null)   //_dao posiada getter i setter, więc warto sprawdzić
            {
                _dao = new DAOMock();             
            }
            return _dao.getProducersDataset();
        }
        public IEnumerable<IGraphicCard> getProducts()
        {
            if (_dao == null)
            {
                _dao = new DAOMock();
            }
            return _dao.getProductsDataset();
        }

        public IGraphicCard CreateNewProduct()
        {
            return _dao.CreateNewProduct();
        }

        public IProducer CreateNewProducer()
        {
            return _dao.CreateNewProducer();
        }
    }
}
