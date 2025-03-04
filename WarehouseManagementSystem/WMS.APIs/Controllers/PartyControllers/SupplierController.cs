namespace WMS.APIs.Controllers.PartyControllers
{
    [ApiController]
    [Route("WarehouseAPI/[controller]")]
    public class SupplierController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public SupplierController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllSupplier")]
        public async Task<IEnumerable<SupplierDTO>> GetAll()
        {
            var query = new GetAllSupplierQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetSupplierById")]
        public async Task<SupplierDTO> GetById(string id)
        {
            var query = new GetSupplierByIdQuery(id);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpPost("Create New Supplier")]
        public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpDelete("Delete Supplier/{id}")]
        public async Task<IActionResult> DeleteSupplier(string id)
        {
            var request = new DeleteSupplierCommand(id);

            return await CommandAsync(request);
        }

        [HttpPut("Update Supplier")]
        public async Task<IActionResult> UpdateSupplier([FromBody] UpdateSupplierCommand command)
        {
            return await CommandAsync(command);
        }

    }
}
