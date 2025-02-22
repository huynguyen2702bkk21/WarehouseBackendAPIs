namespace WMS.Domain.AggregateModels.PartyAggregate
{
    public class Customer : Entity, IAggregateRoot
    {
        [Key]
        public string customerId { get; set; }

        public string customerName { get; set; }
        public string address { get; set; }
        public string contactDetails { get; set; }
        public List<InventoryIssue> inventoryIssues { get; set; }


    }
}
