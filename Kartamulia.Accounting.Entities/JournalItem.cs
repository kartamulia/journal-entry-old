﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Kartamulia.Accounting.Entities
{
    public class JournalItem
    {
        #region ctor

        public JournalItem()
        {
        }

        #endregion

        #region Properties

        public int Id { get; set; }

        public string AccountNumber { get; set; }

        public decimal Debit { get; set; }

        public decimal Credit { get; set; }

        #endregion

        #region References

        public Account Account { get; set; }

        #endregion
    }
}
