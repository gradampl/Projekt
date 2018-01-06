using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasaFiskalna
{
    class Aplikacja
    {
        private static char klawisz;
        private static Koszyk Zakupy = new Koszyk();
        public static char ktorySklep;

        public static void Rozpoczecie()
        {
            Console.WriteLine("Dzień dobry!");
            Console.WriteLine("Ta kasa obsługuje dwa sklepy: meblowy i spożywczy.");
            Console.WriteLine("Którego z nich dotyczą zakupy? Wybierz odpowiedni klawisz i naciśnij \"enter\"");
            Console.WriteLine("Jeśli meblowego, wciśnij M, jeśli spożywczego, wciśnij S.");
            Zacznij();
        }

        public static void Zacznij()
        {
            char[] ktSkl = { 'M', 'm', 'S', 's' };
            bool czyPoprawny = false;
            while (!czyPoprawny)
            {
                czyPoprawny = true;
                try
                {
                    ktorySklep = Convert.ToChar(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Wystąpił błąd przy pobieraniu klawisza.");
                    czyPoprawny = false;
                }
                if (!ktSkl.Contains(ktorySklep))
                    czyPoprawny = false;
            }
            Console.Clear();

            if (ktorySklep == 's' || ktorySklep == 'S')
            {
                Console.WriteLine("Witamy w sklepie spożywczym \"Smakosz\".\n");
            }

            else if (ktorySklep == 'm' || ktorySklep == 'M')
            {
                Console.WriteLine("Witamy w sklepie meblowym \"Furniturama\".\n");
            }
            WykonajDzialanie();

        }

        private static void WczytajKlawisz()
        {
            Console.WriteLine("Co chcesz zrobić? Naciśnij odpowiedni klawisz.");
            Console.WriteLine("Legenda:");
            Console.WriteLine("P - dodaj produkt do koszyka");
            Console.WriteLine("K - skopiuj ostatnio wprowadzony produkt");
            Console.WriteLine("Z - pokaż zawartość koszyka");
            Console.WriteLine("S - pokaż sumę do zapłaty");
            Console.WriteLine("X - skasuj produkt z listy (musisz znać wcześniej numer na liście");
            Console.WriteLine("W - wydrukuj paragon");
            Console.WriteLine("N - dodaj nowy koszyk");
            Console.WriteLine("E - zakończ działanie programu");

            char[] wybor = { 'P', 'p', 'K', 'k', 'Z', 'z', 'S', 's', 'X', 'x', 'W', 'w', 'N', 'n', 'E', 'e' };
            bool czyPoprawny = false;

            while (!czyPoprawny)
            {
                czyPoprawny = true;

                try
                {
                    Console.Write(": :: :");
                    klawisz = Convert.ToChar(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Wystąpił błąd przy pobieraniu klawisza.");
                    czyPoprawny = false;
                }
                if (!wybor.Contains(klawisz))
                    czyPoprawny = false;
            }
            Console.Clear();
        }


        public static void WykonajDzialanie()
        {
            while (true)
            {
                WczytajKlawisz();
                char decyzja = 't';
                switch (klawisz)
                {
                    case 'P':
                    case 'p': do
                        {
                            Zakupy.Dodaj(); Console.WriteLine("Czy dodać następny produkt?");
                            Console.WriteLine("Jeśli nie, wciśnij n, jeśli tak, wciśnij t.");
                            decyzja = Convert.ToChar(Console.ReadLine());
                        } while (decyzja != 'n'); Continue();
                        break;

                    case 'K':
                    case 'k': Zakupy.Clone(); Continue(); break;

                    case 'Z':
                    case 'z': Zakupy.WypiszKoszyk(); Continue(); break;

                    case 'S':
                    case 's': Console.WriteLine("W sumie do zapłaty: " + Zakupy.PodajSume()); Continue(); break;

                    case 'X':
                    case 'x': Console.WriteLine("Podaj numer pozycji do skasowania."); Zakupy.SkasujProdukt(); Continue(); break;

                    case 'W':
                    case 'w': Zakupy.ZapiszParagon(); Console.WriteLine("Paragon został zapisany."); Continue(); break;

                    case 'N':
                    case 'n': Zakupy.Wyczysc(); Console.WriteLine("Koszyk został wyczyszczony."); Continue(); break;

                    case 'E':
                    case 'e': return;
                }
            }
        }

        private static void Continue()
        {
            Console.WriteLine("\nWciśnij dowolny klawisz, aby kontynuować.");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
