﻿using WMS.Application.DTOs.StorageDTOs;

namespace WMS.Application.Queries.StorageQueries.Warehouses
{
    public class GetAllWarehouseQuery : IRequest<IEnumerable<WarehouseDTO>>
    {
        public GetAllWarehouseQuery() { }
    }

}
