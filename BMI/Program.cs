using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMI.Models;

namespace BMI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person(1, "Sampada", 22, 1.75, 50);
            Person person2 = new Person(2, "Swamini", 21);

            Console.WriteLine(person1);
            Console.WriteLine(person2);


        }
    }
}
