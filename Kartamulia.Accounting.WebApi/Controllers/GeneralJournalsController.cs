using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Kartamulia.Accounting.Entities;
using Kartamulia.Accounting.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kartamulia.Accounting.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/GeneralJournals")]
    public class GeneralJournalsController : Controller
    {
        private readonly IGeneralJournalRepository _generalJournalRepository;

        #region ctor

        public GeneralJournalsController(IGeneralJournalRepository generalJournalRepository)
        {
            _generalJournalRepository = generalJournalRepository;
        }

        #endregion

        // GET: api/GeneralJournals
        [HttpGet]
        public async Task<IActionResult> GetGeneralJournals(CancellationToken cancellationToken)
        {
            return this.Ok(await _generalJournalRepository.GetGeneralJournals(cancellationToken));
        }

        // GET: api/GeneralJournals/5
        [HttpGet("{generalJournalId}", Name = "GetGeneralJournal")]
        public async Task<IActionResult> GetGeneralJournal(int generalJournalId, CancellationToken cancellationToken)
        {
            var generalJournal = _generalJournalRepository.GetGeneralJournal(generalJournalId, cancellationToken);
            if (generalJournal == null) return this.NotFound();
            return this.Ok(await Task.FromResult(generalJournal));
        }

        // POST: api/GeneralJournals
        [HttpPost]
        public async Task<IActionResult> AddGeneralJournal([FromBody]GeneralJournal generalJournal, CancellationToken cancellationToken)
        {
            var result = await _generalJournalRepository.AddGeneralJournal(generalJournal, cancellationToken);
            return this.CreatedAtRoute("GetGeneralJournal", new { generalJournalId = result.Id }, result);
        }
        
        //// PUT: api/GeneralJournals/5
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
