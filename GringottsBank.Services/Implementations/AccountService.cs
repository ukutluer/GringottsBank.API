using GringottsBank.Core.Entities;
using GringottsBank.DataAccess.Abstract;
using GringottsBank.Entities.Account;
using GringottsBank.Services.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GringottsBank.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IAccountDal _accountDal;

        public AccountService(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }

        public IEnumerable<Account> GetUserAccounts(string userId)
        {
            return _accountDal.Get(q => q.UserId == userId);
        }

        public async Task AddUserAccounts(string userId, Account account)
        {
            account = account ?? new Account() { Currency = "TL" };
            account.AccountNumber = DateTime.Now.ToString("yyyyMMddHHmmss");
            account.UserId = userId;
            await _accountDal.AddAsync(account);
        }

        public async Task<Account> GetUserAccountById(string userId , string accountId)
        {
            return _accountDal.GetAsync(q=> q.UserId == userId && q.Id == accountId).Result;
        }
    }
}
