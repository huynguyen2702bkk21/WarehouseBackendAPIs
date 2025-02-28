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

        [HttpGet("MaterialClasses/GetMaterialClassById")]
        public async Task<MaterialClassDTO> GetById(string materialClassId)
        {
            var query = new GetMaterialClassByIdQuery(materialClassId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("MaterialClasses/GetMaterialClassPropertyById")]
        public async Task<MaterialClassPropertyDTO> GetPropertyById(string materialClassPropertyId)
        {
            var query = new GetMaterialClassPropertyByIdQuerry(materialClassPropertyId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpPost("MaterialClasses/CreateMaterialClass")]
        public async Task<IActionResult> CreateMaterialClass([FromBody] CreateMaterialClassCommand command)
        {
            return await CommandAsync(command);
        }


    }
}
