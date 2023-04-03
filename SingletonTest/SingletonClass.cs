using SingletonLib;
using System;

namespace SingletonTest
{
    public class Klasa1 : Singleton<Klasa1>, ISingleton<Klasa1>
    {
        private int data;
        public int Data { get => data; set => data = value; }
        public override string? ToString()
        {
            return string.Format("{0} :  {1}",base.ToString(), data);
        }

        protected Klasa1()
        {
            Console.WriteLine("klasa1 create");
        }
        static Klasa1 ISingleton<Klasa1>.initilize()
        {
            return new();
        }
    }

    //public class Klasa2 : Singleton<Klasa2>
    //{

    //    public int iter;
    //    static int _iter = 0;
    //    public Klasa2()
    //    {
    //        Console.WriteLine("klasa 2 konstruktor");
    //        _iter++;
    //        iter = _iter;
    //    }


    //}
}

