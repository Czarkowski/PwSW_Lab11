using SingletonLib;
using System;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace SingletonTest
{
    public class Klasa1 : Singleton<Klasa1>, ISingleton<Klasa1>
    {
        private int data;
        public int Data { get => data; set => data = value; }
        public override string? ToString()
        {
            return string.Format("{0} :  {1}", base.ToString(), data);
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


    public class Klasa2 : ISingleton<Klasa2>
    {

        private int data;
        public int Data { get => data; set => data = value; }

        protected Klasa2()
        {
            Console.WriteLine("klasa 2 konstruktor");
        }

        static Klasa2 ISingleton<Klasa2>.initilize()
        {
            return new();
        }
    }

    public class Klasa3 : ISingleton2<Klasa3>
    {

        private int data;
        public int Data { get => data; set
            {
                Console.WriteLine("zmieniono wartość z {0} na {1}",data,value);
                data = value;
            }

        }

        public static Klasa3 Instance => ISingleton2<Klasa3>.getInstance();
        static Klasa3 ISingleton2<Klasa3>.initialize() => new();
        

        protected Klasa3()
        {
            Console.WriteLine("klasa 3 konstruktor");
        }


    }
}

