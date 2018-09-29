using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.DataAccess.Enum
{
    public enum PurchaseInvoiceLineType : Byte
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "Comment", Order = 0)]
        Comment = 0,
        [System.ComponentModel.DataAnnotations.Display(Name = "Item", Order = 1)]
        Item = 1
    }
}
