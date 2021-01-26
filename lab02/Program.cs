using System;
using System.Collections.Generic;

namespace lab02
{
    class Program
    {
        static double saldo = 0;
        static bool keepGoing = true;
        static string[] kontotransaktioner = new string[3];
        static int totalaTransaktioner = 0;
        static int size = kontotransaktioner.Length;
        static void Main(string[] args)
        {
            while (keepGoing)
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
                    Uttag();
                    Console.WriteLine("Du har gjort ett uttag");
                    break;
                case ConsoleKey.S:
                    Console.Write("Här är ditt saldo: ");
                    Console.WriteLine(saldo);
                    VisaSaldoHistorik();
                    Console.ReadLine();
                    break;
                case ConsoleKey.A:
                default:
                    keepGoing = false;
                    break;
            }
        }

        private static void Uttag()
        {
            Console.WriteLine("Du har valt Uttag:");
            Console.Write("Hur mycket vill du ta ut: ");
            string input = Console.ReadLine();
            string kontohändelse = SkapaKontohändelse(input, "-");
            try
            {

                // 100kr vill plocka ut 110

                double uttag = int.Parse(input);
                if (uttag <= saldo && uttag > 0)
                {
                    saldo -= uttag;
                    kontotransaktioner[totalaTransaktioner % size] = kontohändelse;
                    totalaTransaktioner++;
                    Console.WriteLine($"Du har gjort en insättning på {uttag}kr och ditt totala saldo efter uttaget är {saldo}kr");
                    Console.ReadKey();
                }
                else if  (uttag <= saldo && uttag > 0)
                {
                    Console.WriteLine("Du har inte tillräckligt med pengar för uttaget");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Uttaget får inte vara negativt");
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Ogiltig inmatning");
                Console.ReadKey();
            }
        }

        private static void VisaSaldoHistorik()
        {

            var tidsstämpel = totalaTransaktioner - 1 + kontotransaktioner.Length;
                                // 4                        // 3
            for (int i = 0; i < kontotransaktioner.Length; i++)
            {
                string kontohändelse = kontotransaktioner[tidsstämpel % kontotransaktioner.Length];
                tidsstämpel--;
                if (kontohändelse != null)
                {
                    Console.WriteLine(kontohändelse);
                }
            }

        }

        private static void Insattning()
        {
            Console.WriteLine("Du har valt insättning");
            Console.WriteLine("Hur mycket vill du sätta in");
            string input = Console.ReadLine();
            string kontohändelse = SkapaKontohändelse(input, "+");
            try
            {
                double insattning = int.Parse(input);
                if (insattning > 0)
                {
                    saldo += insattning;
                    kontotransaktioner[totalaTransaktioner % size] = kontohändelse;
                    totalaTransaktioner++;
                    Console.WriteLine($"Du har gjort en insättning på {insattning}kr och ditt totala saldo är {saldo}kr");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Du kan inte sätta in ett negativt tal");
                    Console.ReadKey();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ogiltig inmatning");
                Console.ReadKey();
            }

        }

        private static string SkapaKontohändelse(string input, string operand)
        {
            DateTime händelseTid = DateTime.Now;
            string uppdelare = " ";
            string kontohändelse = $"{händelseTid} {uppdelare} {operand}{input}";
            return kontohändelse;
        }
    }
}
