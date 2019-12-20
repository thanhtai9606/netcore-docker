using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface IBusinessEntityAddressService : IService<BusinessEntityAddress> { }
    public class BusinessEntityAddressService : Service<BusinessEntityAddress>, IBusinessEntityAddressService
    {
        public BusinessEntityAddressService(IRepositoryAsync<BusinessEntityAddress> repository) : base(repository)
        {
        }
    }
}