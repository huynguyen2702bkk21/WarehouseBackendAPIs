namespace WMS.Application.Queries.InventoryIssueQueries.InventoryIssues
{
    public class GetInventoryIssueByIdQueryHandler : IRequestHandler<GetInventoryIssueByIdQuery, InventoryIssueDTO>
    {
        private readonly IInventoryIssueRepository _inventoryIssueRepository;
        private readonly IPersonRepository _personRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMediator _mediator;

        public GetInventoryIssueByIdQueryHandler(IInventoryIssueRepository inventoryIssueRepository, IPersonRepository personRepository, ICustomerRepository customerRepository, IWarehouseRepository warehouseRepository, IMediator mediator)
        {
            _inventoryIssueRepository = inventoryIssueRepository;
            _personRepository = personRepository;
            _customerRepository = customerRepository;
            _warehouseRepository = warehouseRepository;
            _mediator = mediator;
        }

        public async Task<InventoryIssueDTO> Handle(GetInventoryIssueByIdQuery request, CancellationToken cancellationToken)
        {
            var inventoryIssue = await _inventoryIssueRepository.GetByIdAsync(request.InventoryIssueId);
            if (inventoryIssue == null)
            {
                throw new EntityNotFoundException(nameof(InventoryIssue), request.InventoryIssueId);
            }

            var person = await _personRepository.GetPersonById(inventoryIssue.pesonId);
            if (person == null)
            {
                throw new EntityNotFoundException(nameof(Person), inventoryIssue.pesonId);
            }

            var customer = await _customerRepository.GetCustomerById(inventoryIssue.customerId);
            if (customer == null)
            {
                throw new EntityNotFoundException(nameof(Customer), inventoryIssue.customerId);
            }

            var warehouse = await _warehouseRepository.GetWarehouseById(inventoryIssue.warehouseId);
            if (warehouse == null)
            {
                throw new EntityNotFoundException(nameof(Warehouse), inventoryIssue.warehouseId);
            }

            var Entries = new List<InventoryIssueEntryDTO>();

            foreach (var inventoryIssueEntry in inventoryIssue.entries)
            {
                var inventoryIssueEntryDTO = await _mediator
                    .Send(new GetInventoryIssueEntryByIdQuery(inventoryIssueEntry.inventoryIssueEntryId));

                Entries.Add(inventoryIssueEntryDTO);
            }

            var inventoryIssueDTO = new InventoryIssueDTO(inventoryIssueId: inventoryIssue.inventoryIssueId,
                                                          issueDate: inventoryIssue.issueDate,
                                                          issueStatus: inventoryIssue.issueStatus,
                                                          customerName: customer.customerName,
                                                          personName: person.personName,
                                                          warehouseName: warehouse.warehouseName,
                                                          entries: Entries);


            return inventoryIssueDTO;


        }

    }
}
