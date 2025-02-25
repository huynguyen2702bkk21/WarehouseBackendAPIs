using WMS.Application.DTOs.PartyDTOs;
using WMS.Domain.AggregateModels.PartyAggregate;
using WMS.Domain.Enum;

namespace WMS.Application.Mapping
{
    public class ModelToViewModelProfile : Profile
    {
        public ModelToViewModelProfile()
        {
            MapPersonViewModel();
        }

        public void MapPersonViewModel()
        {
            CreateMap<Person, PersonDTO>();



        }




    }
}
