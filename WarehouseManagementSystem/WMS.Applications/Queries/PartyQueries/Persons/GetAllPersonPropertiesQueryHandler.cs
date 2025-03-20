using WMS.Domain.InterfaceRepositories.IParty.People;

namespace WMS.Application.Queries.PartyQueries.Persons
{
    public class GetAllPersonPropertiesQueryHandler : IRequestHandler<GetAllPersonPropertiesQuery, IEnumerable<PersonPropertyDTO>>
    {
        private readonly IPersonPropertyRepository _personPropertyRepository;
        private readonly IMapper _mapper;

        public GetAllPersonPropertiesQueryHandler(IPersonPropertyRepository personPropertyRepository, IMapper mapper)
        {
            _personPropertyRepository = personPropertyRepository;
            _mapper = mapper;
        }

        public async  Task<IEnumerable<PersonPropertyDTO>> Handle(GetAllPersonPropertiesQuery request, CancellationToken cancellationToken)
        {
            var personProperties = await _personPropertyRepository.GetAllPersonProperties();
            if (personProperties.Count == 0)
            {
                throw new EntityNotFoundException("PersonProperties is not Found");
            }

            var personPropertyDTOs = _mapper.Map<IEnumerable<PersonPropertyDTO>>(personProperties);

            return personPropertyDTOs;


        }
    }
}
