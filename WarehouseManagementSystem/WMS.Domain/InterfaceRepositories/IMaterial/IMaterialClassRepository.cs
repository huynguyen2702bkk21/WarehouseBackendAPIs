namespace WMS.Domain.InterfaceRepositories.IMaterial
{
    public interface IMaterialClassRepository : IRepository<MaterialClass>
    {
        Task<List<MaterialClass>> GetAllAsync();

    }
}
