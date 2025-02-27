using WMS.Application.DTOs.MaterialDTOs;
using WMS.Domain.AggregateModels.MaterialAggregate;

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
            MapMaterialClassViewModel();
            MapMaterialClassPropertyViewModel();
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

        public void MapMaterialClassViewModel()
        {
            CreateMap<MaterialClass, MaterialClassDTO>();
        }

        public void MapMaterialClassPropertyViewModel()
        {
            CreateMap<MaterialClassProperty, MaterialClassPropertyDTO>()
                .ForMember(s => s.UnitOfMeasure, s => s.MapFrom(s => s.unitOfMeasure.ToString()));
        }

    }
}
