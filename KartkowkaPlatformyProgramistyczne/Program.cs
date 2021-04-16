using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace kartkowkaPlatformyWyklad
{
    public class Produkt
    {
        public int ID { set; get; }
        public string nazwa { set; get; }
        public float cena { set; get; }
        public int ilosc { set; get; }
    }

    public class Automat : DbContext
    {
        public virtual DbSet<Produkt> Produkts { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var context = new Automat();
            context.Produkts.Add(new Produkt { nazwa = "Snickers", cena = 2.50f, ilosc = 10 });
            context.Produkts.Add(new Produkt { nazwa = "Coca-Cola-05", cena = 5.99f, ilosc = 8 });
            context.SaveChanges();

            var produkts = (from s in context.Produkts select s).ToList<Produkt>();
            foreach (var pr in produkts)
            {
                Console.WriteLine("ID: {0}, Nazwa: {1}, Cena: {2:0.00} pln, Ilość: {3}", pr.ID, pr.nazwa, pr.cena, pr.ilosc);
            }
            Console.ReadKey();
        }
    }
}