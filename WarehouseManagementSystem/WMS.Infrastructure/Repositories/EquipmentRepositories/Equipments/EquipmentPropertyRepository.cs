
namespace WMS.Infrastructure.Repositories.EquipmentRepositories
{
    public class EquipmentPropertyRepository : BaseRepository, IEquipmentPropertyRepository
    {
        public EquipmentPropertyRepository(WMSDbContext context) : base(context)
        {
        }

        public Task<List<EquipmentProperty>> GetAllAsync()
        {
            return _context.EquipmentProperties.ToListAsync();
        }

        public async Task<EquipmentProperty> GetByIdAsync(string id)
        {
            return await _context.EquipmentProperties.FirstOrDefaultAsync(x => x.propertyId == id);
        }

        public void Create(EquipmentProperty equipmentProperty)
        {
            _context.EquipmentProperties.Add(equipmentProperty);
        }

        public void Delete(EquipmentProperty equipmentProperty)
        {
            _context.EquipmentProperties.Remove(equipmentProperty);
        }
    }
}
