using System;
using System.Collections.Generic;
using AVLTree;
using Drzewa;

namespace TestDrzewa
{
    class Program
    {
        
        static void Main(string[] args)
        {


            AVL<int> avl = new();
                  
            for (int i = 1; i < 10; i++)
            {
                avl.Add(i);
            }
            avl.DisplayTree();
            Console.WriteLine(avl.Remove(1));
            Console.WriteLine(avl.Remove(0));
            avl.DisplayTree();
            for (int i = -1; i > -10; i--)
            {
                avl.Add(i);
            }
            avl.DisplayTree();

            return;
  

            //DrzewoBinarne<string> imiona = new DrzewoBinarne<string>();
            //imiona.Wstaw("Wojtek");
            //imiona.Wstaw("Zosia");
            //imiona.Wstaw("Piotr");
            //imiona.Wstaw("Karol");
            //imiona.Wstaw("Anna");
            //foreach (string s in imiona.ZamienNaTablice())
            //{
            //    Console.Write("{0}, ",s);
            //}
            //Console.Write("\nPodaj imie: ");
            //string im = Console.ReadLine();
            //if (imiona.Wyszukaj(im))
            //{
            //    Console.WriteLine("Podene imie znajduje się na liście");
            //}
            //else
            //{
            //    Console.WriteLine("Podanego imienia nie ma na liście");
            //}

            //DrzewoBinarne<int> numery = new DrzewoBinarne<int>();
            //numery.Wstaw(11);
            //numery.Wstaw(6);
            //numery.Wstaw(21);
            //numery.Wstaw(55);
            //numery.Wstaw(14);
            //numery.Wstaw(9);
            //foreach (int i in numery.ZamienNaTablice())
            //{
            //    Console.Write("{0}, ", i);
            //}
            //Console.Write("\nPodaj numer: ");
            //int num = int.Parse(Console.ReadLine());
            //if (numery.Wyszukaj(num))
            //{
            //    Console.WriteLine("Podany numer znajduje się na liście");
            //}
            //else
            //{
            //    Console.WriteLine("Podanego numeru nie ma na liście");
            //}
        }
    }
}
