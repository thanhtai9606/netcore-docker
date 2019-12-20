using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface IPurchaseOrderDetailService : IService<PurchaseOrderDetail> { }
    public class PurchaseOrderDetailService : Service<PurchaseOrderDetail>, IPurchaseOrderDetailService
    {
        public PurchaseOrderDetailService(IRepositoryAsync<PurchaseOrderDetail> repository) : base(repository)
        {
        }
    }
}