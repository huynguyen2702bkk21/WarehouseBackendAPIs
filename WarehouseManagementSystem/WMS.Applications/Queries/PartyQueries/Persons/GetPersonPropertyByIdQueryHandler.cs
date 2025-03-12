namespace WMS.Application.Queries.PartyQueries.Persons
{
    public class GetPersonPropertyByIdQueryHandler : IRequestHandler<GetPersonPropertyByIdQuery, PersonPropertyDTO>
    {
        private readonly IPersonPropertyRepository _personPropertyRepository;
        private readonly IMapper _mapper;

        public GetPersonPropertyByIdQueryHandler(IPersonPropertyRepository personPropertyRepository, IMapper mapper)
        {
            _personPropertyRepository = personPropertyRepository;
            _mapper = mapper;
        }

        public async Task<PersonPropertyDTO> Handle(GetPersonPropertyByIdQuery request, CancellationToken cancellationToken)
        {
            var personProperty = await _personPropertyRepository.GetByIdAsync(request.PropertyId);
            if(personProperty == null)
            {
                throw new EntityNotFoundException(nameof(PersonProperty), request.PropertyId);
            }

            var personPropertyDTO = _mapper.Map<PersonPropertyDTO>(personProperty);
            return personPropertyDTO;


        }


    }
}
