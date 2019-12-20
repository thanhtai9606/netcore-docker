using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface IBusinessEntityPhoneService : IService<BusinessEntityPhone> { }
    public class BusinessEntityPhoneService : Service<BusinessEntityPhone>, IBusinessEntityPhoneService
    {
        public BusinessEntityPhoneService(IRepositoryAsync<BusinessEntityPhone> repository) : base(repository)
        {
        }
    }
}