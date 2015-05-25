using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.DataAccess
{
    public enum DocumentType
    {
        None = 0,
        GeneralJournal = 100,
        CashReceipt = 200,
        CashPayment = 300,
        BankCheck = 400, //Bao no - Chuyen tien tu ngan hang cho nha cung cap
        BankDeposit = 500, //Bao co - Ngan hang co tien khach hang tra
        AssetJournalDepreciation = 600
    }
}
