namespace WMS.Domain.InterfaceRepositories.IMaterial
{
    public interface IMaterialLotRepository : IRepository<MaterialLot>
    {
        Task<List<MaterialLot>> GetAllAsync();
        Task<MaterialLot> GetMaterialLotById(string lotNumber);
        Task<List<MaterialLot>> GetMaterialLotsByMaterialId(string materialId);
        Task<List<MaterialLot>> GetMaterialLotsByStatus(string status);
    }
}
