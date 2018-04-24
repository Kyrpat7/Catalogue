using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stasiewski.Catalogue.BL;
using Catalogue.Properties;

namespace Stasiewski.Catalogue
{
    public class Program
    {
        static void Main(string[] args)
        {
            Settings _appSettings = new Settings();
            Stasiewski.Catalogue.BL.Query _q = new Stasiewski.Catalogue.BL.Query(_appSettings.DAO);
            Console.WriteLine("Producenci");
            foreach (var _p in _q.getProducers())
            {
                Console.WriteLine(_p.Name);
            }
            Console.WriteLine("Produkty");
            foreach (var _p in _q.getProducts())
            {
                Console.WriteLine(_p.Model + " " + _p.Series);
            }
        }
    }
}
