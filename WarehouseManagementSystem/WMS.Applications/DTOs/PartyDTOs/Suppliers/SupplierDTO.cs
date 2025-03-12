namespace WMS.Application.DTOs.PartyDTOs
{
    public class SupplierDTO
    {
        public string SupplierId { get; set; }

        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string ContactDetails { get; set; }

        public SupplierDTO(string supplierId, string supplierName, string address, string contactDetails)
        {
            SupplierId = supplierId;
            SupplierName = supplierName;
            Address = address;
            ContactDetails = contactDetails;
        }

    }
}
