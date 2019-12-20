using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface IPhoneTypeService : IService<PhoneType> { }
    public class PhoneTypeService : Service<PhoneType>, IPhoneTypeService
    {
        public PhoneTypeService(IRepositoryAsync<PhoneType> repository) : base(repository)
        {
        }
    }
}