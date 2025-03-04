namespace WMS.Domain.InterfaceRepositories.IMaterial
{
    public interface IMaterialRepository : IRepository<Material>
    {
        Task<List<Material>> GetAllAsync();
        Task<Material> GetByIdAsync(string materialId);
        Task<MaterialClass> GetByClassIdAsync(string classId);
    }
}
