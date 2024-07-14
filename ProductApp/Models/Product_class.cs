using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Models
{
    internal class Product_class
    {

        /*public int Id { get; set; } // auto properties

        public string Name { get; set; }

        public int Price { get; set; }

        public double DiscountPercent { get; set; }*/

        private int _id; string _name; double _price; double _discountPercentage;

        public int Id { get; set; }
            //set { _id = value; } get { return _id; } }

        public string Name {set {  _name = value; } get { return _name; } }

        public double Price { set { _price = value; } get { return _price; } }

        public double DiscountPercent
        {
            set
            {
                if (value > 0.4)
                    _discountPercentage = 0.4;
                else if (value < 0.2)
                    _discountPercentage = 0.2;
                else
                    _discountPercentage = value;

            }

            get { return _discountPercentage; }
        }

        public Product_class() //default constructor----> parameterless 
        {
            Console.WriteLine("welcome");

        }

        public Product_class(int id, string name, double price, double discountPercentage):this() // this() calls the default constructor first and then the cureent constructor executes
        {
            
            Id = id;
            Name = name;
            Price = price;
            DiscountPercent = discountPercentage;
        }

        public double CalculateDiscount()
        {
            return _price - _price * DiscountPercent / 100;
           

        }


    }
}
