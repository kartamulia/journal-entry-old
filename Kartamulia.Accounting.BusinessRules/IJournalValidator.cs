using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kartamulia.Accounting.BusinessRules
{
    public interface IJournalValidator : IValidator<IJournal>
    {
    }

    public class JournalValidator : IJournalValidator
    {
        #region ctor

        public JournalValidator()
            : base()
        {
        }

        #endregion

        #region Methods

        public bool Validate(IJournal data)
        {
            if (data == null) return false;
            if (string.IsNullOrWhiteSpace(data.Description) == true) return false;
            if (string.IsNullOrWhiteSpace(data.Reference) == true) return false;

            var items = data.GetItems();

            if (items == null) return false;

            foreach (var item in items)
            {
                if (string.IsNullOrWhiteSpace(item.AccountNumber) == true) return false;
            }

            if (items.Count < 2) return false;
            if (items.Sum(x => x.Debit) - items.Sum(x => x.Credit) != 0) return false;

            return true;
        }

        #endregion

        #region Events

        #endregion

    }
}
