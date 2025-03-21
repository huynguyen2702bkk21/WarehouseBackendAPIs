namespace WMS.APIs.Controllers.MaterialControllers
{
    [ApiController]
    [Route("WarehouseAPI/[controller]")]
    public class MaterialController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public MaterialController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllMaterialProperties")]
        public async Task<IEnumerable<MaterialPropertyDTO>> GetAllProperties()
        {
            var query = new GetAllMaterialPropertiesQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetAllMaterials")]
        public async Task<IEnumerable<MaterialDTO>> GetAll()
        {
            var query = new GetAllMaterialQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetMaterialById/{materialId}")]
        public async Task<MaterialDTO> GetById(string materialId)
        {
            var query = new GetMaterialByIdQuery(materialId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetMaterialPropertyById/{propertyId}")]
        public async Task<MaterialPropertyDTO> GetPropertyById(string propertyId)
        {
            var query = new GetMaterialPropertyByIdQuery(propertyId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetMaterialsByClassIdQuery/{classId}")]
        public async Task<IEnumerable<MaterialDTO>> GetMaterialsByClassId(string classId)
        {
            var query = new GetMaterialsByClassIdQuery(classId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpPost("CreateMaterial")]
        public async Task<IActionResult> CreateMaterial([FromBody] CreateMaterialCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpPost("CreateMaterialProperty")]
        public async Task<IActionResult> CreateMaterialProperty([FromBody] CreateMaterialPropertyCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpDelete("DeleteMaterial/{materialId}")]
        public async Task<IActionResult> DeleteMaterial(string materialId)
        {
            var command = new DeleteMaterialCommand(materialId);
            return await CommandAsync(command);
        }

        [HttpDelete("DeleteMaterialProperty/{propertyId}")]
        public async Task<IActionResult> DeleteMaterialProperty(string propertyId)
        {
            var command = new DeleteMaterialPropertyCommand(propertyId);
            return await CommandAsync(command);
        }

        [HttpPut("UpdateMaterial")]
        public async Task<IActionResult> UpdateMaterial([FromBody] UpdateMaterialCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpPut("UpdateMaterialProperty")]
        public async Task<IActionResult> UpdateMaterialProperty([FromBody] UpdateMaterialPropertyCommand command)
        {
            return await CommandAsync(command);
        }

    }
}
