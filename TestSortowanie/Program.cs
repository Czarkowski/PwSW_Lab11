﻿using Sortowanie;
using System;

namespace TestSortowanie
{
    class Osoba
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            double[] tab1 = { 22.3, 3.5, 1, 7.8, 6.5 };
            string[] imiona = { "Paweł", "Ania", "Karol", "Piotr" };
            SortowanieStogowe.Sortuj(tab1);
            SortowanieStogowe.Sortuj(imiona);

            Console.Write("Imiona: ");
            foreach (string s in imiona)
            {
                Console.Write("{0}, ",s);
            }

            Console.Write("\nLiczby: ");
            foreach (double x in tab1)
            {
                Console.Write("{0}, ",x);
            }

            Osoba[] osoby =
            {
                new Osoba{Imie="Jan",Nazwisko="Kowalski" },
                new Osoba{Imie="Tomasz", Nazwisko="Nowal"},
                new Osoba{Imie="Marek",Nazwisko="Markowski"}
            };
            //SortowanieStogowe.Sortuj<Osoba>(osoby);
            Console.Read();
        }
    }
}
