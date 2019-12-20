using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface IPurchaseOrderHeaderService : IService<PurchaseOrderHeader> { }
    public class PurchaseOrderHeaderService : Service<PurchaseOrderHeader>, IPurchaseOrderHeaderService
    {
        public PurchaseOrderHeaderService(IRepositoryAsync<PurchaseOrderHeader> repository) : base(repository)
        {
        }
    }
}