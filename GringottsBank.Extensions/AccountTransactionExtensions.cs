using GringottsBank.Core.Entities.Base;
using GringottsBank.Entities.Account;
using GringottsBank.Entities.AccountTransaction;
using GringottsBank.Entities.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace GringottsBank.Extensions
{
    public static class AccountTransactionExtensions
    {
        public static BaseGringottsBankApiResponse ToAccountViewModel(this AccountTransaction accountTransaction)
        {
            var response = new BaseGringottsBankApiResponse();
            response.Body = MapAccountTransactionToViewModel(accountTransaction);
            return response;
        }

        public static BaseGringottsBankApiResponse ToAccountListViewModel(this IEnumerable<AccountTransaction> accountTransactions)
        {
            var response = new BaseGringottsBankApiResponse();
            response.Body = from item in accountTransactions select MapAccountTransactionToViewModel(item);
            return response;
        }

        public static BaseGringottsBankApiResponse ToUserAccountTransactionListViewModel(this IEnumerable<UserAccountTransactions> userAccountTransactions)
        {
            var response = new BaseGringottsBankApiResponse();
            response.Body = from item in userAccountTransactions select MapUserAccountTransactionToViewModel(item);
            return response;
        }

        private static object MapAccountTransactionToViewModel(AccountTransaction account)
        {
            return new
            {
                TransactionDate = account.CreatedAt.ToShortDateString(),
                TransactionAmount = account.TransactionAmount,
            };
        }

        private static object MapUserAccountTransactionToViewModel(UserAccountTransactions userAccountTransaction)
        {
            return new
            {
                AccountNumber = userAccountTransaction?.Account?.AccountNumber,
                AccountBalance = userAccountTransaction?.Account?.Balance,
                AccountTransactions = from item in userAccountTransaction.AccountTransactions select new
                {
                    TransactionDate = item.CreatedAt.ToShortDateString(),
                    TransactionAmount = item.TransactionAmount
                }
            };
        }
    }
}
