using System;
using System.Collections.Generic;
using System.Text;

namespace Kartamulia.Accounting.BusinessRules
{
    public interface IJournalItem
    {
        int Id { get; set; }

        int JournalId { get; set; }

        string AccountNumber { get; set; }

        decimal Debit { get; set; }

        decimal Credit { get; set; }
    }
}
