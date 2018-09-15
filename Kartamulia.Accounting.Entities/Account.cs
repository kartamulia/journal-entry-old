using System;

namespace Kartamulia.Accounting.Entities
{
    public class Account
    {
        #region ctor

        public Account()
        {
        }

        #endregion

        #region Properties

        public string Number { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        #endregion
    }
}
