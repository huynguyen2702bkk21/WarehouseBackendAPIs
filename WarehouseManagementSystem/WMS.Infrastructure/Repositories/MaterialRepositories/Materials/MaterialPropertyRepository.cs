namespace WMS.Infrastructure.Repositories.MaterialRepositories
{
    public class MaterialPropertyRepository : BaseRepository, IMaterialPropertyRepository
    {
        public MaterialPropertyRepository(WMSDbContext context) : base(context)
        {
        }

        public void Create(MaterialProperty materialProperty)
        {
            _context.MaterialProperties.Add(materialProperty);
        }

        public void Delete(MaterialProperty materialProperty)
        {
            _context.MaterialProperties.Remove(materialProperty);
        }

        public async Task<List<MaterialProperty>> GetAllAsync()
        {
            return await _context.MaterialProperties.ToListAsync();
        }

        public async Task<MaterialProperty> GetByIdAsync(string materialPropertyId)
        {
            return await _context.MaterialProperties.FirstOrDefaultAsync(x => x.propertyId == materialPropertyId);
        }

        public void Update(MaterialProperty materialProperty)
        {
            _context.MaterialProperties.Update(materialProperty);
        }
    }
}
