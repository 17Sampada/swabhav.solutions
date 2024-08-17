namespace MiniProj2InventoryManagementSys.Exceptions
{
    internal class NoTransactionFoundException : Exception
    {
        public NoTransactionFoundException(string message) : base(message) { }
    }
}
