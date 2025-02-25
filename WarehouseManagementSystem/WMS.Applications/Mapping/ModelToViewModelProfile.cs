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
            CreateMap<Person, PersonDTO>()
                .ForMember(s => s.EmployeeType, s => s.MapFrom(s => s.role.ToString()));

        }




    }
}
