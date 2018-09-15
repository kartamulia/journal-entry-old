using Kartamulia.Accounting.NetCoreMvcClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kartamulia.Accounting.NetCoreMvcClient.Repositories
{
    public interface IGeneralJournalRepository
    {
        Task<List<GeneralJournal>> GetGeneralJournalsAsync();
    }

    public class GeneralJournalRepository : IGeneralJournalRepository
    {
        private readonly string baseAddress = "http://localhost:65453/";

        #region ctor

        public GeneralJournalRepository()
            : base()
        {
        }

        #endregion

        #region Methods

        public async Task<List<GeneralJournal>> GetGeneralJournalsAsync()
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
                        return await response.Content.ReadAsAsync<List<GeneralJournal>>();
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

    }
}
