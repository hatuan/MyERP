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
	[Table("session")]
	public partial class Session
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
		
		private Guid _userId;
		[Column("user_id", OpenAccessType = OpenAccessType.Guid, Length = 0, Scale = 0, SqlType = "uuid", Converter = "OpenAccessRuntime.Data.GuidConverter")]
		[Storage("_userId")]
		public virtual Guid UserId
		{
			get
			{
				return this._userId;
			}
			set
			{
				this._userId = value;
			}
		}
		
		private bool _expire;
		[Column("expire", OpenAccessType = OpenAccessType.Bit, IsNullable = true, Length = 0, Scale = 0, SqlType = "bool", Converter = "OpenAccessRuntime.Data.BooleanConverter")]
		[Storage("_expire")]
		public virtual bool Expire
		{
			get
			{
				return this._expire;
			}
			set
			{
				this._expire = value;
			}
		}
		
		private DateTime? _workingDate;
		[Column("working_date", OpenAccessType = OpenAccessType.DateTime, Length = 0, Scale = 0, SqlType = "date", Converter = "OpenAccessRuntime.Data.PostgresTimestampTZConverter")]
		[Storage("_workingDate")]
		public virtual DateTime? WorkingDate
		{
			get
			{
				return this._workingDate;
			}
			set
			{
				this._workingDate = value;
			}
		}
		
		private Guid? _organizationId;
		[Column("organization_id", OpenAccessType = OpenAccessType.Guid, IsNullable = true, Length = 0, Scale = 0, SqlType = "uuid", Converter = "OpenAccessRuntime.Data.GuidConverter")]
		[Storage("_organizationId")]
		public virtual Guid? OrganizationId
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
		
		private DateTime _lastTime;
		[Column("last_time", OpenAccessType = OpenAccessType.DateTime, Length = 0, Scale = 0, SqlType = "timestamp", Converter = "OpenAccessRuntime.Data.PostgresTimestampTZConverter")]
		[Storage("_lastTime")]
		public virtual DateTime LastTime
		{
			get
			{
				return this._lastTime;
			}
			set
			{
				this._lastTime = value;
			}
		}
		
		private Guid? _warehouseId;
		[Column("warehouse_id", OpenAccessType = OpenAccessType.Guid, IsNullable = true, Length = 0, Scale = 0, SqlType = "uuid", Converter = "OpenAccessRuntime.Data.GuidConverter")]
		[Storage("_warehouseId")]
		public virtual Guid? WarehouseId
		{
			get
			{
				return this._warehouseId;
			}
			set
			{
				this._warehouseId = value;
			}
		}
		
		private Guid _clientId;
		[Column("client_id", Length = 0, Scale = 0, SqlType = "uuid")]
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
		
		private Client _client;
		[ForeignKeyAssociation(SharedFields = "ClientId", TargetFields = "ClientId")]
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
