namespace WMS.APIs.Controllers.MaterialControllers
{
    [ApiController]
    [Route("WarehouseAPI/[controller]")]
    public class MaterialClassController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public MaterialClassController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllMaterialClass")]
        public async Task<IEnumerable<MaterialClassDTO>> GetAll()
        {
            var query = new GetALlMaterialClassesQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetAllProperties")]
        public async Task<IEnumerable<MaterialClassPropertyDTO>> GetAllProperties()
        {
            var query = new GetAllMaterialClassPropertiesQuerry();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetMaterialClassById/{materialClassId}")]
        public async Task<MaterialClassDTO> GetById(string materialClassId)
        {
            var query = new GetMaterialClassByIdQuery(materialClassId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetMaterialClassPropertyById/{materialClassPropertyId}")]
        public async Task<MaterialClassPropertyDTO> GetPropertyById(string materialClassPropertyId)
        {
            var query = new GetMaterialClassPropertyByIdQuerry(materialClassPropertyId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpPost("CreateMaterialClass")]
        public async Task<IActionResult> CreateMaterialClass([FromBody] CreateMaterialClassCommand command)
        {
            return await CommandAsync(command);
        }
        
        [HttpPost("CreateMaterialClassProperty")]
        public async Task<IActionResult> CreateMaterialClassProperty([FromBody] CreateMaterialClassPropertyCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpDelete("DeleteMaterialClass/{materialClassId}")]
        public async Task<IActionResult> DeleteMaterialClass(string materialClassId)
        {
            var command = new DeleteMaterialClassCommand(materialClassId);
            return await CommandAsync(command);
        }

        [HttpDelete("DeleteMaterialClassProperty/{materialClassPropertyId}")]
        public async Task<IActionResult> DeleteMaterialClassProperty(string materialClassPropertyId)
        {
            var command = new DeleteMaterialClassPropertyCommand(materialClassPropertyId);
            return await CommandAsync(command);
        }

        [HttpPut("UpdateMaterialClass")]
        public async Task<IActionResult> UpdateMaterialClass([FromBody] UpdateMaterialClassCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpPut("UpdateMaterialClassProperty")]
        public async Task<IActionResult> UpdateMaterialClassProperty([FromBody] UpdateMaterialClassPropertyCommand command)
        {
            return await CommandAsync(command);
        }

    }
}
