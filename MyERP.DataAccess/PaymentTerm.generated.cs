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
	[Table("payment_term", UpdateSchema = true)]
	[ConcurrencyControl(OptimisticConcurrencyControlStrategy.Version)]
	public partial class PaymentTerm
	{
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
		
		private short _han_tt;
		[Column("han_tt", Length = 0, Scale = 0, SqlType = "int2")]
		[Storage("_han_tt")]
		public virtual short Han_Tt
		{
			get
			{
				return this._han_tt;
			}
			set
			{
				this._han_tt = value;
			}
		}
		
		private short _han_tt_gg;
		[Column("han_tt_gg", Length = 0, Scale = 0, SqlType = "int2")]
		[Storage("_han_tt_gg")]
		public virtual short Han_Tt_Gg
		{
			get
			{
				return this._han_tt_gg;
			}
			set
			{
				this._han_tt_gg = value;
			}
		}
		
		private decimal _pt_gg;
		[Column("pt_gg", Length = 38, Scale = 20, SqlType = "numeric")]
		[Storage("_pt_gg")]
		public virtual decimal Pt_Gg
		{
			get
			{
				return this._pt_gg;
			}
			set
			{
				this._pt_gg = value;
			}
		}
		
		private DateTime _date0;
		[Column("date0", Length = 0, Scale = 0, SqlType = "timestamp")]
		[Storage("_date0")]
		public virtual DateTime Date0
		{
			get
			{
				return this._date0;
			}
			set
			{
				this._date0 = value;
			}
		}
		
		private Guid _userId0;
		[Column("user_id0", Length = 0, Scale = 0, SqlType = "uuid")]
		[Storage("_userId0")]
		public virtual Guid UserId0
		{
			get
			{
				return this._userId0;
			}
			set
			{
				this._userId0 = value;
			}
		}
		
		private DateTime _date2;
		[Column("date2", Length = 0, Scale = 0, SqlType = "timestamp")]
		[Storage("_date2")]
		public virtual DateTime Date2
		{
			get
			{
				return this._date2;
			}
			set
			{
				this._date2 = value;
			}
		}
		
		private Guid _userId2;
		[Column("user_id2", Length = 0, Scale = 0, SqlType = "uuid")]
		[Storage("_userId2")]
		public virtual Guid UserId2
		{
			get
			{
				return this._userId2;
			}
			set
			{
				this._userId2 = value;
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
