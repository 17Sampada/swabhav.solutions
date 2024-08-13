using GuitarOOAD.Models;

namespace GuitarOOAD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            InitializeInventory(inventory);



            GuitarSpec whatErinLikes = new GuitarSpec(Builder.Fender, "Stratocastor", Models.Type.Electric, 6, Wood.Alder, Wood.Alder);
            List<Guitar> matchingGuitars = inventory.Search(whatErinLikes);

            if (matchingGuitars.Count > 0)
            {

                Console.WriteLine("Erin, you might like these guitars:\n");
                foreach (Guitar guitar in matchingGuitars)
                {
                    GuitarSpec spec = guitar.Spec;
                    Console.WriteLine($"We have a {spec.Builder} {spec.Model} {spec.Type} guitar: \n" +
                                      $"{spec.BackWood} back and sides, \n{spec.TopWood} top. \nYou can have it for only ${guitar.Price}\n");
                }
            }
            else
            {
                Console.WriteLine("Sorry, Erin, we have nothing for you.");
            }
        }

        private static void InitializeInventory(Inventory inventory)
        {
            inventory.AddGuitar(new Guitar("v95693", 1499.95, new GuitarSpec(Builder.Fender, "Stratocastor", Models.Type.Electric, 6, Wood.Alder, Wood.Alder)));
        }
    }
}
