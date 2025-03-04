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

        [HttpGet("GetWarehouseById/{warehouseId}")]
        public async Task<WarehouseDTO> GetById(string warehouseId)
        {
            var query = new GetWarehouseByIdQuery(warehouseId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpPost("Create New Warehouse")]
        public async Task<IActionResult> CreateWarehouse([FromBody] CreateWarehouseCommand request)
        {
            return await CommandAsync(request);
        }

        [HttpDelete("Delete Warehouse/{warehouseId}")]
        public async Task<IActionResult> DeleteWarehouse(string warehouseId)
        {
            var request = new DeleteWarehouseCommand(warehouseId);

            return await CommandAsync(request);
        }

        [HttpPut("Update Warehouse")]
        public async Task<IActionResult> UpdateWarehouse([FromBody] UpdateWarehouseCommand request)
        {
            return await CommandAsync(request);
        }

    }
}
