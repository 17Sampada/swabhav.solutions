using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProj2InventoryManagementSys.Models
{
    internal class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        public Product ProDuctId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public string Type { get; set; }

        public int TransactionQuantity { get; set; }

        public DateOnly TransactionDate { get; set; }

        public Inventory Inventory { get; set; }

        [ForeignKey("Inventory")]
        public int? InventoryId { get; set; }

        public Transaction()
        {

        }
        public Transaction(int id, int productid, string type, int quantity, DateOnly date, int inventoryid)
        {
            TransactionId = id;
            ProductId = productid;
            Type = type;
            TransactionQuantity = quantity;
            TransactionDate = date;
            InventoryId = inventoryid;
        }

        public override string ToString()
        {
            return $"Inventory Id: {InventoryId}\n" +
                $"Transaction Id: {TransactionId}\n" +
                $"Product Id: {ProductId}\n" +
                $"Transaction Type: {Type}\n" +
                $"Quantity: {TransactionQuantity}\n" +
                $"Date: {TransactionDate}\n";
        }
    }
}
