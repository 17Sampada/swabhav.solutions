using MiniProj2InventoryManagementSys.ViewControllers;
namespace MiniProj2InventoryManagementSys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                OuterMenu.DisplayMainMenu();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

        }
    }
}
