using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kartamulia.Accounting.NetCoreMvcClient.ViewModels
{
    public class Modal
    {
        #region ctor

        public Modal()
            : base()
        {
        }

        #endregion

        #region Properties

        public string ID { get; set; }

        public string AreaLabelID { get; set; }

        public ModalSize Size { get; set; }

        public string ModalSizeClass
        {
            get
            {
                string modalSize = "modal-sm";

                switch (this.Size)
                {
                    case ModalSize.Small:
                        modalSize = "modal-sm";
                        break;
                    case ModalSize.Large:
                        modalSize = "modal-lg";
                        break;
                    case ModalSize.Medium:
                    default:
                        modalSize = "";
                        break;
                }

                return modalSize;
            }
        }

        #endregion
    }
}
