
using WMS.Application.Commands.MaterialCommands.MaterialSubLots;
using WMS.Application.Queries.MaterialQueries.MaterialSublots;

namespace WMS.APIs.Controllers.MaterialControllers
{
    [ApiController]
    [Route("WarehouseAPI/[controller]")]
    public class MaterialSubLotController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public MaterialSubLotController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllMaterialSubLot")]
        public async Task<IActionResult> GetAllMaterialSubLot()
        {
            var query = new GetAllMaterialSubLotsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetMaterialSubLotById/{sublotId}")]
        public async Task<IActionResult> GetMaterialSubLotById(string sublotId)
        {
            var query = new GetMaterialSubLotByIdQuery(sublotId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetMaterialSubLotsByLocationId/{LocationId}")]
        public async Task<IActionResult> GetMaterialSubLotsByLocationId(string LocationId)
        {
            var query = new GetMaterialSubLotsByLocationIdQuery(LocationId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetMaterialSubLotsByLotNumber/{lotNumber}")]
        public async Task<IActionResult> GetMaterialSubLotsByLotNumber(string lotNumber)
        {
            var query = new GetMaterialSubLotsByLotNumberQuery(lotNumber);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetMaterialSubLotsByStatus/{status}")]
        public async Task<IActionResult> GetMaterialSubLotsByStatus(string status)
        {
            var query = new GetMaterialSubLotsByStatusQuery(status);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("CreateMaterialSubLot")]
        public async Task<IActionResult> CreateMaterialSubLot([FromBody] CreateMaterialSubLotCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpPut("UpdateMaterialSubLot")]
        public async Task<IActionResult> UpdateMaterialSubLot([FromBody] UpdateMaterialSubLotCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpDelete("DeleteMaterialSubLot/{sublotId}")]
        public async Task<IActionResult> DeleteMaterialSubLot(string sublotId)
        {
            var command = new DeleteMaterialSubLotCommand(sublotId);
            return await CommandAsync(command);
        }

    }
}
