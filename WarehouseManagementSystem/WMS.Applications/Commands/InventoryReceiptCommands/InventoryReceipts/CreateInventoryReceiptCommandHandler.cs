namespace WMS.Application.Commands.InventoryReceiptCommands.InventoryReceipts
{
    public class CreateInventoryReceiptCommandHandler : IRequestHandler<CreateInventoryReceiptCommand, bool>
    {
        private readonly IInventoryReceiptRepository _inventoryReceiptRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IReceiptServices _receiptServices;

        public CreateInventoryReceiptCommandHandler(IInventoryReceiptRepository inventoryReceiptRepository, ISupplierRepository supplierRepository, IPersonRepository personRepository, IWarehouseRepository warehouseRepository, IReceiptServices receiptServices)
        {
            _inventoryReceiptRepository = inventoryReceiptRepository;
            _supplierRepository = supplierRepository;
            _personRepository = personRepository;
            _warehouseRepository = warehouseRepository;
            _receiptServices = receiptServices;
        }

        public async Task<bool> Handle(CreateInventoryReceiptCommand request, CancellationToken cancellationToken)
        {
            var inventoryReceipt = await _inventoryReceiptRepository.GetByIdAsync(request.InventoryReceiptId);
            if(inventoryReceipt != null)
            {
                throw new DuplicateRecordException(nameof(InventoryReceipt),request.InventoryReceiptId);
            }

            var supplier = await _supplierRepository.GetByIdAsync(request.SupplierId);
            if(supplier == null)
            {
                throw new EntityNotFoundException(nameof(Supplier),request.SupplierId);
            }

            var person = await _personRepository.GetPersonById(request.PersonId);
            if(person == null)
            {
                throw new EntityNotFoundException(nameof(Person),request.PersonId);
            }

            var warehouse = await _warehouseRepository.GetWarehouseById(request.WarehouseId);
            if(warehouse == null)
            {
                throw new EntityNotFoundException(nameof(Warehouse),request.WarehouseId);
            }

            var newInventoryReceipt = await _receiptServices.CreateNewInventoryReceipt(request);

            await _receiptServices.AddToMaterialLot(newInventoryReceipt);

            _inventoryReceiptRepository.Create(newInventoryReceipt);
            
            return await _inventoryReceiptRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }


    }

}
