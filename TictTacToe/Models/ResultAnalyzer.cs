using TictTacToe.Enums;

namespace TictTacToe.Models
{
    internal class ResultAnalyzer
    {
        private Board Board { get; set; }

        private ResultType Result { get; set; }

        public ResultAnalyzer(Board board)
        {
            this.Board = board;
            Result = ResultType.PROGRESS;
        }

        public ResultType AnalyzeResult()
        {

            if (HorizontalWinCheck() || VerticalWinCheck() || DiagonalWinCheck())
            {
                return ResultType.WIN;
            }
            if (Board.IsBoardFull())
            {
                return ResultType.DRAW;
            }
            return ResultType.PROGRESS;

        }

        private bool HorizontalWinCheck()
        {

            for (int i = 0; i <= 6; i += 3)
            {
                if (Board.GetCell(i).Mark != MarkType.EMPTY &&
                    Board.GetCell(i).Mark == Board.GetCell(i + 1).Mark &&
                    Board.GetCell(i).Mark == Board.GetCell(i + 2).Mark)
                {
                    return true;
                }
            }
            return false;
        }

        private bool VerticalWinCheck()
        {

            for (int i = 0; i <= 2; i++)
            {
                if (Board.GetCell(i).Mark != MarkType.EMPTY &&
                    Board.GetCell(i).Mark == Board.GetCell(i + 3).Mark &&
                    Board.GetCell(i).Mark == Board.GetCell(i + 6).Mark)
                {
                    return true;
                }
            }
            return false;
        }

        private bool DiagonalWinCheck()
        {

            if (Board.GetCell(0).Mark != MarkType.EMPTY &&
                Board.GetCell(0).Mark == Board.GetCell(4).Mark &&
                Board.GetCell(0).Mark == Board.GetCell(8).Mark)
            {
                return true;
            }

            if (Board.GetCell(2).Mark != MarkType.EMPTY &&
                Board.GetCell(2).Mark == Board.GetCell(4).Mark &&
                Board.GetCell(2).Mark == Board.GetCell(6).Mark)
            {
                return true;
            }
            return false;
        }




    }
}
