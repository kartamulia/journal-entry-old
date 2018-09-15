using Kartamulia.Accounting.NetCoreMvcClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kartamulia.Accounting.NetCoreMvcClient.Repositories
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAccountsAsync();
    }

    public class AccountRepository : IAccountRepository
    {
        private readonly string baseAddress = "http://localhost:65453/";

        #region ctor

        public AccountRepository()
            : base()
        {
        }

        #endregion

        #region Methods

        public async Task<List<Account>> GetAccountsAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    string requestUri = "api/accounts";
                    var response = await client.GetAsync(requestUri);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return await response.Content.ReadAsAsync<List<Account>>();
                    }
                    else
                    {
                        throw new Exception(response.StatusCode.ToString());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Events

        #endregion
    }
}
