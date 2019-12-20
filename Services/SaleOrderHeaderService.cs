using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface ISaleOrderHeaderService : IService<SaleOrderHeader> { }
    public class SaleOrderHeaderService : Service<SaleOrderHeader>, ISaleOrderHeaderService
    {
        public SaleOrderHeaderService(IRepositoryAsync<SaleOrderHeader> repository) : base(repository)
        {
        }
    }
}