using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kartamulia.Accounting.NetCoreMvcClient.ViewModels
{
    public class ModalFooter
    {
        #region ctor

        public ModalFooter()
            : base()
        {
        }

        #endregion

        #region Properties

        public string SubmitButtonText { get; set; } = "Submit";

        public string CancelButtonText { get; set; } = "Cancel";

        public string SubmitButtonID { get; set; } = "btn-submit";

        public string CancelButtonID { get; set; } = "btn-cancel";

        public bool OnlyCancelButton { get; set; }

        #endregion
    }
}
