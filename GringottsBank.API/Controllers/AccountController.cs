using GringottsBank.Core.Entities.Base;
using GringottsBank.Entities.Account;
using GringottsBank.Extensions;
using GringottsBank.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GringottsBank.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AccountController: BaseController
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetAccountById(string accountId)
        {
            var result = await _accountService.GetUserAccountById(GetUserId(), accountId);
            if (result == null)
            {
                throw new GringottsBankApiException("User Account not found !!!");
            }
            return Json(result.ToAccountViewModel());
        }

        [HttpGet]
        public async Task<IActionResult> GetUserAccounts()
        {
            var userId = GetUserId();
            var userAccounts = _accountService.GetUserAccounts(userId);
            return Json(userAccounts.ToAccountListViewModel());
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddUserAccounts(Account account)
        {
            var userId = GetUserId();
            await _accountService.AddUserAccounts(userId,account);
            return Json(account.ToAccountViewModel());
        }

       
    }
}
