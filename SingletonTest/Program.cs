using SingletonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SingletonTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Klasa3.Instance.Data = 10;
            Klasa3 k3 = Klasa3.Instance;
            k3.Data = 20;
            
            ISingleton2<Klasa3>.getInstance();


            Klasa1 k1 = Klasa1.Instance;
            Klasa1 k2 = Klasa1.Instance;
            k2.Data = 20;
            Console.WriteLine(k1);

            
            
        }
    }
}
