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
using MyERP.DataAccess;

namespace MyERP.DataAccess	
{
	public partial class UserInRole : IDataErrorInfo, INotifyPropertyChanging, INotifyPropertyChanged
	{
		private Guid _id;
		public virtual Guid Id
		{
			get
			{
				return this._id;
			}
			set
			{
				if(this._id != value)
				{
					this.OnPropertyChanging("Id");
					this._id = value;
					this.OnPropertyChanged("Id");
				}
			}
		}
		
		private Guid _roleId;
		public virtual Guid RoleId
		{
			get
			{
				return this._roleId;
			}
			set
			{
				if(this._roleId != value)
				{
					this.OnPropertyChanging("RoleId");
					this._roleId = value;
					this.OnPropertyChanged("RoleId");
				}
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
				if(this._version != value)
				{
					this.OnPropertyChanging("Version");
					this._version = value;
					this.OnPropertyChanged("Version");
				}
			}
		}
		
		private Guid _userId;
		public virtual Guid UserId
		{
			get
			{
				return this._userId;
			}
			set
			{
				if(this._userId != value)
				{
					this.OnPropertyChanging("UserId");
					this._userId = value;
					this.OnPropertyChanged("UserId");
				}
			}
		}
		
		private Role _role;
		public virtual Role Role
		{
			get
			{
				return this._role;
			}
			set
			{
				if(this._role != value)
				{
					this.OnPropertyChanging("Role");
					this._role = value;
					this.OnPropertyChanged("Role");
				}
			}
		}
		
		private User _user;
		public virtual User User
		{
			get
			{
				return this._user;
			}
			set
			{
				if(this._user != value)
				{
					this.OnPropertyChanging("User");
					this._user = value;
					this.OnPropertyChanged("User");
				}
			}
		}
		
		#region IDataErrorInfo members
		
		private string error = string.Empty;
		public string Error
		{
			get
			{
				return this.error;
			}
		}
		
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
