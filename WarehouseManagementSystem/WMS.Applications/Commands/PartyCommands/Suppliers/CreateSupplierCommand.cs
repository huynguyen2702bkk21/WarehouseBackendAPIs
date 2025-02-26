namespace WMS.Application.Commands.PartyCommands.Suppliers
{
    public class CreateSupplierCommand : IRequest<bool>
    {
        public string SupplierId { get; set; }

        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string ContactDetails { get; set; }

        public CreateSupplierCommand(string supplierId, string supplierName, string address, string contactDetails)
        {
            SupplierId = supplierId;
            SupplierName = supplierName;
            Address = address;
            ContactDetails = contactDetails;
        }
    }
}
