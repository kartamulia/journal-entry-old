using Kartamulia.Accounting.BusinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kartamulia.Accounting.Entities
{
    public abstract class Journal : IJournal
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

        public string Description { get; set; }

        public string Reference { get; set; }

        #endregion

        #region Collections

        public ICollection<JournalItem> Items { get; set; }

        public ICollection<IJournalItem> GetItems()
        {
            if (this.Items == null) return null;
            var items = new List<IJournalItem>();
            this.Items.ToList().ForEach(x =>
            {
                items.Add(x);
            });
            return items;
        }

        #endregion
    }
}
