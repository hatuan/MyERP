using System;
using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(Organization.OrganizationMetadata))]
    public partial class Organization
    {
        internal sealed class OrganizationMetadata
        {
            public OrganizationMetadata()
            {
            }

            [Association("Organization-client-association", "ClientId", "ClientId")]
            public Client Client { get; set; }

            [Association("Organization-user-created-association", "RecCreatedById", "Id")]
            public User RecCreatedByUser { get; set; }

            [Association("Organization-user-modified-association", "RecModifiedById", "Id")]
            public User RecModifiedByUser { get; set; }
        }
        
        /// <summary>
        /// Cot khong co trong CSDL. Chi dung de su lay Organization.Code = "*" cua Organization hien tai sau thu tuc GET http://localhost/MyERP.Web/odata/Organizations(guid'...')/AllOrganization
        /// 
        /// Neu khong tao cot nay thi phai dung ActionConfiguration trong WebApiConfig.cs
        /// ActionConfiguration allOrganization = builder.Entity<Organization>().Action("AllOrganization");
        /// allOrganization.Parameter<Guid>("key");
        /// allOrganization.ReturnsFromEntitySet<Organization>("Organizations");
        /// va goi POST http://localhost/MyERP.Web/odata/Organizations(guid'...')/AllOrganization
        /// </summary>
        public virtual Organization AllOrganization { get; set; }

        public virtual GeneralJournalSetup GeneralJournalSetup { get; set; }
    }
}
