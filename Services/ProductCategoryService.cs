using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface IProductCategoryService : IService<ProductCategory> { }
    public class ProductCategoryService : Service<ProductCategory>, IProductCategoryService
    {
        public ProductCategoryService(IRepositoryAsync<ProductCategory> repository) : base(repository)
        {
        }
    }
}