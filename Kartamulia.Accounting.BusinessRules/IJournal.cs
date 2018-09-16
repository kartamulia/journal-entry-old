using System;
using System.Collections;
using System.Collections.Generic;

namespace Kartamulia.Accounting.BusinessRules
{
    public interface IJournal
    {
        int Id { get; set; }

        DateTime Date { get; set; }

        string Description { get; set; }

        string Reference { get; set; }

        ICollection<IJournalItem> GetItems();
    }
}
