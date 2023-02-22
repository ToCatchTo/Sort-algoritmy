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
            Quicksort(a);
        }

        public static int Divide(int[] list, int left, int right, int pivot) // provede rozdělení pomocí předaného pivotu
        {
            int temp = list[pivot]; // klasické prohození pomocí pomocného čísla, pivot se tak dostane na konec pole 
            list[pivot] = list[right];
            list[right] = temp;
            int i = left; // index kam se pak vrátí pivot
            for (int j = left; j < right; j++) // cyklus projde pole a určí kde bude "domov" pro pivot
            {
                if (list[j] < list[right]) // pokud je porovnávaný prvek menší než pivot tak se prohodí porovnávane číslo s číslem na pozici "domova"
                { 
                    temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                    i++; // posun index "domova"
                }
            }
            temp = list[i]; // prohozeni pivotu zpet
            list[i] = list[right];
            list[right] = temp;
            return i; // vrati novy index pivotu
        }

        public static void HalfQuicksort(int[] list, int left, int right) // použije quicksort na 2 pole, které vznikly po Divide a rekurzivně znova dokud to jde
        {
            if (right >= left) //kontroluje jestli je něco k setřízení, pokud ano může proběhnout rekurze
            {
                int pivot = left; // určí se pivot
                int new_pivot = Divide(list, left, right, pivot); // new_pivot je index, kam se vrátil pivot po Divide
                HalfQuicksort(list, left, new_pivot - 1); // pomocí rekurze zavolá na vzniklou levou část 
                HalfQuicksort(list, new_pivot + 1, right); // pomocí rekurze zavolá na vzniklou pravou část 
            }

        }

        public static void Quicksort(int[] list) // použije quicksort na celé pole
        {
            HalfQuicksort(list, 0, list.Length - 1);
            for (int h = 0; h < list.Length; h++)
            {
                Console.Write(list[h] + " ");
            }
            Console.ReadLine();
        }
    }
}
