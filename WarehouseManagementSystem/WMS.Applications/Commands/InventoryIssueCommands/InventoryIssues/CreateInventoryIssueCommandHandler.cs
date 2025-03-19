namespace WMS.Application.Commands.InventoryIssueCommands.InventoryIssues
{
    public class CreateInventoryIssueCommandHandler : IRequestHandler<CreateInventoryIssueCommand, bool>
    {
        private readonly IInventoryIssueRepository _inventoryIssueRepository;
        private readonly IPersonRepository _personRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IIssueServices _issueServices;

        public CreateInventoryIssueCommandHandler(IInventoryIssueRepository inventoryIssueRepository, IPersonRepository personRepository, ICustomerRepository customerRepository, IWarehouseRepository warehouseRepository, IIssueServices issueServices)
        {
            _inventoryIssueRepository = inventoryIssueRepository;
            _personRepository = personRepository;
            _customerRepository = customerRepository;
            _warehouseRepository = warehouseRepository;
            _issueServices = issueServices;
        }

        public async Task<bool> Handle(CreateInventoryIssueCommand request, CancellationToken cancellationToken)
        {
            var inventoryIssue = await _inventoryIssueRepository.GetByIdAsync(request.InventoryIssueId);
            if (inventoryIssue != null)
            {
                throw new DuplicateRecordException(nameof(InventoryIssue), request.InventoryIssueId);
            }

            var customer = await _customerRepository.GetCustomerById(request.CustomerId);
            if (customer == null)
            {
                throw new EntityNotFoundException(nameof(Customer), request.CustomerId);
            }

            var person = await _personRepository.GetPersonById(request.PersonId);
            if (person == null)
            {
                throw new EntityNotFoundException(nameof(Person), request.PersonId);
            }

            var warehouse = await _warehouseRepository.GetWarehouseById(request.WarehouseId);
            if (warehouse == null)
            {
                throw new EntityNotFoundException(nameof(Warehouse), request.WarehouseId);
            }

            var newInventoryIssue = await _issueServices.CreateNewInventoryIssue(request);

            await _issueServices.UpdateMaterialLot(newInventoryIssue);

            _inventoryIssueRepository.Create(newInventoryIssue);

            return await _inventoryIssueRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }

    }
}
