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
	[Table("no_series", UpdateSchema = true)]
	[ConcurrencyControl(OptimisticConcurrencyControlStrategy.Version)]
	public partial class NoSeries
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
		[Column("code", OpenAccessType = OpenAccessType.Varchar, Length = 0, Scale = 0, SqlType = "varchar", Converter = "OpenAccessRuntime.Data.VariableLengthStringConverter")]
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
		
		private int _currentNo;
		[Column("current_no", Length = 0, Scale = 0, SqlType = "int4")]
		[Storage("_currentNo")]
		public virtual int CurrentNo
		{
			get
			{
				return this._currentNo;
			}
			set
			{
				this._currentNo = value;
			}
		}
		
		private int _endingNo;
		[Column("ending_no", Length = 0, Scale = 0, SqlType = "int4")]
		[Storage("_endingNo")]
		public virtual int EndingNo
		{
			get
			{
				return this._endingNo;
			}
			set
			{
				this._endingNo = value;
			}
		}
		
		private string _formatNo;
		[Column("format_no", Length = 0, Scale = 0, SqlType = "varchar")]
		[Storage("_formatNo")]
		public virtual string FormatNo
		{
			get
			{
				return this._formatNo;
			}
			set
			{
				this._formatNo = value;
			}
		}
		
		private bool _isDefault;
		[Column("is_default", Length = 0, Scale = 0, SqlType = "bool")]
		[Storage("_isDefault")]
		public virtual bool IsDefault
		{
			get
			{
				return this._isDefault;
			}
			set
			{
				this._isDefault = value;
			}
		}
		
		private bool _manual;
		[Column("manual", Length = 0, Scale = 0, SqlType = "bool")]
		[Storage("_manual")]
		public virtual bool Manual
		{
			get
			{
				return this._manual;
			}
			set
			{
				this._manual = value;
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
		
		private string _noSeqName;
		[Column("no_seq_name", Length = 0, Scale = 0, SqlType = "varchar")]
		[Storage("_noSeqName")]
		public virtual string NoSeqName
		{
			get
			{
				return this._noSeqName;
			}
			set
			{
				this._noSeqName = value;
			}
		}
		
		private Guid _organizationId;
		[Column("organization_id", Length = 0, Scale = 0, SqlType = "uuid")]
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
		
		private int _startingNo;
		[Column("starting_no", Length = 0, Scale = 0, SqlType = "int4")]
		[Storage("_startingNo")]
		public virtual int StartingNo
		{
			get
			{
				return this._startingNo;
			}
			set
			{
				this._startingNo = value;
			}
		}
		
		private short _status;
		[Column("status", Length = 0, Scale = 0, SqlType = "int2")]
		[Storage("_status")]
		public virtual short Status
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
		
		private Guid _recModifiedBy;
		[Column("rec_modified_by", Length = 0, Scale = 0, SqlType = "uuid")]
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
		
		private Guid _recCreatedBy;
		[Column("rec_created_by", Length = 0, Scale = 0, SqlType = "uuid")]
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
		
		private User _user;
		[ForeignKeyAssociation(SharedFields = "RecModifiedBy", TargetFields = "Id")]
		[Storage("_user")]
		public virtual User RecModidiedByUser
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
		[ForeignKeyAssociation(SharedFields = "RecCreatedBy", TargetFields = "Id")]
		[Storage("_user1")]
		public virtual User RecCreatedByUser
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
		
	}
}
#pragma warning restore 1591
