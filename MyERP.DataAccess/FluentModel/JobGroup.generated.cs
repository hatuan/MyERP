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
	public partial class JobGroup
	{
		private short _level;
		public virtual short Level
		{
			get
			{
				return this._level;
			}
			set
			{
				this._level = value;
			}
		}
		
		private string _code;
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
		
		private Guid _recCreateBy;
		public virtual Guid RecCreateBy
		{
			get
			{
				return this._recCreateBy;
			}
			set
			{
				this._recCreateBy = value;
			}
		}
		
		private byte _status;
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
		
		private DateTime _recModified;
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
		
		private Guid _recModifiedBy;
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
		
		private Guid _clientId;
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
		
		private Client _client;
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
		
		private User _userinfo;
		public virtual User RecCreatedByUser
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
		public virtual User RecModifiedByUser
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
		
		private IList<Job> _job = new List<Job>();
		public virtual IList<Job> Job1s
		{
			get
			{
				return this._job;
			}
		}
		
		private IList<Job> _job1 = new List<Job>();
		public virtual IList<Job> Job2s
		{
			get
			{
				return this._job1;
			}
		}
		
		private IList<Job> _job2 = new List<Job>();
		public virtual IList<Job> Job3s
		{
			get
			{
				return this._job2;
			}
		}
		
	}
}
#pragma warning restore 1591