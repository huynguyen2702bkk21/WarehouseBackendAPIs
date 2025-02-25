namespace WMS.Application.Queries.PartyQueries.Person
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

            return _mapper.Map<PersonDTO>(person);
        }


    }
}
