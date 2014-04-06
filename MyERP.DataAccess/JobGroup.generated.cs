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
	[Table("job_group", UpdateSchema = true)]
	[ConcurrencyControl(OptimisticConcurrencyControlStrategy.Changed)]
	public partial class JobGroup
	{
		private short _loai_nh;
		[Column("loai_nh", Length = 0, Scale = 0, SqlType = "int2")]
		[Storage("_loai_nh")]
		public virtual short Loai_Nh
		{
			get
			{
				return this._loai_nh;
			}
			set
			{
				this._loai_nh = value;
			}
		}
		
		private string _ma_nh;
		[Column("code", IsPrimaryKey = true, Length = 0, Scale = 0, SqlType = "text")]
		[Storage("_ma_nh")]
		public virtual string Code
		{
			get
			{
				return this._ma_nh;
			}
			set
			{
				this._ma_nh = value;
			}
		}
		
		private string _ten_nh;
		[Column("ten_nh", Length = 0, Scale = 0, SqlType = "text")]
		[Storage("_ten_nh")]
		public virtual string Ten_Nh
		{
			get
			{
				return this._ten_nh;
			}
			set
			{
				this._ten_nh = value;
			}
		}
		
		private string _ten_nh2;
		[Column("ten_nh2", Length = 0, Scale = 0, SqlType = "text")]
		[Storage("_ten_nh2")]
		public virtual string Ten_Nh2
		{
			get
			{
				return this._ten_nh2;
			}
			set
			{
				this._ten_nh2 = value;
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
		
		private Guid _user_id0;
		[Column("user_id0", Length = 0, Scale = 0, SqlType = "uuid")]
		[Storage("_user_id0")]
		public virtual Guid User_Id0
		{
			get
			{
				return this._user_id0;
			}
			set
			{
				this._user_id0 = value;
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
		
		private Guid _user_id2;
		[Column("user_id2", Length = 0, Scale = 0, SqlType = "uuid")]
		[Storage("_user_id2")]
		public virtual Guid User_Id2
		{
			get
			{
				return this._user_id2;
			}
			set
			{
				this._user_id2 = value;
			}
		}
		
		private User _userinfo;
		[ForeignKeyAssociation(SharedFields = "User_Id0", TargetFields = "Id")]
		[Storage("_userinfo")]
		public virtual User Userinfo0
		{
			get
			{
				return this._userinfo;
			}
			set
			{
				this._userinfo = value;
			}
		}
		
		private User _userinfo1;
		[ForeignKeyAssociation(SharedFields = "User_Id2", TargetFields = "Id")]
		[Storage("_userinfo1")]
		public virtual User Userinfo2
		{
			get
			{
				return this._userinfo1;
			}
			set
			{
				this._userinfo1 = value;
			}
		}
		
		private IList<Job> _dmvvs = new List<Job>();
		[Collection(InverseProperty = "Dmnhvv1")]
		[Storage("_dmvvs")]
		public virtual IList<Job> Dmvv1s
		{
			get
			{
				return this._dmvvs;
			}
		}
		
		private IList<Job> _dmvvs1 = new List<Job>();
		[Collection(InverseProperty = "Dmnhvv2")]
		[Storage("_dmvvs1")]
		public virtual IList<Job> Dmvv2s
		{
			get
			{
				return this._dmvvs1;
			}
		}
		
		private IList<Job> _dmvvs2 = new List<Job>();
		[Collection(InverseProperty = "Dmnhvv3")]
		[Storage("_dmvvs2")]
		public virtual IList<Job> Dmvv3s
		{
			get
			{
				return this._dmvvs2;
			}
		}
		
	}
}
#pragma warning restore 1591
