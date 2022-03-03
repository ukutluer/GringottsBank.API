using GringottsBank.Core.Entities.Base;
using GringottsBank.Entities.Account;
using GringottsBank.Entities.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace GringottsBank.Extensions
{
    public static class AccountExtensions
    {
        public static AccountViewModelResponse ToAccountViewModel(this Account account)
        {
            var response = new AccountViewModelResponse();
            response.Body = MapAccountToAccountViewModel(account);
            return response;
        }

        public static BaseGringottsBankApiResponse ToAccountListViewModel(this IEnumerable<Account> accounts)
        {
            var response = new BaseGringottsBankApiResponse();
            response.Body = from item in accounts select MapAccountToAccountViewModel(item);
            return response;
        }

        private static object MapAccountToAccountViewModel(Account account)
        {
            return new
            {
                AccountNumber = account.AccountNumber,
                Balance = account.Balance,
                Currency = account.Currency
            };
        }
    }
}
