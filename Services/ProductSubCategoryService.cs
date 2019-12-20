using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface IProductSubCategoryService : IService<ProductSubCategory> { }
    public class ProductSubCategoryService : Service<ProductSubCategory>, IProductSubCategoryService
    {
        public ProductSubCategoryService(IRepositoryAsync<ProductSubCategory> repository) : base(repository)
        {
        }
    }
}