using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kartamulia.Accounting.NetCoreMvcClient.Models
{
    public abstract class Journal
    {
        #region ctor

        public Journal()
        {
            this.Date = DateTime.Today.Date;
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
