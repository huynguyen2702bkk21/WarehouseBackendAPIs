namespace WMS.Domain.InterfaceRepositories.IEquipment
{
    public interface IEquipmentClassRepository : IRepository<EquipmentClass>
    {
        Task<List<EquipmentClass>> GetAllAsync();
        Task<EquipmentClass> GetByIdAsync(string EquipmentClassId);
        void Create(EquipmentClass equipmentClass);
        void Delete(EquipmentClass equipmentClass);
    }
}
