using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductApp.Models;

namespace ProductApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //product 1
            Product_class product1 = new Product_class(1,"book", 50,0.1);
            /*product1.Id=1;
            product1.Name="Book";
            product1.Price=50;
            product1.DiscountPercent=20;*/

            //product 2
            Product_class product2 = new Product_class(2,"bag", 5000,0.3);
           /* product1.Id=2;
            product1.Name="Bag";
            product1.Price=5000;
            product1.DiscountPercent=33;*/

            PrintProductDetails(product1);
            Console.WriteLine("-----------------------------------------");
            PrintProductDetails( product2);

            
        }
        
        static void PrintProductDetails(Product_class product)
        {
            Console.WriteLine($" Product ID: {product.Id}\n" +
                $"Product Name: {product.Name}\n" +
                $"Product Price: {product.Price}\n" +
                $"Product Discount: {product.DiscountPercent}\n" +
                $"Product Cost after discount: {product.CalculateDiscount()}");
                
                     
        }


    }
}
