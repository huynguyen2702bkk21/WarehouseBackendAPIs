namespace WMS.Infrastructure.Repositories.MaterialRepositories
{
    public class MaterialSubLotRepository : BaseRepository, IMaterialSubLotRepository
    {
        public MaterialSubLotRepository(WMSDbContext context) : base(context)
        {
        }

        public async Task<List<MaterialSubLot>> GetAllAsync()
        {
            return await _context.MaterialSubLots.ToListAsync();
        }

        public async Task<MaterialSubLot> GetByIdAsync(string Id)
        {
            return await _context.MaterialSubLots.FirstOrDefaultAsync(x => x.subLotId== Id);
        }

        public Task<List<MaterialSubLot>> GetMaterialSubLotsByStatus(string Status)
        {
            if (!Enum.TryParse<LotStatus>(Status, out var outStatus))
            {
                throw new ArgumentException("Invalid status");
            }

            return _context.MaterialSubLots.Where(x => x.subLotStatus == outStatus).ToListAsync();    

        }

        public async Task<List<MaterialSubLot>> GetMaterialSubLotsByLocationId(string locationId)
        {
            return await _context.MaterialSubLots.Where(x => x.locationId == locationId).ToListAsync();
        }

        public async Task<List<MaterialSubLot>> GetMaterialSubLotsByLotNumber(string lotNumber)
        {
            return await _context.MaterialSubLots.Where(x => x.lotNumber == lotNumber).ToListAsync();
        }

        public void Create(MaterialSubLot materialSubLot)
        {
            _context.MaterialSubLots.Add(materialSubLot);
        }

        public void Delete(MaterialSubLot materialSubLot)
        {
            _context.MaterialSubLots.Remove(materialSubLot);
        }
    }
}
