namespace WMS.APIs.Controllers.EquipmentControllers
{
    [ApiController]
    [Route("WarehouseAPI/[controller]")]
    public class EquipmentController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public EquipmentController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllEquipmentProperties")]
        public async Task<IEnumerable<EquipmentPropertyDTO>> GetAllEquipmentProperties()
        {
            var query = new GetAllEquipmentPropertiesQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetEquipmentPropertyById/{equipmentPropertyId}")]
        public async Task<EquipmentPropertyDTO> GetEquipmentPropertyById(string equipmentPropertyId)
        {
            var query = new GetEquipmentPropertyByIdQuery(equipmentPropertyId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetAllEquipments")]
        public async Task<IEnumerable<EquipmentDTO>> GetAllEquipments()
        {
            var query = new GetAllEquipmentsQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetEquipmentById/{equipmentId}")]
        public async Task<EquipmentDTO> GetEquipmentById(string equipmentId)
        {
            var query = new GetEquipmentByIdQuery(equipmentId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpPost("CreateEquipment")]
        public async Task<IActionResult> CreateEquipment([FromBody] CreateEquipmentCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpPost("CreateEquipmentProperty")]
        public async Task<IActionResult> CreateEquipmentProperty([FromBody] CreateEquipmentPropertyCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpPut("UpdateEquipmentProperty")]
        public async Task<IActionResult> UpdateEquipmentProperty([FromBody] UpdateEquipmentPropertyCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpPut("UpdateEquipment")]
        public async Task<IActionResult> UpdateEquipment([FromBody] UpdateEquipmentCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpDelete("DeleteEquipmentProperty/{equipmentPropertyId}")]
        public async Task<IActionResult> DeleteEquipmentProperty(string equipmentPropertyId)
        {
            var command = new DeleteEquipmentPropertyCommand(equipmentPropertyId);
            return await CommandAsync(command);
        }

        [HttpDelete("DeleteEquipment/{equipmentId}")]
        public async Task<IActionResult> DeleteEquipment(string equipmentId)
        {
            var command = new DeleteEquipmentCommand(equipmentId);
            return await CommandAsync(command);
        }

    }
}
