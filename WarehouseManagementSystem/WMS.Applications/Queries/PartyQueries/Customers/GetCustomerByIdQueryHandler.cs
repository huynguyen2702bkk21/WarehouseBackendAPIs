namespace WMS.Application.Queries.PartyQueries.Customers
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDTO>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerById(request.CustomerId);
            if (customer == null)
            {
                throw new EntityNotFoundException(nameof(Customer),request.CustomerId);
            }

            var customerDTO =  _mapper.Map<CustomerDTO>(customer);

            return customerDTO;
        }



    }
}
