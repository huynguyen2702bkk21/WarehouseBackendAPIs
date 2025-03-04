
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
    }
}
