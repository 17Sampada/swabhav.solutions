using IMiniProj2InventoryManagementSys.Exceptions;
using MiniProj2InventoryManagementSys.DataFolder;
using MiniProj2InventoryManagementSys.Exceptions;
using MiniProj2InventoryManagementSys.Models;
using MiniProj2InventoryManagementSys.Repository;

namespace MiniProj2InventoryManagementSys.ViewControllers
{
    internal class ProductStore
    {
        private static readonly ProductRepository _productRepository = new ProductRepository(new InventoryContext());

        public static void DisplayProductMenu()
        {


            while (true)
            {
                Console.WriteLine("---------------------Welcome to Product Management App-------------------");
                Console.WriteLine($"What do u want to do?\n" +
                    $"1.Add a Product\n" +
                    $"2.Update a product\n" +
                    $"3.Delete a product\n" +
                    $"4.Find product by Id\n" +
                    $"5.Display all product\n" +
                    $"6.Go Back to main menu\n" +
                    $"Enter your choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                try
                {
                    DoTask(choice);
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


        }

        static void DoTask(int choice)
        {

            switch (choice)
            {
                case 1:
                    AddProduct();
                    break;
                case 2:
                    UpdateProduct();
                    break;
                case 3:
                    DeleteProduct();

                    break;
                case 4:
                    FindProduct();
                    break;
                case 5:
                    DisplayProducts();
                    break;
                case 6:
                    OuterMenu.DisplayMainMenu();
                    break;
                default:
                    Console.WriteLine("Please enter valid input");
                    break;


            }
        }

        static void AddProduct()
        {
            int inventoryId = TakeInventoryId();
            Console.WriteLine("Enter Product Name:");
            string name = Console.ReadLine();
            if (_productRepository.CheckProductNameExists(name) != null)
            {
                throw new ProductNameAlreadyExistsException("Product with the given name already exists!!\n" +
                "-----------------------------------------------------------");
            }
            Console.WriteLine("Enter Product Description:");
            string description = (Console.ReadLine());
            Console.WriteLine("Enter Product Quantity:");
            int quantity = Convert.ToInt32((Console.ReadLine()));
            Console.WriteLine("Enter Product Price:");
            double price = Convert.ToInt32((Console.ReadLine()));
            _productRepository.AddNewProduct(new Product() { ProductName = name, ProductDescription = description, ProductQuantity = quantity, ProductPrice = price });

            Console.WriteLine("Product added successfully");


        }

        static void UpdateProduct()
        {
            int inventoryId = TakeInventoryId();
            Console.WriteLine("Enter the Current Product Name: ");
            string currentName = Console.ReadLine();
            var existingProduct = _productRepository.CheckProductNameExists(currentName);
            if (existingProduct == null)
            {
                throw new ProductDoesNotExistException("Product with given Current Name doesn't exist!!\n" +
                    "------------------------------------------------------------");
            }
            Console.WriteLine("Enter the New Product Name: ");
            string newName = Console.ReadLine();
            if (_productRepository.CheckProductNameExists(newName) != null)
            {
                throw new ProductNameAlreadyExistsException("Product with the given New Name already exists!!\n" +
                "------------------------------------------------------------------");
            }
            Console.WriteLine("Enter the New Product Description: ");
            string newDescription = Console.ReadLine();
            Console.WriteLine("Enter the New Product Price: ");
            int newPrice = Convert.ToInt32(Console.ReadLine());

            existingProduct.ProductName = newName;
            existingProduct.ProductDescription = newDescription;
            existingProduct.ProductPrice = newPrice;
            _productRepository.Update(existingProduct);
            Console.WriteLine("Product Name Updated Successfully..\n" +
                "---------------------------------------------------------------------");
        }

        static void DeleteProduct()
        {
            int inventoryId = TakeInventoryId();
            Console.WriteLine("Enter Product Name: ");
            string productName = Console.ReadLine();
            var existingProduct = _productRepository.CheckProductNameExists(productName);
            if (existingProduct == null)
            {
                throw new ProductDoesNotExistException("Product with given Name doesn't exist!!\n" +
                    "------------------------------------------------------------------");
            }
            _productRepository.Delete(existingProduct);
            Console.WriteLine("Product Deleted Successfully..\n" +
                "----------------------------------------------------------------------");
        }

        static void FindProduct()
        {
            int inventoryId = TakeInventoryId();
            Console.WriteLine("Enter Product Name: ");
            string productName = Console.ReadLine();
            var existingProduct = _productRepository.CheckProductNameExists(productName);
            if (existingProduct == null)
            {
                throw new ProductDoesNotExistException("Product with given Name doesn't exist!!\n" +
                    "-------------------------------------------------------------------");
            }
            Console.WriteLine(existingProduct);
            Console.WriteLine("---------------------------------------------------------");

        }
        static void DisplayProducts()
        {
            int inventoryId = TakeInventoryId();
            var products = _productRepository.GetAll();
            if (products.Count == 0)
            {
                throw new ProductDoesNotExistException("No products found!!\n" +
                    "--------------------------------------------------------------------");
            }
            Console.WriteLine("                 Products List                     \n" +
                "--------------------------------------------------------------------");
            products.ForEach(product => Console.WriteLine(product));
            Console.WriteLine("-----------------------------------------------------------------");

        }

        static int TakeInventoryId()
        {
            Console.WriteLine("Enter Inventory Id: ");
            int inventoryId = Convert.ToInt32(Console.ReadLine());
            if (_productRepository.CheckInventoryIdExists(inventoryId))
            {
                throw new InventoryDoesNotExistsException("Inventory with given Id doesn't exist!!\n" +
                "-----------------------------------------------------------------");
            }
            return inventoryId;
        }
    }
}

