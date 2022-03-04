using GringottsBank.Entities.AccountTransaction;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GringottsBank.Services.Interfaces
{
    public interface IAccountTransactionService
    {
        IEnumerable<AccountTransaction> GetAccountTransactions(string userId, string accountId);
        Task AddAccountTransaction(string userId, AccountTransaction accountTransaction);
        IEnumerable<UserAccountTransactions> GetUserTransactions(string userId, DateTime startDate, DateTime endDate);
    }
}
