namespace WMS.APIs.Controllers.PartyControllers
{
    [ApiController]
    [Route("WarehouseAPI/[controller]")]
    public class CustomerController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllCustomers")]
        public async Task<IEnumerable<CustomerDTO>> GetAll()
        {
            var query = new GetAllCustomersQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetCustomerById/{customerId}")]
        public async Task<CustomerDTO> GetById(string customerId)
        {
            var query = new GetCustomerByIdQuery(customerId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpPost("CreateSupplier New Customer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand request)
        {
            return await CommandAsync(request);
        }

        [HttpDelete("Delete Customer/{customerId}")]
        public async Task<IActionResult> DeleteCustomer(string customerId)
        {
            var request = new DeleteCustomerCommand(customerId);

            return await CommandAsync(request);
        }

        [HttpPut("Update Customer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand request)
        {
            return await CommandAsync(request);
        }

    }
}
