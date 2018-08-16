using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.DataAccess.Enum
{
    public enum DocumentType
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "General Journal", Order = 1)]
        GeneralJournal = 1,
        [System.ComponentModel.DataAnnotations.Display(Name = "Cash Receipt", Order = 1)]
        CashReceipt = 2,
        [System.ComponentModel.DataAnnotations.Display(Name = "Cash Payment", Order = 2)]
        CashPayment = 3
    }

    public enum CashReceiptDocumentSubType
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "Cash Receipt From One BP", Order = 1)]
        CashReceipt = 1,
        [System.ComponentModel.DataAnnotations.Display(Name = "Cash Receipt From Multi BP", Order = 2)]
        CashReceiptMultiBusinessPartner = 2,
        [System.ComponentModel.DataAnnotations.Display(Name = "Cash Receipt From Sales Invoice", Order = 3)]
        CashReceiptForSalesInvoice = 3,
    }

    public enum CashPaymentDocumentSubType
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "Cash Payment From One BP", Order = 1)]
        CashPayment = 1,
        [System.ComponentModel.DataAnnotations.Display(Name = "Cash Payment From Multi BP", Order = 2)]
        CashPaymentMultiBusinessPartner = 2,
        [System.ComponentModel.DataAnnotations.Display(Name = "Cash Payment From Purchase Invoice", Order = 3)]
        CashPaymentForPurchaseInvoice = 3,
    }
}
