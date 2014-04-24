using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.DomainServices.Server;
using System.Web;
using MyERP.DataAccess;
using Telerik.OpenAccess;

namespace MyERP.Web
{
    public partial class MyERPOtherDomainService
    {
        [Invoke]
        public void UpdateSchema()
        {
            this.DataContext.UpdateSchema();
        }

        [Invoke]
        public void LoadDemoData()
        {
            
            User adminUser = this.DataContext.Users.FirstOrDefault(i => i.Id == new Guid("4e7739e3-939a-4181-b468-c35bdbf7a7ef"));
            if (adminUser == null)
            {
                adminUser = new User()
                {
                    Id = new Guid("4e7739e3-939a-4181-b468-c35bdbf7a7ef"),
                    Comment = "",
                    FullName = "Administrator",
                    Name = "ADMIN",
                    Password = "GUnbLXEWFUTZgEVPsnDoyg==",
                    CreatedDate = DateTime.Now,
                    Email = "admin@myerp.com",
                    IsActivated = true,
                    IsLockedOut = false,
                    LastLockedOutDate = DateTime.MinValue,
                    LastLockedOutReason = "",
                    LastLoginDate = DateTime.Now,
                    LastLoginIp = "0.0.0.0",
                    LastModifiedDate = DateTime.Now,
                    PasswordAnswer = "",
                    PasswordQuestion = ""
                };
                this.DataContext.Add(adminUser);
            }

            User demoUser = this.DataContext.Users.FirstOrDefault(i => i.Id == new Guid("5e6af2aa-e21a-4afd-815e-0cc3dbefa08a"));
            if (demoUser == null)
            {
                demoUser = new User()
                {
                    Id = new Guid("5e6af2aa-e21a-4afd-815e-0cc3dbefa08a"),
                    Comment = "",
                    FullName = "Demo User",
                    Name = "DEMO",
                    Password = "WAZN81PC/QcCl2dCsMYdjw==",
                    CreatedDate = DateTime.Now,
                    Email = "demo@myerp.com",
                    IsActivated = true,
                    IsLockedOut = false,
                    LastLockedOutDate = DateTime.MinValue,
                    LastLockedOutReason = "",
                    LastLoginDate = DateTime.Now,
                    LastLoginIp = "0.0.0.0",
                    LastModifiedDate = DateTime.Now,
                    PasswordAnswer = "",
                    PasswordQuestion = ""
                };
                this.DataContext.Add(demoUser);
            }

            Client client = this.DataContext.Clients.FirstOrDefault(i => i.Id == new Guid("28CC612C-807D-458D-91E7-F759080B0E40"));
            if (client == null)
            {
                client = new Client()
                {
                    Id = new Guid("28CC612C-807D-458D-91E7-F759080B0E40"),
                    Name = "Demo Company",
                    IsActivated = true,
                    RecCreated = DateTime.Now,
                    RecCreatedById = new Guid("4e7739e3-939a-4181-b468-c35bdbf7a7ef")
                };
                this.DataContext.Add(client);
            }

            Organization allOrganization =
                this.DataContext.Organizations.FirstOrDefault(
                    i => i.Id == new Guid("4336fecf-8c21-4531-afe6-76d34603ea34"));
            if (allOrganization == null)
            {
                allOrganization = new Organization()
                {
                    Id = new Guid("4336fecf-8c21-4531-afe6-76d34603ea34"),
                    ClientId = new Guid("28CC612C-807D-458D-91E7-F759080B0E40"),
                    Code = "*",
                    Name = "All Organization",
                    RecCreated = DateTime.Now,
                    RecCreatedById = new Guid("4e7739e3-939a-4181-b468-c35bdbf7a7ef"),
                    RecModified = DateTime.Now,
                    RecModifiedById = new Guid("4e7739e3-939a-4181-b468-c35bdbf7a7ef"),
                    Status = 1
                };
                this.DataContext.Add(allOrganization);
            }

            Organization HQOrganization =
                this.DataContext.Organizations.FirstOrDefault(
                    i => i.Id == new Guid("876A2286-4907-4A7F-B841-5CF7FD4C1288"));
            if (HQOrganization == null)
            {
                HQOrganization = new Organization()
                {
                    Id = new Guid("876A2286-4907-4A7F-B841-5CF7FD4C1288"),
                    ClientId = new Guid("28CC612C-807D-458D-91E7-F759080B0E40"),
                    Code = "0",
                    Name = "HQ Organization",
                    RecCreated = DateTime.Now,
                    RecCreatedById = new Guid("4e7739e3-939a-4181-b468-c35bdbf7a7ef"),
                    RecModified = DateTime.Now,
                    RecModifiedById = new Guid("4e7739e3-939a-4181-b468-c35bdbf7a7ef"),
                    Status = 1
                };
                this.DataContext.Add(HQOrganization);
            }

            adminUser.Client = client;
            adminUser.Organization = allOrganization;
            this.DataContext.Refresh(RefreshMode.OverwriteChangesFromStore, adminUser);

            demoUser.Client = client;
            demoUser.Organization = allOrganization;
            this.DataContext.Refresh(RefreshMode.OverwriteChangesFromStore, demoUser);
            
            Currency currency =
                this.DataContext.Currencies.FirstOrDefault(c => c.Id == new Guid("3AD409C2-7859-468E-8FC3-C41C6C9A9587"));
            if (currency == null)
            {
                Currency newCurrency = new Currency()
                {
                    Client = client,
                    Organization = allOrganization,
                    Id = new Guid("3AD409C2-7859-468E-8FC3-C41C6C9A9587"),
                    Code = "VND",
                    Name = "Đồng Việt Nam",
                    RecCreated = DateTime.Now,
                    RecCreatedByUser = adminUser,
                    RecModified = DateTime.Now,
                    RecModifiedByUser = adminUser,
                    Status = (byte)CurrencyStatusType.Active
                };
                this.DataContext.Add(newCurrency);
            }

            currency =
                this.DataContext.Currencies.FirstOrDefault(c => c.Id == new Guid("15971519-42A3-4514-A053-1EDB5D32E1E4"));
            if (currency == null)
            {
                Currency newCurrency = new Currency()
                {
                    Client = client,
                    Organization = allOrganization,
                    Id = new Guid("15971519-42A3-4514-A053-1EDB5D32E1E4"),
                    Code = "USD",
                    Name = "USD Dolar",
                    RecCreated = DateTime.Now,
                    RecCreatedByUser = adminUser,
                    RecModified = DateTime.Now,
                    RecModifiedByUser = adminUser,
                    Status = (byte)CurrencyStatusType.Active
                };
                this.DataContext.Add(newCurrency);
            }

            currency =
                this.DataContext.Currencies.FirstOrDefault(c => c.Id == new Guid("A5362238-0EED-46F3-98DE-58729906E8ED"));
            if (currency == null)
            {
                Currency newCurrency = new Currency()
                {
                    Client = client,
                    Organization = allOrganization,
                    Id = new Guid("A5362238-0EED-46F3-98DE-58729906E8ED"),
                    Code = "EUR",
                    Name = "EURO",
                    RecCreated = DateTime.Now,
                    RecCreatedByUser = adminUser,
                    RecModified = DateTime.Now,
                    RecModifiedByUser = adminUser,
                    Status = (byte)CurrencyStatusType.Active
                };
                this.DataContext.Add(newCurrency);
            }

            currency =
                this.DataContext.Currencies.FirstOrDefault(c => c.Id == new Guid("1D05CD23-E928-4E24-ACBE-3EB1A676434B"));
            if (currency == null)
            {
                Currency newCurrency = new Currency()
                {
                    Client = client,
                    Organization = allOrganization,
                    Id = new Guid("1D05CD23-E928-4E24-ACBE-3EB1A676434B"),
                    Code = "JPY",
                    Name = "Yên",
                    RecCreated = DateTime.Now,
                    RecCreatedByUser = adminUser,
                    RecModified = DateTime.Now,
                    RecModifiedByUser = adminUser,
                    Status = (byte)CurrencyStatusType.Active
                };
                this.DataContext.Add(newCurrency);
            }

            currency =
                this.DataContext.Currencies.FirstOrDefault(c => c.Id == new Guid("B1F21473-8FA0-4C1E-BC19-B36E1827F8F1"));
            if (currency == null)
            {
                Currency newCurrency = new Currency()
                {
                    Client = client,
                    Organization = allOrganization,
                    Id = new Guid("B1F21473-8FA0-4C1E-BC19-B36E1827F8F1"),
                    Code = "CNY",
                    Name = "Nhân dân tệ",
                    RecCreated = DateTime.Now,
                    RecCreatedByUser = adminUser,
                    RecModified = DateTime.Now,
                    RecModifiedByUser = adminUser,
                    Status = (byte)CurrencyStatusType.Active
                };
                this.DataContext.Add(newCurrency);
            }

            Client otherClient = this.DataContext.Clients.FirstOrDefault(i => i.Id == new Guid("EA084FC9-B630-4016-97E2-021A2B120879"));
            if (otherClient == null)
            {
                otherClient = new Client()
                {
                    Id = new Guid("EA084FC9-B630-4016-97E2-021A2B120879"),
                    Name = "Demo Company",
                    IsActivated = true,
                    RecCreated = DateTime.Now,
                    RecCreatedById = new Guid("4e7739e3-939a-4181-b468-c35bdbf7a7ef")
                };
                this.DataContext.Add(otherClient);
            }

            Organization allOrganizationOfOtherClient =
                this.DataContext.Organizations.FirstOrDefault(
                    i => i.Id == new Guid("E1744F1E-1959-4F05-99A8-6ABEDF134E6F"));
            if (allOrganizationOfOtherClient == null)
            {
                allOrganizationOfOtherClient = new Organization()
                {
                    Id = new Guid("E1744F1E-1959-4F05-99A8-6ABEDF134E6F"),
                    ClientId = new Guid("EA084FC9-B630-4016-97E2-021A2B120879"),
                    Code = "*",
                    Name = "All Organization",
                    RecCreated = DateTime.Now,
                    RecCreatedById = new Guid("4e7739e3-939a-4181-b468-c35bdbf7a7ef"),
                    RecModified = DateTime.Now,
                    RecModifiedById = new Guid("4e7739e3-939a-4181-b468-c35bdbf7a7ef"),
                    Status = 1
                };
                this.DataContext.Add(allOrganizationOfOtherClient);
            }

            this.DataContext.SaveChanges();

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
                    ClientId = new Guid("{28cc612c-807d-458d-91e7-f759080b0e40}"),
                    Name = ModuleName.GeneralLeaderJournals.ToString(),
                    Id = (int)ModuleName.GeneralLeaderJournals,
                    Group = "GeneralLeaderJournals",
                    Description = "General Leader Journals"
                },
                new Module(){
                    ClientId = new Guid("{28cc612c-807d-458d-91e7-f759080b0e40}"),
                    Name = ModuleName.GeneralLeaderReportsAccountActivity.ToString(),
                    Id = (int)ModuleName.GeneralLeaderReportsAccountActivity,
                    Group = "GeneralLeaderReports",
                    Description = "AccountActivity"
                },
                new Module(){
                    ClientId = new Guid("{28cc612c-807d-458d-91e7-f759080b0e40}"),
                    Name = ModuleName.GeneralLeaderReportsTrialBalance.ToString(),
                    Id = (int)ModuleName.GeneralLeaderReportsTrialBalance,
                    Group = "GeneralLeaderReports",
                    Description = "Trial Balance"
                },
                new Module(){
                    ClientId = new Guid("{28cc612c-807d-458d-91e7-f759080b0e40}"),
                    Name = ModuleName.GeneralLeaderReportsAccountTFormSummary.ToString(),
                    Id = (int)ModuleName.GeneralLeaderReportsAccountTFormSummary,
                    Group = "GeneralLeaderReports",
                    Description = "Account TForm Summary"
                },
                new Module(){
                    ClientId = new Guid("{28cc612c-807d-458d-91e7-f759080b0e40}"),
                    Name = ModuleName.GeneralLeaderReportsTransactionList.ToString(),
                    Id = (int)ModuleName.GeneralLeaderReportsTransactionList,
                    Group = "GeneralLeaderReports",
                    Description = "Transaction List"
                },
                new Module(){
                    ClientId = new Guid("{28cc612c-807d-458d-91e7-f759080b0e40}"),
                    Name = ModuleName.GeneralLeaderSetupAccountOpeningBalances.ToString(),
                    Id = (int) ModuleName.GeneralLeaderSetupAccountOpeningBalances,
                    Group = "GeneralLeaderSetup",
                    Description = "Account Opening Balances"
                },
                new Module(){
                    ClientId = new Guid("{28cc612c-807d-458d-91e7-f759080b0e40}"),
                    Name = ModuleName.GeneralLeaderSetupChartOfAccounts.ToString(),
                    Id = (int)ModuleName.GeneralLeaderSetupChartOfAccounts,
                    Group = "GeneralLeaderSetup",
                    Description = "Chart Of Accounts"
                },
                new Module(){
                    ClientId = new Guid("{28cc612c-807d-458d-91e7-f759080b0e40}"),
                    Name = ModuleName.GeneralLeaderSetupPeriod.ToString(),
                    Id = (int)ModuleName.GeneralLeaderSetupPeriod,
                    Group = "GeneralLeaderSetup",
                    Description = "Period"
                },
                new Module(){
                    ClientId = new Guid("{28cc612c-807d-458d-91e7-f759080b0e40}"),
                    Name = ModuleName.CashJournalsReceipt.ToString(),
                    Id = (int)ModuleName.CashJournalsReceipt,
                    Group = "CashJournals",
                    Description = "Receipt"
                },
                new Module(){
                    ClientId = new Guid("{28cc612c-807d-458d-91e7-f759080b0e40}"),
                    Name = ModuleName.CashJournalsPayment.ToString(),
                    Id = (int)ModuleName.CashJournalsPayment,
                    Group = "CashJournals",
                    Description = "CashJournalsPayment"
                },
                new Module(){
                    ClientId = new Guid("{28cc612c-807d-458d-91e7-f759080b0e40}"),
                    Name = ModuleName.CashReportsBook.ToString(),
                    Id = (int)ModuleName.CashReportsBook,
                    Group = "CashReports",
                    Description = "Book"
                },
                new Module(){
                    ClientId = new Guid("{28cc612c-807d-458d-91e7-f759080b0e40}"),
                    Name = ModuleName.CashReportsReceiptJournal.ToString(),
                    Id = (int)ModuleName.CashReportsReceiptJournal,
                    Group = "CashReports",
                    Description = "Receipt Journal"
                },
                new Module(){
                    ClientId = new Guid("{28cc612c-807d-458d-91e7-f759080b0e40}"),
                    Name = ModuleName.CashReportsPaymentJournal.ToString(),
                    Id = (int)ModuleName.CashReportsPaymentJournal,
                    Group = "CashReports",
                    Description = "Payment Journal"
                },
                new Module(){
                    ClientId = new Guid("{28cc612c-807d-458d-91e7-f759080b0e40}"),
                    Name = ModuleName.CashSetupBank.ToString(),
                    Id = (int)ModuleName.CashSetupBank,
                    Group = "CashSetup",
                    Description = "Bank"
                },
            };
            this.DataContext.Add(modules);
            this.DataContext.SaveChanges();
        }
    }
}