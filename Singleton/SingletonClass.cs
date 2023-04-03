using SingletonLib;
using System;

namespace Singleton
{


    public class Klasa1 : Singleton<Klasa1>, ISingleton<Klasa1>
    {
        

        private int data;

        public int Data { get => data; set => data = value; }


        protected Klasa1()
        {

            Console.WriteLine("klasa1 create");
        }

        static Klasa1 ISingleton<Klasa1>.initilize()
        {
            throw new NotImplementedException();
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

