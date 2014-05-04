#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ClassGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using MyERP.DataAccess;

namespace MyERP.DataAccess	
{
	[Table("general_journal_setup", UpdateSchema = true)]
	[ConcurrencyControl(OptimisticConcurrencyControlStrategy.Version)]
	public partial class GeneralJournalSetup
	{
		private Guid _id;
		[Column("id", OpenAccessType = OpenAccessType.Guid, IsPrimaryKey = true, Length = 0, Scale = 0, SqlType = "uuid", Converter = "OpenAccessRuntime.Data.GuidConverter")]
		[Storage("_id")]
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
		
		private Guid _organizationId;
		[Column("organization_id", OpenAccessType = OpenAccessType.Guid, Length = 0, Scale = 0, SqlType = "uuid", Converter = "OpenAccessRuntime.Data.GuidConverter")]
		[Storage("_organizationId")]
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
		
		private Guid _clientId;
		[Column("client_id", OpenAccessType = OpenAccessType.Guid, Length = 0, Scale = 0, SqlType = "uuid", Converter = "OpenAccessRuntime.Data.GuidConverter")]
		[Storage("_clientId")]
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
		
		private Guid _localCurrencyId;
		[Column("local_currency_id", OpenAccessType = OpenAccessType.Guid, Length = 0, Scale = 0, SqlType = "uuid", Converter = "OpenAccessRuntime.Data.GuidConverter")]
		[Storage("_localCurrencyId")]
		public virtual Guid LocalCurrencyId
		{
			get
			{
				return this._localCurrencyId;
			}
			set
			{
				this._localCurrencyId = value;
			}
		}
		
		private int _lcyExchangeRateUnit;
		[Column("lcy_exchange_rate_unit", OpenAccessType = OpenAccessType.Int32, Length = 0, Scale = 0, SqlType = "int4", Converter = "OpenAccessRuntime.Data.IntConverter")]
		[Storage("_lcyExchangeRateUnit")]
		public virtual int LcyExchangeRateUnit
		{
			get
			{
				return this._lcyExchangeRateUnit;
			}
			set
			{
				this._lcyExchangeRateUnit = value;
			}
		}
		
		private Guid _defaultDocumentType1NoId;
		[Column("default_document_type_1_no_id", OpenAccessType = OpenAccessType.Guid, Length = 0, Scale = 0, SqlType = "uuid", Converter = "OpenAccessRuntime.Data.GuidConverter")]
		[Storage("_defaultDocumentType1NoId")]
		public virtual Guid DefaultDocumentType1NoId
		{
			get
			{
				return this._defaultDocumentType1NoId;
			}
			set
			{
				this._defaultDocumentType1NoId = value;
			}
		}
		
		private DateTime _recCreated;
		[Column("rec_created", OpenAccessType = OpenAccessType.DateTime, Length = 0, Scale = 0, SqlType = "timestamp", Converter = "OpenAccessRuntime.Data.PostgresTimestampTZConverter")]
		[Storage("_recCreated")]
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
		
		private DateTime _recModified;
		[Column("rec_modified", OpenAccessType = OpenAccessType.DateTime, Length = 0, Scale = 0, SqlType = "timestamp", Converter = "OpenAccessRuntime.Data.PostgresTimestampTZConverter")]
		[Storage("_recModified")]
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
		
		private Guid _recCreatedBy;
		[Column("rec_created_by", OpenAccessType = OpenAccessType.Guid, Length = 0, Scale = 0, SqlType = "uuid", Converter = "OpenAccessRuntime.Data.GuidConverter")]
		[Storage("_recCreatedBy")]
		public virtual Guid RecCreatedBy
		{
			get
			{
				return this._recCreatedBy;
			}
			set
			{
				this._recCreatedBy = value;
			}
		}
		
		private Guid _recModifiedBy;
		[Column("rec_modified_by", OpenAccessType = OpenAccessType.Guid, Length = 0, Scale = 0, SqlType = "uuid", Converter = "OpenAccessRuntime.Data.GuidConverter")]
		[Storage("_recModifiedBy")]
		public virtual Guid RecModifiedBy
		{
			get
			{
				return this._recModifiedBy;
			}
			set
			{
				this._recModifiedBy = value;
			}
		}
		
		private long _version;
		[Column("version", OpenAccessType = OpenAccessType.Int64, IsVersion = true, Length = 0, Scale = 0, SqlType = "int8", Converter = "OpenAccessRuntime.Data.BigIntConverter")]
		[Storage("_version")]
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
		
		private User _user;
		[ForeignKeyAssociation(SharedFields = "RecCreatedBy", TargetFields = "Id")]
		[Storage("_user")]
		public virtual User RecCreatedByUser
		{
			get
			{
				return this._user;
			}
			set
			{
				this._user = value;
			}
		}
		
		private User _user1;
		[ForeignKeyAssociation(SharedFields = "RecModifiedBy", TargetFields = "Id")]
		[Storage("_user1")]
		public virtual User RecModifiedByUser
		{
			get
			{
				return this._user1;
			}
			set
			{
				this._user1 = value;
			}
		}
		
		private Currency _currency;
		[ForeignKeyAssociation(SharedFields = "LocalCurrencyId", TargetFields = "Id")]
		[Storage("_currency")]
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
		
		private Organization _organization;
		[ForeignKeyAssociation(SharedFields = "OrganizationId", TargetFields = "Id")]
		[Storage("_organization")]
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
		
		private NoSeries _defaultDocumentType1No;
		[ForeignKeyAssociation(SharedFields = "DefaultDocumentType1NoId", TargetFields = "Id")]
		[Storage("_defaultDocumentType1No")]
		public virtual NoSeries DefaultDocumentType1No
		{
			get
			{
				return this._defaultDocumentType1No;
			}
			set
			{
				this._defaultDocumentType1No = value;
			}
		}
		
		private Client _client;
		[ForeignKeyAssociation(SharedFields = "ClientId", TargetFields = "Id")]
		[Storage("_client")]
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
		
	}
}
#pragma warning restore 1591
