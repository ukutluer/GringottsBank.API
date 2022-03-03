using GringottsBank.Entities.Account;

namespace GringottsBank.DataAccess.Abstract
{
    public interface IAccountDal : IRepository<Account, string>
    {
    }
}
