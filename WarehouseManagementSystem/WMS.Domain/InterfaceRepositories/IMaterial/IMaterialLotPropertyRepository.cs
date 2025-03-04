﻿namespace WMS.Domain.InterfaceRepositories.IMaterial
{
    public interface IMaterialLotPropertyRepository : IRepository<MaterialLotProperty>
    {
        Task<List<MaterialLotProperty>> GetAllAsync();
        Task<MaterialLotProperty> GetMaterialLotPropertyById(string id);
    }
}
