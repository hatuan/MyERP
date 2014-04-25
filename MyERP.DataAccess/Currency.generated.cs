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
	[Table("currency", UpdateSchema = true)]
	[ConcurrencyControl(OptimisticConcurrencyControlStrategy.Version)]
	[KeyGenerator(KeyGenerator.Guid)]
	public partial class Currency
	{
		private Guid _id;
		[Column("id", IsPrimaryKey = true, Length = 0, Scale = 0, SqlType = "uuid")]
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
		
		private string _name;
		[Column("name", Length = 0, Scale = 0, SqlType = "varchar")]
		[Storage("_name")]
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
		
		private DateTime _recCreated;
		[Column("rec_created", Length = 0, Scale = 0, SqlType = "timestamp")]
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
		
		private Guid _recCreatedById;
		[Column("rec_created_by", Length = 0, Scale = 0, SqlType = "uuid")]
		[Storage("_recCreatedById")]
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
		
		private DateTime _recModified;
		[Column("rec_modified", Length = 0, Scale = 0, SqlType = "timestamp")]
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
		
		private Guid _recModifiedById;
		[Column("rec_modified_by", Length = 0, Scale = 0, SqlType = "uuid")]
		[Storage("_recModifiedById")]
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
		[Column("status", Length = 0, Scale = 0, SqlType = "int2")]
		[Storage("_status")]
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
		[Column("version", IsVersion = true, IsBackendVersion = true, Length = 0, Scale = 0, SqlType = "int8")]
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
		
		private string _code;
		[Column("code", Length = 0, Scale = 0, SqlType = "varchar")]
		[Storage("_code")]
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
		
		private User _user2;
		[ForeignKeyAssociation(SharedFields = "RecModifiedById", TargetFields = "Id")]
		[Storage("_user2")]
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
		[ForeignKeyAssociation(SharedFields = "RecCreatedById", TargetFields = "Id")]
		[Storage("_user0")]
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
		
	}
}
#pragma warning restore 1591
