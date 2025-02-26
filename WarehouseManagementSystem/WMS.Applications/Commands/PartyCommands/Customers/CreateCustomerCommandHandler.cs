namespace WMS.Application.Commands.PartyCommands.Customers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerById(request.CustomerId);
            if (customer != null)
            {
                throw new DuplicateRecordException("Customers", request.CustomerId);
            }

            var newCustomer = new Customer(customerId: request.CustomerId,
                                           customerName: request.CustomerName,
                                           address: request.Address,
                                           contactDetails: request.ContactDetails);

            _customerRepository.Create(newCustomer);

            return await _customerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }
    }
}
