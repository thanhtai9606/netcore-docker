using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface IBusinessEntityService : IService<BusinessEntity> { }
    public class BusinessEntityService : Service<BusinessEntity>, IBusinessEntityService
    {
        public BusinessEntityService(IRepositoryAsync<BusinessEntity> repository) : base(repository)
        {
        }
    }
}