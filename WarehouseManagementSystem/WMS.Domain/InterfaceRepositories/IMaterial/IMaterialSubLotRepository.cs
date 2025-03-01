namespace WMS.Domain.InterfaceRepositories.IMaterial
{
    public interface IMaterialSubLotRepository : IRepository<MaterialSubLot>
    {
        Task<List<MaterialSubLot>> GetAllAsync();
        Task<List<MaterialSubLot>> GetMaterialSubLotsByLocationId(string locationId);
    }
}
