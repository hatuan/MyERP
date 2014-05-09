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
	[Table("general_journal_line", UpdateSchema = true)]
	[ConcurrencyControl(OptimisticConcurrencyControlStrategy.Version)]
	[KeyGenerator(KeyGenerator.Guid)]
	public partial class GeneralJournalLine
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
		
		private Guid _corAccountId;
		[Column("cor_account_id", Length = 0, Scale = 0, SqlType = "uuid")]
		[Storage("_corAccountId")]
		public virtual Guid CorAccountId
		{
			get
			{
				return this._corAccountId;
			}
			set
			{
				this._corAccountId = value;
			}
		}
		
		private Guid _accountId;
		[Column("account_id", Length = 0, Scale = 0, SqlType = "uuid")]
		[Storage("_accountId")]
		public virtual Guid AccountId
		{
			get
			{
				return this._accountId;
			}
			set
			{
				this._accountId = value;
			}
		}
		
		private string _description;
		[Column("description", Length = 0, Scale = 0, SqlType = "varchar")]
		[Storage("_description")]
		public virtual string Description
		{
			get
			{
				return this._description;
			}
			set
			{
				this._description = value;
			}
		}
		
		private decimal _debitAmount;
		[Column("debit_amount", Length = 38, Scale = 20, SqlType = "numeric")]
		[Storage("_debitAmount")]
		public virtual decimal DebitAmount
		{
			get
			{
				return this._debitAmount;
			}
			set
			{
				this._debitAmount = value;
			}
		}
		
		private decimal _creditAmountLcy;
		[Column("credit_amount_lcy", Length = 38, Scale = 20, SqlType = "numeric")]
		[Storage("_creditAmountLcy")]
		public virtual decimal CreditAmountLcy
		{
			get
			{
				return this._creditAmountLcy;
			}
			set
			{
				this._creditAmountLcy = value;
			}
		}
		
		private decimal _debitAmountLcy;
		[Column("debit_amount_lcy", Length = 38, Scale = 20, SqlType = "numeric")]
		[Storage("_debitAmountLcy")]
		public virtual decimal DebitAmountLcy
		{
			get
			{
				return this._debitAmountLcy;
			}
			set
			{
				this._debitAmountLcy = value;
			}
		}
		
		private decimal _creditAmount;
		[Column("credit_amount", Length = 38, Scale = 20, SqlType = "numeric")]
		[Storage("_creditAmount")]
		public virtual decimal CreditAmount
		{
			get
			{
				return this._creditAmount;
			}
			set
			{
				this._creditAmount = value;
			}
		}
		
		private Guid _businessPartnerId;
		[Column("business_partner_id", IsNullable = true, Length = 0, Scale = 0, SqlType = "uuid")]
		[Storage("_businessPartnerId")]
		public virtual Guid BusinessPartnerId
		{
			get
			{
				return this._businessPartnerId;
			}
			set
			{
				this._businessPartnerId = value;
			}
		}
		
		private Guid _jobId;
		[Column("job_id", IsNullable = true, Length = 0, Scale = 0, SqlType = "uuid")]
		[Storage("_jobId")]
		public virtual Guid JobId
		{
			get
			{
				return this._jobId;
			}
			set
			{
				this._jobId = value;
			}
		}
		
		private long _lineNo;
		[Column("line_no", Length = 0, Scale = 0, SqlType = "int8")]
		[Storage("_lineNo")]
		public virtual long LineNo
		{
			get
			{
				return this._lineNo;
			}
			set
			{
				this._lineNo = value;
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
		
		private Guid _generalJournalDocumentId;
		[Column("general_journal_document_id", Length = 0, Scale = 0, SqlType = "uuid")]
		[Storage("_generalJournalDocumentId")]
		public virtual Guid GeneralJournalDocumentId
		{
			get
			{
				return this._generalJournalDocumentId;
			}
			set
			{
				this._generalJournalDocumentId = value;
			}
		}
		
		private decimal? _currencyExchangeRate;
		[Column("currency_exchange_rate", IsNullable = true, Length = 38, Scale = 20, SqlType = "numeric")]
		[Storage("_currencyExchangeRate")]
		public virtual decimal? CurrencyExchangeRate
		{
			get
			{
				return this._currencyExchangeRate;
			}
			set
			{
				this._currencyExchangeRate = value;
			}
		}
		
		private Guid? _currencyId;
		[Column("currency_id", IsNullable = true, Length = 0, Scale = 0, SqlType = "uuid")]
		[Storage("_currencyId")]
		public virtual Guid? CurrencyId
		{
			get
			{
				return this._currencyId;
			}
			set
			{
				this._currencyId = value;
			}
		}
		
		private DateTime _documentCreated;
		[Column("document_created_date", Length = 0, Scale = 0, SqlType = "date")]
		[Storage("_documentCreated")]
		public virtual DateTime DocumentCreated
		{
			get
			{
				return this._documentCreated;
			}
			set
			{
				this._documentCreated = value;
			}
		}
		
		private string _documentNo;
		[Column("document_no", Length = 0, Scale = 0, SqlType = "varchar")]
		[Storage("_documentNo")]
		public virtual string DocumentNo
		{
			get
			{
				return this._documentNo;
			}
			set
			{
				this._documentNo = value;
			}
		}
		
		private DateTime _documentPosted;
		[Column("document_posted_date", Length = 0, Scale = 0, SqlType = "date")]
		[Storage("_documentPosted")]
		public virtual DateTime DocumentPosted
		{
			get
			{
				return this._documentPosted;
			}
			set
			{
				this._documentPosted = value;
			}
		}
		
		private DocumentType _documentType;
		[Column("document_type", Length = 0, Scale = 0, SqlType = "int4")]
		[Storage("_documentType")]
		public virtual DocumentType DocumentType
		{
			get
			{
				return this._documentType;
			}
			set
			{
				this._documentType = value;
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
		
		private TransactionType _transactionType;
		[Column("transaction_type", Length = 0, Scale = 0, SqlType = "int4")]
		[Storage("_transactionType")]
		public virtual TransactionType TransactionType
		{
			get
			{
				return this._transactionType;
			}
			set
			{
				this._transactionType = value;
			}
		}
		
		private Guid _fixAssetId;
		[Column("fix_asset_id", OpenAccessType = OpenAccessType.Guid, IsNullable = true, Length = 0, Scale = 0, SqlType = "uuid", Converter = "OpenAccessRuntime.Data.GuidConverter")]
		[Storage("_fixAssetId")]
		public virtual Guid FixAssetId
		{
			get
			{
				return this._fixAssetId;
			}
			set
			{
				this._fixAssetId = value;
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
		
		private BusinessPartner _businessPartner;
		[ForeignKeyAssociation(SharedFields = "BusinessPartnerId", TargetFields = "Id")]
		[Storage("_businessPartner")]
		public virtual BusinessPartner BusinessPartner
		{
			get
			{
				return this._businessPartner;
			}
			set
			{
				this._businessPartner = value;
			}
		}
		
		private Job _job;
		[ForeignKeyAssociation(SharedFields = "JobId", TargetFields = "Id")]
		[Storage("_job")]
		public virtual Job Job
		{
			get
			{
				return this._job;
			}
			set
			{
				this._job = value;
			}
		}
		
		private User _recModifiedByUser;
		[ForeignKeyAssociation(SharedFields = "RecModifiedBy", TargetFields = "Id")]
		[Storage("_recModifiedByUser")]
		public virtual User RecModifiedByUser
		{
			get
			{
				return this._recModifiedByUser;
			}
			set
			{
				this._recModifiedByUser = value;
			}
		}
		
		private User _recCreatedByUser;
		[ForeignKeyAssociation(SharedFields = "RecCreatedBy", TargetFields = "Id")]
		[Storage("_recCreatedByUser")]
		public virtual User RecCreatedByUser
		{
			get
			{
				return this._recCreatedByUser;
			}
			set
			{
				this._recCreatedByUser = value;
			}
		}
		
		private Account _account;
		[ForeignKeyAssociation(SharedFields = "AccountId", TargetFields = "Id")]
		[Storage("_account")]
		public virtual Account Account
		{
			get
			{
				return this._account;
			}
			set
			{
				this._account = value;
			}
		}
		
		private Account _corAccount;
		[ForeignKeyAssociation(SharedFields = "CorAccountId", TargetFields = "Id")]
		[Storage("_corAccount")]
		public virtual Account CorAccount
		{
			get
			{
				return this._corAccount;
			}
			set
			{
				this._corAccount = value;
			}
		}
		
		private GeneralJournalDocument _transactionDocument;
		[ForeignKeyAssociation(SharedFields = "GeneralJournalDocumentId", TargetFields = "Id")]
		[Storage("_transactionDocument")]
		public virtual GeneralJournalDocument GeneralJournalDocument
		{
			get
			{
				return this._transactionDocument;
			}
			set
			{
				this._transactionDocument = value;
			}
		}
		
	}
}
#pragma warning restore 1591
