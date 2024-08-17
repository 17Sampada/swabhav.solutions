namespace IMiniProj2InventoryManagementSys.Exceptions
{
    internal class ProductDoesNotExistException : Exception
    {
        public ProductDoesNotExistException(string message) : base(message) { }
    }
}
