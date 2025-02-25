namespace WMS.Application.Queries.PartyQueries.Person
{
    public class GetAllPersonQueryHandler : IRequestHandler<GetAllPersonQuery, IEnumerable<PersonDTO>>
    {
        private readonly IPersonRepository _personRepository;
        private IMapper  _mapper;

        public GetAllPersonQueryHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonDTO>> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
        {
            var persons = await _personRepository.GetAll();

            if (persons == null)
            {
                return null;
            }

            var personDTOs = _mapper.Map<IEnumerable<PersonDTO>>(persons);

            return personDTOs;
        }
    }
}
