using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zahlenraten
{
    class Program
    {
        static void Main(string[] args)
        {
            // Computer "denkt" sich eine Zahl
            Random random = new Random();
            int computerZahl = random.Next(1, 11);

            // Benutzer hat 3 Versuche, diese zu raten
            int benutzerZahl;
            int i = 0;
            do
            {
                Console.WriteLine($"Versuch Nr. {i + 1}: Bitte rate eine Zahl:");
                benutzerZahl = Convert.ToInt32(Console.ReadLine());
                i++;

            } while (computerZahl != benutzerZahl && i<3); // "fußgesteuert"

            //while (true) // "kopfgesteuert"
            //{

            //}


            // Immer: "Die richtige Zahl war..."
            Console.WriteLine($"Die richtige Zahl war {computerZahl}.");

            Console.ReadKey();
        }

        static void ZahlenRatenFor(string[] args)
        {
            // Computer "denkt" sich eine Zahl
            Random random = new Random();
            int computerZahl = random.Next(1, 11);

            // Benutzer hat 3 Versuche, diese zu raten
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Versuch Nr. {i + 1}: Bitte rate eine Zahl:");
                int benutzerZahl = Convert.ToInt32(Console.ReadLine());
                // wenn richtig geraten: Herzlichen Glückwunsch!
                if (benutzerZahl == computerZahl)
                {
                    Console.WriteLine("Herzlichen Glückwunsch!");
                    break;
                }
            }

            // Immer: "Die richtige Zahl war..."
            Console.WriteLine($"Die richtige Zahl war {computerZahl}.");

            Console.ReadKey();
        }

        static void EvaPrinzip(string[] args)
        {
            // Eingabe
            Console.Write("Wie geht's Dir heute?");

            string antwort = Console.ReadLine();

            // Verarbeitung
            if (antwort.ToLower().Contains("gut"))
            {
                // Ausgabe
                Console.WriteLine("Prima!");
            }

            // Damit die Konsole sich nicht sofort schließt bei Programmende
            Console.ReadKey();
        }
    }
}
