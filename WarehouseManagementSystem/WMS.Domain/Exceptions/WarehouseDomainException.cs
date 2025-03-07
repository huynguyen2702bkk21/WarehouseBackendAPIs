namespace WMS.Domain.Exceptions
{
    public class WarehouseDomainException : Exception
    {
        public WarehouseDomainException() { }
        public WarehouseDomainException(string message) : base(message)
        {

        }
    }
}
