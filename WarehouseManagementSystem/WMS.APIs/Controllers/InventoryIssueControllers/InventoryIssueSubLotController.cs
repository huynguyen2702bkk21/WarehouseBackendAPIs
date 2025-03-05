namespace WMS.APIs.Controllers.InventoryIssueControllers
{
    [ApiController]
    [Route("WarehouseAPI/[controller]")]
    public class InventoryIssueSubLotController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public InventoryIssueSubLotController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllIssueSubLots")]
        public async Task<IEnumerable<IssueSubLotDTO>> GetAllIssueSubLots()
        {
            var query = new GetAllIssueSubLotsQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetIssueSubLotById/{issueSublotId}")]
        public async Task<IssueSubLotDTO> GetIssueSubLotById(string issueSublotId)
        {
            var query = new GetIssueSubLotByIdQuery(issueSublotId);
            var result = await _mediator.Send(query);

            return result;
        }

    }
}
