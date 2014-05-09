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
	[Table("job", UpdateSchema = true)]
	[ConcurrencyControl(OptimisticConcurrencyControlStrategy.Version)]
	[KeyGenerator(KeyGenerator.Guid)]
	public partial class Job
	{
		private string _ma_vv;
		[Column("code", Length = 0, Scale = 0, SqlType = "varchar")]
		[Storage("_ma_vv")]
		public virtual string Code
		{
			get
			{
				return this._ma_vv;
			}
			set
			{
				this._ma_vv = value;
			}
		}
		
		private string _ten_vv;
		[Column("ten_vv", Length = 0, Scale = 0, SqlType = "varchar")]
		[Storage("_ten_vv")]
		public virtual string Ten_Vv
		{
			get
			{
				return this._ten_vv;
			}
			set
			{
				this._ten_vv = value;
			}
		}
		
		private string _ten_vv2;
		[Column("ten_vv2", Length = 0, Scale = 0, SqlType = "varchar")]
		[Storage("_ten_vv2")]
		public virtual string Ten_Vv2
		{
			get
			{
				return this._ten_vv2;
			}
			set
			{
				this._ten_vv2 = value;
			}
		}
		
		private Guid _ma_kh;
		[Column("business_partner_id", Length = 0, Scale = 0, SqlType = "uuid")]
		[Storage("_ma_kh")]
		public virtual Guid Ma_Kh
		{
			get
			{
				return this._ma_kh;
			}
			set
			{
				this._ma_kh = value;
			}
		}
		
		private string _nh_vv1;
		[Column("nh_vv1", Length = 0, Scale = 0, SqlType = "varchar")]
		[Storage("_nh_vv1")]
		public virtual string Nh_Vv1
		{
			get
			{
				return this._nh_vv1;
			}
			set
			{
				this._nh_vv1 = value;
			}
		}
		
		private string _nh_vv2;
		[Column("nh_vv2", Length = 0, Scale = 0, SqlType = "varchar")]
		[Storage("_nh_vv2")]
		public virtual string Nh_Vv2
		{
			get
			{
				return this._nh_vv2;
			}
			set
			{
				this._nh_vv2 = value;
			}
		}
		
		private string _nh_vv3;
		[Column("nh_vv3", Length = 0, Scale = 0, SqlType = "varchar")]
		[Storage("_nh_vv3")]
		public virtual string Nh_Vv3
		{
			get
			{
				return this._nh_vv3;
			}
			set
			{
				this._nh_vv3 = value;
			}
		}
		
		private DateTime _ngay_vv1;
		[Column("ngay_vv1", Length = 0, Scale = 0, SqlType = "date")]
		[Storage("_ngay_vv1")]
		public virtual DateTime Ngay_Vv1
		{
			get
			{
				return this._ngay_vv1;
			}
			set
			{
				this._ngay_vv1 = value;
			}
		}
		
		private DateTime _ngay_vv2;
		[Column("ngay_vv2", Length = 0, Scale = 0, SqlType = "date")]
		[Storage("_ngay_vv2")]
		public virtual DateTime Ngay_Vv2
		{
			get
			{
				return this._ngay_vv2;
			}
			set
			{
				this._ngay_vv2 = value;
			}
		}
		
		private Guid _ma_nt;
		[Column("ma_nt", Length = 0, Scale = 0, SqlType = "uuid")]
		[Storage("_ma_nt")]
		public virtual Guid Ma_Nt
		{
			get
			{
				return this._ma_nt;
			}
			set
			{
				this._ma_nt = value;
			}
		}
		
		private decimal _tien_nt;
		[Column("tien_nt", Length = 38, Scale = 20, SqlType = "numeric")]
		[Storage("_tien_nt")]
		public virtual decimal Tien_Nt
		{
			get
			{
				return this._tien_nt;
			}
			set
			{
				this._tien_nt = value;
			}
		}
		
		private decimal _tien;
		[Column("tien", Length = 38, Scale = 20, SqlType = "numeric")]
		[Storage("_tien")]
		public virtual decimal Tien
		{
			get
			{
				return this._tien;
			}
			set
			{
				this._tien = value;
			}
		}
		
		private string _ghi_chu;
		[Column("ghi_chu", Length = 0, Scale = 0, SqlType = "varchar")]
		[Storage("_ghi_chu")]
		public virtual string Ghi_Chu
		{
			get
			{
				return this._ghi_chu;
			}
			set
			{
				this._ghi_chu = value;
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
		
		private Guid _tk;
		[Column("tk", Length = 0, Scale = 0, SqlType = "uuid")]
		[Storage("_tk")]
		public virtual Guid Tk
		{
			get
			{
				return this._tk;
			}
			set
			{
				this._tk = value;
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
		
		private JobGroup _dmnhvv;
		[ForeignKeyAssociation(SharedFields = "Nh_Vv1", TargetFields = "Code")]
		[Storage("_dmnhvv")]
		public virtual JobGroup Dmnhvv1
		{
			get
			{
				return this._dmnhvv;
			}
			set
			{
				this._dmnhvv = value;
			}
		}
		
		private JobGroup _dmnhvv1;
		[ForeignKeyAssociation(SharedFields = "Nh_Vv2", TargetFields = "Code")]
		[Storage("_dmnhvv1")]
		public virtual JobGroup Dmnhvv2
		{
			get
			{
				return this._dmnhvv1;
			}
			set
			{
				this._dmnhvv1 = value;
			}
		}
		
		private JobGroup _dmnhvv2;
		[ForeignKeyAssociation(SharedFields = "Nh_Vv3", TargetFields = "Code")]
		[Storage("_dmnhvv2")]
		public virtual JobGroup Dmnhvv3
		{
			get
			{
				return this._dmnhvv2;
			}
			set
			{
				this._dmnhvv2 = value;
			}
		}
		
		private Account _dmtk;
		[ForeignKeyAssociation(SharedFields = "Tk", TargetFields = "Id")]
		[Storage("_dmtk")]
		public virtual Account Dmtk
		{
			get
			{
				return this._dmtk;
			}
			set
			{
				this._dmtk = value;
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
		
		private BusinessPartner _dmkh;
		[ForeignKeyAssociation(SharedFields = "Ma_Kh", TargetFields = "Id")]
		[Storage("_dmkh")]
		public virtual BusinessPartner Dmkh
		{
			get
			{
				return this._dmkh;
			}
			set
			{
				this._dmkh = value;
			}
		}
		
	}
}
#pragma warning restore 1591
