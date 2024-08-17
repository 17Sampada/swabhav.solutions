using MiniProj2InventoryManagementSys.DataFolder;
using MiniProj2InventoryManagementSys.Models;

namespace MiniProj2InventoryManagementSys.Repository
{
    internal class ProductRepository

    {


        private readonly InventoryContext _context;

        public ProductRepository(InventoryContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();

        }
        public void AddNewProduct(Product product)
        {

            _context.Products.Add(product);
            _context.SaveChanges();

        }

        public void Update(Product products)
        {
            _context.Products.Update(products);
            _context.SaveChanges();
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();


        }



        public Product CheckProductNameExists(string productName)
        {
            var checkProduct = _context.Products.Where(x => x.ProductName == productName).FirstOrDefault();
            return checkProduct;
        }

        public bool CheckInventoryIdExists(int id)
        {
            var checkInventory = _context.Inventories.Where(x => x.InventoryId == id).FirstOrDefault();
            return checkInventory == null;
        }

    }
}
