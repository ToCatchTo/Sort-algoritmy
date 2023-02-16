using System;
using System.Collections.Generic;

namespace Insertion_sort
{
    class Program
    {
        static void Main(string[] args)
        {
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

            //Úvodní loop
            for (int i = 0; i < a.Length - 1; i++)
            {
                //index čísla, kterým se bude porovnávat
                int j = i + 1;
                //uložení čísla, kterým se bude porovnávat
                int tmp = a[j];
                //dokud číslo uložené v tmp je větší než předchozí číslo, cyklus jde dál, až když je menší tak se cyklus zastaví
                while(j > 0 && tmp > a[j - 1])
                {
                    //číslo předchozí se dá na pozici porovnívajícího čísla
                    a[j] = a[j - 1];
                    j--;
                }
                //číslo porovnávající se dá na pozici čísla předchozího
                a[j] = tmp;

                //vypíše aktuální řadu
                for (int h = 0; h < a.Length; h++)
                {
                    Console.Write(a[h] + " ");
                }
                Console.ReadLine();
            }
        }
    }
}
