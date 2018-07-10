using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.DataAccess.Enum
{
    public enum OptionParameter
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "SalesPosLocationId")]
        SalesPosLocationId = 0,
        [System.ComponentModel.DataAnnotations.Display(Name = "SalesPosSequenceId")]
        SalesPosSequenceId = 1,
        [System.ComponentModel.DataAnnotations.Display(Name = "SalesOrderSequenceId")]
        SalesOrderSequenceId = 2,
        [System.ComponentModel.DataAnnotations.Display(Name = "SalesShipmentSeqId")]
        SalesShipmentSeqId = 3,
        [System.ComponentModel.DataAnnotations.Display(Name = "SalesInvoiceSeqId")]
        SalesInvoiceSeqId = 4,
        [System.ComponentModel.DataAnnotations.Display(Name = "PurchOrderSequenceId")]
        PurchOrderSequenceId = 5,
        [System.ComponentModel.DataAnnotations.Display(Name = "PurchReceiveSeqId")]
        PurchReceiveSeqId = 6,
        [System.ComponentModel.DataAnnotations.Display(Name = "PurchInvoiceSeqId")]
        PurchInvoiceSeqId = 7,
        [System.ComponentModel.DataAnnotations.Display(Name = "OneTimeBusinessPartnerId")]
        OneTimeBusinessPartnerId = 8,
    }
}
