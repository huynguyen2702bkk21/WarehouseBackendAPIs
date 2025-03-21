﻿namespace WMS.Application.Queries.MaterialQueries.MaterialSublots
{
    public class GetMaterialSubLotsByLotNumberQueryHandler : IRequestHandler<GetMaterialSubLotsByLotNumberQuery,IEnumerable<MaterialSubLotDTO>>
    {
        private readonly IMaterialSubLotRepository _materialSubLotRepository;
        private readonly IMapper _mapper;

        public GetMaterialSubLotsByLotNumberQueryHandler(IMaterialSubLotRepository materialSubLotRepository, IMapper mapper)
        {
            _materialSubLotRepository = materialSubLotRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaterialSubLotDTO>> Handle(GetMaterialSubLotsByLotNumberQuery request, CancellationToken cancellationToken)
        {
            var materialSublots = await _materialSubLotRepository.GetMaterialSubLotsByLotNumber(request.LotNumber);
            if (materialSublots.Count == 0)
            {
                throw new EntityNotFoundException("MaterialSublots Not Found");
            }

            var materialSublotsDTO = _mapper.Map<IEnumerable<MaterialSubLotDTO>>(materialSublots);
            
            return materialSublotsDTO;
        }

    }
}
