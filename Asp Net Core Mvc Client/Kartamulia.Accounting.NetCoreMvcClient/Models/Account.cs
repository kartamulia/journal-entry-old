using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kartamulia.Accounting.NetCoreMvcClient.Models
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
