using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Klasa1.Instance.Data = 10;
            Console.WriteLine(Klasa1.Instance);
            Klasa1 k1 = Klasa1.Instance;
            Klasa1 k2 = Klasa1.Instance;
            k2.Data = 20;
            Console.WriteLine(k1);
        }
    }
}
