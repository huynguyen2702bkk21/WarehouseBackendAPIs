namespace WMS.Domain.InterfaceRepositories.IEquipment
{
    public interface IEquipmentCLassPropertyRepository : IRepository<EquipmentClassProperty>
    {
        Task<List<EquipmentClassProperty>> GetAllAsync();
        Task<EquipmentClassProperty> GetByIdAsync(string propertyId);
        void Create(EquipmentClassProperty equipmentClassProperty);
        void Delete(EquipmentClassProperty equipmentClassProperty);
    }
}
