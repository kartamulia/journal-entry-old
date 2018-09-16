using Kartamulia.Accounting.BusinessRules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kartamulia.Accounting.Entities
{
    public class JournalItem : IJournalItem
    {
        #region ctor

        public JournalItem()
        {
        }

        #endregion

        #region Properties

        public int Id { get; set; }

        public int JournalId { get; set; }

        public string AccountNumber { get; set; }

        public decimal Debit { get; set; }

        public decimal Credit { get; set; }

        #endregion

        #region References

        public Account Account { get; set; }

        #endregion
    }
}
