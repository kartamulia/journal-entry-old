using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kartamulia.Accounting.NetCoreMvcClient.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Kartamulia.Accounting.NetCoreMvcClient.Controllers
{
    public class GeneralJournalsController : Controller
    {
        private readonly IGeneralJournalRepository _generalJournalRepository;

        public GeneralJournalsController(IGeneralJournalRepository generalJournalRepository)
        {
            _generalJournalRepository = generalJournalRepository;
        }

        public async Task<IActionResult> Index()
        {
            var generalJournals = await _generalJournalRepository.GetGeneralJournalsAsync();
            return View(generalJournals);
        }
    }
}