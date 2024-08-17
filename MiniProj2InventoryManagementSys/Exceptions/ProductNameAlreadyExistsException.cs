namespace MiniProj2InventoryManagementSys.Exceptions
{
    internal class ProductNameAlreadyExistsException : Exception
    {
        public ProductNameAlreadyExistsException(string message) : base(message) { }
    }
}
