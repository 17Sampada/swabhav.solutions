using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLevelInheritance.models
{
    internal class Mammal: Animal
    {
        public void Walk()
        {
            Console.WriteLine("Mammal is walking.");
        }
    }
}
