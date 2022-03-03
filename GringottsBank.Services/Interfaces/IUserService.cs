using GringottsBank.Entities.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GringottsBank.Services.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string name, string password);
        IEnumerable<User> GetAll();
        Task InsertAsync(User user);
        bool IsUserExist(User user);
    }
}
