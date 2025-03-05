
using WMS.Application.Queries.InventoryIssueQueries.IssueLots;

namespace WMS.APIs.Controllers.InventoryIssueControllers
{
    [ApiController]
    [Route("WarehouseAPI/[controller]")]
    public class InventoryIssueLotController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public InventoryIssueLotController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllIssueLots")]
        public async Task<IEnumerable<IssueLotDTO>> GetAllIssueLots()
        {
            var query = new GetAllIssueLotsQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetIssueLotById/{IssueLotId}")]
        public async Task<IssueLotDTO> GetIssueLotById(string IssueLotId)
        {
            var query = new GetIssueLotByIdQuery(IssueLotId);
            var result = await _mediator.Send(query);

            return result;
        }

    }
}
