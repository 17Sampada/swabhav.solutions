using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLevelInheritance.models
{
    internal class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Animal is eating.");
        }

        public void Sleep()
        {
            Console.WriteLine("Animal is sleeping.");
        }
    }
}
