namespace WMS.APIs.Controllers.PartyControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public SupplierController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Suppliers/GetAll")]
        public async Task<IEnumerable<SupplierDTO>> GetAll()
        {
            var query = new GetAllSupplierQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("Suppliers/GetById")]
        public async Task<SupplierDTO> GetById(string id)
        {
            var query = new GetSupplierByIdQuery(id);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpPost("Suppliers/Create New Supplier")]
        public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpDelete("Suppliers/Delete Supplier/{id}")]
        public async Task<IActionResult> DeleteSupplier(string id)
        {
            var request = new DeleteSupplierCommand(id);

            return await CommandAsync(request);
        }

        [HttpPut("Suppliers/Update Supplier")]
        public async Task<IActionResult> UpdateSupplier([FromBody] UpdateSupplierCommand command)
        {
            return await CommandAsync(command);
        }

    }
}
