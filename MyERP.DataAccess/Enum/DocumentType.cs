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
        [System.ComponentModel.DataAnnotations.Display(Name = "Cash Receipt", Order = 1)]
        CashReceipt = 0,
        [System.ComponentModel.DataAnnotations.Display(Name = "Cash Receipt Multi Business Partner", Order = 2)]
        CashReceiptMultiBusinessPartner = 1,
        [System.ComponentModel.DataAnnotations.Display(Name = "Cash Receipt For Sales Invoice", Order = 3)]
        CashReceiptForSalesInvoice = 3,
    }

    public enum CashPaymentDocumentSubType
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "Cash Payment", Order = 1)]
        CashPayment = 0,
        [System.ComponentModel.DataAnnotations.Display(Name = "Cash Payment Multi Business Partner", Order = 2)]
        CashPaymentMultiBusinessPartner = 1,
        [System.ComponentModel.DataAnnotations.Display(Name = "Cash Payment For Purchase Invoice", Order = 3)]
        CashPaymentForPurchaseInvoice = 3,
    }
}
