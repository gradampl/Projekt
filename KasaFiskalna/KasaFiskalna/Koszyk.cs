using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KasaFiskalna
{
    class Koszyk
    {
        private static Sklep meblowy = new Meblowy();
        private static Sklep spozywczy = new Spozywczy();
        public static List<Produkt> Zakupy;

        public Koszyk()
        {
            Zakupy = new List<Produkt>();
        }
        public void Clone()
        {
            Zakupy.Add(Zakupy.Last());
            Console.WriteLine("Ostatnio dodany element został skopiowany.");
        }

        public void Dodaj()
        {
            if (Aplikacja.ktorySklep == 'M' || Aplikacja.ktorySklep == 'm')
            {
                meblowy.Add();
            }
            else if (Aplikacja.ktorySklep == 'S' || Aplikacja.ktorySklep == 's')
            {
                spozywczy.Add();
            }

        }

        public void WypiszKoszyk()
        {
            foreach (var prod in Zakupy)
            {
                prod.WypiszProdukt();
            }
            Console.WriteLine("W sumie do zapłaty: " + PodajSume());
        }

        public double PodajSume()
        {
            double suma = 0;
            foreach (var prod in Zakupy)
            {
                suma += prod.PodajCene();
            }
            return suma;
        }

        public void SkasujProdukt()
        {
            bool czyPoprawny = false;
            int doUsuniecia = -1;

            while (!czyPoprawny)
            {
                czyPoprawny = true;

                try
                {
                    doUsuniecia = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Pojawił się problem przy pobieraniu danych.");
                    czyPoprawny = false;
                }

                try
                {
                    Zakupy.RemoveAt(doUsuniecia);
                    Console.WriteLine("Usunięto.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Pojawił się problem przy próbie usunięcia elementu.\nSprawdź indeks.");
                }
            }
        }

        public void Wyczysc()
        {
            Zakupy.Clear();
        }


        public void ZapiszParagon()
        {
            string day = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string hour = DateTime.Now.Hour.ToString();
            string minute = DateTime.Now.Minute.ToString();
            string second = DateTime.Now.Second.ToString();
            string name = day + month + year + hour + minute + second + ".txt";
            string line;

            FileStream fs = new FileStream(name, FileMode.CreateNew);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                foreach (var prod in Zakupy)
                {
                    line = prod.PodajProdukt();
                    sw.WriteLine(line);
                }
                sw.WriteLine("W sumie do zapłaty: " + PodajSume());
                Wyczysc();
            }

        }

    }
}
