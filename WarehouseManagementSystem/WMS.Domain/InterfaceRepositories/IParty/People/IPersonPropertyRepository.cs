namespace WMS.Domain.InterfaceRepositories.IParty.People
{
    public interface IPersonPropertyRepository: IRepository<PersonProperty>
    {
        Task<PersonProperty> GetByIdAsync(string propertyId);
        Task<List<PersonProperty>> GetAllPersonProperties();

        void Create(PersonProperty personProperty);
        void Delete(PersonProperty personProperty);


    }
}
