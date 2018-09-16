using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kartamulia.Accounting.NetCoreMvcClient.Models;
using Kartamulia.Accounting.NetCoreMvcClient.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Kartamulia.Accounting.NetCoreMvcClient.Controllers
{
    public class GeneralJournalsController : Controller
    {
        private readonly IGeneralJournalRepository _generalJournalRepository;

        public GeneralJournalsController(IGeneralJournalRepository generalJournalRepository)
        {
            _generalJournalRepository = generalJournalRepository;
        }

        #region Journal

        public async Task<IActionResult> Index()
        {
            var generalJournals = await _generalJournalRepository.GetGeneralJournalsAsync();
            return View(generalJournals);
        }

        public IActionResult Create()
        {
            object tempDataJournal = null;
            GeneralJournal generalJournal = null;

            if (TempData.TryGetValue("GeneralJournal", out tempDataJournal) == true)
            {
                generalJournal = JsonConvert.DeserializeObject<GeneralJournal>((string)tempDataJournal);
            }
            else
            {
                generalJournal = new GeneralJournal();
                generalJournal.Date = DateTime.Now;
                generalJournal.Description = "Description";
                generalJournal.Reference = "Reference";
            }

            var serializeObject = JsonConvert.SerializeObject(generalJournal);
            TempData["GeneralJournal"] = serializeObject;

            return View(generalJournal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GeneralJournal generalJournal)
        {
            var taskCode = await Task.FromResult(0);

            if (ModelState.IsValid)
            {
                await _generalJournalRepository.AddOrUpdateGeneralJournalAsync(generalJournal);
                TempData.Clear();
                return RedirectToAction(nameof(Index));
            }
            return View(generalJournal);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(GeneralJournal generalJournal)
        //{
        //    var taskCode = await Task.FromResult(0);

        //    if (ModelState.IsValid)
        //    {
        //        await _generalJournalRepository.AddOrUpdateGeneralJournalAsync(generalJournal);
        //        TempData.Clear();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(generalJournal);
        //}

        // GET: Journals/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var taskCode = await Task.FromResult(0);

            object tempJournal = null;
            GeneralJournal generalJournal = null;

            if (TempData.TryGetValue("GeneralJournal", out tempJournal) == true)
            {
                generalJournal = JsonConvert.DeserializeObject<GeneralJournal>((string)tempJournal);

                if (generalJournal.Id.Equals(id) == false)
                {
                    generalJournal = await _generalJournalRepository.GetGeneralJournalAsync(id);
                }
            }
            else
            {
                generalJournal = await _generalJournalRepository.GetGeneralJournalAsync(id);
            }

            if (generalJournal == null)
            {
                return NotFound();
            }

            var serializeObject = JsonConvert.SerializeObject(generalJournal);
            TempData["GeneralJournal"] = serializeObject;

            return View(generalJournal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Desciption,Reference")] GeneralJournal generalJournal)
        {
            if (id != generalJournal.Id)
            {
                return NotFound();
            }

            // Test tempdata is still exist
            //
            object tempDataJournal = null;
            if (TempData.TryGetValue("GeneralJournal", out tempDataJournal) == false)
            {
                // TempData exist.
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _generalJournalRepository.AddOrUpdateGeneralJournalAsync(generalJournal);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(generalJournal);
        }

        #endregion

        #region JournalItem

        [HttpGet]
        public async Task<IActionResult> AddEditJournalItem(int id)
        {
            var taskCode = await Task.FromResult(0);

            JournalItem journalItem = null;
            GeneralJournal generalJournal = null;

            if (id != 0)
            {
                // get journal item for edit
            }
            else
            {
                journalItem = new JournalItem();

                object tempDataJournal = null;
                if (TempData.TryGetValue("GeneralJournal", out tempDataJournal) == true)
                {
                    generalJournal = JsonConvert.DeserializeObject<GeneralJournal>((string)tempDataJournal);
                }

                journalItem.JournalId = generalJournal != null ? generalJournal.Id : 0;
            }

            var serializeObject = JsonConvert.SerializeObject(generalJournal);
            TempData["GeneralJournal"] = serializeObject;

            return PartialView("~/Views/GeneralJournals/_FormJournalItem.cshtml", journalItem);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditJournalItem(int id, JournalItem journalItem)
        {
            GeneralJournal generalJournal = null;

            try
            {
                var taskCode = await Task.FromResult(0);

                if (ModelState.IsValid == true)
                {
                    bool isNew = id.Equals(0);

                    if (isNew == true)
                    {
                        object tempJournal = null;

                        if (TempData.TryGetValue("GeneralJournal", out tempJournal) == true)
                        {
                            generalJournal = JsonConvert.DeserializeObject<GeneralJournal>((string)tempJournal);

                            if (generalJournal.Id.Equals(id) == false)
                            {
                                return NotFound();
                            }
                            else
                            {
                                generalJournal.Items.Add(journalItem);
                            }
                        }
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            var serializeObject = JsonConvert.SerializeObject(generalJournal);
            TempData["GeneralJournal"] = serializeObject;

            return RedirectToAction(nameof(Create));
        }

        #endregion

    }
}