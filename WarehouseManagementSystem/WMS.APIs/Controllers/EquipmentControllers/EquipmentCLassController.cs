namespace WMS.APIs.Controllers.EquipmentControllers
{
    [ApiController]
    [Route("WarehouseAPI/[controller]")]
    public class EquipmentCLassController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public EquipmentCLassController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllEquipmentClasses")]
        public async Task<IEnumerable<EquipmentCLassDTO>> GetAllEquipmentClasses()
        {
            var query = new GetAllEquipmentCLassesQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetEquipmentClassById/{EquipmentClassId}")]
        public async Task<EquipmentCLassDTO> GetEquipmentClassById(string EquipmentClassId)
        {
            var query = new GetEquipmentCLassByIdQuery(EquipmentClassId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetAllEquipmentClassProperties")]
        public async Task<IEnumerable<EquipmentCLassPropertyDTO>> GetAllEquipmentClassProperties()
        {
            var query = new GetAllEquipmentCLassPropertiesQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetEquipmentClassPropertyById/{equipmentClassPropertyId}")]
        public async Task<EquipmentCLassPropertyDTO> GetEquipmentClassPropertyById(string equipmentClassPropertyId)
        {
            var query = new GetEquipmentCLassPropertyByIdQuery(equipmentClassPropertyId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpPost("CreateEquipmentClassProperty")]
        public async Task<IActionResult> CreateEquipmentClassProperty([FromBody] CreateEquipmentClassPropertyCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpPost("CreateEquipmentCLass")]
        public async Task<IActionResult> CreateEquipmentCLass([FromBody] CreateEquipmentCLassCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpDelete("DeleteEquipmentClassProperty/{equipmentClassPropertyId}")]
        public async Task<IActionResult> DeleteEquipmentClassProperty(string equipmentClassPropertyId)
        {
            var command = new DeleteEquipmentClassPropertyCommand(equipmentClassPropertyId);
            return await CommandAsync(command);
        }

        [HttpDelete("DeleteEquipmentClass/{EquipmentClassId}")]
        public async Task<IActionResult> DeleteEquipmentClass(string EquipmentClassId)
        {
            var command = new DeleteEquipmentCLassCommand(EquipmentClassId);
            return await CommandAsync(command);
        }

        [HttpPut("UpdateEquipmentClassProperty")]
        public async Task<IActionResult> UpdateEquipmentClassProperty([FromBody] UpdateEquipmentClassPropertyCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpPut("UpdateEquipmentClass")]
        public async Task<IActionResult> UpdateEquipmentClass([FromBody] UpdateEquipmentCLassCommand command)
        {
            return await CommandAsync(command);
        }


    }
}
