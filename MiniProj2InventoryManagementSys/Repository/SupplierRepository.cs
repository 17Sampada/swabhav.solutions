using MiniProj2InventoryManagementSys.DataFolder;
using MiniProj2InventoryManagementSys.Models;

namespace MiniProj2InventoryManagementSys.Repository
{
    internal class SupplierRepository
    {


        private readonly InventoryContext _context;

        public SupplierRepository(InventoryContext context)
        {
            _context = context;
        }

        public List<Supplier> GetAll()
        {
            return _context.Suppliers.ToList();

        }
        public void Add(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

        }

        public void Update(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            _context.SaveChanges();
        }

        public void Delete(Supplier supplier)
        {
            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();

        }
        public Supplier CheckSupplierNameExists(string supplierName)
        {
            var checkSupplier = _context.Suppliers.Where(x => x.SupplierName == supplierName).FirstOrDefault();
            return checkSupplier;
        }

        public bool CheckInventoryIdExists(int id)
        {
            var checkInventory = _context.Inventories.Where(x => x.InventoryId == id).FirstOrDefault();
            return checkInventory == null;
        }



    }
}
