namespace ContactApp.View_Controller
{
    internal class StaffMenu
    {
        private readonly ContactMenu _contactMenu;
        private readonly ContactDetailsMenu _contactDetailsMenu;

        public StaffMenu(ContactMenu contactMenu, ContactDetailsMenu contactDetailsMenu)
        {
            _contactMenu = contactMenu;
            _contactDetailsMenu = contactDetailsMenu;
        }

        public void DisplayMenu()
        {
            while (true)
            {

                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("            Staff Menu                  ");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("1. Work on Contacts");
                Console.WriteLine("2. Work on Contact Details");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        _contactMenu.DisplayMenu();
                        break;
                    case 2:
                        _contactDetailsMenu.DisplayMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
