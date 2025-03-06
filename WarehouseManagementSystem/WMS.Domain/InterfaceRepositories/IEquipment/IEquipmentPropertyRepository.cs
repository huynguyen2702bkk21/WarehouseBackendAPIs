namespace WMS.Domain.InterfaceRepositories.IEquipment
{
    public interface IEquipmentPropertyRepository : IRepository<EquipmentProperty>
    {
        Task<List<EquipmentProperty>> GetAllAsync();
        Task<EquipmentProperty> GetByIdAsync(string id);
        void Create(EquipmentProperty equipmentProperty);
        void Delete(EquipmentProperty equipmentProperty);
    }
}
