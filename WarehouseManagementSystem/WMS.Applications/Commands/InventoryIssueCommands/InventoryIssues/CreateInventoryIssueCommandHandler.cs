namespace WMS.Application.Commands.InventoryIssueCommands.InventoryIssues
{
    public class CreateInventoryIssueCommandHandler : IRequestHandler<CreateInventoryIssueCommand, bool>
    {
        private readonly IInventoryIssueRepository _inventoryIssueRepository;
        private readonly IPersonRepository _personRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IIssueLotRepository _issueLotRepository;
        private readonly IIssueSubLotRepository _issueSubLotRepository;
        private readonly IMaterialLotRepository _materialLotRepository;
        private readonly IMaterialSubLotRepository _materialSubLotRepository;

        public CreateInventoryIssueCommandHandler(IInventoryIssueRepository inventoryIssueRepository, IPersonRepository personRepository, ICustomerRepository customerRepository, IWarehouseRepository warehouseRepository, IIssueLotRepository issueLotRepository, IIssueSubLotRepository issueSubLotRepository, IMaterialLotRepository materialLotRepository, IMaterialSubLotRepository materialSubLotRepository)
        {
            _inventoryIssueRepository = inventoryIssueRepository;
            _personRepository = personRepository;
            _customerRepository = customerRepository;
            _warehouseRepository = warehouseRepository;
            _issueLotRepository = issueLotRepository;
            _issueSubLotRepository = issueSubLotRepository;
            _materialLotRepository = materialLotRepository;
            _materialSubLotRepository = materialSubLotRepository;
        }

        public async Task<bool> Handle(CreateInventoryIssueCommand request, CancellationToken cancellationToken)
        {
            var inventoryIssue = await _inventoryIssueRepository.GetByIdAsync(request.InventoryIssueId);
            if (inventoryIssue != null)
            {
                throw new DuplicateRecordException(nameof(InventoryIssue), request.InventoryIssueId);
            }

            var customer = await _customerRepository.GetCustomerById(request.CustomerId);
            if (customer == null)
            {
                throw new EntityNotFoundException(nameof(Customer), request.CustomerId);
            }

            var person = await _personRepository.GetPersonById(request.PersonId);
            if (person == null)
            {
                throw new EntityNotFoundException(nameof(Person), request.PersonId);
            }

            var warehouse = await _warehouseRepository.GetWarehouseById(request.WarehouseId);
            if (warehouse == null)
            {
                throw new EntityNotFoundException(nameof(Warehouse), request.WarehouseId);
            }

            var newInventoryIssue = await CreateNewInventoryIssue(request);

            await UpdateMaterialLot(newInventoryIssue);

            _inventoryIssueRepository.Create(newInventoryIssue);

            return await _inventoryIssueRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }


        public async Task<InventoryIssue> CreateNewInventoryIssue(CreateInventoryIssueCommand request)
        {
            if (!Enum.TryParse<IssueStatus>(request.IssueStatus, out var Status))
            {
                throw new Exception($"Invalid receipt status: {request.IssueStatus}");
            }

            var newInventoryIssue = new InventoryIssue(inventoryIssueId: request.InventoryIssueId,
                                                       issueDate: GetVietnamTime(),
                                                       issueStatus: Status,
                                                       customerId: request.CustomerId,
                                                       personId: request.PersonId,
                                                       warehouseId: request.WarehouseId);

            foreach (var entry in request.Entries)
            {

                var Entry = await _inventoryIssueRepository.GetByIdAsync(entry.InventoryIssueEntryId);
                if (Entry != null)
                {
                    throw new DuplicateRecordException(nameof(InventoryIssueEntry), entry.InventoryIssueEntryId);
                }

                var newEntry = new InventoryIssueEntry(inventoryIssueEntryId: entry.InventoryIssueEntryId,
                                                       purchaseOrderNumber: entry.PurchaseOrderNumber,
                                                       requestedQuantity: entry.RequestedQuantity,
                                                       note: entry.Note,
                                                       materialId: entry.MaterialId,
                                                       issueLotId: entry.IssueLotId,
                                                       inventoryIssueId: entry.InventoryIssueId);

                var issueLot = await _issueLotRepository.GetIssueLotByIdAsync(entry.IssueLot.IssueLotId);
                if (issueLot != null)
                {
                    throw new DuplicateRecordException(nameof(IssueLot), entry.IssueLot.IssueLotId);
                }

                if (!Enum.TryParse<LotStatus>(entry.IssueLot.IssueLotStatus, out var LotStatus))
                {
                    throw new Exception($"Invalid issueLot status: {entry.IssueLot.IssueLotStatus}");
                }

                var newIssueLot = new IssueLot(issueLotId: entry.IssueLot.IssueLotId,
                                               requestedQuantity: entry.IssueLot.RequestedQuantity,
                                               issueLotStatus: LotStatus,
                                               materialLotId: entry.IssueLot.MaterialLotId,
                                               inventoryIssueEntryId: entry.InventoryIssueEntryId);

                if (newIssueLot.issueLotStatus != LotStatus.Done)
                {
                    newInventoryIssue.issueStatus = IssueStatus.Pending;
                }


                foreach (var subLot in entry.IssueLot.IssueSublots) 
                {

                    var SubLot = await _issueSubLotRepository.GetByIdAsync(subLot.IssueSublotId);
                    if (SubLot != null)
                    {
                        throw new DuplicateRecordException(nameof(IssueSublot), subLot.IssueSublotId);
                    }

                    var newIssueSubLot = new IssueSublot(issueSublotId: subLot.IssueSublotId,
                                                         requestedQuantity: subLot.RequestedQuantity,
                                                         materialSublotId: subLot.MaterialSublotId,
                                                         issueLotId: subLot.IssueLotId);

                    newIssueLot.AddSublot(newIssueSubLot);

                }

                newEntry.issueLot = newIssueLot;

                newInventoryIssue.AddEntry(newEntry);
            }

            return newInventoryIssue;

        }

        public async Task UpdateMaterialLot(InventoryIssue inventoryIssue)
        {
            var materialLots = new List<MaterialLot>();
            var inventoryIssueStatus = IssueStatus.Completed;

            foreach (var entry in inventoryIssue.entries)
            {
                if (entry.issueLot.issueLotStatus != LotStatus.Done)
                {
                    inventoryIssueStatus = IssueStatus.Pending;
                }

                var materialLot = await _materialLotRepository.GetMaterialLotById(entry.issueLot.materialLotId);
                if (materialLot == null)
                {
                    throw new EntityNotFoundException(nameof(MaterialLot), entry.issueLot.materialLotId);
                }

                if (entry.issueLot.requestedQuantity > materialLot.exisitingQuantity)
                {
                    throw new Exception($"Requested quantity ({entry.issueLot.requestedQuantity}) exceeds existing quantity ({materialLot.exisitingQuantity}) for lot {materialLot.lotNumber}.");
                }

                foreach (var sublot in entry.issueLot.issueSublots)
                {
                    var materialSubLot = await _materialSubLotRepository.GetByIdAsync(sublot.sublotId);
                    if (materialSubLot == null)
                    {
                        throw new EntityNotFoundException(nameof(MaterialSubLot), sublot.sublotId);
                    }

                    if (sublot.requestedQuantity > materialSubLot.existingQuality)
                    {
                        throw new Exception($"Requested quantity ({sublot.requestedQuantity}) exceeds existing quantity ({materialSubLot.existingQuality}) for sublot {materialSubLot.subLotId}.");
                    }


                }


                materialLots.Add(materialLot);

            }

            if (inventoryIssueStatus == IssueStatus.Completed)
            {
                inventoryIssue.Confirm(materialLots, inventoryIssue);
                inventoryIssue.issueStatus = inventoryIssueStatus;
            }
            else
            {
                inventoryIssue.issueStatus = inventoryIssueStatus;
            }

        }

        private static DateTime GetVietnamTime()
        {
            return TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
        }






    }
}
