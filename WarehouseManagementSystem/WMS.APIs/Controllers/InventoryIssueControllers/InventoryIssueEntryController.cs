namespace WMS.APIs.Controllers.InventoryIssueControllers
{
    [ApiController]
    [Route("WarehouseAPI/[controller]")]
    public class InventoryIssueEntryController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public InventoryIssueEntryController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllIssueEntries")]
        public async Task<IEnumerable<InventoryIssueEntryDTO>> GetAllIssueEntries()
        {
            var query = new GetAllInventoryIssueEntriesQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetIssueEntryById/{IssueEntryId}")]
        public async Task<InventoryIssueEntryDTO> GetIssueEntryById(string IssueEntryId)
        {
            var query = new GetInventoryIssueEntryByIdQuery(IssueEntryId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpPost("CreateIssueEntry")]
        public async Task<IActionResult> CreateIssueEntry([FromBody] CreateInventoryIssueEntryCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpPut("UpdateIssueEntry")]
        public async Task<IActionResult> UpdateIssueEntry([FromBody] UpdateInventoryIssueEntryCommand command)
        {
            return await CommandAsync(command);
        }


    }
}
