using WMS.Application.DTOs.StorageDTOs;
using WMS.Domain.AggregateModels.StorageAggregate;

namespace WMS.Application.Mapping
{
    public class ModelToViewModelProfile : Profile
    {
        public ModelToViewModelProfile()
        {
            MapPersonViewModel();
            MapCustomerViewModel();
            MapSupplierViewModel();
            MapLocationViewModel();
            MapWarehouseViewModel();
        }

        public void MapPersonViewModel()
        {
            CreateMap<Person, PersonDTO>()
                .ForMember(s => s.EmployeeType, s => s.MapFrom(s => s.role.ToString()));

        }

        public void MapCustomerViewModel()
        {
            CreateMap<Customer, CustomerDTO>();
        }

        public void MapSupplierViewModel()
        {
            CreateMap<Supplier, SupplierDTO>();
        }

        public void MapLocationViewModel()
        {
            CreateMap<Location, LocationDTO>();
        }

        public void MapWarehouseViewModel()
        {
            CreateMap<Warehouse, WarehouseDTO>();
        }

    }
}
