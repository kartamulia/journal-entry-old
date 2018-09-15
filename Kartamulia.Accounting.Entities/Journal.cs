using System;
using System.Collections.Generic;
using System.Text;

namespace Kartamulia.Accounting.Entities
{
    public abstract class Journal
    {
        #region ctor

        public Journal()
        {
            this.Items = new HashSet<JournalItem>();
        }

        #endregion

        #region Properties

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Desciption { get; set; }

        public string Reference { get; set; }

        #endregion

        #region Collections

        public ICollection<JournalItem> Items { get; set; }

        #endregion
    }
}
