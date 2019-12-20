using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface IDistrictService : IService<District> { }
    public class DistrictService : Service<District>, IDistrictService
    {
        public DistrictService(IRepositoryAsync<District> repository) : base(repository)
        {
        }
    }
}