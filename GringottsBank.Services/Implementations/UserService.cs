using GringottsBank.Core.Entities;
using GringottsBank.DataAccess.Abstract;
using GringottsBank.Entities.User;
using GringottsBank.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GringottsBank.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IUserDal _userDal;

        public UserService(IOptions<AppSettings> appSettings, IUserDal userDal)
        {
            _appSettings = appSettings.Value;
            _userDal = userDal;
        }

        public IEnumerable<User> GetAll()
        {
            // all user passwords setted null
            return _userDal.Get().ToList().Select(x =>
            {
                x.Password = null;
                return x;
            });
        }

        public bool IsUserExist(User user)
        {
            return _userDal.Get(q => q.Name.ToLower() == user.Name.ToLower()).FirstOrDefault() != null;
        }

        public async Task InsertAsync(User user)
        {
            await _userDal.AddAsync(user);
        }

        User IUserService.Authenticate(string name, string password)
        {
            var user = _userDal.Get(q=>q.Name == name & q.Password == password).FirstOrDefault();

            // if user not found return null
            if (user == null)
                return null;

            // if authentication is success then generate jwttoken
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // password sending null
            user.Password = null;

            return user;
        }
    }
}