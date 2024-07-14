using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace TypeCasting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            float b = a;

            Console.WriteLine(b);
            Console.WriteLine("Datatype of b: " + b.GetType());

            float x = 3.5f;
            int y = (int)x;

          
            string s = "hello";
            object obj = s;

            object obj1 = "hello";
            string s1=(string)obj;

            int i = 10;
            object obj2 = i;

            Object obj3 = 10;
            int g = (int)obj3;




        }
    }
}
