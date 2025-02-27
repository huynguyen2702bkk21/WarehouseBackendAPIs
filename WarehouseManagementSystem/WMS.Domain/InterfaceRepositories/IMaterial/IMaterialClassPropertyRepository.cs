namespace WMS.Domain.InterfaceRepositories.IMaterial
{
    public interface IMaterialClassPropertyRepository : IRepository<MaterialClassProperty>
    {
        Task<List<MaterialClassProperty>> GetAllAsync();
    }
}
