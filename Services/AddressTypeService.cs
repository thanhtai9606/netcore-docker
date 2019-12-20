using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface IAddressTypeService : IService<AddressType> { }
    public class AddressTypeService : Service<AddressType>, IAddressTypeService
    {
        public AddressTypeService(IRepositoryAsync<AddressType> repository) : base(repository)
        {
        }
    }
}