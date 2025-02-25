using WMS.Application.Commands.PartyCommands.Persons;

namespace WMS.APIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ApiControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMediator _mediator;

        public PersonController(IPersonRepository personRepository, IMediator mediator) : base(mediator)
        {
            _personRepository = personRepository;
            _mediator = mediator;
        }

        [HttpGet("Persons/Getalll")]
        public async Task<IEnumerable<PersonDTO>> GetAll()
        {
            var query = new GetAllPersonQuery();
            var result = await _mediator.Send(query);

            return result;

        }

        [HttpGet("Persons/GetPersonById/{id}")]
        public async Task<PersonDTO> GetById(string id)
        {
            var query = new GetPersonByIdQuery(id);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpPost("Persons/Create New Person")]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonCommand request)
        {
            return await CommandAsync(request);
        }


    }
}
