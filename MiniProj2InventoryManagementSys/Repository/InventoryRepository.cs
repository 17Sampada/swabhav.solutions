using Microsoft.EntityFrameworkCore;
using MiniProj2InventoryManagementSys.DataFolder;
using MiniProj2InventoryManagementSys.Models;

namespace MiniProj2InventoryManagementSys.Repository
{
    internal class InventoryRepository
    {
        private readonly InventoryContext _context;

        public InventoryRepository(InventoryContext inventoryContext)
        {
            _context = inventoryContext;
        }

        public List<Inventory> GetAll()
        {
            return _context.Inventories
                .Include(inventory => inventory.Products)
                .Include(inventory => inventory.Suppliers)
                .Include(inventory => inventory.Transactions)
                .ToList();
        }
    }
}
