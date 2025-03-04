
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

        [HttpGet("GetMaterialSubLotById/{Id}")]
        public async Task<IActionResult> GetMaterialSubLotById(string Id)
        {
            var query = new GetMaterialSubLotByIdQuery(Id);
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

    }
}
