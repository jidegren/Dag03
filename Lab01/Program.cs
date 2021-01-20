using System;

namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Skriv in ett tal mellan 1-100 ");
            string input = Console.ReadLine();
            try
            {
            int i = int.Parse(input);
            if (i >= 1 && i <= 100)
            {
                do
                {
                    Console.WriteLine(i);
                    i++;
                } while (i != 101);
            }

            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("ArgumentNullExeception");
            }
            catch (FormatException)
            {
                Console.WriteLine("FormatException");
            }
            catch (OverflowException)
            {
                Console.WriteLine("OverflowException");
            }
            finally
            {
                Console.WriteLine("Detta kommer alltid köras");
            }
        }
    }
}
