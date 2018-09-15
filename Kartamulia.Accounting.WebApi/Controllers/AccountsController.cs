using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Kartamulia.Accounting.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kartamulia.Accounting.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Accounts")]
    public class AccountsController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        #region ctor

        public AccountsController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        #endregion

        // GET: api/Accounts
        [HttpGet]
        public async Task<IActionResult> GetAccounts(CancellationToken cancellationToken)
        {
            return this.Ok(await _accountRepository.GetAccounts(cancellationToken));
        }

        // GET: api/Accounts/5
        [HttpGet("{accountNumber}", Name = "GetAccount")]
        public async Task<IActionResult> GetAccount(string accountNumber, CancellationToken cancellationToken)
        {
            return this.Ok(await _accountRepository.GetAccount(accountNumber, cancellationToken));
        }
        
        //// POST: api/Accounts
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}
        
        //// PUT: api/Accounts/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}
        
        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
