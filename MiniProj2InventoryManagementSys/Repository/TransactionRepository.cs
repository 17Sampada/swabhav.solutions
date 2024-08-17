using IMiniProj2InventoryManagementSys.Exceptions;
using MiniProj2InventoryManagementSys.DataFolder;
using MiniProj2InventoryManagementSys.Exceptions;
using MiniProj2InventoryManagementSys.Models;

namespace MiniProj2InventoryManagementSys.Repository
{
    internal class TransactionRepository
    {
        private readonly InventoryContext _context;
        public TransactionRepository(InventoryContext inventoryContext)
        {
            _context = inventoryContext;
        }

        public Product GetProductById(int id, int inventoryId)
        {
            return _context.Products.Where(x => x.ProductId == id && x.InventoryId == inventoryId).FirstOrDefault();
        }

        public void Add(int id, int quantity, int inventoryId)
        {
            var product = GetProductById(id, inventoryId);
            product.ProductQuantity += quantity;
            var transaction = new Transaction
            {
                ProductId = id,
                Type = "Add Stock",
                TransactionQuantity = quantity,
                TransactionDate = DateOnly.FromDateTime(DateTime.Now),
                InventoryId = inventoryId
            };
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public void Remove(int id, int quantity, int inventoryId)
        {
            var product = GetProductById(id, inventoryId);
            product.ProductQuantity -= quantity;
            var transaction = new Transaction
            {
                ProductId = id,
                Type = "Remove Stock",
                TransactionQuantity = quantity,
                TransactionDate = DateOnly.FromDateTime(DateTime.Now),
                InventoryId = inventoryId
            };
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }
        public List<Transaction> ViewHistory(int id, int inventoryId)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                throw new ProductDoesNotExistException("Product doesn't exist!!\n" +
                    "............................................................................................");
            }
            var transactions = _context.Transactions.Where(t => t.ProductId == id && t.InventoryId == inventoryId).OrderBy(t => t.TransactionDate).ToList();
            if (transactions.Count == 0)
            {
                throw new NoTransactionFoundException("No transactions found!!\n" +
                    "............................................................................................");
            }
            return transactions;
        }


        public bool CheckInventoryIdExists(int id)
        {
            var checkInventory = _context.Inventories.Where(x => x.InventoryId == id).FirstOrDefault();
            return checkInventory == null;
        }
    }
}
