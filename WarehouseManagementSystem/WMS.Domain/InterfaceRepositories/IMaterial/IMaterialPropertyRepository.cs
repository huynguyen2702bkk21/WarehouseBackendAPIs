namespace WMS.Domain.InterfaceRepositories.IMaterial
{
    public interface IMaterialPropertyRepository : IRepository<MaterialProperty>
    {
        Task<List<MaterialProperty>> GetAllAsync();
        Task<MaterialProperty> GetByIdAsync(string materialPropertyId);

    }
}
