namespace WMS.APIs.Controllers.InventoryIssueControllers
{
    [ApiController]
    [Route("WarehouseAPI/[controller]")]
    public class InventoryIssueController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public InventoryIssueController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllIssues")]
        public async Task<IEnumerable<InventoryIssueDTO>> GetAllIssue()
        {
            var query = new GetAllInventoryIssuesQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetIssueById/{InventoryIssueId}")]
        public async Task<InventoryIssueDTO> GetIssueById(string InventoryIssueId)
        {
            var query = new GetInventoryIssueByIdQuery(InventoryIssueId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpPost("CreateInventoryIssue")]
        public async Task<IActionResult> CreateIssue([FromBody] CreateInventoryIssueCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpPut("RefreshInventoryIssueStatus/{IssueId}")]
        public async Task<IActionResult> RefreshIssueStatus(string IssueId)
        {
            var command = new RefreshInventoryIssueStatusCommand(IssueId);
            return await CommandAsync(command);
        }

        [HttpPut("UpdateInventoryIssue")]
        public async Task<IActionResult> UpdateIssue([FromBody] UpdateInventoryIssueCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpDelete("DeleteInventoryIssue/{IssueId}")]
        public async Task<IActionResult> DeleteIssue(string IssueId)
        {
            var command = new DeleteInventoryIssueCommand(IssueId);
            return await CommandAsync(command);
        }

    }

}
