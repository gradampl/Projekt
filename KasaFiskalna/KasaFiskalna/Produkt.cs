using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasaFiskalna
{
    class Produkt
    {
        private string nazwa;
        private double cenaJednostkowa;
        private int ilosc;

        public Produkt(string nazwa, double cenaJednostkowa, int ilosc)
        {
            this.nazwa = nazwa;
            this.cenaJednostkowa = cenaJednostkowa;
            this.ilosc = ilosc;
        }

        public void WypiszProdukt()
        {
            Console.WriteLine(nazwa + "--" + ilosc + " * " + cenaJednostkowa + " = " + ilosc * cenaJednostkowa);
        }

        public string PodajProdukt()
        {
            return nazwa + "--" + ilosc + " * " + cenaJednostkowa + " = " + ilosc * cenaJednostkowa;
        }

        public double PodajCene()
        {
            return ilosc * cenaJednostkowa;
        }
    }
}
