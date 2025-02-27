using WMS.Application.Commands.StorageCommands.Locations;
using WMS.Application.Queries.StorageQueries.Locations;

namespace WMS.APIs.Controllers.StorageControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public LocationController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Locations/GetAll")]
        public async Task<IEnumerable<LocationDTO>> GetAll()
        {
            var query = new GetAllLocationQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("Locations/GetByLocationId")]
        public async Task<LocationDTO> GetById(string id)
        {
            var query = new GetLocationByIdQuery(id);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("Locations/GetByWarehouseId")]
        public async Task<IEnumerable<LocationDTO>> GetByWarehouseId(string warehouseId)
        {
            var query = new GetLocationsByWarehouseIdQuery(warehouseId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpPost("Locations/Create New Location")]
        public async Task<IActionResult> Create([FromBody] CreateLocationCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpDelete("Locations/Delete Location/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var command = new DeleteLocationCommand(id);

            return await CommandAsync(command);
        }

        [HttpPut("Locations/Update Location")]
        public async Task<IActionResult> Update([FromBody] UpdateLocationCommand command)
        {
            return await CommandAsync(command);
        }

    }
}
