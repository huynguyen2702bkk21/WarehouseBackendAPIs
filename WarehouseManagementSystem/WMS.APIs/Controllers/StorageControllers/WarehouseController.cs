using WMS.Application.Commands.StorageCommands.Warehouses;
using WMS.Application.Queries.StorageQueries.Warehouses;

namespace WMS.APIs.Controllers.StorageControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public WarehouseController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Warehouses/GetAll")]
        public async Task<IEnumerable<WarehouseDTO>> GetAll()
        {
            var query = new GetAllWarehouseQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("Warehouses/GetById/{id}")]
        public async Task<WarehouseDTO> GetById(string id)
        {
            var query = new GetWarehouseByIdQuery(id);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpPost("Warehouses/Create New Warehouse")]
        public async Task<IActionResult> CreateWarehouse([FromBody] CreateWarehouseCommand request)
        {
            return await CommandAsync(request);
        }

        [HttpDelete("Warehouses/Delete Warehouse/{id}")]
        public async Task<IActionResult> DeleteWarehouse(string id)
        {
            var request = new DeleteWarehouseCommand(id);

            return await CommandAsync(request);
        }

        [HttpPut("Warehouses/Update Warehouse")]
        public async Task<IActionResult> UpdateWarehouse([FromBody] UpdateWarehouseCommand request)
        {
            return await CommandAsync(request);
        }

    }
}
