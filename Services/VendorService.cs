using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface IVendorService : IService<Vendor> { }
    public class VendorService : Service<Vendor>, IVendorService
    {
        public VendorService(IRepositoryAsync<Vendor> repository) : base(repository)
        {
        }
    }
}