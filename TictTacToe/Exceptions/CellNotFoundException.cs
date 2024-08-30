namespace TTictTacToe.Exceptions
{
    internal class CellNotFoundException : Exception
    {
        public CellNotFoundException(string message) : base(message) { }
    }
}
