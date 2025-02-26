namespace WMS.Application.Commands.PartyCommands.Customers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerById(request.CustomerId);
            if (customer == null)
            {
                throw new EntityNotFoundException("Customers", request.CustomerId);
            }

            customer.UpdateCustomer(customerName: request.CustomerName, 
                                    address: request.Address, 
                                    contactDetails: request.ContactDetails);

            _customerRepository.Update(customer);

            return await _customerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            

        }
    }
}
