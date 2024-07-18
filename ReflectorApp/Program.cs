using ReflectorApp.models;

namespace ReflectorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reflector.ShowDetails(typeof(Account));

            Console.WriteLine();

            
            Reflector.ShowDetails(typeof(Customer));
        }
    }
}
