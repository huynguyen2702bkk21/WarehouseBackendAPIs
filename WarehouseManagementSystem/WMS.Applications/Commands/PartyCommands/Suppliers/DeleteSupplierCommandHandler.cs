namespace WMS.Application.Commands.PartyCommands.Suppliers
{
    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand,bool>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public DeleteSupplierCommandHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetByIdAsync(request.SupplierId);
            if (supplier == null)
            {
                throw new EntityNotFoundException(nameof(Supplier), request.SupplierId);
            }

            _supplierRepository.Delete(supplier);

            return await _supplierRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }




    }
}
