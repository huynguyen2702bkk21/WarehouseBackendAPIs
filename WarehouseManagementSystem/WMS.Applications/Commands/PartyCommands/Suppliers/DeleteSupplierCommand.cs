namespace WMS.Application.Commands.PartyCommands.Suppliers
{
    public class DeleteSupplierCommand : IRequest<bool>
    {
        public string SupplierId { get; set; }

        public DeleteSupplierCommand(string supplierId)
        {
            SupplierId = supplierId;
        }
    }
}
