using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface ISaleOrderDetailService : IService<SalesOrderDetail> { }
    public class SaleOrderDetailService : Service<SalesOrderDetail>, ISaleOrderDetailService
    {
        public SaleOrderDetailService(IRepositoryAsync<SalesOrderDetail> repository) : base(repository)
        {
        }
    }
}