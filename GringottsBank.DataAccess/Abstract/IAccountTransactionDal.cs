using GringottsBank.Entities.AccountTransaction;
using System;

namespace GringottsBank.DataAccess.Abstract
{
    public interface IAccountTransactionDal : IRepository<AccountTransaction, string>
    {
    }
}
