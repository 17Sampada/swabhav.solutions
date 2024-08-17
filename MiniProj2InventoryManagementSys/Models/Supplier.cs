using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProj2InventoryManagementSys.Models
{
    internal class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }

        public string SupplierContactInfo { get; set; }

        public Inventory Inventory { get; set; }


        [ForeignKey("Inventory")]
        public int? InventoryId { get; set; }

        public Supplier()
        {

        }

        public Supplier(int supplierid, string suppliername, string suppliercontactinfo, int inventoryid)
        {
            SupplierId = supplierid;
            SupplierName = suppliername;
            SupplierContactInfo = suppliercontactinfo;
            InventoryId = inventoryid;
        }



        public override string ToString()
        {
            return $"Inventory Id: {InventoryId}\n" +
                $"Supplier id:{SupplierId}\n" +
                $"Supplier name:{SupplierName}\n" +
                $"Supplier Contact Information: {SupplierContactInfo}\n" +

                $"---------------------";
        }
    }
}
