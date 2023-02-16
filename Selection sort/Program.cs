using System;
using System.Collections.Generic;

namespace sortování
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dostane délku od uživatele
            Console.WriteLine("Zadejte délku řady:");
            string length = Console.ReadLine();

            //Vytvoří list a rnd generator
            List<int> rada = new List<int>();
            Random rnd = new Random();

            //Naplní list
            for (int i = 0; i < Convert.ToInt32(length); i++)
            {
                int rndNumber = rnd.Next(-20, 21);
                rada.Add(rndNumber);
            }

            //Konvertuje list na pole
            int[] a = rada.ToArray();

            //Vypíše nesetřízené pole
            for (int h = 0; h < a.Length; h++)
            {
                Console.Write(a[h] + " ");
            }
            Console.ReadLine();

            //První loop, prochází pole
            for (int i = 0; i < a.Length - 1; i++)
            {
                //Dáme do minima první číslo, aby bylo s čím pracovat
                int jMin = i;

                //Druhý loop, prochází a porovnává
                for (int j = i + 1; j < a.Length; j++)
                {
                    //Podmínka když je něco menší
                    if (a[j] < a[jMin])
                    {
                        jMin = j;
                    }
                }

                //Vymění nejmenší číslo s minulým nejmenším číslem pomocí pomocného temp
                int temp = a[jMin];
                a[jMin] = a[i];
                a[i] = temp;

                //Pokaždé vypíše změnu
                for (int h = 0; h < a.Length; h++)
                {
                    if(h <= i || (h <= i + 1 && h == a.Length - 1))
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(a[h] + " ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(a[h] + " ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                Console.ReadLine();
            }
        }
    }
}
