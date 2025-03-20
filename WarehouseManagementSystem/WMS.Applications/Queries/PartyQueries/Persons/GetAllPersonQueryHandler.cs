namespace WMS.Application.Queries.PartyQueries.Persons
{
    public class GetAllPersonQueryHandler : IRequestHandler<GetAllPersonQuery, IEnumerable<PersonDTO>>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper  _mapper;

        public GetAllPersonQueryHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonDTO>> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
        {
            var persons = await _personRepository.GetAllAsync();

            if (persons.Count == 0)
            {
                throw new EntityNotFoundException("Persons", "No persons found");
            }

            var personDTOs = _mapper.Map<IEnumerable<PersonDTO>>(persons);

            return personDTOs;
        }
    }
}
