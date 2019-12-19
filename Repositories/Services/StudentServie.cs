using acb_app.Models;
using acb_app.Repositories.Contract;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;

namespace acb_app.Repositories.Services
{
    public class PhoneService : Service<Phone>, IPhoneService
    {
        public PhoneService(IRepositoryAsync<Phone> repository) : base(repository)
        {
        }
    }
}