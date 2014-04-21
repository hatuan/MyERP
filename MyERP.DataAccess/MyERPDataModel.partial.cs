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
            //MetaColumn metaColumnClientOfTableBusinessPartnerGroup = metaTableBusinessPartnerGroup.Columns.First(c => c.Name.Equals("client_id"));
            metaIndexNameOfTableBusinessPartnerGroup.Columns.Add(new MetaIndexColumnMapping("Code", metaColumnCodeOfTableBusinessPartnerGroup, 1, SortOrder.Ascending));
            //metaIndexNameOfTableBusinessPartnerGroup.Columns.Add(new MetaIndexColumnMapping("Client", metaColumnClientOfTableBusinessPartnerGroup, 1, SortOrder.Ascending));
            metaIndexNameOfTableBusinessPartnerGroup.Clustered = true;
            metaIndexNameOfTableBusinessPartnerGroup.Unique = true;
            metaTableBusinessPartnerGroup.Indexes.Add(metaIndexNameOfTableBusinessPartnerGroup);
            metadataContainer.Indexes.Add(metaIndexNameOfTableBusinessPartnerGroup);

            MetaTable metaTableJob = metadataContainer.Tables.First(t => t.Name.Equals("job"));
            MetaIndex metaIndexNameOfTableJob = new MetaIndex("idx_job_code", metaTableJob);
            MetaColumn metaColumnCodeOfTableJob = metaTableJob.Columns.First(c => c.Name.Equals("code"));
            //MetaColumn metaColumnClientOfTableJob = metaTableJob.Columns.First(c => c.Name.Equals("client_id"));
            metaIndexNameOfTableJob.Columns.Add(new MetaIndexColumnMapping("Code", metaColumnCodeOfTableJob, 1, SortOrder.Ascending));
            //metaIndexNameOfTableJob.Columns.Add(new MetaIndexColumnMapping("Client", metaColumnClientOfTableJob, 1, SortOrder.Ascending));
            metaIndexNameOfTableJob.Clustered = true;
            metaIndexNameOfTableJob.Unique = true;
            metaTableJob.Indexes.Add(metaIndexNameOfTableJob);
            metadataContainer.Indexes.Add(metaIndexNameOfTableJob);

            MetaTable metaTableJobGroup = metadataContainer.Tables.First(t => t.Name.Equals("job_group"));
            MetaIndex metaIndexNameOfTableJobGroup = new MetaIndex("idx_job_group_code", metaTableJobGroup);
            MetaColumn metaColumnCodeOfTableJobGroup = metaTableJobGroup.Columns.First(c => c.Name.Equals("code"));
            //MetaColumn metaColumnClientOfTableJobGroup = metaTableJobGroup.Columns.First(c => c.Name.Equals("client_id"));
            metaIndexNameOfTableJobGroup.Columns.Add(new MetaIndexColumnMapping("Code", metaColumnCodeOfTableJobGroup, 1, SortOrder.Ascending));
            //metaIndexNameOfTableJobGroup.Columns.Add(new MetaIndexColumnMapping("Client", metaColumnClientOfTableJobGroup, 1, SortOrder.Ascending));
            metaIndexNameOfTableJobGroup.Clustered = true;
            metaIndexNameOfTableJobGroup.Unique = true;
            metaTableJobGroup.Indexes.Add(metaIndexNameOfTableJobGroup);
            metadataContainer.Indexes.Add(metaIndexNameOfTableJobGroup);

            MetaTable metaTablePaymentTerm = metadataContainer.Tables.First(t => t.Name.Equals("payment_term"));
            MetaIndex metaIndexNameOfTablePaymentTerm = new MetaIndex("idx_payment_term_code", metaTablePaymentTerm);
            MetaColumn metaColumnCodeOfTablePaymentTerm = metaTablePaymentTerm.Columns.First(c => c.Name.Equals("code"));
            //MetaColumn metaColumnClientOfTablePaymentTerm = metaTablePaymentTerm.Columns.First(c => c.Name.Equals("client_id"));
            metaIndexNameOfTablePaymentTerm.Columns.Add(new MetaIndexColumnMapping("Code", metaColumnCodeOfTablePaymentTerm, 1, SortOrder.Ascending));
            //metaIndexNameOfTablePaymentTerm.Columns.Add(new MetaIndexColumnMapping("Client", metaColumnClientOfTablePaymentTerm, 1, SortOrder.Ascending));
            metaIndexNameOfTablePaymentTerm.Clustered = true;
            metaIndexNameOfTablePaymentTerm.Unique = true;
            metaTablePaymentTerm.Indexes.Add(metaIndexNameOfTablePaymentTerm);
            metadataContainer.Indexes.Add(metaIndexNameOfTablePaymentTerm);

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
