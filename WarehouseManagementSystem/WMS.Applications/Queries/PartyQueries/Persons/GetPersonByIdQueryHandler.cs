namespace WMS.Application.Queries.PartyQueries.Persons
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, PersonDTO>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public GetPersonByIdQueryHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<PersonDTO> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetPersonById(request.PersonId);

            if (person == null)
            {
                throw new EntityNotFoundException("Persons", request.PersonId);
            }

            var personDTO =  _mapper.Map<PersonDTO>(person);

            return personDTO;
        }


    }
}
