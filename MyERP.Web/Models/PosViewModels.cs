using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MyERP.DataAccess;
using MyERP.DataAccess.Enum;
using Newtonsoft.Json;

namespace MyERP.Web.Models
{
    public class PosHeaderViewModel
    {
        [Required]
        public Int64 Id { get; set; }

        [Required]
        [Display(Name = "Organization")]
        public String OrganizationCode { get; set; }

        [Display(Name = "Document No")]
        public string DocumentNo { get; set; }

        [Display(Name = "Document Date")]
        [Required]
        public DateTime DocumentDate { get; set; }

        [Required]
        [Display(Name = "Description")]
        public String Description { get; set; }

        [Display(Name = "Customer")]
        [Required]
        public String SellToCustomerCode { get; set; }

        [Display(Name = "Customer Name")]
        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String SellToCustomerName { get; set; }

        [Display(Name = "Address")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String SellToAddress { get; set; }

        [Display(Name = "Total Payment")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalPayment { get; set; }

        [Display(Name = "Cash Of Customer")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal CashOfCustomer { get; set; }

        [Display(Name = "Change Return")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal ChangeReturnToCustomer { get; set; }

        [Display(Name = "Location")]
        public String LocationCode { get; set; }

        [Display(Name = "Sales Person")]
        public String SalesPersonCode { get; set; }

        [Required]
        public Int64 Version { get; set; }

        [Required]
        [Display(Name = "Status")]
        public DefaultDocumentStatusType Status { get; set; }

        [Required]
        [Display(Name = "Created By")]
        public String RecCreateBy { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Created")]
        public DateTime RecCreatedAt { get; set; }

        [Required]
        [Display(Name = "Modified By")]
        public String RecModifiedBy { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Modified")]
        public DateTime RecModifiedAt { get; set; }
    }

    public class PosHeaderEditViewModel
    {
        public long? Id { get; set; }

        [Display(Name = "Document No")]
        public string DocumentNo { get; set; }

        [Display(Name = "Sequence No")]
        [Required]
        public long DocSequenceId { get; set; }

        [Display(Name = "Document Date")]
        [Required]
        public DateTime DocumentDate { get; set; }

        [Display(Name = "Currency")]
        [Required]
        public long CurrencyId { get; set; }

        [Display(Name = "Currency Factor")]
        [Required]
        public Decimal CurrencyFactor { get; set; }

        [Display(Name = "Customer")]
        [Required]
        public long SellToCustomerId { get; set; }

        [Display(Name = "Customer Name")]
        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String SellToCustomerName { get; set; }

        [Display(Name = "Address")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String SellToAddress { get; set; }

        [Display(Name = "Description")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Description { get; set; }

        [Display(Name = "Total Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalAmount { get; set; }

        [Display(Name = "Total Vat Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalVatAmount { get; set; }

        [Display(Name = "Total Line Discount Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalLineDiscountAmount { get; set; }

        [Display(Name = "Invoice Discount %")]
        [DisplayFormat(DataFormatString = "{0:n}")]
        public byte InvoiceDiscountPercentage { get; set; }

        [Display(Name = "Invoice Discount Amount")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal InvoiceDiscountAmount { get; set; }

        [Display(Name = "Total Payment")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal TotalPayment { get; set; }

        [Display(Name = "Cash Of Customer")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal CashOfCustomer { get; set; }

        [Display(Name = "Change Return")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public Decimal ChangeReturnToCustomer { get; set; }

        [Display(Name = "Location")]
        public long LocationId { get; set; }

        [Display(Name = "Sales Person")]
        public long SalesPersonId { get; set; }

        [EnsureMinimumElements(1, ErrorMessage = "At least a POS Line is required")]
        [JsonProperty("PosLines")]
        public List<PosLineEditViewModel> PosLines { get; set; }

        [JsonProperty("Version")]
        public Int64 Version { get; set; }

        [JsonProperty("Status")]
        public DefaultDocumentStatusType Status { get; set; }

        [Display(Name = "Created By")]
        public String RecCreateBy { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created At")]
        public DateTime RecCreatedAt { get; set; }

        [Display(Name = "Modified By")]
        public String RecModifiedBy { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Modified At")]
        public DateTime RecModifiedAt { get; set; }
    }

    public class PosLineEditViewModel
    {
        public long? Id { get; set; }

        [Required]
        public long LineNo { get; set; }
                  
        [Display(Name = "Item")]
        [Required]
        public long ItemId { get; set; }

        [Display(Name = "Description")]
        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Description { get; set; }

        [Display(Name = "UOM")]
        [Required]
        public long UomId { get; set; }

        [Display(Name = "UOM")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String UomDescription { get; set; }

        public Item Item { get; set; }

        public UOMViewModel Uom { get; set; }

        public List<ItemUomLookUpViewModel> ItemUoms { get; set; }

        [Display(Name = "Quantity")]
        public Decimal Quantity { get; set; }

        [Range(0.01, Double.MaxValue, ErrorMessage = "Please enter a price above zero.")]
        [Display(Name = "Unit Price")]
        public Decimal UnitPrice { get; set; }

        [Display(Name = "Amount")]
        public Decimal Amount { get; set; }

        [Display(Name = "VatIdentifier")]
        public long? VatIdentifierId { get; set; }

        [Display(Name = "Vat %")]
        public byte VatPercentage { get; set; }

        [Display(Name = "Vat Amount")]
        public Decimal VatAmount { get; set; }

        [Display(Name = "Discount %")]
        public byte LineDiscountPercentage { get; set; }

        [Display(Name = "Discount Amount")]
        public Decimal LineDiscountAmount { get; set; }

        [Display(Name = "Invoice Discount Amount")]
        public Decimal InvoiceDiscountAmount { get; set; }

        [Display(Name = "Unit Price LCY")]
        public Decimal UnitPriceLCY { get; set; }

        [Display(Name = "Amount LCY")]
        public Decimal AmountLCY { get; set; }

        [Display(Name = "Vat Amount LCY")]
        public Decimal VatAmountLCY { get; set; }
 
        [Display(Name = "Discount Amount LCY")]
        public Decimal LineDiscountAmountLCY { get; set; }

        [Display(Name = "Invoice Discount Amount LCY")]
        public Decimal InvoiceDiscountAmountLCY { get; set; }

        [Display(Name = "Qty Per Uom")]
        public Decimal QtyPerUom { get; set; }

        [Display(Name = "Quantity Base")]
        public Decimal QuantityBase { get; set; }
    }
}