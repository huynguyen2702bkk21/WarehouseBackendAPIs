namespace WMS.Application.Queries.PartyQueries.Suppliers
{
    public class GetAllSupplierQueryHandler : IRequestHandler<GetAllSupplierQuery, IEnumerable<SupplierDTO>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetAllSupplierQueryHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SupplierDTO>> Handle(GetAllSupplierQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await _supplierRepository.GetAllAsync();

            if (suppliers == null)
            {
                throw new EntityNotFoundException("Suppliers", "No suppliers found");
            }

            var supplierDTOs = _mapper.Map<IEnumerable<SupplierDTO>>(suppliers);

            return supplierDTOs;
        }



    }
}
