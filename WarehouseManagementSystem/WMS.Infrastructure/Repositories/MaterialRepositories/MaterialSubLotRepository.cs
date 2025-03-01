
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

        public async Task<List<MaterialSubLot>> GetMaterialSubLotsByLocationId(string locationId)
        {
            return await _context.MaterialSubLots.Where(x => x.locationId == locationId).ToListAsync();
        }
    }
}
