using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            this.Items = new List<JournalItem>();
        }

        #endregion

        #region Properties

        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [StringLength(100)]
        public string Reference { get; set; }

        #endregion

        #region Collections

        public List<JournalItem> Items { get; set; }

        #endregion
    }
}
