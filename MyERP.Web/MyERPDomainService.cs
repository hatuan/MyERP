using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.DomainServices.Server;
using System.ServiceModel.DomainServices.Server.ApplicationServices;
using System.Web.ApplicationServices;
using System.Web.Security;
using MyERP.DataAccess;
using Telerik.OpenAccess;

namespace MyERP.Web
{
    public partial class MyERPDomainService
    {

        [Invoke]
        public void UpdateSchema()
        {
            this.DataContext.UpdateSchema();
        }

        [Invoke]
        public void LoadDemoData()
        {
            //List<User> users = this.DataContext.Users.ToList();
            //this.DataContext.Delete(users);
            //this.DataContext.SaveChanges();

            //users = new List<User>()
            //{
            //    new User()
            //    {
            //        Id = new Guid("4e7739e3-939a-4181-b468-c35bdbf7a7ef"),
            //        Administrator = true,
            //        Comment = "",
            //        FullName = "Administrator",
            //        Name = "ADMIN",
            //        Password = "GUnbLXEWFUTZgEVPsnDoyg==",
            //        RightAccess = "",
            //        RightAdd = "",
            //        RightDel = "",
            //        RightEdit = "",
            //        RightPrint = "",
            //        RightRead = "",
            //        RightSearch = "",
            //        Status = (Byte)UserStatusType.Active
            //    },
            //    new User()
            //    {
            //        Id = new Guid("5e6af2aa-e21a-4afd-815e-0cc3dbefa08a"),
            //        Administrator = true,
            //        Comment = "",
            //        FullName = "Demo User",
            //        Name = "DEMO",
            //        Password = "WAZN81PC/QcCl2dCsMYdjw==",
            //        RightAccess = "",
            //        RightAdd = "",
            //        RightDel = "",
            //        RightEdit = "",
            //        RightPrint = "",
            //        RightRead = "",
            //        RightSearch = "",
            //        Status = (Byte)UserStatusType.Active
            //    }
            //};
            
            //this.DataContext.Add(users);
            //this.DataContext.SaveChanges();
        }

        [Invoke]
        public void LoadModuleData()
        {
            List<Module> modules = this.DataContext.Modules.ToList();
            this.DataContext.Delete(modules);
            this.DataContext.SaveChanges();

            modules = new List<Module>()
            {
                new Module(){
                    Name = ModuleName.GeneralLeaderJournals.ToString(),
                    Id = (int)ModuleName.GeneralLeaderJournals,
                    Group = "GeneralLeaderJournals",
                    Description = "General Leader Journals"
                },
                new Module(){
                    Name = ModuleName.GeneralLeaderReportsAccountActivity.ToString(),
                    Id = (int)ModuleName.GeneralLeaderReportsAccountActivity,
                    Group = "GeneralLeaderReports",
                    Description = "AccountActivity"
                },
                new Module(){
                    Name = ModuleName.GeneralLeaderReportsTrialBalance.ToString(),
                    Id = (int)ModuleName.GeneralLeaderReportsTrialBalance,
                    Group = "GeneralLeaderReports",
                    Description = "Trial Balance"
                },
                new Module(){
                    Name = ModuleName.GeneralLeaderReportsAccountTFormSummary.ToString(),
                    Id = (int)ModuleName.GeneralLeaderReportsAccountTFormSummary,
                    Group = "GeneralLeaderReports",
                    Description = "Account TForm Summary"
                },
                new Module(){
                    Name = ModuleName.GeneralLeaderReportsTransactionList.ToString(),
                    Id = (int)ModuleName.GeneralLeaderReportsTransactionList,
                    Group = "GeneralLeaderReports",
                    Description = "Transaction List"
                },
                new Module(){
                    Name = ModuleName.GeneralLeaderSetupAccountOpeningBalances.ToString(),
                    Id = (int) ModuleName.GeneralLeaderSetupAccountOpeningBalances,
                    Group = "GeneralLeaderSetup",
                    Description = "Account Opening Balances"
                },
                new Module(){
                    Name = ModuleName.GeneralLeaderSetupChartOfAccounts.ToString(),
                    Id = (int)ModuleName.GeneralLeaderSetupChartOfAccounts,
                    Group = "GeneralLeaderSetup",
                    Description = "Chart Of Accounts"
                },
                new Module(){
                    Name = ModuleName.GeneralLeaderSetupPeriod.ToString(),
                    Id = (int)ModuleName.GeneralLeaderSetupPeriod,
                    Group = "GeneralLeaderSetup",
                    Description = "Period"
                },
                new Module(){
                    Name = ModuleName.CashJournalsReceipt.ToString(),
                    Id = (int)ModuleName.CashJournalsReceipt,
                    Group = "CashJournals",
                    Description = "Receipt"
                },
                new Module(){
                    Name = ModuleName.CashJournalsPayment.ToString(),
                    Id = (int)ModuleName.CashJournalsPayment,
                    Group = "CashJournals",
                    Description = "CashJournalsPayment"
                },
                new Module(){
                    Name = ModuleName.CashReportsBook.ToString(),
                    Id = (int)ModuleName.CashReportsBook,
                    Group = "CashReports",
                    Description = "Book"
                },
                new Module(){
                    Name = ModuleName.CashReportsReceiptJournal.ToString(),
                    Id = (int)ModuleName.CashReportsReceiptJournal,
                    Group = "CashReports",
                    Description = "Receipt Journal"
                },
                new Module(){
                    Name = ModuleName.CashReportsPaymentJournal.ToString(),
                    Id = (int)ModuleName.CashReportsPaymentJournal,
                    Group = "CashReports",
                    Description = "Payment Journal"
                },
                new Module(){
                    Name = ModuleName.CashSetupBank.ToString(),
                    Id = (int)ModuleName.CashSetupBank,
                    Group = "CashSetup",
                    Description = "Bank"
                },
            };
            this.DataContext.Add(modules);
            this.DataContext.SaveChanges();
        }

        #region Dashboard services
        public DashboardStats GetDashboardStats()
        {
            var stats = new DashboardStats() { };
            return stats;
        }
        #endregion
    }
}