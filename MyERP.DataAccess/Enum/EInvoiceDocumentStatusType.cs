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
        [System.ComponentModel.DataAnnotations.Display(Name = "Released", Order = 2)]
        Released = 1,
        [System.ComponentModel.DataAnnotations.Display(Name = "Signed", Order = 3)]
        Signed = 1,
    }
}
