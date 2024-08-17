namespace MiniProj2InventoryManagementSys.Exceptions
{
    internal class InsufficientProductStockException : Exception
    {
        public InsufficientProductStockException(string message) : base(message) { }
    }
}
