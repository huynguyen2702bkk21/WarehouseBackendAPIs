namespace WMS.Application.Services.InventoryIssueServices
{
    public class IssueServices : IIssueServices
    {
        private readonly IInventoryIssueRepository _inventoryIssueRepository;
        private readonly IInventoryIssueEntryRepository _inventoryIssueEntryRepository;
        private readonly IIssueLotRepository _issueLotRepository;
        private readonly IIssueSubLotRepository _issueSubLotRepository;
        private readonly IMaterialLotRepository _materialLotRepository;
        private readonly IMaterialSubLotRepository _materialSubLotRepository;

        public IssueServices(IInventoryIssueRepository inventoryIssueRepository, IInventoryIssueEntryRepository inventoryIssueEntryRepository, IIssueLotRepository issueLotRepository, IIssueSubLotRepository issueSubLotRepository, IMaterialLotRepository materialLotRepository, IMaterialSubLotRepository materialSubLotRepository)
        {
            _inventoryIssueRepository = inventoryIssueRepository;
            _inventoryIssueEntryRepository = inventoryIssueEntryRepository;
            _issueLotRepository = issueLotRepository;
            _issueSubLotRepository = issueSubLotRepository;
            _materialLotRepository = materialLotRepository;
            _materialSubLotRepository = materialSubLotRepository;
        }

        private static DateTime GetVietnamTime()
        {
            return TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
        }

        public async Task<InventoryIssueEntry> CreateEntry(CreateInventoryIssueEntryCommand request)
        {
            var newEntry = new InventoryIssueEntry(inventoryIssueEntryId: request.InventoryIssueEntryId,
                                                   purchaseOrderNumber: request.PurchaseOrderNumber,
                                                   requestedQuantity: request.RequestedQuantity,
                                                   note: request.Note,
                                                   materialId: request.MaterialId,
                                                   issueLotId: request.IssueLotId,
                                                   inventoryIssueId: request.InventoryIssueId);

            var issueLot = await _issueLotRepository.GetIssueLotByIdAsync(request.IssueLot.IssueLotId);
            if (issueLot != null)
            {
                throw new DuplicateRecordException(nameof(IssueLot), request.IssueLot.IssueLotId);
            }

            if (!Enum.TryParse<LotStatus>(request.IssueLot.IssueLotStatus, out var LotStatus))
            {
                throw new Exception($"Invalid IssueLot status: {request.IssueLot.IssueLotStatus}");
            }

            var newIssueLot = new IssueLot(issueLotId: request.IssueLot.IssueLotId,
                                           requestedQuantity: request.IssueLot.RequestedQuantity,
                                           issueLotStatus: LotStatus,
                                           materialLotId: request.IssueLot.MaterialLotId,
                                           inventoryIssueEntryId: request.InventoryIssueEntryId);

            foreach (var subLot in request.IssueLot.IssueSublots)
            {

                var SubLot = await _issueSubLotRepository.GetByIdAsync(subLot.IssueSublotId);
                if (SubLot != null)
                {
                    throw new DuplicateRecordException(nameof(IssueLot), subLot.IssueSublotId);
                }

                var newIssueSubLot = new IssueSublot(issueSublotId: subLot.IssueSublotId,
                                                     requestedQuantity: subLot.RequestedQuantity,
                                                     materialSublotId: subLot.MaterialSublotId,
                                                     issueLotId: subLot.IssueLotId);

                newIssueLot.AddSublot(newIssueSubLot);

            }
            newEntry.issueLot = newIssueLot;

            return newEntry;
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

        public async Task UpdateIssueEntries(UpdateInventoryIssueEntryCommand request)
        {
            foreach (var entry in request.Entries)
            {
                var inventoryIssueEntry = await _inventoryIssueEntryRepository.GetInventoryIssueEntryByIdAsync(entry.InventoryIssueEntryId);
                if (inventoryIssueEntry == null)
                {
                    throw new EntityNotFoundException(nameof(InventoryIssueEntry), entry.InventoryIssueEntryId);
                }

                inventoryIssueEntry.Update(purchaseOrderNumber: entry.PurchaseOrderNumber,
                                           requestedQuantity: entry.RequestedQuantity,
                                           note: entry.Note);

                var issueLot = await _issueLotRepository.GetIssueLotByIdAsync(entry.IssueLot.IssueLotId);
                if (issueLot == null)
                {
                    throw new EntityNotFoundException(nameof(IssueLot), entry.IssueLot.IssueLotId);
                }
                if (!Enum.TryParse<LotStatus>(entry.IssueLot.IssueLotStatus, out var issueLotStatus))
                {
                    throw new Exception($"Invalid LotStatus status: {entry.IssueLot.IssueLotStatus}");
                }
                issueLot.Update(requestedQuantity: entry.IssueLot.RequestedQuantity,
                                issueLotStatus: issueLotStatus,
                                materialLotId: entry.IssueLot.MaterialLotId);

                foreach (var sublot in entry.IssueLot.IssueSublots)
                {
                    var issueSubLot = await _issueSubLotRepository.GetByIdAsync(sublot.IssueSublotId);
                    if (issueSubLot == null)
                    {
                        throw new EntityNotFoundException(nameof(IssueSublot), sublot.IssueSublotId);
                    }

                    issueSubLot.Update(requestedQuantity: sublot.RequestedQuantity,
                                       materialSubLotId: sublot.MaterialSublotId);

                }

            }
        }

        public async Task UpdateMaterialLot(InventoryIssue inventoryIssue)
        {
            await CheckMateriaLot(inventoryIssue);
            await CheckMaterialSublot(inventoryIssue);

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

                if (!materialLots.Contains(materialLot))
                {
                    materialLots.Add(materialLot);
                }

                if (materialLots.Count == 0)
                {
                    throw new Exception("MaterialLots is empty, cannot confirm issue.");
                }

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


        private async Task CheckMateriaLot(InventoryIssue inventoryIssue)
        {
            var groupEntries = inventoryIssue.entries
                .Where(e => e.issueLot?.materialLot != null)
                .GroupBy(e => e.issueLot.materialLot.lotNumber)
                .Select(g => new
                {
                    materialLotId = g.Key,
                    totalQuantity = g.Sum(e => e.requestedQuantity)
                })
                .ToList();

            var materialLots = await _materialLotRepository.GetAllAsync();
            var materialLotDict = materialLots.ToDictionary(ml => ml.lotNumber);

            foreach (var entry in groupEntries)
            {
                if (!materialLotDict.TryGetValue(entry.materialLotId, out var materialLot))
                {
                    throw new Exception($"Material Lot {entry.materialLotId} not found.");
                }

                if (entry.totalQuantity > materialLot.exisitingQuantity)
                {
                    throw new InvalidOperationException($"Requested quantity ({entry.totalQuantity}) exceeds existing quantity ({materialLot.exisitingQuantity}) for lot {materialLot.lotNumber}.");
                }
            }

        }

        public async Task CheckMaterialSublot(InventoryIssue inventoryIssue)
        {
            var groupEntries = inventoryIssue.entries
                .SelectMany(e => e.issueLot.issueSublots, (entry, sublot) => new
                {
                    sublot.sublotId,
                    sublot.requestedQuantity
                })
                .GroupBy(x => x.sublotId)
                .Select(g => new
                {
                    sublotId = g.Key,
                    totalQuantity = g.Sum(x => x.requestedQuantity)
                })
                .ToList();

            var subLots = await _materialSubLotRepository.GetAllAsync();
            var subLotDict = subLots.ToDictionary(s => s.subLotId);

            foreach (var entry in groupEntries)
            {
                if (!subLotDict.TryGetValue(entry.sublotId, out var subLot))
                {
                    throw new Exception($"SubLot {entry.sublotId} not found.");
                }

                if (entry.totalQuantity > subLot.existingQuality)
                {
                    throw new InvalidOperationException($"Requested quantity ({entry.totalQuantity}) exceeds existing quantity ({subLot.existingQuality}) for sublot {subLot.subLotId}.");
                }
            }
        }

    }
}
