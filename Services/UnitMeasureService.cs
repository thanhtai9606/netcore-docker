using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface IUnitMeasureService : IService<UnitMeasure> { }
    public class UnitMeasureService : Service<UnitMeasure>, IUnitMeasureService
    {
        public UnitMeasureService(IRepositoryAsync<UnitMeasure> repository) : base(repository)
        {
        }
    }
}