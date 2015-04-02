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
    public class CurrencyConvertRateViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Organization")]
        public String OrganizationName { get; set; }

        [Required]
        public Guid CurrencyId { get; set; }

        [Required]
        [Display(Name = "From Currency")]
        public String CurrencyCode { get; set; }

        [Required]
        public Guid CurrencyRelationalId { get; set; }

        [Required]
        [Display(Name = "To Currency")]
        public String CurrencyRelationalCode { get; set; }

        [Display(Name = "Exchange Rate Amount")]
        public short ExchangeRateAmount { get; set; }

        [Display(Name = "Relational Exch Rate Amount")]
        public short RelationalExchRateAmount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}")]
        [Display(Name = "Valid From")]
        public DateTime ValidFrom { get; set; }

        [Required]
        public Int64 Version { get; set; }

        [Required]
        [Display(Name = "Status")]
        public CurrencyConvertRateStatusType Status { get; set; }

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

    public class CurrencyConvertRateEditViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public Guid? CurrencyId { get; set; }

        [Required]
        [Display(Name = "From Currency")]
        public String CurrencyCode { get; set; }

        [Required]
        public Guid? CurrencyRelationId { get; set; }

        [Required]
        [Display(Name = "To Currency Name")]
        public String CurrencyRelationCode { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}")]
        [Display(Name = "Valid From")]
        public DateTime ValidFrom { get; set; }

        [Display(Name = "Exchange Rate Amount")]
        public short ExchangeRateAmount { get; set; }

        [Display(Name = "Relational Exch Rate Amount")]
        public short RelationalExchRateAmount { get; set; }

        [Required]
        [Display(Name = "Status")]
        public CurrencyConvertRateStatusType Status { get; set; }

        public Int64 Version { get; set; }
    }



    public class CurrencyConvertRateSearchViewModel
    {
        public CurrencyConvertRateSearchViewModel()
        {
            Searches = new List<MyERP.Search.SearchFieldInfo>();
        }

        public List<MyERP.Search.SearchFieldInfo> Searches { get; set; }
    }
}