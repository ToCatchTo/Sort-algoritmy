using System;
using System.Collections.Generic;

namespace Merge_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadejte délku řady:");
            string length = Console.ReadLine();

            //Vytvoří list a rnd generator
            List<int> rada = new List<int>();
            List<int> tmpRada = new List<int>();
            Random rnd = new Random();

            //Naplní list
            for (int i = 0; i < Convert.ToInt32(length); i++)
            {
                int rndNumber = rnd.Next(-20, 21);
                rada.Add(rndNumber);
            }

            for (int i = 0; i < Convert.ToInt32(length); i++)
            {
                tmpRada.Add(0);
            }

            //Konvertuje list na pole
            int[] a = rada.ToArray();

            //Vypíše nesetřízené pole
            for (int h = 0; h < a.Length; h++)
            {
                Console.Write(a[h] + " ");
            }
            Console.ReadLine();

            MergeSort(a);
        }

        public static void Merge(int[] list, int[] left, int[] right)
        {
            int i = 0; // index levého pole
            int j = 0; // index pravého pole

            while ((i < left.Length) && (j < right.Length)) // procházíme do té doby, než dojdeme na konec jednoho z polí
            {
                if (left[i] < right[j]) // pokud je levý prvek menší, dá se do výsledného pole levý prvek
                {
                    list[i + j] = left[i];
                    i++;
                }
                else // pokud je pravý prvek menší, dá se do výsledného pole pravý prvek
                {
                    list[i + j] = right[j];
                    j++;
                }
            }

            if (i < left.Length) // jestli jedna půlka byla větší než ta druhá tak zbyde poslední prvek
            {
                while (i < left.Length)
                {
                    list[i + j] = left[i];
                    i++;
                }
            }
            else
            {
                while (j < right.Length)
                {
                    list[i + j] = right[j];
                    j++;
                }
            }

            for (int h = 0; h < list.Length; h++)
            {
                if (h == 0)
                    Console.WriteLine("Proběhlo spojení:");
                Console.Write(list[h] + " ");
            }
            Console.ReadLine();
        }

        public static void MergeSort(int[] list)
        {
            for (int h = 0; h < list.Length; h++)
            {
                Console.Write(list[h] + " ");
            }
            Console.ReadLine();
            if (list.Length <= 1) //pole musí být delší než 1, aby dalo třídit
                return;
            int center = list.Length / 2; //určíme si střed pole, díky kterému mužeme pole rozdělit
            int[] left = new int[center]; //levá část se vytvoří a naplní
            for (int i = 0; i < center; i++)
                left[i] = list[i];
            int[] right = new int[list.Length - center]; //pravá část se vytvoří a naplní
            for (int i = center; i < list.Length; i++)
                right[i - center] = list[i];
            MergeSort(left); // pomocí rekurze tak budeme rozdělovat vzniklá pole dál a dál až do samotných prvků
            MergeSort(right);
            Merge(list, left, right); //nakonec se pole postupně spojí a setřídí
        }
    }
}
