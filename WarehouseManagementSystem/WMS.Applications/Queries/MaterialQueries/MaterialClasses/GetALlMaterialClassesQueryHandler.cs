﻿namespace WMS.Application.Queries.MaterialQueries.MaterialClasses
{
    public class GetALlMaterialClassesQueryHandler : IRequestHandler<GetALlMaterialClassesQuery,IEnumerable<MaterialClassDTO>>
    {
        private readonly IMaterialClassRepository _materialClassRepository;
        private readonly IMapper _mapper;

        public GetALlMaterialClassesQueryHandler(IMaterialClassRepository materialClassRepository, IMapper mapper)
        {
            _materialClassRepository = materialClassRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaterialClassDTO>> Handle(GetALlMaterialClassesQuery request, CancellationToken cancellationToken)
        {
            var materialClasses = await _materialClassRepository.GetAllAsync();
            if (materialClasses.Count == 0)
            {
                throw new EntityNotFoundException("MaterialClasses", "No material classes found");
            }
            
            var materialClassDTOs = _mapper.Map<IEnumerable<MaterialClassDTO>>(materialClasses);
            return materialClassDTOs;
        }


    }
}
