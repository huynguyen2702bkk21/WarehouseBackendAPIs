﻿namespace WMS.Application.Mapping
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

            MapMaterialSubLotPropertyViewModel();

            MapMaterialViewModel();  
            MapMaterialPropertyViewModel();

            MapMaterialLotViewModel();
            MapMaterialLotPropertyViewModel();

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
            CreateMap<Location, LocationDTO>()
                .ForMember(s => s.MaterialSubLotDTOs, s => s.MapFrom(s => s.materialSubLots));
        }

        public void MapWarehouseViewModel()
        {
            CreateMap<Warehouse, WarehouseDTO>()
                .ForMember(s => s.Locations, s => s.MapFrom(s => s.locations));
        }

        public void MapMaterialClassViewModel()
        {
            CreateMap<MaterialClass, MaterialClassDTO>()
                .ForMember(s => s.Properties, s => s.MapFrom(s => s.properties))
                .ForMember(s => s.MaterialDTOs, s => s.MapFrom(s => s.materials));
        }

        public void MapMaterialClassPropertyViewModel()
        {
            CreateMap<MaterialClassProperty, MaterialClassPropertyDTO>()
                .ForMember(s => s.UnitOfMeasure, s => s.MapFrom(s => s.unitOfMeasure.ToString()));
        }

        public void MapMaterialSubLotPropertyViewModel()
        {
            CreateMap<MaterialSubLot, MaterialSubLotDTO>()
                .ForMember(s => s.UnitOfMeasure, s => s.MapFrom(s => s.unitOfMeasure.ToString()))
                .ForMember(s => s.SubLotStatus, s => s.MapFrom(s => s.subLotStatus.ToString()));
        }

        public void MapMaterialViewModel()
        {
            CreateMap<Material, MaterialDTO>()
                .ForMember(s => s.Properties, s => s.MapFrom(s => s.properties));

        }

        public void MapMaterialPropertyViewModel()
        {
            CreateMap<MaterialProperty, MaterialPropertyDTO>()
                .ForMember(s => s.UnitOfMeasure, s => s.MapFrom(s => s.unitOfMeasure.ToString()));
        }

        public void MapMaterialLotViewModel()
        {
            CreateMap<MaterialLot, MaterialLotDTO>()
                .ForMember(s => s.SubLots, s => s.MapFrom(s => s.subLots))
                .ForMember(s => s.Properties, s => s.MapFrom(s => s.properties))
                .ForMember(s => s.LotStatus, s => s.MapFrom(s => s.lotStatus.ToString()));

        }

        public void MapMaterialLotPropertyViewModel()
        {
            CreateMap<MaterialLotProperty, MaterialLotPropertyDTO>()
                .ForMember(s => s.UnitOfMeasure, s => s.MapFrom(s => s.unitOfMeasure.ToString()));
        }

    }
}
