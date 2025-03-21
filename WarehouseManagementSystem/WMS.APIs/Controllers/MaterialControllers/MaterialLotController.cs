namespace WMS.APIs.Controllers.MaterialControllers
{
    [ApiController]
    [Route("WarehouseAPI/[controller]")]
    public class MaterialLotController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public MaterialLotController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllMaterialLotProperties")]
        public async Task<IEnumerable<MaterialLotPropertyDTO>> GetAllProperties()
        {
            var query = new GetAllMaterialLotPropertiesQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetAllMaterialLots")]
        public async Task<IEnumerable<MaterialLotDTO>> GetAllMaterialLots()
        {
            var query = new GetAllMaterialLotsQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetMaterialLotById/{lotNumber}")]
        public async Task<MaterialLotDTO> GetMaterialLotById(string lotNumber)
        {
            var query = new GetMaterialLotByIdQuery(lotNumber);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetMaterialLotPropertyById/{propertyId}")]
        public async Task<MaterialLotPropertyDTO> GetMaterialLotPropertyById(string propertyId)
        {
            var query = new GetMaterialLotPropertyByIdQuery(propertyId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetMaterialLotsByMaterialId/{materialId}")]
        public async Task<IEnumerable<MaterialLotDTO>> GetMaterialLotsByMaterialId(string materialId)
        {
            var query = new GetMaterialLotsByMaterialIdQuery(materialId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("Get MaterialLot by LotStatus/{status}")]
        public async Task<IEnumerable<MaterialLotDTO>> GetMaterialLotsByStatus(string status)
        {
            var query = new GetMaterialLotsByStatusQuery(status);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpPost("CreateMaterialLotProperty")]
        public async Task<IActionResult> CreateMaterialLotProperty([FromBody] CreateMaterialLotPropertyCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpPost("CreateMaterialLot")]
        public async Task<IActionResult> CreateMaterialLot([FromBody] CreateMaterialLotCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpDelete("DeleteMaterialLotProperty/{propertyId}")]
        public async Task<IActionResult> DeleteMaterialLotProperty(string propertyId)
        {
            var command = new DeleteMaterialLotPropertyCommand(propertyId); 
            return await CommandAsync(command);
        }

        [HttpDelete("DeleteMaterialLot/{lotNumber}")]
        public async Task<IActionResult> DeleteMaterialLot(string lotNumber)
        {
            var command = new DeleteMaterialLotCommand(lotNumber);
            return await CommandAsync(command);
        }

        [HttpPut("UpdateMaterialLotProperty")]
        public async Task<IActionResult> UpdateMaterialLotProperty([FromBody] UpdateMaterialLotPropertyCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpPut("UpdateMaterialLot")]
        public async Task<IActionResult> UpdateMaterialLot([FromBody] UpdateMaterialLotCommand command)
        {
            return await CommandAsync(command);
        }

    }
}
