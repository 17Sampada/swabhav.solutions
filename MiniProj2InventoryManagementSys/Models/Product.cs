using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProj2InventoryManagementSys.Models
{
    internal class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public int ProductQuantity { get; set; }

        public double ProductPrice { get; set; }
        public List<Transaction> Transactions { get; set; }
        public Inventory Inventory { get; set; }

        [ForeignKey("Inventory")]
        public int? InventoryId { get; set; }

        public Product()
        {

        }

        public Product(int productid, string productname, string productdescription, int productquantity, double productprice, int inventoryid)
        {
            ProductId = productid;
            ProductName = productname;
            ProductDescription = productdescription;
            ProductQuantity = productquantity;
            ProductPrice = productprice;
            InventoryId = inventoryid;

        }



        public override string ToString()
        {
            return $"Inventory Id: {InventoryId}\n" +
                $"Product id:{ProductId}\n" +
                $"Product name:{ProductName}\n" +
                $"Product Description: {ProductDescription}\n" +
                $"Product Quantity:{ProductQuantity}\n" +
                $"Product Price:{ProductPrice}\n" +
                $"---------------------";
        }
    }
}
