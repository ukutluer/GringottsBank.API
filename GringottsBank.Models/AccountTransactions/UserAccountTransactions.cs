using GringottsBank.Core.Entities.Abstract;
using System.Collections.Generic;

namespace GringottsBank.Entities.AccountTransaction
{
    public class UserAccountTransactions
    {
        public string AccountId { get; set; }
        public Account.Account Account { get; set; }

        public List<AccountTransaction> AccountTransactions{ get; set; }
    }
}
