namespace WMS.Domain.AggregateModels.PartyAggregate.People
{
    public class PersonProperty : Entity, IAggregateRoot
    {
        [Key]
        public string propertyId { get; set; }

        public string propertyName { get; set; }
        public string propertyValue { get; set; }
        public UnitOfMeasure unitOfMeasure { get; set; }

        [ForeignKey("personId")]
        public string personId { get; set; }
        public Person person { get; set; }

        public PersonProperty(string propertyId, string propertyName, string propertyValue, UnitOfMeasure unitOfMeasure, string personId)
        {
            this.propertyId = propertyId;
            this.propertyName = propertyName;
            this.propertyValue = propertyValue;
            this.unitOfMeasure = unitOfMeasure;
            this.personId = personId;
        }

        public void Update(string propertyName, string propertyValue, UnitOfMeasure unitOfMeasure)
        {
            this.propertyName = propertyName;
            this.propertyValue = propertyValue;
            this.unitOfMeasure = unitOfMeasure;
        }


    }
}
