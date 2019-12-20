using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface IPhoneService : IService<Phone> { }
    public class PhoneService : Service<Phone>, IPhoneService
    {
        public PhoneService(IRepositoryAsync<Phone> repository) : base(repository)
        {
        }
    }
}