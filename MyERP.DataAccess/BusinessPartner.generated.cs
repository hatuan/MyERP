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
	[Table("business_partner", UpdateSchema = true)]
	[ConcurrencyControl(OptimisticConcurrencyControlStrategy.Version)]
	[KeyGenerator(KeyGenerator.Guid)]
	public partial class BusinessPartner
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
		
		private string _vatCode;
		[Column("vat_code", Length = 0, Scale = 0, SqlType = "varchar")]
		[Storage("_vatCode")]
		public virtual string VatCode
		{
			get
			{
				return this._vatCode;
			}
			set
			{
				this._vatCode = value;
			}
		}
		
		private string _address;
		[Column("address", Length = 0, Scale = 0, SqlType = "varchar")]
		[Storage("_address")]
		public virtual string Address
		{
			get
			{
				return this._address;
			}
			set
			{
				this._address = value;
			}
		}
		
		private string _telephone;
		[Column("telephone", Length = 0, Scale = 0, SqlType = "varchar")]
		[Storage("_telephone")]
		public virtual string Telephone
		{
			get
			{
				return this._telephone;
			}
			set
			{
				this._telephone = value;
			}
		}
		
		private string _fax;
		[Column("fax", Length = 0, Scale = 0, SqlType = "varchar")]
		[Storage("_fax")]
		public virtual string Fax
		{
			get
			{
				return this._fax;
			}
			set
			{
				this._fax = value;
			}
		}
		
		private string _mail;
		[Column("e_mail", Length = 0, Scale = 0, SqlType = "varchar")]
		[Storage("_mail")]
		public virtual string Mail
		{
			get
			{
				return this._mail;
			}
			set
			{
				this._mail = value;
			}
		}
		
		private string _homePage;
		[Column("home_page", Length = 0, Scale = 0, SqlType = "varchar")]
		[Storage("_homePage")]
		public virtual string HomePage
		{
			get
			{
				return this._homePage;
			}
			set
			{
				this._homePage = value;
			}
		}
		
		private string _contactName;
		[Column("contact_name", Length = 0, Scale = 0, SqlType = "varchar")]
		[Storage("_contactName")]
		public virtual string ContactName
		{
			get
			{
				return this._contactName;
			}
			set
			{
				this._contactName = value;
			}
		}
		
		private string _comment;
		[Column("comment", Length = 0, Scale = 0, SqlType = "varchar")]
		[Storage("_comment")]
		public virtual string Comment
		{
			get
			{
				return this._comment;
			}
			set
			{
				this._comment = value;
			}
		}
		
		private Guid _employeeAccountId;
		[Column("employee_account_id", Length = 0, Scale = 0, SqlType = "uuid")]
		[Storage("_employeeAccountId")]
		public virtual Guid EmployeeAccountId
		{
			get
			{
				return this._employeeAccountId;
			}
			set
			{
				this._employeeAccountId = value;
			}
		}
		
		private Guid _businessPartnerGroupId1;
		[Column("business_partner_group_id1", Length = 0, Scale = 0, SqlType = "uuid")]
		[Storage("_businessPartnerGroupId1")]
		public virtual Guid BusinessPartnerGroupId1
		{
			get
			{
				return this._businessPartnerGroupId1;
			}
			set
			{
				this._businessPartnerGroupId1 = value;
			}
		}
		
		private Guid _businessPartnerGroupId2;
		[Column("business_partner_group_id2", Length = 0, Scale = 0, SqlType = "uuid")]
		[Storage("_businessPartnerGroupId2")]
		public virtual Guid BusinessPartnerGroupId2
		{
			get
			{
				return this._businessPartnerGroupId2;
			}
			set
			{
				this._businessPartnerGroupId2 = value;
			}
		}
		
		private Guid _businessPartnerGroupId3;
		[Column("business_partner_group_id3", Length = 0, Scale = 0, SqlType = "uuid")]
		[Storage("_businessPartnerGroupId3")]
		public virtual Guid BusinessPartnerGroupId3
		{
			get
			{
				return this._businessPartnerGroupId3;
			}
			set
			{
				this._businessPartnerGroupId3 = value;
			}
		}
		
		private decimal _creditLimit;
		[Column("credit_limit", Length = 38, Scale = 20, SqlType = "numeric")]
		[Storage("_creditLimit")]
		public virtual decimal CreditLimit
		{
			get
			{
				return this._creditLimit;
			}
			set
			{
				this._creditLimit = value;
			}
		}
		
		private decimal _amountLimit;
		[Column("amount_limit", Length = 38, Scale = 20, SqlType = "numeric")]
		[Storage("_amountLimit")]
		public virtual decimal AmountLimit
		{
			get
			{
				return this._amountLimit;
			}
			set
			{
				this._amountLimit = value;
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
		
		private Guid _paymentTermId;
		[Column("payment_term_id", Length = 0, Scale = 0, SqlType = "uuid")]
		[Storage("_paymentTermId")]
		public virtual Guid PaymentTermId
		{
			get
			{
				return this._paymentTermId;
			}
			set
			{
				this._paymentTermId = value;
			}
		}
		
		private bool _isCustomer;
		[Column("is_customer", Length = 0, Scale = 0, SqlType = "bool")]
		[Storage("_isCustomer")]
		public virtual bool IsCustomer
		{
			get
			{
				return this._isCustomer;
			}
			set
			{
				this._isCustomer = value;
			}
		}
		
		private bool _isVendor;
		[Column("is_vendor", Length = 0, Scale = 0, SqlType = "bool")]
		[Storage("_isVendor")]
		public virtual bool IsVendor
		{
			get
			{
				return this._isVendor;
			}
			set
			{
				this._isVendor = value;
			}
		}
		
		private bool _isEmployee;
		[Column("is_employee", Length = 0, Scale = 0, SqlType = "bool")]
		[Storage("_isEmployee")]
		public virtual bool IsEmployee
		{
			get
			{
				return this._isEmployee;
			}
			set
			{
				this._isEmployee = value;
			}
		}
		
		private Guid _customerAccountId;
		[Column("customer_account_id", Length = 0, Scale = 0, SqlType = "uuid")]
		[Storage("_customerAccountId")]
		public virtual Guid CustomerAccountId
		{
			get
			{
				return this._customerAccountId;
			}
			set
			{
				this._customerAccountId = value;
			}
		}
		
		private Guid _vendorAccountId;
		[Column("vendor_account_id", Length = 0, Scale = 0, SqlType = "uuid")]
		[Storage("_vendorAccountId")]
		public virtual Guid VendorAccountId
		{
			get
			{
				return this._vendorAccountId;
			}
			set
			{
				this._vendorAccountId = value;
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
		
		private Account _employeeAccount;
		[ForeignKeyAssociation(SharedFields = "EmployeeAccountId", TargetFields = "Id")]
		[Storage("_employeeAccount")]
		public virtual Account EmployeeAccount
		{
			get
			{
				return this._employeeAccount;
			}
			set
			{
				this._employeeAccount = value;
			}
		}
		
		private Account _vendorAccount;
		[ForeignKeyAssociation(SharedFields = "VendorAccountId", TargetFields = "Id")]
		[Storage("_vendorAccount")]
		public virtual Account VendorAccount
		{
			get
			{
				return this._vendorAccount;
			}
			set
			{
				this._vendorAccount = value;
			}
		}
		
		private Account _account1;
		[ForeignKeyAssociation(SharedFields = "CustomerAccountId", TargetFields = "Id")]
		[Storage("_account1")]
		public virtual Account CustomerAccount
		{
			get
			{
				return this._account1;
			}
			set
			{
				this._account1 = value;
			}
		}
		
		private PaymentTerm _paymentTerm;
		[ForeignKeyAssociation(SharedFields = "PaymentTermId", TargetFields = "Id")]
		[Storage("_paymentTerm")]
		public virtual PaymentTerm PaymentTerm
		{
			get
			{
				return this._paymentTerm;
			}
			set
			{
				this._paymentTerm = value;
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
		
		private User _user0;
		[ForeignKeyAssociation(SharedFields = "RecCreatedBy", TargetFields = "Id")]
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
		
		private User _user2;
		[ForeignKeyAssociation(SharedFields = "RecModifiedBy", TargetFields = "Id")]
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
		
		private BusinessPartnerGroup _businessPartnerGroup1;
		[ForeignKeyAssociation(SharedFields = "BusinessPartnerGroupId1", TargetFields = "Id")]
		[Storage("_businessPartnerGroup1")]
		public virtual BusinessPartnerGroup BusinessPartnerGroup1
		{
			get
			{
				return this._businessPartnerGroup1;
			}
			set
			{
				this._businessPartnerGroup1 = value;
			}
		}
		
		private BusinessPartnerGroup _businessPartnerGroup3;
		[ForeignKeyAssociation(SharedFields = "BusinessPartnerGroupId3", TargetFields = "Id")]
		[Storage("_businessPartnerGroup3")]
		public virtual BusinessPartnerGroup BusinessPartnerGroup3
		{
			get
			{
				return this._businessPartnerGroup3;
			}
			set
			{
				this._businessPartnerGroup3 = value;
			}
		}
		
		private BusinessPartnerGroup _businessPartnerGroup2;
		[ForeignKeyAssociation(SharedFields = "BusinessPartnerGroupId2", TargetFields = "Id")]
		[Storage("_businessPartnerGroup2")]
		public virtual BusinessPartnerGroup BusinessPartnerGroup2
		{
			get
			{
				return this._businessPartnerGroup2;
			}
			set
			{
				this._businessPartnerGroup2 = value;
			}
		}
		
	}
}
#pragma warning restore 1591
