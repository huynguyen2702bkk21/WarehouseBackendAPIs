using WMS.Application.DTOs.MaterialDTOs;
using WMS.Application.Queries.MaterialQueries.MaterialClasses;

namespace WMS.APIs.Controllers.MaterialControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialClassController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public MaterialClassController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("MaterialClasses/GetAll")]
        public async Task<IEnumerable<MaterialClassDTO>> GetAll()
        {
            var query = new GetALlMaterialClassesQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("MaterialClasses/GetAllProperties")]
        public async Task<IEnumerable<MaterialClassPropertyDTO>> GetAllProperties()
        {
            var query = new GetAllMaterialClassPropertiesQuerry();
            var result = await _mediator.Send(query);

            return result;
        }


    }
}
