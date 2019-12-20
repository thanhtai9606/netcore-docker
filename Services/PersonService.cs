using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface IPersonService : IService<Person> { }
    public class PersonService : Service<Person>, IPersonService
    {
        public PersonService(IRepositoryAsync<Person> repository) : base(repository)
        {
        }
    }
}