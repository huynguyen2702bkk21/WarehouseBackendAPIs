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

        [HttpGet("GetSupplierById/{supplierId}")]
        public async Task<SupplierDTO> GetById(string supplierId)
        {
            var query = new GetSupplierByIdQuery(supplierId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpPost("Create New Supplier")]
        public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpDelete("Delete Supplier/{supplierId}")]
        public async Task<IActionResult> DeleteSupplier(string supplierId)
        {
            var request = new DeleteSupplierCommand(supplierId);

            return await CommandAsync(request);
        }

        [HttpPut("Update Supplier")]
        public async Task<IActionResult> UpdateSupplier([FromBody] UpdateSupplierCommand command)
        {
            return await CommandAsync(command);
        }

    }
}
