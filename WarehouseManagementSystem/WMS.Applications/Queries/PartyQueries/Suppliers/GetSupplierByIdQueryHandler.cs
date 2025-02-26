namespace WMS.Application.Queries.PartyQueries.Suppliers
{
    public class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, SupplierDTO>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetSupplierByIdQueryHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<SupplierDTO> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetByIdAsync(request.Id);

            if (supplier == null)
            {
                throw new EntityNotFoundException(nameof(Supplier), request.Id);                
            }

            var supplierDTO = _mapper.Map<SupplierDTO>(supplier);

            return supplierDTO;
        }



    }
}
