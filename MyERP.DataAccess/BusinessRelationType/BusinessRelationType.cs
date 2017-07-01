using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyERP.DataAccess.Resources;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Metadata.Fluent;

namespace MyERP.DataAccess
{
    [System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(BusinessRelationType.BusinessRelationTypeMetadata))]
    public partial class BusinessRelationType
    {
        private string _code;
        public virtual string Code
        {
            get
            {
                return this._code;
            }
            set
            {
                this._code = value;
            }
        }

        private string _name;
        public virtual string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        private DateTime _recModified;
        public virtual DateTime RecModified
        {
            get
            {
                return this._recModified;
            }
            set
            {
                this._recModified = value;
            }
        }

        private Guid _recCreatedById;
        public virtual Guid RecCreatedById
        {
            get
            {
                return this._recCreatedById;
            }
            set
            {
                this._recCreatedById = value;
            }
        }

        private DateTime _recCreated;
        public virtual DateTime RecCreated
        {
            get
            {
                return this._recCreated;
            }
            set
            {
                this._recCreated = value;
            }
        }

        private Guid _recModifiedById;
        public virtual Guid RecModifiedById
        {
            get
            {
                return this._recModifiedById;
            }
            set
            {
                this._recModifiedById = value;
            }
        }

        private byte _status;
        public virtual byte Status
        {
            get
            {
                return this._status;
            }
            set
            {
                this._status = value;
            }
        }

        private long _version;
        public virtual long Version
        {
            get
            {
                return this._version;
            }
            set
            {
                this._version = value;
            }
        }

        private Guid _id;
        public virtual Guid Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        private Guid _clientId;
        public virtual Guid ClientId
        {
            get
            {
                return this._clientId;
            }
            set
            {
                this._clientId = value;
            }
        }

        private Guid _organizationId;
        public virtual Guid OrganizationId
        {
            get
            {
                return this._organizationId;
            }
            set
            {
                this._organizationId = value;
            }
        }

        private Currency _currency;
        public virtual Currency Currency
        {
            get
            {
                return this._currency;
            }
            set
            {
                this._currency = value;
            }
        }

        private Account _parentAccount;
        public virtual Account ParentAccount
        {
            get
            {
                return this._parentAccount;
            }
            set
            {
                this._parentAccount = value;
            }
        }

        private User _user2;
        public virtual User RecModifiedByUser
        {
            get
            {
                return this._user2;
            }
            set
            {
                this._user2 = value;
            }
        }

        private User _user0;
        public virtual User RecCreatedByUser
        {
            get
            {
                return this._user0;
            }
            set
            {
                this._user0 = value;
            }
        }

        private Client _client;
        public virtual Client Client
        {
            get
            {
                return this._client;
            }
            set
            {
                this._client = value;
            }
        }

        private Organization _organization;
        public virtual Organization Organization
        {
            get
            {
                return this._organization;
            }
            set
            {
                this._organization = value;
            }
        }

        internal sealed class BusinessRelationTypeMetadata
        {
            public BusinessRelationTypeMetadata()
            {
            }

            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            public String Code { get; set; }

            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            public String Name { get; set; }
            
            [System.ComponentModel.DataAnnotations.Association("BusinessRelationType-client-association", "ClientId", "ClientId")]
            public Client Client { get; set; }

            [System.ComponentModel.DataAnnotations.Association("BusinessRelationType-organization-association", "OrganizationId", "Id")]
            public Organization Organization { get; set; }

            [System.ComponentModel.DataAnnotations.Association("BusinessRelationType-user-created-association", "RecCreatedById", "Id")]
            public User RecCreatedByUser { get; set; }

            [System.ComponentModel.DataAnnotations.Association("BusinessRelationType-user-modified-association", "RecModifiedById", "Id")]
            public User RecModifiedByUser { get; set; }

        }
    }

    public partial class EntitiesModelFluentMetadataSource
    {
        public MappingConfiguration<BusinessRelationType> GetBusinessRelationTypeMappingConfiguration()
        {
            MappingConfiguration<BusinessRelationType> configuration = this.GetBusinessRelationTypeClassConfiguration();
            this.PrepareBusinessRelationTypePropertyConfigurations(configuration);
            this.PrepareBusinessRelationTypeAssociationConfigurations(configuration);

            return configuration;
        }

        public MappingConfiguration<BusinessRelationType> GetBusinessRelationTypeClassConfiguration()
        {
            MappingConfiguration<BusinessRelationType> configuration = new MappingConfiguration<BusinessRelationType>();
            configuration.MapType(x => new { }).WithConcurencyControl(OptimisticConcurrencyControlStrategy.Version).ToTable("business_relation_type");

            return configuration;
        }

        public void PrepareBusinessRelationTypePropertyConfigurations(MappingConfiguration<BusinessRelationType> configuration)
        {
            configuration.HasProperty(x => x.Code).HasFieldName("_code").WithDataAccessKind(DataAccessKind.ReadWrite).ToColumn("code").IsNotNullable().HasColumnType("varchar").HasLength(0);
            configuration.HasProperty(x => x.Name).HasFieldName("_name").WithDataAccessKind(DataAccessKind.ReadWrite).ToColumn("name").IsNotNullable().HasColumnType("varchar").HasLength(0);
            configuration.HasProperty(x => x.RecModified).HasFieldName("_recModified").WithDataAccessKind(DataAccessKind.ReadWrite).ToColumn("rec_created_at").IsNotNullable().HasColumnType("timestamp with time zone");
            configuration.HasProperty(x => x.RecCreatedById).HasFieldName("_recCreatedById").WithDataAccessKind(DataAccessKind.ReadWrite).ToColumn("rec_created_by").IsNotNullable().HasColumnType("uuid").HasPrecision(0).HasScale(0);
            configuration.HasProperty(x => x.RecCreated).HasFieldName("_recCreated").WithDataAccessKind(DataAccessKind.ReadWrite).ToColumn("rec_modified_at").IsNotNullable().HasColumnType("timestamp with time zone");
            configuration.HasProperty(x => x.RecModifiedById).HasFieldName("_recModifiedById").WithDataAccessKind(DataAccessKind.ReadWrite).ToColumn("rec_modified_by").IsNotNullable().HasColumnType("uuid").HasPrecision(0).HasScale(0);
            configuration.HasProperty(x => x.Status).HasFieldName("_status").WithDataAccessKind(DataAccessKind.ReadWrite).ToColumn("status").IsNotNullable().HasColumnType("int2").HasPrecision(0).HasScale(0);
            configuration.HasProperty(x => x.Version).HasFieldName("_version").IsVersion().WithDataAccessKind(DataAccessKind.ReadWrite).ToColumn("version").IsNotNullable().HasColumnType("int8").HasPrecision(0).HasScale(0);
            configuration.HasProperty(x => x.Id).IsIdentity(KeyGenerator.Guid).HasFieldName("_id").WithDataAccessKind(DataAccessKind.ReadWrite).ToColumn("id").IsNotNullable().HasColumnType("uuid").HasPrecision(0).HasScale(0);
            configuration.HasProperty(x => x.ClientId).HasFieldName("_clientId").ToColumn("client_id").IsNotNullable().HasColumnType("uuid").HasPrecision(0).HasScale(0).WithConverter("OpenAccessRuntime.Data.GuidConverter");
            configuration.HasProperty(x => x.OrganizationId).HasFieldName("_organizationId").ToColumn("organization_id").IsNotNullable().HasColumnType("uuid").HasPrecision(0).HasScale(0).WithConverter("OpenAccessRuntime.Data.GuidConverter");
        }

        public void PrepareBusinessRelationTypeAssociationConfigurations(MappingConfiguration<BusinessRelationType> configuration)
        {
            configuration.HasAssociation(x => x.RecModifiedByUser).HasFieldName("_user2").ToColumn("rec_modified_by").IsRequired().WithDataAccessKind(DataAccessKind.ReadWrite);
            configuration.HasAssociation(x => x.RecCreatedByUser).HasFieldName("_user0").ToColumn("rec_created_by").IsRequired().WithDataAccessKind(DataAccessKind.ReadWrite);
            configuration.HasAssociation(x => x.Client).HasFieldName("_client").ToColumn("client_id").IsRequired().WithDataAccessKind(DataAccessKind.ReadWrite);
            configuration.HasAssociation(x => x.Organization).HasFieldName("_organization").ToColumn("organization_id").IsRequired().WithDataAccessKind(DataAccessKind.ReadWrite);
        }
    }
}
