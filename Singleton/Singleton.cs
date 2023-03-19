using System;

namespace Singleton
{
    public static class Singleton<T> where T : new()
    {
        //private static Singleton<T> instance;
        private static T instance = new T();

        public static Klasa1 k1 = new Klasa1();

        public static T Instance { get => instance; }
    }

    public class Klasa1
    {
        public int iter;
        static int _iter = 0;
        public Klasa1()
        {
            Console.WriteLine("klasa 1 konstruktor");
            _iter++;
            iter = _iter;
        }
    }

    public class klasa2
    {
        public int iter;
        static int _iter = 0;
        public klasa2()
        {
            Console.WriteLine("klasa 2 konstruktor");
            _iter++;
            iter = _iter;
        }
    }
}

