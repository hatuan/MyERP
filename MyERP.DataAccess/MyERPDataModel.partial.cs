using System;
using System.Linq;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Metadata.Relational;

namespace MyERP.DataAccess
{
    public partial class EntitiesModel
    {
        protected override void OnDatabaseOpen(BackendConfiguration backendConfiguration,
            MetadataContainer metadataContainer, MetadataContainer aggregatedMetadataContainer)
        {
            MetaTable metaTableClient = metadataContainer.Tables.First(t => t.Name.Equals("client"));
            MetaIndex metaIndexCurrencyOfTableClient = new MetaIndex("idx_client_currency_lcy", metaTableClient);
            MetaColumn metaColumnCurrencyOfTableClient = metaTableClient.Columns.First(c => c.Name.Equals("currency_lcy_id"));
            metaIndexCurrencyOfTableClient.Columns.Add(new MetaIndexColumnMapping("CurrencyLCY", metaColumnCurrencyOfTableClient, 1, SortOrder.Ascending));
            metaTableClient.Indexes.Add(metaIndexCurrencyOfTableClient);
            metadataContainer.Indexes.Add(metaIndexCurrencyOfTableClient);
            
            MetaTable metaTableOrganization = metadataContainer.Tables.First(t => t.Name.Equals("organization"));
            MetaIndex metaIndexNameOfTableOrganization = new MetaIndex("idx_organization_code", metaTableOrganization);
            MetaColumn metaColumnCodeOfTableOrganization = metaTableOrganization.Columns.First(c => c.Name.Equals("code"));
            MetaColumn metaColumnClientOfTableOrganization = metaTableOrganization.Columns.First(c => c.Name.Equals("client_id"));
            metaIndexNameOfTableOrganization.Columns.Add(new MetaIndexColumnMapping("Code", metaColumnCodeOfTableOrganization, 1, SortOrder.Ascending));
            metaIndexNameOfTableOrganization.Columns.Add(new MetaIndexColumnMapping("Client", metaColumnClientOfTableOrganization, 1, SortOrder.Ascending));
            metaIndexNameOfTableOrganization.Clustered = true;
            metaIndexNameOfTableOrganization.Unique = true;
            metaTableOrganization.Indexes.Add(metaIndexNameOfTableOrganization);
            metadataContainer.Indexes.Add(metaIndexNameOfTableOrganization);

            MetaTable metaTableCurrency = metadataContainer.Tables.First(t => t.Name.Equals("currency"));
            MetaIndex metaIndexNameOfTableCurrency = new MetaIndex("idx_currency_code", metaTableCurrency);
            MetaColumn metaColumnCodeOfTableUser = metaTableCurrency.Columns.First(c => c.Name.Equals("code"));
            MetaColumn metaColumnClientOfTableUser = metaTableCurrency.Columns.First(c => c.Name.Equals("client_id"));
            metaIndexNameOfTableCurrency.Columns.Add(new MetaIndexColumnMapping("Code", metaColumnCodeOfTableUser, 1, SortOrder.Ascending));
            metaIndexNameOfTableCurrency.Columns.Add(new MetaIndexColumnMapping("Client", metaColumnClientOfTableUser, 1, SortOrder.Ascending));
            metaIndexNameOfTableCurrency.Clustered = true;
            metaIndexNameOfTableCurrency.Unique = true;
            metaTableCurrency.Indexes.Add(metaIndexNameOfTableCurrency);
            metadataContainer.Indexes.Add(metaIndexNameOfTableCurrency);

            MetaTable metaTableAccount = metadataContainer.Tables.First(t => t.Name.Equals("account"));
            MetaIndex metaIndex = new MetaIndex("idx_account_code", metaTableAccount);
            MetaColumn metaColumnCodeOfTableAccount = metaTableAccount.Columns.First(c => c.Name.Equals("code"));
            MetaColumn metaColumnClientOfTableAccount = metaTableAccount.Columns.First(c => c.Name.Equals("client_id"));
            metaIndex.Columns.Add(new MetaIndexColumnMapping("Code", metaColumnCodeOfTableAccount, 1, SortOrder.Ascending));
            metaIndex.Columns.Add(new MetaIndexColumnMapping("Client", metaColumnClientOfTableAccount, 1, SortOrder.Ascending));
            metaIndex.Clustered = true;
            metaIndex.Unique = true;
            metaTableAccount.Indexes.Add(metaIndex);
            metadataContainer.Indexes.Add(metaIndex);

            MetaTable metaTableUser = metadataContainer.Tables.First(t => t.Name.Equals("user"));
            MetaIndex metaIndexNameOfTableUser = new MetaIndex("idx_user_name", metaTableUser);
            MetaColumn metaColumnNameOfTableUser = metaTableUser.Columns.First(c => c.Name.Equals("name"));
            metaIndexNameOfTableUser.Columns.Add(new MetaIndexColumnMapping("Name", metaColumnNameOfTableUser, 1, SortOrder.Ascending));
            metaIndexNameOfTableUser.Clustered = true;
            metaIndexNameOfTableUser.Unique = true;
            metaTableUser.Indexes.Add(metaIndexNameOfTableUser);
            metadataContainer.Indexes.Add(metaIndexNameOfTableUser);

            MetaIndex metaIndexEmailOfTableUser = new MetaIndex("idx_user_email", metaTableUser);
            MetaColumn metaColumnEmailOfTableUser = metaTableUser.Columns.First(c => c.Name.Equals("email"));
            metaIndexEmailOfTableUser.Columns.Add(new MetaIndexColumnMapping("Email", metaColumnEmailOfTableUser, 1, SortOrder.Ascending));
            metaIndexEmailOfTableUser.Clustered = true;
            metaIndexEmailOfTableUser.Unique = true;
            metaTableUser.Indexes.Add(metaIndexEmailOfTableUser);
            metadataContainer.Indexes.Add(metaIndexEmailOfTableUser);

            MetaTable metaTableBusinessPartner = metadataContainer.Tables.First(t => t.Name.Equals("business_partner"));
            MetaIndex metaIndexNameOfTableBusinessPartner = new MetaIndex("idx_business_partner_code", metaTableBusinessPartner);
            MetaColumn metaColumnCodeOfTableBusinessPartner = metaTableBusinessPartner.Columns.First(c => c.Name.Equals("code"));
            MetaColumn metaColumnClientOfTableBusinessPartner = metaTableBusinessPartner.Columns.First(c => c.Name.Equals("client_id"));
            metaIndexNameOfTableBusinessPartner.Columns.Add(new MetaIndexColumnMapping("Code", metaColumnCodeOfTableBusinessPartner, 1, SortOrder.Ascending));
            metaIndexNameOfTableBusinessPartner.Columns.Add(new MetaIndexColumnMapping("Client", metaColumnClientOfTableBusinessPartner, 1, SortOrder.Ascending));
            metaIndexNameOfTableBusinessPartner.Clustered = true;
            metaIndexNameOfTableBusinessPartner.Unique = true;
            metaTableBusinessPartner.Indexes.Add(metaIndexNameOfTableBusinessPartner);
            metadataContainer.Indexes.Add(metaIndexNameOfTableBusinessPartner);

            MetaTable metaTableBusinessPartnerGroup = metadataContainer.Tables.First(t => t.Name.Equals("business_partner_group"));
            MetaIndex metaIndexNameOfTableBusinessPartnerGroup = new MetaIndex("idx_business_partner_group_code", metaTableBusinessPartner);
            MetaColumn metaColumnCodeOfTableBusinessPartnerGroup = metaTableBusinessPartnerGroup.Columns.First(c => c.Name.Equals("code"));
            MetaColumn metaColumnClientOfTableBusinessPartnerGroup = metaTableBusinessPartnerGroup.Columns.First(c => c.Name.Equals("client_id"));
            metaIndexNameOfTableBusinessPartnerGroup.Columns.Add(new MetaIndexColumnMapping("Code", metaColumnCodeOfTableBusinessPartnerGroup, 1, SortOrder.Ascending));
            metaIndexNameOfTableBusinessPartnerGroup.Columns.Add(new MetaIndexColumnMapping("Client", metaColumnClientOfTableBusinessPartnerGroup, 1, SortOrder.Ascending));
            metaIndexNameOfTableBusinessPartnerGroup.Clustered = true;
            metaIndexNameOfTableBusinessPartnerGroup.Unique = true;
            metaTableBusinessPartnerGroup.Indexes.Add(metaIndexNameOfTableBusinessPartnerGroup);
            metadataContainer.Indexes.Add(metaIndexNameOfTableBusinessPartnerGroup);

            MetaTable metaTableJob = metadataContainer.Tables.First(t => t.Name.Equals("job"));
            MetaIndex metaIndexNameOfTableJob = new MetaIndex("idx_job_code", metaTableJob);
            MetaColumn metaColumnCodeOfTableJob = metaTableJob.Columns.First(c => c.Name.Equals("code"));
            MetaColumn metaColumnClientOfTableJob = metaTableJob.Columns.First(c => c.Name.Equals("client_id"));
            metaIndexNameOfTableJob.Columns.Add(new MetaIndexColumnMapping("Code", metaColumnCodeOfTableJob, 1, SortOrder.Ascending));
            metaIndexNameOfTableJob.Columns.Add(new MetaIndexColumnMapping("Client", metaColumnClientOfTableJob, 1, SortOrder.Ascending));
            metaIndexNameOfTableJob.Clustered = true;
            metaIndexNameOfTableJob.Unique = true;
            metaTableJob.Indexes.Add(metaIndexNameOfTableJob);
            metadataContainer.Indexes.Add(metaIndexNameOfTableJob);

            MetaTable metaTableJobGroup = metadataContainer.Tables.First(t => t.Name.Equals("job_group"));
            MetaIndex metaIndexNameOfTableJobGroup = new MetaIndex("idx_job_group_code", metaTableJobGroup);
            MetaColumn metaColumnCodeOfTableJobGroup = metaTableJobGroup.Columns.First(c => c.Name.Equals("code"));
            MetaColumn metaColumnClientOfTableJobGroup = metaTableJobGroup.Columns.First(c => c.Name.Equals("client_id"));
            metaIndexNameOfTableJobGroup.Columns.Add(new MetaIndexColumnMapping("Code", metaColumnCodeOfTableJobGroup, 1, SortOrder.Ascending));
            metaIndexNameOfTableJobGroup.Columns.Add(new MetaIndexColumnMapping("Client", metaColumnClientOfTableJobGroup, 1, SortOrder.Ascending));
            metaIndexNameOfTableJobGroup.Clustered = true;
            metaIndexNameOfTableJobGroup.Unique = true;
            metaTableJobGroup.Indexes.Add(metaIndexNameOfTableJobGroup);
            metadataContainer.Indexes.Add(metaIndexNameOfTableJobGroup);

            MetaTable metaTablePaymentTerm = metadataContainer.Tables.First(t => t.Name.Equals("payment_term"));
            MetaIndex metaIndexNameOfTablePaymentTerm = new MetaIndex("idx_payment_term_code", metaTablePaymentTerm);
            MetaColumn metaColumnCodeOfTablePaymentTerm = metaTablePaymentTerm.Columns.First(c => c.Name.Equals("code"));
            MetaColumn metaColumnClientOfTablePaymentTerm = metaTablePaymentTerm.Columns.First(c => c.Name.Equals("client_id"));
            metaIndexNameOfTablePaymentTerm.Columns.Add(new MetaIndexColumnMapping("Code", metaColumnCodeOfTablePaymentTerm, 1, SortOrder.Ascending));
            metaIndexNameOfTablePaymentTerm.Columns.Add(new MetaIndexColumnMapping("Client", metaColumnClientOfTablePaymentTerm, 1, SortOrder.Ascending));
            metaIndexNameOfTablePaymentTerm.Clustered = true;
            metaIndexNameOfTablePaymentTerm.Unique = true;
            metaTablePaymentTerm.Indexes.Add(metaIndexNameOfTablePaymentTerm);
            metadataContainer.Indexes.Add(metaIndexNameOfTablePaymentTerm);

            MetaTable metaTableGeneralJournalSetup = metadataContainer.Tables.First(t => t.Name.Equals("general_journal_setup"));
            MetaIndex metaIndexOrgOfTableGeneralJournalSetup = new MetaIndex("idx_general_journal_setup_organization_id", metaTableGeneralJournalSetup);
            MetaColumn metaColumnOrganizationOfTableGeneralJournalSetup = metaTableGeneralJournalSetup.Columns.First(c => c.Name.Equals("organization_id"));
            MetaColumn metaColumnClientOfTableGeneralJournalSetup = metaTablePaymentTerm.Columns.First(c => c.Name.Equals("client_id"));
            metaIndexOrgOfTableGeneralJournalSetup.Columns.Add(new MetaIndexColumnMapping("Organization", metaColumnOrganizationOfTableGeneralJournalSetup, 1, SortOrder.Ascending));
            metaIndexOrgOfTableGeneralJournalSetup.Columns.Add(new MetaIndexColumnMapping("Client", metaColumnClientOfTableGeneralJournalSetup, 1, SortOrder.Ascending));
            metaIndexOrgOfTableGeneralJournalSetup.Clustered = true;
            metaIndexOrgOfTableGeneralJournalSetup.Unique = true;
            metaTableGeneralJournalSetup.Indexes.Add(metaIndexOrgOfTableGeneralJournalSetup);
            metadataContainer.Indexes.Add(metaIndexOrgOfTableGeneralJournalSetup);

            //General Journal Document
            MetaTable metaTableGeneralJournalDocument = metadataContainer.Tables.First(t => t.Name.Equals("general_journal_document"));
            MetaIndex metaIndexNoOfTableGeneralJournalDocument = new MetaIndex("idx_general_journal_document_no", metaTableGeneralJournalDocument);
            MetaColumn metaColumnNoOfTableGeneralJournalDocument = metaTableGeneralJournalDocument.Columns.First(c => c.Name.Equals("document_no"));
            metaIndexNoOfTableGeneralJournalDocument.Columns.Add(new MetaIndexColumnMapping("DocumentNo", metaColumnNoOfTableGeneralJournalDocument, 1, SortOrder.Ascending));
            metaTableGeneralJournalDocument.Indexes.Add(metaIndexNoOfTableGeneralJournalDocument);
            metadataContainer.Indexes.Add(metaIndexNoOfTableGeneralJournalDocument);

            MetaIndex metaIndexClientOfTableGeneralJournalDocument = new MetaIndex("idx_general_journal_document_client", metaTableGeneralJournalDocument);
            MetaColumn metaColumnClientOfTableGeneralJournalDocument = metaTableGeneralJournalDocument.Columns.First(c => c.Name.Equals("client_id"));
            metaIndexClientOfTableGeneralJournalDocument.Columns.Add(new MetaIndexColumnMapping("Client", metaColumnClientOfTableGeneralJournalDocument, 1, SortOrder.Ascending));
            metaTableGeneralJournalDocument.Indexes.Add(metaIndexClientOfTableGeneralJournalDocument);
            metadataContainer.Indexes.Add(metaIndexClientOfTableGeneralJournalDocument);

            MetaIndex metaIndexOrganizationOfTableGeneralJournalDocument = new MetaIndex("idx_general_journal_document_organization", metaTableGeneralJournalDocument);
            MetaColumn metaColumnOrganizationOfTableGeneralJournalDocument = metaTableGeneralJournalDocument.Columns.First(c => c.Name.Equals("organization_id"));
            metaIndexOrganizationOfTableGeneralJournalDocument.Columns.Add(new MetaIndexColumnMapping("Organization", metaColumnOrganizationOfTableGeneralJournalDocument, 1, SortOrder.Ascending));
            metaTableGeneralJournalDocument.Indexes.Add(metaIndexOrganizationOfTableGeneralJournalDocument);
            metadataContainer.Indexes.Add(metaIndexOrganizationOfTableGeneralJournalDocument);

            MetaIndex metaIndexPostedDateOfTableGeneralJournalDocument = new MetaIndex("idx_general_journal_document_posted", metaTableGeneralJournalDocument);
            MetaColumn metaColumnPostedDateOfTableGeneralJournalDocument = metaTableGeneralJournalDocument.Columns.First(c => c.Name.Equals("document_posted_date"));
            metaIndexPostedDateOfTableGeneralJournalDocument.Columns.Add(new MetaIndexColumnMapping("PostedDate", metaColumnPostedDateOfTableGeneralJournalDocument, 1, SortOrder.Ascending));
            metaTableGeneralJournalDocument.Indexes.Add(metaIndexPostedDateOfTableGeneralJournalDocument);
            metadataContainer.Indexes.Add(metaIndexPostedDateOfTableGeneralJournalDocument);

            //General Journal Line
            MetaTable metaTableGeneralJournalLine = metadataContainer.Tables.First(t => t.Name.Equals("general_journal_line"));

            MetaIndex metaIndexNoOfTableGeneralJournalLine = new MetaIndex("idx_general_journal_line_document_no", metaTableGeneralJournalLine);
            MetaColumn metaColumnNoOfTableGeneralJournalLine = metaTableGeneralJournalLine.Columns.First(c => c.Name.Equals("document_no"));
            metaIndexNoOfTableGeneralJournalLine.Columns.Add(new MetaIndexColumnMapping("DocumentNo", metaColumnNoOfTableGeneralJournalLine, 1, SortOrder.Ascending));
            metaTableGeneralJournalLine.Indexes.Add(metaIndexNoOfTableGeneralJournalLine);
            metadataContainer.Indexes.Add(metaIndexNoOfTableGeneralJournalLine);

            MetaIndex metaIndexClientOfTableGeneralJournalLine = new MetaIndex("idx_general_journal_line_client", metaTableGeneralJournalLine);
            MetaColumn metaColumnClientOfTableGeneralJournalLine = metaTableGeneralJournalLine.Columns.First(c => c.Name.Equals("client_id"));
            metaIndexClientOfTableGeneralJournalLine.Columns.Add(new MetaIndexColumnMapping("Client", metaColumnClientOfTableGeneralJournalLine, 1, SortOrder.Ascending));
            metaTableGeneralJournalLine.Indexes.Add(metaIndexClientOfTableGeneralJournalLine);
            metadataContainer.Indexes.Add(metaIndexClientOfTableGeneralJournalLine);

            MetaIndex metaIndexOrganizationOfTableGeneralJournalLine = new MetaIndex("idx_general_journal_line_organization", metaTableGeneralJournalLine);
            MetaColumn metaColumnOrganizationOfTableGeneralJournalLine = metaTableGeneralJournalLine.Columns.First(c => c.Name.Equals("organization_id"));
            metaIndexOrganizationOfTableGeneralJournalLine.Columns.Add(new MetaIndexColumnMapping("Organization", metaColumnOrganizationOfTableGeneralJournalLine, 1, SortOrder.Ascending));
            metaTableGeneralJournalLine.Indexes.Add(metaIndexOrganizationOfTableGeneralJournalLine);
            metadataContainer.Indexes.Add(metaIndexOrganizationOfTableGeneralJournalLine);

            MetaIndex metaIndexPostedDateOfTableGeneralJournalLine = new MetaIndex("idx_general_journal_line_posted", metaTableGeneralJournalLine);
            MetaColumn metaColumnPostedDateOfTableGeneralJournalLine = metaTableGeneralJournalLine.Columns.First(c => c.Name.Equals("document_posted_date"));
            metaIndexPostedDateOfTableGeneralJournalLine.Columns.Add(new MetaIndexColumnMapping("PostedDate", metaColumnPostedDateOfTableGeneralJournalLine, 1, SortOrder.Ascending));
            metaTableGeneralJournalLine.Indexes.Add(metaIndexPostedDateOfTableGeneralJournalLine);
            metadataContainer.Indexes.Add(metaIndexPostedDateOfTableGeneralJournalLine);

            MetaIndex metaIndexLineNoOfTableGeneralJournalLine = new MetaIndex("idx_general_journal_line_no", metaTableGeneralJournalLine);
            MetaColumn metaColumnLineNoOfTableGeneralJournalLine = metaTableGeneralJournalLine.Columns.First(c => c.Name.Equals("line_no"));
            MetaColumn metaColumnDocumentIdOfTableGeneralJournalLine = metaTableGeneralJournalLine.Columns.First(c => c.Name.Equals("general_journal_document_id"));
            metaIndexLineNoOfTableGeneralJournalLine.Columns.Add(new MetaIndexColumnMapping("LineNo", metaColumnLineNoOfTableGeneralJournalLine, 1, SortOrder.Ascending));
            metaIndexLineNoOfTableGeneralJournalLine.Columns.Add(new MetaIndexColumnMapping("DocumentId", metaColumnDocumentIdOfTableGeneralJournalLine, 1, SortOrder.Ascending));
            metaIndexLineNoOfTableGeneralJournalLine.Unique = true;
            metaIndexLineNoOfTableGeneralJournalLine.Clustered = true;
            metaTableGeneralJournalLine.Indexes.Add(metaIndexLineNoOfTableGeneralJournalLine);
            metadataContainer.Indexes.Add(metaIndexLineNoOfTableGeneralJournalLine);

            base.OnDatabaseOpen(backendConfiguration, metadataContainer, aggregatedMetadataContainer);

        }

       public void UpdateSchema()
       {
           var handler = this.GetSchemaHandler();
           string script = null;
           try
           {
               script = handler.CreateUpdateDDLScript(null);
           }
           catch
           {
               bool throwException = false;
               try
               {
                   handler.CreateDatabase();
                   script = handler.CreateDDLScript();
               }
               catch
               {
                   throwException = true;
               }
               if (throwException)
               {
                   throw;
               }
           }
           if (string.IsNullOrEmpty(script) == false)
           {

               handler.ForceExecuteDDLScript(script);

           }
       }
    }
}
