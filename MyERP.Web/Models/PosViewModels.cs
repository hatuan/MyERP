using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MyERP.DataAccess;
using MyERP.DataAccess.Enum;

namespace MyERP.Web.Models
{
    public class PosHeaderEditViewModel
    {
        public long? Id { get; set; }

        [Display(Name = "Document No")]
        public string DocumentNo { get; set; }

        [Display(Name = "Sequence No")]
        public long DocSequenceId { get; set; }

        [Display(Name = "Document Date")]
        public DateTime DocumentDate { get; set; }

        [Display(Name = "Customer")]
        public long? SellToCustomerId { get; set; }

        [Display(Name = "Customer Name")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String SellToCustomerName { get; set; }

        [Display(Name = "Address")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String SellToAddress { get; set; }

        [Display(Name = "Description")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Description { get; set; }

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
        public long? LocationId { get; set; }

        [Display(Name = "Sales Person")]
        public long? SalesPersonId { get; set; }

        public List<PosLineEditViewModel> PosLineEditViewModels { get; set; }
    }

    public class PosLineEditViewModel
    {
        public long? Id { get; set; }

        public long LineNo { get; set; }
                                                 
        [Display(Name = "Item")]
        public long? ItemId { get; set; }

        [Display(Name = "Description")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Description { get; set; }

        [Display(Name = "UOM")]
        public long? UomId { get; set; }

        [Display(Name = "UOM")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String UomDescription { get; set; }

        public Item Item { get; set; }

        public UOMViewModel Uom { get; set; }

        public List<ItemUomLookUpViewModel> ItemUoms { get; set; }

        [Display(Name = "Quantity")]
        public Decimal Quantity { get; set; }

        [Display(Name = "Unit Price")]
        public Decimal UnitPrice { get; set; }

        [Display(Name = "Amount")]
        public Decimal Amount { get; set; }

        [Display(Name = "Unit Price LCY")]
        public Decimal UnitPriceLCY { get; set; }

        [Display(Name = "Amount LCY")]
        public Decimal AmountLCY { get; set; }

        [Display(Name = "Qty Per Uom")]
        public Decimal QtyPerUom { get; set; }

        [Display(Name = "Quantity Base")]
        public Decimal QuantityBase { get; set; }
    }
}