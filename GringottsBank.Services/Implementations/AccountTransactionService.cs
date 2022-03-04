using GringottsBank.Core.Entities.Base;
using GringottsBank.DataAccess.Abstract;
using GringottsBank.Entities.AccountTransaction;
using GringottsBank.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GringottsBank.Services.Implementations
{
    public class AccountTransactionService : IAccountTransactionService
    {
        private readonly IAccountTransactionDal _accountTransactionDal;
        private readonly IAccountDal _accountDal;

        public AccountTransactionService(IAccountTransactionDal accountTransactionDal, IAccountDal accountDal)
        {
            _accountTransactionDal = accountTransactionDal;
            _accountDal = accountDal;
        }

        public IEnumerable<AccountTransaction> GetAccountTransactions(string userId, string accountId)
        {
            return _accountTransactionDal.Get(q => q.UserId == userId && q.AccountId == accountId);
        }

        public async Task AddAccountTransaction(string userId, AccountTransaction accountTransaction)
        {
            Action<AccountTransaction, string> customActionForAccountTransaction = BeginAccountTransactionOperations;
            await _accountTransactionDal.BeginComplexTransaction(customActionForAccountTransaction, new object[] { accountTransaction, userId });
        }

        public void BeginAccountTransactionOperations(AccountTransaction txn, string userId)
        {
            var account = _accountDal.GetAsync(q => q.Id == txn.AccountId && q.UserId == userId).Result;
            if(account == null)
                throw new GringottsBankApiException("Account not found !!!");
            account.Balance += txn.TransactionAmount;
            txn.UserId = userId;
            txn.AccountId = account.Id;
            _accountTransactionDal.AddAsync(txn);
            _accountDal.UpdateAsync(account, q => q.Id == account.Id);
        }

        public IEnumerable<UserAccountTransactions> GetUserTransactions(string userId, DateTime startDate, DateTime endDate)
        {
            var accountTransactions = _accountTransactionDal.Get(q => q.UserId == userId
                                                                 && q.CreatedAt >= startDate
                                                                 && q.CreatedAt <= endDate);

            
            List<UserAccountTransactions> txnList = new List<UserAccountTransactions>();
            foreach (var item in accountTransactions)
            {
                var txnItemInList = txnList.FirstOrDefault(q => q.AccountId == item.AccountId);
                if (txnItemInList == null)
                {
                    var txnItem = new UserAccountTransactions();
                    txnItem.AccountId = item.AccountId;
                    txnItem.Account = _accountDal.Get(q => q.Id == item.AccountId).FirstOrDefault();
                    txnItem.AccountTransactions = new List<AccountTransaction>();
                    txnItem.AccountTransactions.Add(item);
                    txnList.Add(txnItem);
                }
                else
                {
                    txnItemInList.AccountTransactions.Add(item);
                }
            }
            return txnList;
        }
    }
}
