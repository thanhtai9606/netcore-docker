using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface IContactTypeService : IService<ContactType> { }
    public class ContactTypeService : Service<ContactType>, IContactTypeService
    {
        public ContactTypeService(IRepositoryAsync<ContactType> repository) : base(repository)
        {
        }
    }
}