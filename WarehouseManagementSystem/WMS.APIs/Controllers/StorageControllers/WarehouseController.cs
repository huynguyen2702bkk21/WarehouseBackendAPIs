namespace WMS.APIs.Controllers.StorageControllers
{
    [ApiController]
    [Route("WarehouseAPI/[controller]")]
    public class WarehouseController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public WarehouseController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllWarehouses")]
        public async Task<IEnumerable<WarehouseDTO>> GetAll()
        {
            var query = new GetAllWarehouseQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetWarehouseById/{id}")]
        public async Task<WarehouseDTO> GetById(string id)
        {
            var query = new GetWarehouseByIdQuery(id);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpPost("Create New Warehouse")]
        public async Task<IActionResult> CreateWarehouse([FromBody] CreateWarehouseCommand request)
        {
            return await CommandAsync(request);
        }

        [HttpDelete("Delete Warehouse/{id}")]
        public async Task<IActionResult> DeleteWarehouse(string id)
        {
            var request = new DeleteWarehouseCommand(id);

            return await CommandAsync(request);
        }

        [HttpPut("Update Warehouse")]
        public async Task<IActionResult> UpdateWarehouse([FromBody] UpdateWarehouseCommand request)
        {
            return await CommandAsync(request);
        }

    }
}
