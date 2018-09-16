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
        Task<GeneralJournal> AddOrUpdateGeneralJournalAsync(GeneralJournal generalJournal);
        Task<GeneralJournal> GetGeneralJournalAsync(int id);
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
                    string requestUri = "api/generaljournals";
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

        public async Task<GeneralJournal> AddOrUpdateGeneralJournalAsync(GeneralJournal generalJournal)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    string requestUri = "api/generaljournals";
                    HttpResponseMessage response = null;

                    if (generalJournal.Id == 0)
                    {
                        response = await client.PostAsJsonAsync<GeneralJournal>(requestUri, generalJournal);
                    }
                    else
                    {
                        response = await client.PutAsJsonAsync<GeneralJournal>(requestUri, generalJournal);
                    }

                    if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        return await response.Content.ReadAsAsync<GeneralJournal>();
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

        public async Task<GeneralJournal> GetGeneralJournalAsync(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    string requestUri = $"api/generaljournals/{id}";
                    var response = await client.GetAsync(requestUri);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return await response.Content.ReadAsAsync<GeneralJournal>();
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
