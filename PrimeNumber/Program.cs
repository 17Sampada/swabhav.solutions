using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number, a = 0;
            Console.WriteLine("Number to be checked:");
            number = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    a++;
                }
            }
            if (a == 2)
            {
                Console.WriteLine("It is a Prime Number");
            }
            else
            {
                Console.WriteLine("Not a Prime Number");
            }
        }
    }
}
