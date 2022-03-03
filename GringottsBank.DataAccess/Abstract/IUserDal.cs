using GringottsBank.Entities.User;

namespace GringottsBank.DataAccess.Abstract
{
    public interface IUserDal : IRepository<User, string>
    {
    }
}
