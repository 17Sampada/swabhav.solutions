namespace MiniProj2InventoryManagementSys.ViewControllers
{
    internal class OuterMenu
    {
        public static void DisplayMainMenu()
        {
            Console.WriteLine("         WELCOME TO INVENTORY MANAGEMENT SYSTEM              \n");
            while (true)
            {
                try
                {
                    Console.WriteLine("---------------------------------------------------------------------");
                    Console.WriteLine("1. Product Management\n" +
                        "2. Supplier Management\n" +
                        "3. Transaction Management\n" +
                        "4. Generate Report\n" +
                        "5. Exit\n\n" +
                        "Enter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("---------------------------------------------------------------------");

                    ChooseManagement(choice);
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }
        }
        static void ChooseManagement(int choice)
        {
            switch (choice)
            {
                case 1:
                    ProductStore.DisplayProductMenu();
                    break;
                case 2:
                    SupplierStore.DisplaySupplierMenu();
                    break;
                case 3:
                    TransactionStore.DisplayTransactionMenu();
                    break;
                case 4:
                    InventoryStore.DisplayReport();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter valid input!!\n" +
                        "---------------------------------------------------------------------");
                    break;
            }
        }
    }
}
