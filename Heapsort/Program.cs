using System;
using System.Collections.Generic;

namespace Heapsort
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

            Heapsort(a);
        }

        //umisti nejvetsi cislo nahoru
        public static void FindRoot(int[] list, int i) //predam list a index ktery znaci jeste nezhaldovana cisla
        {
            int son = i; //ulozi index syna
            int father, temp; // vytvori otce a pomocne cislo
            while (son != 0) // index syna nesmi byt zaporny
            {
                father = (son - 1) / 2; //index otce spocitam pomoci vzorecku
                if (list[father] < list[son]) // když je otec mensi než syn, tak se musí prohodit platí otec > syn
                { 
                    temp = list[father]; //prohozeni syna s otcem, stejne 3 radky prohození jako v ostatních algoritmech pomocí pomocneho cisla
                    list[father] = list[son];
                    list[son] = temp;
                    son = father; //opravy syna
                }
                else
                    return; //jestli je vsechno jak ma jde dal
            }
        }

        //presunuti rootu dolu
        public static void MoveRootDown(int[] list, int last)
        {
            int father = 0; 
            int son, temp;
            while (father * 2 + 1 <= last)
            {
                son = father * 2 + 1; // index syna spocitam pomoci dalsiho vzorecku(index praveho syna = (father * 2) + 2)
                //v pripade ze se vezme mensi syn z dvojice
                if ((son < last) && (list[son] < list[son + 1]))
                    son++; //vybereme toho vetsiho
                if (list[father] < list[son]) // kdyz je otec mensi nez syn tak si prohodi pozice
                { 
                    temp = list[father]; //prohozeni syna s otcem
                    list[father] = list[son];
                    list[son] = temp;
                    father = son; //oprava otce
                }
                else
                    return;
            }
        }

        // postaveni haldy z pole
        public static void Heapify(int[] list)
        {
            for (int i = 1; i < list.Length; i++) //postFindRootne se predane pole halduje
                FindRoot(list, i);
        }

        public static void Swap(int[] list, int temp, int index)
        {
            temp = list[0]; 
            list[0] = list[index];
            list[index] = temp;
        }

        // samotne trideni
        public static void Heapsort(int[] list)
        {
            Heapify(list); // pole se zhalduje
            int index = list.Length - 1; // vezme se posledni prvek
            int temp = 0; // pomocne cislo
            while (index > 0) // index nesmi byt zaporny
            {
                Swap(list, temp, index);
                index -= 1; //nastaveni noveho posledniho prvku
                MoveRootDown(list, index); // root se presune dolu a pomoci radku nad timto tak je potom ignorovan
                for (int h = 0; h < list.Length; h++)
                {
                    Console.Write(list[h] + " ");
                }
                Console.ReadLine();
            }
        }
    }
}
