using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface IAddressService : IService<Address> { }
    public class AddressService : Service<Address>, IAddressService
    {
        public AddressService(IRepositoryAsync<Address> repository) : base(repository)
        {
        }
    }
}