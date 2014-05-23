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
	public partial class GeneralJournalDocument
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
				this._id = value;
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
		
		private decimal _totalCreditAmountLcy;
		public virtual decimal TotalCreditAmountLcy
		{
			get
			{
				return this._totalCreditAmountLcy;
			}
			set
			{
				this._totalCreditAmountLcy = value;
			}
		}
		
		private Guid _numberSequenceId;
		public virtual Guid NumberSequenceId
		{
			get
			{
				return this._numberSequenceId;
			}
			set
			{
				this._numberSequenceId = value;
			}
		}
		
		private DateTime _documentCreated;
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
		
		private int _status;
		public virtual int Status
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
		
		private decimal _totalCreditAmount;
		public virtual decimal TotalCreditAmount
		{
			get
			{
				return this._totalCreditAmount;
			}
			set
			{
				this._totalCreditAmount = value;
			}
		}
		
		private decimal _totalDebitAmount;
		public virtual decimal TotalDebitAmount
		{
			get
			{
				return this._totalDebitAmount;
			}
			set
			{
				this._totalDebitAmount = value;
			}
		}
		
		private decimal _totalDebitAmountLcy;
		public virtual decimal TotalDebitAmountLcy
		{
			get
			{
				return this._totalDebitAmountLcy;
			}
			set
			{
				this._totalDebitAmountLcy = value;
			}
		}
		
		private TransactionType _transactionType;
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
		
		private int _currencyExchangeRate;
		public virtual int CurrencyExchangeRate
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
		
		private string _description;
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
		
		private User _recCreatedByUser;
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
		
		private User _recModifiedByUser;
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
		
		private Currency _currency;
		public virtual Currency Currency
		{
			get
			{
				return this._currency;
			}
			set
			{
				this._currency = value;
			}
		}
		
		private NumberSequence _numberSequence;
		public virtual NumberSequence NumberSequence
		{
			get
			{
				return this._numberSequence;
			}
			set
			{
				this._numberSequence = value;
			}
		}
		
		private IList<GeneralJournalLine> _generalJournalLines = new List<GeneralJournalLine>();
		public virtual IList<GeneralJournalLine> GeneralJournalLines
		{
			get
			{
				return this._generalJournalLines;
			}
		}
		
	}
}
#pragma warning restore 1591
