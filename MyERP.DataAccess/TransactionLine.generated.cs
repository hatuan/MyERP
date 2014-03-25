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
	[Table("transaction_line")]
	[ConcurrencyControl(OptimisticConcurrencyControlStrategy.Changed)]
	public partial class TransactionLine
	{
		private string _stt_rec;
		[Column("stt_rec", IsPrimaryKey = true, Length = 0, Scale = 0, SqlType = "text")]
		[Storage("_stt_rec")]
		public virtual string Stt_Rec
		{
			get
			{
				return this._stt_rec;
			}
			set
			{
				this._stt_rec = value;
			}
		}
		
		private string _ma_ct;
		[Column("ma_ct", Length = 0, Scale = 0, SqlType = "text")]
		[Storage("_ma_ct")]
		public virtual string Ma_Ct
		{
			get
			{
				return this._ma_ct;
			}
			set
			{
				this._ma_ct = value;
			}
		}
		
		private DateTime _ngay_ct;
		[Column("ngay_ct", Length = 0, Scale = 0, SqlType = "date")]
		[Storage("_ngay_ct")]
		public virtual DateTime Ngay_Ct
		{
			get
			{
				return this._ngay_ct;
			}
			set
			{
				this._ngay_ct = value;
			}
		}
		
		private string _so_ct;
		[Column("so_ct", Length = 0, Scale = 0, SqlType = "text")]
		[Storage("_so_ct")]
		public virtual string So_Ct
		{
			get
			{
				return this._so_ct;
			}
			set
			{
				this._so_ct = value;
			}
		}
		
		private string _dien_giaii;
		[Column("dien_giaii", Length = 0, Scale = 0, SqlType = "text")]
		[Storage("_dien_giaii")]
		public virtual string Dien_Giaii
		{
			get
			{
				return this._dien_giaii;
			}
			set
			{
				this._dien_giaii = value;
			}
		}
		
		private string _tk_i;
		[Column("tk_i", Length = 0, Scale = 0, SqlType = "text")]
		[Storage("_tk_i")]
		public virtual string Tk_I
		{
			get
			{
				return this._tk_i;
			}
			set
			{
				this._tk_i = value;
			}
		}
		
		private decimal _ps_no_nt;
		[Column("ps_no_nt", Length = 38, Scale = 20, SqlType = "numeric")]
		[Storage("_ps_no_nt")]
		public virtual decimal Ps_No_Nt
		{
			get
			{
				return this._ps_no_nt;
			}
			set
			{
				this._ps_no_nt = value;
			}
		}
		
		private decimal _ps_co_nt;
		[Column("ps_co_nt", Length = 38, Scale = 20, SqlType = "numeric")]
		[Storage("_ps_co_nt")]
		public virtual decimal Ps_Co_Nt
		{
			get
			{
				return this._ps_co_nt;
			}
			set
			{
				this._ps_co_nt = value;
			}
		}
		
		private decimal _ps_no;
		[Column("ps_no", Length = 38, Scale = 20, SqlType = "numeric")]
		[Storage("_ps_no")]
		public virtual decimal Ps_No
		{
			get
			{
				return this._ps_no;
			}
			set
			{
				this._ps_no = value;
			}
		}
		
		private decimal _ps_co;
		[Column("ps_co", Length = 38, Scale = 20, SqlType = "numeric")]
		[Storage("_ps_co")]
		public virtual decimal Ps_Co
		{
			get
			{
				return this._ps_co;
			}
			set
			{
				this._ps_co = value;
			}
		}
		
		private string _nh_dk;
		[Column("nh_dk", Length = 0, Scale = 0, SqlType = "text")]
		[Storage("_nh_dk")]
		public virtual string Nh_Dk
		{
			get
			{
				return this._nh_dk;
			}
			set
			{
				this._nh_dk = value;
			}
		}
		
		private string _ma_kh_i;
		[Column("ma_kh_i", Length = 0, Scale = 0, SqlType = "text")]
		[Storage("_ma_kh_i")]
		public virtual string Ma_Kh_I
		{
			get
			{
				return this._ma_kh_i;
			}
			set
			{
				this._ma_kh_i = value;
			}
		}
		
		private string _ma_vv_i;
		[Column("ma_vv_i", Length = 0, Scale = 0, SqlType = "text")]
		[Storage("_ma_vv_i")]
		public virtual string Ma_Vv_I
		{
			get
			{
				return this._ma_vv_i;
			}
			set
			{
				this._ma_vv_i = value;
			}
		}
		
		private string _ma_td_i;
		[Column("ma_td_i", Length = 0, Scale = 0, SqlType = "text")]
		[Storage("_ma_td_i")]
		public virtual string Ma_Td_I
		{
			get
			{
				return this._ma_td_i;
			}
			set
			{
				this._ma_td_i = value;
			}
		}
		
		private long _ln;
		[Column("ln", IsPrimaryKey = true, Length = 0, Scale = 0, SqlType = "int8")]
		[Storage("_ln")]
		public virtual long Ln
		{
			get
			{
				return this._ln;
			}
			set
			{
				this._ln = value;
			}
		}
		
		private string _ma_ku;
		[Column("ma_ku", Length = 0, Scale = 0, SqlType = "text")]
		[Storage("_ma_ku")]
		public virtual string Ma_Ku
		{
			get
			{
				return this._ma_ku;
			}
			set
			{
				this._ma_ku = value;
			}
		}
		
		private BusinessPartner _dmkh;
		[ForeignKeyAssociation(SharedFields = "Ma_Kh_I", TargetFields = "Code")]
		[Storage("_dmkh")]
		public virtual BusinessPartner BusinessPartner
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
		
		private Job _dmvv;
		[ForeignKeyAssociation(SharedFields = "Ma_Vv_I", TargetFields = "Ma_Vv")]
		[Storage("_dmvv")]
		public virtual Job Job
		{
			get
			{
				return this._dmvv;
			}
			set
			{
				this._dmvv = value;
			}
		}
		
		private TransactionDocument _ph11;
		[ForeignKeyAssociation(SharedFields = "Stt_Rec", TargetFields = "Stt_Rec")]
		[Storage("_ph11")]
		public virtual TransactionDocument TransactionDocument
		{
			get
			{
				return this._ph11;
			}
			set
			{
				this._ph11 = value;
			}
		}
		
	}
}
#pragma warning restore 1591
