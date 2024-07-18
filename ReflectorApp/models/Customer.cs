using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectorApp.models
{
    internal class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static int CountCustomer { get; set; }

        static Customer()
        {
            Console.WriteLine("Static consructor called");
            CountCustomer = 0;

        }

        public Customer()
        {
            Console.WriteLine("object created");
            CountCustomer++;
        }

        public void PlaceOrder() { }
        public void CancelOrder() { }
    }
}
