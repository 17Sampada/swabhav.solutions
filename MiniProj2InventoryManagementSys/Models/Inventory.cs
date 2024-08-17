using System.ComponentModel.DataAnnotations;

namespace MiniProj2InventoryManagementSys.Models
{
    internal class Inventory
    {
        [Key]
        public int InventoryId { get; set; }
        public string InventoryBranchName { get; set; }
        public List<Product> Products { get; set; }

        public List<Supplier> Suppliers { get; set; }

        public List<Transaction> Transactions { get; set; }

        public override string ToString()
        {
            return $"Inventory Id: {InventoryId}\n" +
                $"Branch Name: {InventoryBranchName}\n";
        }
    }
}
