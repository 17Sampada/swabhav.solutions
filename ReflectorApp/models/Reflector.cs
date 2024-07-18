using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectorApp.models
{
    internal class Reflector
    {
        public static void ShowDetails(Type type)
        {

            int methodCount = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).Length;

            int constructorCount = type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).Length;
            
            int propertyCount = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).Length;
       
            Console.WriteLine($"Type: {type.Name}");
            Console.WriteLine($"Number of methods: {methodCount}");
            Console.WriteLine($"Number of constructors: {constructorCount}");
            Console.WriteLine($"Number of properties: {propertyCount}");
        }
    }
}
