using MiniProj2InventoryManagementSys.DataFolder;
using MiniProj2InventoryManagementSys.Exceptions;
using MiniProj2InventoryManagementSys.Models;
using MiniProj2InventoryManagementSys.Repository;

namespace MiniProj2InventoryManagementSys.ViewControllers
{
    internal class SupplierStore
    {
        private static readonly SupplierRepository _supplierRepository = new SupplierRepository(new InventoryContext());
        public static void DisplaySupplierMenu()
        {
            Console.WriteLine("            WELCOME TO INVENTORY MANAGEMENT SYSTEM                 \n");
            while (true)
            {
                try
                {
                    Console.WriteLine("------------------------------------------------------------------");
                    Console.WriteLine("               SUPPLIER MANAGEMENT                        ");
                    Console.WriteLine("------------------------------------------------------------------");
                    Console.WriteLine("1. Add Supplier\n" +
                        "2. Update Supplier\n" +
                        "3. Delete Supplier\n" +
                        "4. View A Supplier\n" +
                        "5. View All Suppliers\n" +
                        "6. Go Back To Main Menu\n\n" +
                        "Enter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("-------------------------------------------------------------------");
                    DoTask(choice);
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }
        }
        static void DoTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddSupplier();
                    break;
                case 2:
                    UpdateSupplier();
                    break;
                case 3:
                    DeleteSupplier();
                    break;
                case 4:
                    FindSupplier();
                    break;
                case 5:
                    ViewAllSuppliers();
                    break;
                case 6:
                    OuterMenu.DisplayMainMenu();
                    break;
                default:
                    Console.WriteLine("Please enter valid input!!\n" +
                        "............................................................................................");
                    break;
            }
        }
        static void AddSupplier()
        {
            int inventoryId = TakeInventoryId();
            Console.WriteLine("Enter Supplier's Name: ");
            string Name = Console.ReadLine();
            if (_supplierRepository.CheckSupplierNameExists(Name) != null)
            {
                throw new SupplierNameAlreadyExistsException("Supplier with the given name already exists!!\n" +
               "----------------------------------------------------------------------------------------------");
            }
            Console.WriteLine("Enter Supplier's Contact Information: ");
            string ContactInfo = Console.ReadLine();
            _supplierRepository.Add(new Supplier() { SupplierName = Name, SupplierContactInfo = ContactInfo });
            Console.WriteLine("New Supplier Added Successfully..\n" +
                "-----------------------------------------------------------------------------------------------");
        }
        static void UpdateSupplier()
        {
            int inventoryId = TakeInventoryId();
            Console.WriteLine("Enter the Current Supplier's Name: ");
            string currentName = Console.ReadLine();
            var existingSupplier = _supplierRepository.CheckSupplierNameExists(currentName);
            if (existingSupplier == null)
            {
                throw new SupplierDoesNotExistException("Supplier with given Current Name doesn't exist!!\n" +
                    "---------------------------------------------------------------------------------------");
            }
            Console.WriteLine("Enter the Supplier's New Name: ");
            string newName = Console.ReadLine();
            if (_supplierRepository.CheckSupplierNameExists(newName) != null)
            {
                throw new SupplierNameAlreadyExistsException("Supplier with the New Name already exists!!\n" +
                    "----------------------------------------------------------------------------------------");
            }
            Console.WriteLine("Enter the Supplier's New Contact Information: ");
            string newContact = Console.ReadLine();
            existingSupplier.SupplierName = newName;
            existingSupplier.SupplierContactInfo = newContact;
            _supplierRepository.Update(existingSupplier);
            Console.WriteLine("Supplier Name Updated Successfully..\n" +
                "--------------------------------------------------------------------------------------------");
        }
        static void DeleteSupplier()
        {
            int inventoryId = TakeInventoryId();
            Console.WriteLine("Enter Supplier's Name: ");
            string supplierName = Console.ReadLine();
            var existingSupplier = _supplierRepository.CheckSupplierNameExists(supplierName);
            if (existingSupplier == null)
            {
                throw new SupplierDoesNotExistException("Supplier with given Name doesn't exist!!\n" +
                    "----------------------------------------------------------------------------------------");
            }
            _supplierRepository.Delete(existingSupplier);
            Console.WriteLine("Supplier Deleted Successfully..\n" +
                   "-----------------------------------------------------------------------------------------");
        }
        static void FindSupplier()
        {
            int inventoryId = TakeInventoryId();
            Console.WriteLine("Enter Supplier's Name: ");
            string supplierName = Console.ReadLine();
            var existingSupplier = _supplierRepository.CheckSupplierNameExists(supplierName);
            if (existingSupplier == null)
            {
                throw new SupplierDoesNotExistException("Supplier with given Name doesn't exist!!\n" +
                    "----------------------------------------------------------------------------------------");
            }
            Console.WriteLine(existingSupplier);
            Console.WriteLine("----------------------------------------------------------------------------------------");

        }
        static void ViewAllSuppliers()
        {
            int inventoryId = TakeInventoryId();
            var suppliers = _supplierRepository.GetAll();
            if (suppliers.Count == 0)
            {
                throw new SupplierDoesNotExistException("No suppliers found!!\n" +
                    "----------------------------------------------------------------------------------------");
            }
            Console.WriteLine("                          Suppliers List                             \n" +
                "----------------------------------------------------------------------------------------");
            suppliers.ForEach(supplier => Console.WriteLine(supplier));
            Console.WriteLine(".----------------------------------------------------------------------------------------");
        }

        static int TakeInventoryId()
        {
            Console.WriteLine("Enter Inventory Id: ");
            int inventoryId = Convert.ToInt32(Console.ReadLine());
            if (_supplierRepository.CheckInventoryIdExists(inventoryId))
            {
                throw new InventoryDoesNotExistsException("Inventory with given Id doesn't exist!!\n" +
                "............................................................................................");
            }
            return inventoryId;
        }
    }
}

