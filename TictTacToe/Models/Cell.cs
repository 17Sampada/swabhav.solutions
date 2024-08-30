using TictTacToe.Enums;
using TictTacToe.Exceptions;

namespace TictTacToe.Models
{
    internal class Cell
    {
        public MarkType Mark { get; private set; }

        public Cell()
        {

            Mark = MarkType.EMPTY;

        }

        public bool IsEmpty()
        {
            return Mark == MarkType.EMPTY;
        }

        public MarkType GetMark()
        {
            return Mark;

        }

        public void SetMark(MarkType mark)
        {
            if (!IsEmpty())

                throw new CellAlreadyMarkedException("This cell is already marked");

            this.Mark = mark;
        }





    }
}
