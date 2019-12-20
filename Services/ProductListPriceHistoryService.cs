using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface IProductListPriceHistoryService : IService<ProductListPriceHistory> { }
    public class ProductListPriceHistoryService : Service<ProductListPriceHistory>, IProductListPriceHistoryService
    {
        public ProductListPriceHistoryService(IRepositoryAsync<ProductListPriceHistory> repository) : base(repository)
        {
        }
    }
}