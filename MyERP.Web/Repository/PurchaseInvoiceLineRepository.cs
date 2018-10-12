using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using Ext.Net;
using MyERP.DataAccess;
using MyERP.DataAccess.Enum;
using MyERP.Web.Models;

namespace MyERP.Web
{
    public partial class PurchaseInvoiceLineRepository
    {
        public void Update(string columnName, ref PurchaseInvoiceHeaderEditViewModel purchaseInvoiceHeader, ref PurchaseInvoiceLineEditViewModel purchaseInvoiceLine)
        {
            switch (columnName)
            {
                case "Quantity":
                {
                    purchaseInvoiceLine.LineDiscountAmount =
                        purchaseInvoiceLine.Quantity * purchaseInvoiceLine.PurchasePrice *
                        purchaseInvoiceLine.LineDiscountPercentage / 100;
                    purchaseInvoiceLine.LineAmount = purchaseInvoiceLine.Quantity * purchaseInvoiceLine.PurchasePrice -
                                                     purchaseInvoiceLine.LineDiscountAmount;



                    break;
                }
            }
        }
    }
}