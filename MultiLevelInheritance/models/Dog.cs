using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLevelInheritance.models
{
    internal class Dog : Mammal
    {
        
            public void Bark()
            {
                Console.WriteLine("Dog is barking.");
            }
        
    }
}
