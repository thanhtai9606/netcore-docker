using acb_app.Models;
using BecamexIDC.Pattern.EF.Repositories;
using BecamexIDC.Pattern.Services;
namespace acb_app.Repositories.Services
{
    public interface ITransactionHistoryService : IService<TransactionHistory> { }
    public class TransactionHistoryService : Service<TransactionHistory>, ITransactionHistoryService
    {
        public TransactionHistoryService(IRepositoryAsync<TransactionHistory> repository) : base(repository)
        {
        }
    }
}