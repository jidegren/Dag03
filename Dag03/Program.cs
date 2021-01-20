using System;
// 1. Compiler errors.
// 2. Run-time errors.
// 3. Logical errors.

namespace Dag03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vänligen mata in en nämnare: ");
            string keyboardInput = Console.ReadLine();
            int nämnare = 0;
            try
            {
                nämnare = int.Parse(keyboardInput);
                if (nämnare != 0)
                {
                    int kvot = 20 / nämnare;
                    Console.WriteLine($"{20}/{nämnare} = {kvot}");
                }
                else
                    Console.WriteLine("Du kan inte dela ett tal med 0");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Strängen har värdet null och kan inte konveteras");
            }
            catch (FormatException)
            {
                Console.WriteLine("Felaktig inmatning");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"Talet måste vara ett tal mellan {int.MaxValue} och {int.MinValue}");
            }
            catch (Exception)
            {
                Console.WriteLine("Det har uppstått oväntat fel.");
            }
            finally
            {
                Console.WriteLine("Denna kodrad kommer alltid att köra oavsett om vi får ett exveption eller inte");
            }


            //Console.Write("Skriv in ett tal mellan 1-100 ");
            //string input = Console.ReadLine();
            //int i = int.Parse(input);
            //if (i >= 1 && i <= 100)
            //{
            //do
            //{
            //    Console.WriteLine(i);
            //    i++;
            //} while (i != 101);
            //}
        }
    }
}
