using GringottsBank.Core.Entities.Base;
using GringottsBank.Entities.User;
using GringottsBank.Extensions;
using GringottsBank.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GringottsBank.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : BaseController
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate(User userParam)
        {
            var user = _userService.Authenticate(userParam.Name, userParam.Password);
            if (user == null)
                throw new GringottsBankApiException("User & Password wrong !!!");

            return Json(user.ToUserViewModel());
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Json(users.ToUserListViewModel());
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register(User user)
        {
            if (_userService.IsUserExist(user))
                throw new GringottsBankApiException("User already exist.");
            _userService.InsertAsync(user);
            return Json(new BaseGringottsBankApiResponse());
        }
    }
}
