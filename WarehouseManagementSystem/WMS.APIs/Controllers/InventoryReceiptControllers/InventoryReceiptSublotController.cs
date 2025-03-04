namespace WMS.APIs.Controllers.InventoryReceiptControllers
{
    [ApiController]
    [Route("WarehouseAPI/[controller]")]
    public class InventoryReceiptSublotController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public InventoryReceiptSublotController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllReceiptSublots")]
        public async Task<IEnumerable<ReceiptSubLotDTO>> GetAllReceiptSublots()
        {
            var query = new GetAllReceiptSubLotsQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetReceiptSubLotById/{receiptSublotId}")]
        public async Task<ReceiptSubLotDTO> GetReceiptSubLotById(string receiptSublotId)
        {
            var query = new GetReceiptSubLotByIdQuery(receiptSublotId);
            var result = await _mediator.Send(query);

            return result;
        }

    }
}
