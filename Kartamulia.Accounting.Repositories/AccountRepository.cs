using Kartamulia.Accounting.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kartamulia.Accounting.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAccounts(CancellationToken cancellationToken);

        Task<Account> GetAccount(string accountNumber, CancellationToken cancellationToken);
    }

    public class AccountRepository : IAccountRepository
    {
        private static List<Account> _accounts = new List<Account>()
        {

        };

        #region ctor

        public AccountRepository()
        {
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<Account>> GetAccounts(CancellationToken cancellationToken)
        {
            return await Task.FromResult(_accounts);
        } 

        public async Task<Account> GetAccount(string accountNumber, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_accounts.FirstOrDefault(x => x.Number == accountNumber));
        }

        #endregion
    }
}
