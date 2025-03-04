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

        [HttpPost("Create New Person")]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonCommand request)
        {
            return await CommandAsync(request);
        }

        [HttpPut("Update Person")]
        public async Task<IActionResult> UpdatePerson([FromBody] UpdatePersonCommand request)
        {
            return await CommandAsync(request);
        }

        [HttpDelete("Delete Person/{personId}")]
        public async Task<IActionResult> DeletePerson(string personId)
        {
            var request = new DeletePersonCommand(personId);

            return await CommandAsync(request);
        }


    }
}
