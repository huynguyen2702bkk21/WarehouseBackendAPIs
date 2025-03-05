namespace WMS.Domain.InterfaceRepositories.IEquipment
{
    public interface IEquipmentRepository : IRepository<Equipment>
    {
        Task<List<Equipment>> GetAllAsync();
        Task<Equipment> GetByIdAsync(string equipmentId);    
    }
}
