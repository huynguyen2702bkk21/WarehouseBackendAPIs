namespace WMS.Domain.InterfaceRepositories.IMaterial
{
    public interface IMaterialSubLotRepository : IRepository<MaterialSubLot>
    {
        Task<List<MaterialSubLot>> GetAllAsync();
        Task<List<MaterialSubLot>> GetMaterialSubLotsByLocationId(string locationId);
        Task<MaterialSubLot> GetByIdAsync(string Id);
        Task<List<MaterialSubLot>> GetMaterialSubLotsByLotNumber(string lotNumber);
        Task<List<MaterialSubLot>> GetMaterialSubLotsByStatus(string Status);
        void Create(MaterialSubLot materialSubLot);
        void Delete(MaterialSubLot materialSubLot);
    }
}
