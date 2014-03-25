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
            MetaTable metaTableAccount = metadataContainer.Tables.First(t => t.Name.Equals("account"));
            MetaIndex metaIndex = new MetaIndex("idx_account_code", metaTableAccount);
            MetaColumn metaColumnRowGuid = metaTableAccount.Columns.First(c => c.Name.Equals("code"));
            metaIndex.Columns.Add(new MetaIndexColumnMapping("Code", metaColumnRowGuid, 1, SortOrder.Ascending));
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
