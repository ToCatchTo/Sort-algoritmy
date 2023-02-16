using System;
using System.Collections.Generic;

namespace Quick_sort
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

            //Zavolám sortící metodu
            Quicksort(a, 0, a.Length);
        }

        public static void Quicksort(int[] array, int left, int right) //předávám pole, index prvního, index posledního
        {
            if (left < right) // 
            {
                int boundary = left; // 
                for (int i = left + 1; i < right; i++)
                {
                    if (array[i] > array[left])
                    {
                        Swap(array, i, ++boundary);
                    }
                }
                Swap(array, left, boundary);

                for (int h = 0; h < array.Length; h++)
                {
                    Console.Write(array[h] + " ");
                }
                Console.ReadLine();

                Quicksort(array, left, boundary);
                Quicksort(array, boundary + 1, right);
            }
        }

        /**
         * Prohodi prvky v zadanem poli
         * @param array pole
         * @param left prvek 1
         * @param right prvek 2
         */
        private static void Swap(int[] array, int left, int right)
        {
            int tmp = array[right];
            array[right] = array[left];
            array[left] = tmp;
        }
    }
}
