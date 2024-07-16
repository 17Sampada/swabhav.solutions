using PlayerApp.models;

namespace PlayerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player[] players = new Player[]
            {
                new Player(101,"Sampada", 14),
                new Player(102,"Swamini",15),
                new Player(103,"Swati",16),
                new Player(104,"Aagya", 17),
                new Player(105,"Sam")

            };

            Player  eldestPlayer=Player.WhoIsElder(players);
            Console.WriteLine($"Eldest Player's details is:");
            Console.WriteLine(Player.WhoIsElder(players));


        }


    }
}
