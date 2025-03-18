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

    }

}
