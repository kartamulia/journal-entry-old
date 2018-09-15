using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kartamulia.Accounting.NetCoreMvcClient.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kartamulia.Accounting.NetCoreMvcClient.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountsController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<IActionResult> Index()
        {
            var accounts = await _accountRepository.GetAccountsAsync();
            return View(accounts);
        }
    }
}