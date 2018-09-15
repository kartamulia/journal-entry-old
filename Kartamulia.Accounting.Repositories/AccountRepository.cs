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
            new Account(){ Number = "111", IsActive = true, Name = "Cash" },
            new Account(){ Number = "112", IsActive = true, Name = "Accounts Receivable" },
            new Account(){ Number = "114", IsActive = true, Name = "Office Supplies" },
            new Account(){ Number = "115", IsActive = true, Name = "Prepaid Rent" },
            new Account(){ Number = "121", IsActive = true, Name = "Word Processing Equipment" },
            new Account(){ Number = "122", IsActive = true, Name = "Accumulated Depreciations, Word Processing Equipment" },

            new Account(){ Number = "211", IsActive = true, Name = "Accounts Payable" },
            new Account(){ Number = "212", IsActive = true, Name = "Salaries Payable" },
            new Account(){ Number = "311", IsActive = true, Name = "X, Capital" },
            new Account(){ Number = "312", IsActive = true, Name = "X, Withdrawals" },
            new Account(){ Number = "313", IsActive = true, Name = "Income Summary" },

            new Account(){ Number = "411", IsActive = true, Name = "Word Processing Fees" },

            new Account(){ Number = "511", IsActive = true, Name = "Office Salaries Expense" },
            new Account(){ Number = "512", IsActive = true, Name = "Advertising Expense" },
            new Account(){ Number = "513", IsActive = true, Name = "Telephone Expense" },
            new Account(){ Number = "514", IsActive = true, Name = "Office Supplies Expense" },
            new Account(){ Number = "515", IsActive = true, Name = "Rent Expense" },
            new Account(){ Number = "516", IsActive = true, Name = "Depreciation Expense, Word Processing Equipment" },
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
