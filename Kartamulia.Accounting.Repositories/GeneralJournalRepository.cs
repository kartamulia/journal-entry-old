using Kartamulia.Accounting.BusinessRules;
using Kartamulia.Accounting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kartamulia.Accounting.Repositories
{
    public interface IGeneralJournalRepository
    {
        Task<IEnumerable<GeneralJournal>> GetGeneralJournals(CancellationToken cancellationToken);

        Task<GeneralJournal> GetGeneralJournalAsync(int generalJournalId, CancellationToken cancellationToken);

        Task<GeneralJournal> AddGeneralJournal(GeneralJournal generalJournal, CancellationToken cancellationToken);
    }

    public class GeneralJournalRepository : IGeneralJournalRepository
    {
        private static List<GeneralJournal> _generalJournals = new List<GeneralJournal>()
        {

        };
        private readonly IJournalValidator _journalValidator;

        #region ctor

        public GeneralJournalRepository(IJournalValidator journalValidator)
        {
            _journalValidator = journalValidator;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<GeneralJournal>> GetGeneralJournals(CancellationToken cancellationToken)
        {
            return await Task.FromResult(_generalJournals);
        }

        public async Task<GeneralJournal> GetGeneralJournalAsync(int generalJournalId, CancellationToken cancellationToken)
        {
            var generalJournal = _generalJournals.FirstOrDefault(x => x.Id == generalJournalId);
            return await Task.FromResult(generalJournal);
        }

        public async Task<GeneralJournal> AddGeneralJournal(GeneralJournal generalJournal, CancellationToken cancellationToken)
        {
            // Validate general journal.
            // ??

            if (_journalValidator.Validate(generalJournal) == false)
            {
                throw new Exception("Journal is not valid.");
            }

            _generalJournals.Add(generalJournal);

            return await Task.FromResult(generalJournal);
        }

        #endregion
    }
}
