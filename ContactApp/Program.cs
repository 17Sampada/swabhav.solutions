using ContactApp.Repositories;
using ContactApp.View_Controller;

namespace ContactApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserRepository userRepository = new UserRepository();
            ContactRepository contactRepository = new ContactRepository();
            ContactDetailsRepository contactDetailsRepository = new ContactDetailsRepository();

            AdminMenu adminMenu = new AdminMenu(userRepository);
            ContactMenu contactMenu = new ContactMenu(contactRepository);
            ContactDetailsMenu contactDetailsMenu = new ContactDetailsMenu(contactDetailsRepository, contactRepository);
            StaffMenu staffMenu = new StaffMenu(contactMenu, contactDetailsMenu);

            while (true)
            {

                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("        Welcome to Contact App          ");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("\nPlease enter your User ID:");
                int userId = Convert.ToInt32(Console.ReadLine());

                var user = userRepository.GetUserById(userId);
                if (user == null)
                {
                    Console.WriteLine("\nUser not found. Please try again.");

                }

                if (!user.IsActive)
                {
                    Console.WriteLine("\nUser is inactive and cannot perform any operations.");

                }



                Console.WriteLine($"\n        Welcome, {user.FName} {user.LName}          \n");


                if (user.IsAdmin)
                {
                    adminMenu.DisplayMenu();
                }
                else
                {
                    staffMenu.DisplayMenu();
                }
            }
        }
    }

}
