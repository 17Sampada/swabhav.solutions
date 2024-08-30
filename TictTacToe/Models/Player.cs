using TictTacToe.Enums;

namespace TictTacToe.Models
{
    internal class Player
    {
        public string Name { get; set; }

        public MarkType Symbol { get; set; }

        public Player(string name, MarkType symbol)
        {
            Name = name;
            Symbol = symbol;

        }
    }
}
