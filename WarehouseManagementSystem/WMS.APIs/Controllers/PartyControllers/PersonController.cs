namespace WMS.APIs.Controllers.PartyControllers
{
    [ApiController]
    [Route("WarehouseAPI/[controller]")]
    public class PersonController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllPeople")]
        public async Task<IEnumerable<PersonDTO>> GetAll()
        {
            var query = new GetAllPersonQuery();
            var result = await _mediator.Send(query);

            return result;

        }

        [HttpGet("GetPersonById/{personId}")]
        public async Task<PersonDTO> GetById(string personId)
        {
            var query = new GetPersonByIdQuery(personId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetAllPersonProperties")]
        public async Task<IEnumerable<PersonPropertyDTO>> GetAllPersonProperties()
        {
            var query = new GetAllPersonPropertiesQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetPersonPropertyById/{propertyId}")]
        public async Task<PersonPropertyDTO> GetPersonPropertyById(string propertyId)
        {
            var query = new GetPersonPropertyByIdQuery(propertyId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpPost("Create New Person")]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonCommand request)
        {
            return await CommandAsync(request);
        }

        [HttpPost("Create New Person Property")]
        public async Task<IActionResult> CreatePersonProperty([FromBody] CreatePersonPropertyCommand request)
        {
            return await CommandAsync(request);
        }

        [HttpPut("Update Person")]
        public async Task<IActionResult> UpdatePerson([FromBody] UpdatePersonCommand request)
        {
            return await CommandAsync(request);
        }

        [HttpPut("Update Person Property")]
        public async Task<IActionResult> UpdatePersonProperty([FromBody] UpdatePersonPropertyCommand request)
        {
            return await CommandAsync(request);
        }

        [HttpDelete("Delete Person/{personId}")]
        public async Task<IActionResult> DeletePerson(string personId)
        {
            var request = new DeletePersonCommand(personId);

            return await CommandAsync(request);
        }

        [HttpDelete("Delete Person Property/{propertyId}")]
        public async Task<IActionResult> DeletePersonProperty(string propertyId)
        {
            var request = new DeletePersonPropertyCommand(propertyId);

            return await CommandAsync(request);
        }

    }
}
