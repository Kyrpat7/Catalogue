using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Stasiewski.Catalogue.BL;

namespace Stasiewski.Catalogue
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stasiewski.Catalogue.BL.Query q = new Stasiewski.Catalogue.BL.Query();
            Console.WriteLine("Producenci");
            foreach (var p in q.getProducers())
            {
                Console.WriteLine(p.Name);
            }
            Console.WriteLine("Produkty");
            foreach (var p in q.getProducts())
            {
                Console.WriteLine(p.Model + " " + p.Series);
            }
        }
    }
}
