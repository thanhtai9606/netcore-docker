using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface IProductProductPhotoService : IService<ProductProductPhoto> { }
    public class ProductProductPhotoService : Service<ProductProductPhoto>, IProductProductPhotoService
    {
        public ProductProductPhotoService(IRepositoryAsync<ProductProductPhoto> repository) : base(repository)
        {
        }
    }
}