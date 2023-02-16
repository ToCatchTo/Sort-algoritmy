using System;
using System.Collections.Generic;

namespace Bubble_sort
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
            bool allCorrect = true;

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

            //První loop 
            for (int i = 0; i < a.Length - 1; i++)
            {
                //Druhý loop, prochází a swapuje
                for (int j = 0; j < a.Length - i - 1; j++)
                {
                    //Jestli je číslo větší další číslo menší než aktuální, prohodí se
                    if(a[j + 1] < a[j])
                    {
                        int tmp = a[j + 1];
                        a[j + 1] = a[j];
                        a[j] = tmp;

                        //Když se čísla prohodí, znamená to, že řada je stále nesetřízená
                        allCorrect = false;
                    }    
                }

                //Když je řada nesetřízená vypíše, když je setřizená nevypíše, nepotřebujeme vidět napsanou setřízenou řadu 2x
                if(allCorrect == false)
                {
                    for (int h = 0; h < a.Length; h++)
                    {
                        Console.Write(a[h] + " ");
                    }
                    Console.ReadLine();
                }

                //Když je řada setřízená předčasně ukončí program, když ne resetuje allCorrect a jde dál
                if (allCorrect == true)
                    break;
                else
                {
                    allCorrect = true;
                    continue;
                }
            }
        }
    }
}
