using System;
using System.Collections.Generic;

namespace lab02
{
    class Program
    {
        static double saldo = 0;
        static bool active = true;
        static List<string> historik = new List<string>();
        static void Main(string[] args)
        {
            while (active)
            {
                Menu();
            }
        }

        private static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Tryck I för insättning");
            Console.WriteLine("Tryck U för uttag");
            Console.WriteLine("Tryck S för saldo");
            Console.WriteLine("Tryck A för avsluta");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.I:
                    Insattning();
                    break;

                case ConsoleKey.U:
                    Console.WriteLine("Du har gjort en insättning");
                    break;
                case ConsoleKey.S:
                    Console.WriteLine("Här är ditt saldo");
                    visaSaldoHistorik();
                    Console.ReadLine();
                    break;
                case ConsoleKey.A:
                default:
                    active = false;
                    break;
            }
        }

        private static void visaSaldoHistorik()
        {
            Console.WriteLine(saldo);
        }

        private static void Insattning()
        {
            Console.WriteLine("Hur mycket vill du sätta in");
            string input = Console.ReadLine();
            try
            {
            double insattning = int.Parse(input);
            saldo += insattning;
            }
            catch (Exception)
            {
                Console.WriteLine("Något gick fel");                
            }
        }


    }
}
