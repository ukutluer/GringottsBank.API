using GringottsBank.Core.Entities.Base;
using GringottsBank.Entities.AccountTransaction;
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
    public class AccountTransactionController : BaseController
    {
        private readonly IAccountTransactionService _accountTransactionService;
        public AccountTransactionController(IAccountTransactionService accountTransactionService)
        {
            _accountTransactionService = accountTransactionService;
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetUserAccountTransactions(string accountId)
        {
            var accountTransactions = _accountTransactionService.GetAccountTransactions(GetUserId(), accountId);
            if (accountTransactions == null)
                throw new GringottsBankApiException("There is no account transaction !!!");
            return Json(accountTransactions.ToAccountListViewModel());
        }

        [HttpPost("AddUserAccountTransaction")]
        public async Task<IActionResult> AddUserAccountTransaction(AccountTransaction accountTransaction)
        {
            await _accountTransactionService.AddAccountTransaction(GetUserId(), accountTransaction);
            return Json(new BaseGringottsBankApiResponse());
        }

        [HttpPost("GetUserAllAccountTransaction")]
        public async Task<IActionResult> GetUserAllAccountTransaction(UserAccountTransactionRequest accountTransactionFilter)
        {
            var userAccountTransactions = await _accountTransactionService.GetUserTransactions(GetUserId(), accountTransactionFilter.StartDate, accountTransactionFilter.EndDate);
            return Json(userAccountTransactions.ToUserAccountTransactionListViewModel());
        }


    }
}
