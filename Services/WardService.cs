using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface IWardService : IService<Ward> { }
    public class WardService : Service<Ward>, IWardService
    {
        public WardService(IRepositoryAsync<Ward> repository) : base(repository)
        {
        }
    }
}