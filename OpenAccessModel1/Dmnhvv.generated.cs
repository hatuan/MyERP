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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MyERPModel;

namespace MyERPModel	
{
	[Table("dmnhvv")]
	[ConcurrencyControl(OptimisticConcurrencyControlStrategy.Changed)]
	public partial class Dmnhvv : IDataErrorInfo, INotifyPropertyChanging, INotifyPropertyChanged
	{
		private short _loai_nh;
		[Column("loai_nh", Length = 0, Scale = 0, SqlType = "int2")]
		[Storage("_loai_nh")]
		[Required()]
		public virtual short Loai_Nh
		{
			get
			{
				return this._loai_nh;
			}
			set
			{
				if(this._loai_nh != value)
				{
					this.OnPropertyChanging("Loai_Nh");
					this._loai_nh = value;
					this.OnPropertyChanged("Loai_Nh");
				}
			}
		}
		
		private string _ma_nh;
		[Column("ma_nh", IsPrimaryKey = true, Length = 0, Scale = 0, SqlType = "text")]
		[Storage("_ma_nh")]
		[Required()]
		[Key()]
		public virtual string Ma_Nh
		{
			get
			{
				return this._ma_nh;
			}
			set
			{
				if(this._ma_nh != value)
				{
					this.OnPropertyChanging("Ma_Nh");
					this._ma_nh = value;
					this.OnPropertyChanged("Ma_Nh");
				}
			}
		}
		
		private string _ten_nh;
		[Column("ten_nh", Length = 0, Scale = 0, SqlType = "text")]
		[Storage("_ten_nh")]
		[Required()]
		public virtual string Ten_Nh
		{
			get
			{
				return this._ten_nh;
			}
			set
			{
				if(this._ten_nh != value)
				{
					this.OnPropertyChanging("Ten_Nh");
					this._ten_nh = value;
					this.OnPropertyChanged("Ten_Nh");
				}
			}
		}
		
		private string _ten_nh2;
		[Column("ten_nh2", Length = 0, Scale = 0, SqlType = "text")]
		[Storage("_ten_nh2")]
		[Required()]
		public virtual string Ten_Nh2
		{
			get
			{
				return this._ten_nh2;
			}
			set
			{
				if(this._ten_nh2 != value)
				{
					this.OnPropertyChanging("Ten_Nh2");
					this._ten_nh2 = value;
					this.OnPropertyChanged("Ten_Nh2");
				}
			}
		}
		
		private DateTime _date0;
		[Column("date0", Length = 0, Scale = 0, SqlType = "timestamp")]
		[Storage("_date0")]
		[Required()]
		public virtual DateTime Date0
		{
			get
			{
				return this._date0;
			}
			set
			{
				if(this._date0 != value)
				{
					this.OnPropertyChanging("Date0");
					this._date0 = value;
					this.OnPropertyChanged("Date0");
				}
			}
		}
		
		private long _user_id0;
		[Column("user_id0", Length = 0, Scale = 0, SqlType = "int8")]
		[Storage("_user_id0")]
		[Required()]
		public virtual long User_Id0
		{
			get
			{
				return this._user_id0;
			}
			set
			{
				if(this._user_id0 != value)
				{
					this.OnPropertyChanging("User_Id0");
					this._user_id0 = value;
					this.OnPropertyChanged("User_Id0");
				}
			}
		}
		
		private string _status;
		[Column("status", Length = 0, Scale = 0, SqlType = "text")]
		[Storage("_status")]
		[Required()]
		public virtual string Status
		{
			get
			{
				return this._status;
			}
			set
			{
				if(this._status != value)
				{
					this.OnPropertyChanging("Status");
					this._status = value;
					this.OnPropertyChanged("Status");
				}
			}
		}
		
		private DateTime _date2;
		[Column("date2", Length = 0, Scale = 0, SqlType = "timestamp")]
		[Storage("_date2")]
		[Required()]
		public virtual DateTime Date2
		{
			get
			{
				return this._date2;
			}
			set
			{
				if(this._date2 != value)
				{
					this.OnPropertyChanging("Date2");
					this._date2 = value;
					this.OnPropertyChanged("Date2");
				}
			}
		}
		
		private long _user_id2;
		[Column("user_id2", Length = 0, Scale = 0, SqlType = "int8")]
		[Storage("_user_id2")]
		[Required()]
		public virtual long User_Id2
		{
			get
			{
				return this._user_id2;
			}
			set
			{
				if(this._user_id2 != value)
				{
					this.OnPropertyChanging("User_Id2");
					this._user_id2 = value;
					this.OnPropertyChanged("User_Id2");
				}
			}
		}
		
		private Userinfo _userinfo;
		[ForeignKeyAssociation(SharedFields = "User_Id0", TargetFields = "User_Id")]
		[Storage("_userinfo")]
		public virtual Userinfo Userinfo0
		{
			get
			{
				return this._userinfo;
			}
			set
			{
				if(this._userinfo != value)
				{
					this.OnPropertyChanging("Userinfo0");
					this._userinfo = value;
					this.OnPropertyChanged("Userinfo0");
				}
			}
		}
		
		private Userinfo _userinfo1;
		[ForeignKeyAssociation(SharedFields = "User_Id2", TargetFields = "User_Id")]
		[Storage("_userinfo1")]
		public virtual Userinfo Userinfo2
		{
			get
			{
				return this._userinfo1;
			}
			set
			{
				if(this._userinfo1 != value)
				{
					this.OnPropertyChanging("Userinfo2");
					this._userinfo1 = value;
					this.OnPropertyChanged("Userinfo2");
				}
			}
		}
		
		private IList<Dmvv> _dmvvs = new List<Dmvv>();
		[Collection(InverseProperty = "Dmnhvv1")]
		[Storage("_dmvvs")]
		public virtual IList<Dmvv> Dmvv1s
		{
			get
			{
				return this._dmvvs;
			}
		}
		
		private IList<Dmvv> _dmvvs1 = new List<Dmvv>();
		[Collection(InverseProperty = "Dmnhvv2")]
		[Storage("_dmvvs1")]
		public virtual IList<Dmvv> Dmvv2s
		{
			get
			{
				return this._dmvvs1;
			}
		}
		
		private IList<Dmvv> _dmvvs2 = new List<Dmvv>();
		[Collection(InverseProperty = "Dmnhvv3")]
		[Storage("_dmvvs2")]
		public virtual IList<Dmvv> Dmvv3s
		{
			get
			{
				return this._dmvvs2;
			}
		}
		
		#region IDataErrorInfo members
		
		[Transient()]
		private string error = string.Empty;
		[Transient()]
		public string Error
		{
			get
			{
				return this.error;
			}
		}
		
		[Transient()]
		public string this[string propertyName]
		{
			get
			{
				this.ValidatePropertyInternal(propertyName, ref this.error);
		
				return this.error;
			}
		}
		
		protected virtual void ValidatePropertyInternal(string propertyName, ref string error)
		{
		    this.ValidateProperty(propertyName, ref error);
		}
		
		// Please implement this method in a partial class in order to provide the error message depending on each of the properties.
		partial void ValidateProperty(string propertyName, ref string error);
		
		#endregion
		
		#region INotifyPropertyChanging members
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		protected virtual void OnPropertyChanging(string propertyName)
		{
			if(this.PropertyChanging != null)
			{
				this.PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
			}
		}
		
		#endregion
		
		#region INotifyPropertyChanged members
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void OnPropertyChanged(string propertyName)
		{
			if(this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		#endregion
		
	}
}
#pragma warning restore 1591
