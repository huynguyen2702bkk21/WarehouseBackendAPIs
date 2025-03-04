namespace WMS.APIs.Controllers.StorageControllers
{
    [ApiController]
    [Route("WarehouseAPI/[controller]")]
    public class LocationController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public LocationController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllLocations")]
        public async Task<IEnumerable<LocationDTO>> GetAll()
        {
            var query = new GetAllLocationQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetLocationById/{locationId}")]
        public async Task<LocationDTO> GetById(string locationId)
        {
            var query = new GetLocationByIdQuery(locationId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetLocationsByWarehouseId/{warehouseId}")]
        public async Task<IEnumerable<LocationDTO>> GetByWarehouseId(string warehouseId)
        {
            var query = new GetLocationsByWarehouseIdQuery(warehouseId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpPost("Create New Location")]
        public async Task<IActionResult> Create([FromBody] CreateLocationCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpDelete("Delete Location/{locationId}")]
        public async Task<IActionResult> Delete(string locationId)
        {
            var command = new DeleteLocationCommand(locationId);

            return await CommandAsync(command);
        }

        [HttpPut("Update Location")]
        public async Task<IActionResult> Update([FromBody] UpdateLocationCommand command)
        {
            return await CommandAsync(command);
        }

    }
}
