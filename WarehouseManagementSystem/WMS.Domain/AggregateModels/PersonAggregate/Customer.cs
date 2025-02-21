namespace WMS.Domain.AggregateModels.PersonAggregate
{
    public class Customer : Entity, IAggregateRoot
    {
        [Key]
        public string customerId { get; set; }

        public string customerName { get; set; }
        public string address { get; set; }
        public string contactDetails { get; set; }
    }
}
