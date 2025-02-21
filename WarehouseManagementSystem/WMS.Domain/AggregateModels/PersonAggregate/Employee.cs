namespace WMS.Domain.AggregateModels.PersonAggregate
{
    public class Employee : Entity, IAggregateRoot
    { 
        public string employeeId { get; set; }
        public string employeeName { get; set; }
        public EmployeeType role { get; set; }
    }
}
