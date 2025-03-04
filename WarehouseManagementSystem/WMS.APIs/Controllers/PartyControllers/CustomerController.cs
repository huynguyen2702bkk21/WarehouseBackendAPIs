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

        [HttpGet("GetCustomerById/{id}")]
        public async Task<CustomerDTO> GetById(string id)
        {
            var query = new GetCustomerByIdQuery(id);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpPost("CreateSupplier New Customer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand request)
        {
            return await CommandAsync(request);
        }

        [HttpDelete("Delete Customer/{id}")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            var request = new DeleteCustomerCommand(id);

            return await CommandAsync(request);
        }

        [HttpPut("Update Customer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand request)
        {
            return await CommandAsync(request);
        }

    }
}
