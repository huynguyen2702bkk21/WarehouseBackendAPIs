namespace WMS.APIs.Controllers.InventoryTrackingControllers
{
    [ApiController]
    [Route("WarehouseAPI/[controller]")]
    public class InventoryLogController : ApiControllerBase
    {   
        private IMediator _mediator;
        public InventoryLogController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetInventoryLogByLotNumber/{lotNumber}")]
        public async Task<IEnumerable<InventoryLogDTO>> GetInventoryLogByLotNumber(string lotNumber)
        {
            var query = new GetInventoryLogByLotNumberQuery(lotNumber);
            var result = await _mediator.Send(query);

            return result;

        }




    }
}
