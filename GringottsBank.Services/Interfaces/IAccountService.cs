using GringottsBank.Entities.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GringottsBank.Services.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetUserAccounts(string userId);
        Task AddUserAccounts(string userId, Account account);
        Task<Account>  GetUserAccountById(string userId, string accountId);
    }
}
