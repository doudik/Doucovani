using System;
using System.Collections.Generic;
using System.Text;

namespace Hodina01
{
    class Sibenice
    {
        Random rnd = new Random();
        string[] slova = { "Zdeněk", "Kuba", "Martin", "Dominik", "Laura", "Kolotoč", "Alabama", "Adam", "LoLko", "Hodiny" };
        char[] podtrzitka;
        char[] hadaneSlovo;
        int chyba = 0;
        bool masCoHadat = true;

        void NaplPolePodtrzitkama() {
            string nahodneSlovo = slova[rnd.Next(0, slova.Length - 1)].ToLower();
            podtrzitka = new char[nahodneSlovo.Length];
            hadaneSlovo = new char[nahodneSlovo.Length];
            hadaneSlovo = nahodneSlovo.ToCharArray();
            for (int i = 0; i < nahodneSlovo.Length; i++)
            {
                podtrzitka[i] = '_';
            }
            
        }
        void VypisPole() {
            Console.Clear();
            for (int i = 0; i < podtrzitka.Length; i++)
            {
                Console.Write(podtrzitka[i] + " ");
            };
            Console.WriteLine("\nPočet Chyb: {0}", chyba);

            
        }
        void Kontrola(char c) {
            bool uhodl = false;
            int tmp = 0;
            for (int i = 0; i < hadaneSlovo.Length; i++)
            {
                if (c == hadaneSlovo[i])
                {
                    tmp++;
                    uhodl = true;
                    podtrzitka[i] = c;
                }
            }
            if (uhodl == false) {
                chyba++;
                if (chyba == 10) {
                    Console.WriteLine("GAME OVER");
                    masCoHadat = false;
                }
            }
            if (tmp == hadaneSlovo.Length) {
                Console.WriteLine("VÝHRA!");
                masCoHadat = false;
            }
        }
        char Vstup()
        {
            Vstup:
            try
            {
                Console.WriteLine("Zadejte písmenko: ");
                char vstup = char.Parse(Console.ReadLine().ToLower());
                return vstup;
            }
            catch {
                goto Vstup;
            }
            
        }

        public void Rozcestnik() {
            NaplPolePodtrzitkama();
            while (masCoHadat) {
                VypisPole();
                Kontrola(Vstup());
            }
        }
    }
}
