using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasaFiskalna
{
    class Meblowy:Sklep
    {
        public override void Add()
        {
            bool czyPoprawna = false;
            string nazwa;
            int ilosc = 0;
            double cena = 0;

            Console.Write("Podaj nazwę produktu: ");
            nazwa = Console.ReadLine();

            Console.Write("Podaj cenę produktu: ");
            while (!czyPoprawna)
            {
                czyPoprawna = true;

                try
                {
                    cena = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Wystąpił błąd przy pobieraniu danych.");
                    czyPoprawna = false;
                }
            }

            Console.WriteLine("Podaj ilość produktu.");
            czyPoprawna = false;
            while (!czyPoprawna)
            {
                czyPoprawna = true;

                try
                {
                    ilosc = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Wystąpił błąd przy pobieraniu danych.");
                    czyPoprawna = false;
                }
            }
            if (ilosc > 1)
                ilosc = (IleSztuk(ilosc));

            Koszyk.Zakupy.Add(new Produkt(nazwa, cena, ilosc));
            Console.WriteLine("Produkt został dodany.");
        }
        public int IleSztuk(int ilosc)
        {
            bool czyPoprawna = false;
            char odp;
            do
            {
                Console.WriteLine("Czy na pewno miało być {0}?", ilosc);
                Console.WriteLine("Jeśli tak, wciśnij t, jeśli nie, wciśnij n.");
                odp = Convert.ToChar(Console.ReadLine());
                if (odp == 't' || odp == 'T') break;
                Console.WriteLine("Jeśli nie, podaj ilość towaru jeszcze raz.");

                czyPoprawna = false;
                while (!czyPoprawna)
                {
                    czyPoprawna = true;
                    try
                    {
                        ilosc = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Wystąpił błąd przy pobieraniu danych.");
                        czyPoprawna = false;
                    }
                }
            } while (ilosc > 1);
            return ilosc;
        }
    }
}
