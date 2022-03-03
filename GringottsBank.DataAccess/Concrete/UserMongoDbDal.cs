using GringottsBank.Core.Entities.Settings;
using GringottsBank.DataAccess.Abstract;
using GringottsBank.Entities.User;
using Microsoft.Extensions.Options;

namespace GringottsBank.DataAccess.Concrete
{
    public class UserMongoDbDal : MongoDbRepositoryBase<User>, IUserDal
    {
        public UserMongoDbDal(IOptions<MongoDbSettings> options) : base(options)
        {
        }
    }
}
