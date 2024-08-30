using TictTacToe.Enums;
using TTictTacToe.Exceptions;

namespace TictTacToe.Models
{
    internal class Board
    {
        private Cell[] cells = new Cell[9];



        public Board()
        {
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i] = new Cell();
            }
        }



        public Cell GetCell(int loc)
        {
            if (loc < 0 || loc >= cells.Length)
            {
                throw new CellNotFoundException("Invalid cell index. Please provide a valid index between 0 and 8.");
            }
            return cells[loc];
        }


        public bool IsBoardFull()
        {
            foreach (var cell in cells)
            {
                if (cell.IsEmpty())
                {
                    return false;
                }
            }
            return true;
        }

        public void SetCellMark(int loc, MarkType mark)
        {
            cells[loc].SetMark(mark);
        }





    }
}
