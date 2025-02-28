namespace WMS.Domain.InterfaceRepositories.IMaterial
{
    public interface IMaterialClassPropertyRepository : IRepository<MaterialClassProperty>
    {
        Task<List<MaterialClassProperty>> GetAllAsync();
        Task<MaterialClassProperty> GetByIdAsync(string id);
        void AddAsync(MaterialClassProperty materialClassProperty);

    }
}
