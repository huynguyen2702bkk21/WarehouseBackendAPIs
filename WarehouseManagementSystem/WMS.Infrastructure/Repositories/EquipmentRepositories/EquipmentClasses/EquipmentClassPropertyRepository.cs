namespace WMS.Infrastructure.Repositories.EquipmentRepositories
{
    public class EquipmentClassPropertyRepository : BaseRepository, IEquipmentCLassPropertyRepository
    {
        public EquipmentClassPropertyRepository(WMSDbContext context) : base(context)
        {
        }

        public void Create(EquipmentClassProperty equipmentClassProperty)
        {
            _context.EquipmentClassProperties.Add(equipmentClassProperty);
        }

        public void Delete(EquipmentClassProperty equipmentClassProperty)
        {
            _context.EquipmentClassProperties.Remove(equipmentClassProperty);
        }

        public async Task<List<EquipmentClassProperty>> GetAllAsync()
        {
            return await _context.EquipmentClassProperties.ToListAsync();

        }

        public async Task<EquipmentClassProperty> GetByIdAsync(string propertyId)
        {
            return await _context.EquipmentClassProperties.FirstOrDefaultAsync(x => x.propertyId== propertyId);
        }
    }
}
