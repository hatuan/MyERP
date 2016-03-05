using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Data.Edm.Csdl;
using MyERP.DataAccess;

namespace MyERP.Web.Models
{
    public class GeneralJournalDocumentViewModels
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Organization")]
        public String OrganizationName { get; set; }

        [Required]
        [Display(Name = "DocumentCreated")]
        public DateTime DocumentCreated { get; set; }

        [Required]
        [Display(Name = "Document Posted")]
        public DateTime DocumentPosted { get; set; }

        [Required]
        [Display(Name = "DocumentNo")]
        public String DocumentNo { get; set; }

        [Display(Name = "Description")]
        public String Description { get; set; }

        public Guid NumberSequenceId { get; set; }

        [Display(Name = "Number Sequence")]
        public String NumberSequenceCode { get; set; }

        public Guid? CurrencyId { get; set; }

        [Display(Name="Currency")]
        public String CurrencyCode { get; set; }

        [Display(Name = "Exchange Rate Amount")]
        public Decimal ExchangeRateAmount { get; set; }

        [Display(Name = "Relational ExchRate Amount")]
        public Decimal RelationalExchRateAmount { get; set; }

        [Display(Name = "Total Credit Amount Lcy")]
        public Decimal TotalCreditAmountLcy { get; set; }

        [Display(Name = "Total Credit Amount")]
        public Decimal TotalCreditAmount { get; set; }

        [Display(Name = "Total Debit Amount Lcy")]
        public Decimal TotalDebitAmountLcy { get; set; }

        [Display(Name = "Total Debit Amount")]
        public Decimal TotalDebitAmount { get; set; }

        [Display(Name = "TransactionType")]
        public TransactionType TransactionType { get; set; }

        [Required]
        public Int64 Version { get; set; }

        [Required]
        [Display(Name = "Status")]
        public GeneralJournalDocumentStatusType Status { get; set; }

        [Required]
        [Display(Name="Created By")]
        public String RecCreateBy { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}")]
        [Display(Name = "Created")]
        public DateTime RecCreated { get; set; }

        [Required]
        [Display(Name = "Modified By")]
        public String RecModifiedBy { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}")]
        [Display(Name = "Modified")]
        public DateTime RecModified { get; set; }
    }

    public class GeneralJournalDocumentCreateViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Description")]
        public String Description { get; set; }

        [Required]
        [Display(Name = "Document Created")]
        public DateTime DocumentCreated { get; set; }

        [Required]
        [Display(Name = "Document Posted")]
        public DateTime DocumentPosted { get; set; }
        
        public Guid NumberSequenceId { get; set; }

        [Required]
        [Display(Name = "Number Sequence")]
        public String NumberSequenceCode { get; set; }

        public Guid? CurrencyId { get; set; }

        [Required]
        [Display(Name = "Currency")]
        public String CurrencyCode { get; set; }

        [Required]
        [Display(Name = "Status")]
        public GeneralJournalDocumentStatusType Status { get; set; }

        public Int64 Version { get; set; }
    }

    public class GeneralJournalDocumentEditViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Document Created")]
        public DateTime DocumentCreated { get; set; }

        [Required]
        [Display(Name = "Document Posted")]
        public DateTime DocumentPosted { get; set; }

        [Required]
        [Display(Name = "Document No")]
        public String DocumentNo { get; set; }

        public Guid NumberSequenceId { get; set; }

        [Required]
        [Display(Name = "Number Sequence")]
        public String NumberSequenceCode { get; set; }

        public Guid? CurrencyId { get; set; }

        [Required]
        [Display(Name = "Currency")]
        public String CurrencyCode { get; set; }

        [Required]
        [Display(Name = "Status")]
        public GeneralJournalDocumentStatusType Status { get; set; }

        public Int64 Version { get; set; }

        public ICollection<GeneralJournalLineEditViewModel> GeneralJournalLines { get; set; }
    }
    
    public class  GeneralJournalDocumentSearchViewModel
    {
        public GeneralJournalDocumentSearchViewModel()
        {
            Searches = new List<MyERP.Search.SearchFieldInfo>();
        }

        public List<MyERP.Search.SearchFieldInfo> Searches { get; set; }
    }
}