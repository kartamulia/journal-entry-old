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

        Task<GeneralJournal> GetGeneralJournal(int generalJournalId, CancellationToken cancellationToken);

        Task<GeneralJournal> AddGeneralJournal(GeneralJournal generalJournal, CancellationToken cancellationToken);
    }

    public class GeneralJournalRepository : IGeneralJournalRepository
    {
        private static List<GeneralJournal> _generalJournals = new List<GeneralJournal>()
        {

        };

        #region ctor

        public GeneralJournalRepository()
        {
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<GeneralJournal>> GetGeneralJournals(CancellationToken cancellationToken)
        {
            return await Task.FromResult(_generalJournals);
        }

        public async Task<GeneralJournal> GetGeneralJournal(int generalJournalId, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_generalJournals.FirstOrDefault(x => x.Id == generalJournalId));
        }

        public async Task<GeneralJournal> AddGeneralJournal(GeneralJournal generalJournal, CancellationToken cancellationToken)
        {
            // Validate general journal.
            // ??

            var journalsCount = _generalJournals.Count;
            int journalItemsCount = _generalJournals.Sum(x => x.Items.Count);

            generalJournal.Id = journalsCount + 1;
            generalJournal?.Items.ToList().ForEach(x =>
            {
                journalItemsCount++;
                x.Id = journalItemsCount;
                x.JournalId = generalJournal.Id;
            });

            _generalJournals.Add(generalJournal);

            return await Task.FromResult(generalJournal);
        }

        #endregion
    }
}
