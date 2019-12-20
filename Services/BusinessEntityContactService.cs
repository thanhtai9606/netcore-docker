using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface IBusinessEntityContactService : IService<BusinessEntityContact> { }
    public class BusinessEntityContactService : Service<BusinessEntityContact>, IBusinessEntityContactService
    {
        public BusinessEntityContactService(IRepositoryAsync<BusinessEntityContact> repository) : base(repository)
        {
        }
    }
}