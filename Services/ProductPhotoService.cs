using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface IProductPhotoService : IService<ProductPhoto> { }
    public class ProductPhotoService : Service<ProductPhoto>, IProductPhotoService
    {
        public ProductPhotoService(IRepositoryAsync<ProductPhoto> repository) : base(repository)
        {
        }
    }
}