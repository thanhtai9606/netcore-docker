using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface IProductInventoryService : IService<ProductInventory> { }
    public class ProductInventoryService : Service<ProductInventory>, IProductInventoryService
    {
        public ProductInventoryService(IRepositoryAsync<ProductInventory> repository) : base(repository)
        {
        }
    }
}