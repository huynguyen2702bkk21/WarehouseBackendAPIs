namespace WMS.Domain.AggregateModels.PersonAggregate
{
    public class Supplier : Entity, IAggregateRoot  
    {
        public string supplierId { get; set; }
        public string supplierName { get; set; }
        public string address { get; set; }
        public string contactDetails { get; set; }
    }
}
