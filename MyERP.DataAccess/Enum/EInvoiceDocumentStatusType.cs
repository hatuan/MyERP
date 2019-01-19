using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.DataAccess.Enum
{
    public enum EInvoiceDocumentStatusType
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "Draft", Order = 1)]
        Draft = 0,
        [System.ComponentModel.DataAnnotations.Display(Name = "Signed", Order = 2)]
        Signed = 1,
    }
}
