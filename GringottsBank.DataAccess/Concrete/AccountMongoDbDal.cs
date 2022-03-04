using GringottsBank.Core.Entities.Settings;
using GringottsBank.DataAccess.Abstract;
using GringottsBank.Entities.Account;
using Microsoft.Extensions.Options;

namespace GringottsBank.DataAccess.Concrete
{
    public class AccountMongoDbDal : MongoDbRepositoryBase<Account>, IAccountDal
    {
        public AccountMongoDbDal(IOptions<MongoDbSettings> options) : base(options)
        {
        }
    }
}
