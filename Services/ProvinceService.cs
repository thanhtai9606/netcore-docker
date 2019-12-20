using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface IProvinceService : IService<Province> { }
    public class ProvinceService : Service<Province>, IProvinceService
    {
        public ProvinceService(IRepositoryAsync<Province> repository) : base(repository)
        {
        }
    }
}