using TictTacToe.Enums;
using TictTacToe.Models;

namespace TictTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player("Allen", MarkType.X);
            Player player2 = new Player("Mark", MarkType.O);


            Board board = new Board();


            Game game = new Game(player1, player2, board);


            game.PlayGame();

        }
    }
}
