namespace WMS.Domain.InterfaceRepositories.IEquipment
{
    public interface IEquipmentCLassPropertyRepository : IRepository<EquipmentClassProperty>
    {
        Task<IEnumerable<EquipmentClassProperty>> GetAllAsync();
        Task<EquipmentClassProperty> GetByIdAsync(string propertyId);
    }
}
