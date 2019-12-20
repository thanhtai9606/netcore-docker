using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface IEmployeeService : IService<Employee> { }
    public class EmployeeService : Service<Employee>, IEmployeeService
    {
        public EmployeeService(IRepositoryAsync<Employee> repository) : base(repository)
        {
        }
    }
}