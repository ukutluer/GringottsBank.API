using GringottsBank.Entities.AccountTransaction;

namespace GringottsBank.DataAccess.Abstract
{
    public interface IAccountTransactionDal : IRepository<AccountTransaction, string>
    {
    }
}
