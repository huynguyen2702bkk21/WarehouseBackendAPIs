namespace WMS.Application.Queries.InventoryIssueQueries.InventoryIssues
{
    public class GetAllInventoryIssuesQueryHandler : IRequestHandler<GetAllInventoryIssuesQuery, IEnumerable<InventoryIssueDTO>>
    {
        private readonly IInventoryIssueRepository _inventoryIssueRepository;
        private readonly IPersonRepository _personRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public GetAllInventoryIssuesQueryHandler(IInventoryIssueRepository inventoryIssueRepository, IPersonRepository personRepository, ICustomerRepository customerRepository, IWarehouseRepository warehouseRepository, IMapper mapper)
        {
            _inventoryIssueRepository = inventoryIssueRepository;
            _personRepository = personRepository;
            _customerRepository = customerRepository;
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InventoryIssueDTO>> Handle(GetAllInventoryIssuesQuery request, CancellationToken cancellationToken)
        {
            var inventoryIssues = await _inventoryIssueRepository.GetAllAsync();
            if (inventoryIssues.Count == 0)
            {
                throw new EntityNotFoundException("No inventory issues found");
            }

            var inventoryIssueDTOs = new List<InventoryIssueDTO>();

            foreach (var inventoryIssue in inventoryIssues)
            {
                var inventoryIssueDTO = _mapper.Map<InventoryIssueDTO>(inventoryIssue);

                var person = await _personRepository.GetPersonById(inventoryIssue.personId);
                if (person == null)
                {
                    throw new EntityNotFoundException(nameof(Person), inventoryIssue.personId);
                }

                var customer = await _customerRepository.GetCustomerById(inventoryIssue.customerId);
                if (customer == null)
                {
                    throw new EntityNotFoundException(nameof(Customer), inventoryIssue.customerId);
                }

                var warehouse = await _warehouseRepository.GetWarehouseById(inventoryIssue.warehouseId);
                if (warehouse == null)
                {
                    throw new EntityNotFoundException(nameof(Warehouse), inventoryIssue.personId);
                }

                inventoryIssueDTO.MapName(customer.customerName, person.personName, warehouse.warehouseName);

                inventoryIssueDTOs.Add(inventoryIssueDTO);
            }
            return inventoryIssueDTOs;
        }

    }
}
