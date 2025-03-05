namespace WMS.Infrastructure.Repositories.EquipmentRepositories
{
    public class EquipmentClassPropertyRepository : BaseRepository, IEquipmentCLassPropertyRepository
    {
        public EquipmentClassPropertyRepository(WMSDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EquipmentClassProperty>> GetAllAsync()
        {
            return await _context.EquipmentClassProperties.ToListAsync();

        }

        public async Task<EquipmentClassProperty> GetByIdAsync(string propertyId)
        {
            return await _context.EquipmentClassProperties.FirstOrDefaultAsync(x => x.propertyId== propertyId);
        }
    }
}
