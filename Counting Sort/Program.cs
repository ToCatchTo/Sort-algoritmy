using System;
using System.Collections.Generic;

namespace Counting_sort
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
            Console.WriteLine("Nesetříděné pole:");
            for (int h = 0; h < a.Length; h++)
            {
                Console.Write(a[h] + " ");
            }
            Console.ReadLine();

            //Zavolám sortící metodu, kterou si dám do proměnné finalArray
            int[] finalArray =  CountingSort(a);

            // Vypíše výsledné pole
            Console.WriteLine("Setříděné pole:");
            for (int h = 0; h < finalArray.Length; h++)
            {
                Console.Write(finalArray[h] + " ");
            }
            Console.ReadLine();
        }

        public static int[] CountingSort(int[] array) // předá se pole k setřízení
        {
            // výsledné pole, do kterého přidáváme setřízené prvky
            int[] aux = new int[array.Length];

            // definujeme si libovolné max a min
            int min = array[0];
            int max = array[0];
            for (int i = 1; i < array.Length; i++) // projdeme pole a najdeme max a min v poli
            {
                if (array[i] < min) min = array[i];
                else if (array[i] > max) max = array[i];
            }

            // vytvoříme si indexové pole
            int[] counts = new int[max - min + 1]; // délka je max - min + 1 jelikož je min záporné tak se z mínusu stane plus

            // projdeme předané pole a naplníme si indexové pole
            for (int i = 0; i < array.Length; i++)
            {
                counts[array[i] - min]++;
            }

            Console.WriteLine("Indexové pole před sčítaním:");
            for (int h = 0; h < counts.Length; h++)
            {
                Console.Write(counts[h] + " ");
            }
            Console.ReadLine();

            counts[0]--; // Hlídá aby jsme neskončili na erroru s překročením hranice pole (IndexOutOfRange)
            for (int i = 1; i < counts.Length; i++) // cyklus projde indexové pole a sčíta vždy aktuální prvek s předchozím
            {
                counts[i] = counts[i] + counts[i - 1];
            }

            Console.WriteLine("Indexové pole po sčítaním:");
            for (int h = 0; h < counts.Length; h++)
            {
                Console.Write(counts[h] + " ");
            }
            Console.ReadLine();

            for (int i = array.Length - 1; i >= 0; i--) // projde předané pole a hodnoty do výsledného pole předá pomocí indexového pole
            {
                aux[counts[array[i] - min]--] = array[i];
            }

            return aux; // vrátí výsledné pole
        }
    }
}
