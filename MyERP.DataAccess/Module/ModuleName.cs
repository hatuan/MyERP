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
        SetupCurencies = 10, //Tien te
        SetupCurenciesExchangeRate = 11, //Ty gia
        SetupClientInformation = 100, //Thong tin cong ty
        SetupOrganizations = 101, //Danh sach cac chi nhanh su dung cua cong ty
        SetupUsers = 102, //Danh sach nguoi dung
        SetupNoSeries = 200, //Quan ly so tu dong
        SetupPeriod = 210, //Ky cap nhat so lieu
        GeneralLeaderJournals = 1000, //Phieu ke toan
        GeneralLeaderReportsAccountActivity = 2000, //Bao cao
        GeneralLeaderReportsTrialBalance = 3000, //Bao cao
        GeneralLeaderReportsAccountTFormSummary = 4000, //Bao cao
        GeneralLeaderReportsTransactionList = 5000, //Bao cao
        GeneralLeaderSetupAccountOpeningBalances = 6000, //So du dau ky
        GeneralLeaderSetupChartOfAccounts = 7000, //Danh muc tai khoan
        GeneralLeaderSetup = 8000, //Khai bao tham so phan he GL
        CashJournalsReceipt = 10000, //Phieu thu tien
        CashJournalsPayment = 11000, //Phieu chi tien
        CashReportsBook = 12000, //Bao cao
        CashReportsReceiptJournal = 13000, //Bao cao
        CashReportsPaymentJournal = 14000, //Bao cao
        CashSetupBank = 15000 //Danh sach ngan hang
    }
   
}
