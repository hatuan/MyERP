using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.DataAccess
{
    public enum ModuleName
    {
        Default = 0,
        GeneralLeaderJournals = 1000,
        GeneralLeaderReportsAccountActivity = 2000,
        GeneralLeaderReportsTrialBalance = 3000,
        GeneralLeaderReportsAccountTFormSummary = 4000,
        GeneralLeaderReportsTransactionList = 5000,
        GeneralLeaderSetupAccountOpeningBalances = 6000,
        GeneralLeaderSetupChartOfAccounts = 7000,
        GeneralLeaderSetupPeriod = 8000,
        CashJournalsReceipt = 10000,
        CashJournalsPayment = 11000,
        CashReportsBook = 12000,
        CashReportsReceiptJournal = 13000,
        CashReportsPaymentJournal = 14000,
        CashSetupBank = 15000
    }
   
}
