using GringottsBank.Core.Entities.Settings;
using GringottsBank.DataAccess.Abstract;
using GringottsBank.Entities.AccountTransaction;
using Microsoft.Extensions.Options;

namespace GringottsBank.DataAccess.Concrete
{
    public class AccountTransactionMongoDbDal : MongoDbRepositoryBase<AccountTransaction>, IAccountTransactionDal
    {
        public AccountTransactionMongoDbDal(IOptions<MongoDbSettings> options) : base(options)
        {

        }

    }

}
